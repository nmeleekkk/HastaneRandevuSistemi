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
    public partial class DoktorBilgiDuzenle : Form
    {
        public DoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        public string TCNO;

        private void DoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCNO;
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM Tbl_Doktorlar WHERE DoktorTC=@doktorTC", baglanti);
            komut.Parameters.AddWithValue("@doktorTC", mskTC.Text);
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            dr.Close();
            baglanti.Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("UPDATE Tbl_Doktorlar SET DoktorAd=@doktorAd, DoktorSoyad=@doktorSoyad, DoktorBrans=@doktorBrans, DoktorSifre=@doktorSifre WHERE DoktorTC=@doktorTC", baglanti);
            komut.Parameters.AddWithValue("@doktorAd", txtAd.Text);
            komut.Parameters.AddWithValue("@doktorSoyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@doktorBrans", cmbBrans.Text);
            komut.Parameters.AddWithValue("@doktorSifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@doktorTC", mskTC.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Bilgiler Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            DoktorGiris doktorGiris = new DoktorGiris();
            doktorGiris.Show();
            this.Hide();
        }
    }
}
