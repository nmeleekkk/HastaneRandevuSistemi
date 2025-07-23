using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Forms;

namespace HastaneProjesi
{
    public partial class HastaDetay : Form
    {
        public HastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void HastaDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = tc;

            var baglanti = bgl.baglanti();

            //Ad Soyad Çekme
            SQLiteCommand komut = new SQLiteCommand("SELECT HastaAd, HastaSoyad FROM Tbl_Hastalar WHERE HastaTC=@hastaTC", baglanti);
            komut.Parameters.AddWithValue("@hastaTC", lblTC.Text);

            SQLiteDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            dr.Close();

            baglanti.Close();

            //Randevu Geçmişi
            baglanti.Open();
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Tbl_Randevular WHERE HastaTC=@tc", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@tc", tc);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            //Branşları Çekme
            baglanti.Open();
            SQLiteCommand komut2 = new SQLiteCommand("SELECT BransAd FROM Tbl_Branslar",baglanti);
            SQLiteDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            dr2.Close();
            baglanti.Close();

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            cmbDoktor.Items.Clear();
            SQLiteCommand komut3 = new SQLiteCommand("SELECT DoktorAd, DoktorSoyad FROM Tbl_Doktorlar WHERE DoktorBrans=@doktorBrans COLLATE NOCASE", baglanti);
            komut3.Parameters.AddWithValue("@doktorBrans", cmbBrans.Text.Trim());
            SQLiteDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }
            dr3.Close();
            baglanti.Close();
        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();
            DataTable dt = new DataTable();

            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Tbl_Randevular WHERE RandevuBrans=@brans AND RandevuDoktor=@doktor", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@brans", cmbBrans.Text.Trim());
            da.SelectCommand.Parameters.AddWithValue("@doktor", cmbDoktor.Text.Trim());

            da.Fill(dt);
            dataGridView2.DataSource = dt;

            baglanti.Close();

        }

        private void lnkBilgiGuncelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            BilgiGuncelle bilgiGuncelle = new BilgiGuncelle();
            bilgiGuncelle.TCno = lblTC.Text;
            bilgiGuncelle.Show();
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("UPDATE Tbl_Randevular SET RandevuDurum=1, HastaTC=@hastaTC, HastaSikayet=@hastaSikayet WHERE RandevuId=@id", baglanti);
            komut.Parameters.AddWithValue("@hastaTC", lblTC.Text);
            komut.Parameters.AddWithValue("hastaSikayet", rchSikayet.Text);
            komut.Parameters.AddWithValue("@id", txtId.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu başarıyla alındı.","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HastaGiris hastaGiris = new HastaGiris();
            hastaGiris.Show();
            this.Hide();
        }
    }
}
