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
    public partial class DoktorDetay : Form
    {
        public DoktorDetay()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        public string TC;

        private void DoktorDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TC;
            var baglanti = bgl.baglanti();

            //Doktor Ad Soyad Çekme

            SQLiteCommand komut = new SQLiteCommand("SELECT DoktorAd, DoktorSoyad FROM Tbl_Doktorlar WHERE DoktorTC=@doktorTC",baglanti);
            komut.Parameters.AddWithValue("@doktorTC", TC);
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            dr.Close();
            baglanti.Close();

            //Randevular
            baglanti.Open();

            string doktorAdSoyad = lblAdSoyad.Text.Trim();

            DataTable dt1 = new DataTable();
            SQLiteCommand komut1 = new SQLiteCommand("SELECT * FROM Tbl_Randevular WHERE RandevuDoktor = @randevuDoktor", baglanti);
            komut1.Parameters.AddWithValue("@randevuDoktor", doktorAdSoyad);
            SQLiteDataAdapter da1 = new SQLiteDataAdapter(komut1);
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
            baglanti.Close();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DoktorBilgiDuzenle doktorBilgiDuzenle = new DoktorBilgiDuzenle();
            doktorBilgiDuzenle.TCNO = lblTC.Text;
            doktorBilgiDuzenle.Show();
            this.Hide();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCıkıs_Click(object sender, EventArgs e)
        {
            DoktorGiris doktorGiris = new DoktorGiris();
            doktorGiris.Show();
            this.Hide();
        }
    }
}
