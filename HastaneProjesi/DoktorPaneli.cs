using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneProjesi
{
    public partial class DoktorPaneli : Form
    {
        public DoktorPaneli()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void DoktorPaneli_Load(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Tbl_Doktorlar", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            //Branşı cmbboxa aktarma
            baglanti.Open();
            SQLiteCommand komut2 = new SQLiteCommand("SELECT BransAd FROM Tbl_Branslar", baglanti);
            SQLiteDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }
            dr2.Close();
            baglanti.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("INSERT INTO Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorBrans, DoktorTC, DoktorSifre) VALUES (@doktorAd, @doktorSoyad, @doktorBrans, @doktorTC, @doktorSifre)", baglanti);
            komut.Parameters.AddWithValue("@doktorAd", txtAd.Text);
            komut.Parameters.AddWithValue("@doktorSoyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@doktorBrans", cmbBrans.Text);
            komut.Parameters.AddWithValue("@doktorTC", mskTC.Text);
            komut.Parameters.AddWithValue("@doktorSifre", txtSifre.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Doktor Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("DELETE FROM Tbl_Doktorlar WHERE DoktorTC=@doktorTC", baglanti);
            komut.Parameters.AddWithValue("@doktorTC", mskTC.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt silindi!","Uyarı",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();
            SQLiteCommand komut = new SQLiteCommand("UPDATE Tbl_Doktorlar SET DoktorAd=@doktorAd, DoktorSoyad=@doktorSoyad, DoktorBrans=@doktorBrans, DoktorSifre=@doktorSifre WHERE DoktorTC=@doktorTC", baglanti);
            komut.Parameters.AddWithValue("@doktorAd", txtAd.Text);
            komut.Parameters.AddWithValue("@doktorSoyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@doktorBrans", cmbBrans.Text);
            komut.Parameters.AddWithValue("@doktorTC", mskTC.Text);
            komut.Parameters.AddWithValue("@doktorSifre", txtSifre.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Doktor Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SekreterDetay sekreterDetay = new SekreterDetay();
            sekreterDetay.Show();
            this.Hide();
        }
    }
}
