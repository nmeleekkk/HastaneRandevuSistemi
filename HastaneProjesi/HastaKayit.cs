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
    public partial class HastaKayit : Form
    {
        public HastaKayit()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl =new sqlbaglantisi();

        private void btnKayıt_Click(object sender, EventArgs e)
        {

            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("INSERT INTO Tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) VALUES (@hastaAd, @hastaSoyad, @hastaTC, @hastaTelefon, @hastaSifre, @hastaCinsiyet)", baglanti);

            komut.Parameters.AddWithValue("@hastaSoyad", txtSoyad.Text);
            komut.Parameters.AddWithValue("@hastaTC", mskTC.Text);
            komut.Parameters.AddWithValue("@hastaTelefon", mskTelefon.Text);
            komut.Parameters.AddWithValue("@hastaSifre", txtSifre.Text);
            komut.Parameters.AddWithValue("@hastaCinsiyet", cmbCinsiyet.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Kaydınız Gerçekleşti. Şifreniz: " + txtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            HastaGiris hastaGiris = new HastaGiris();
            hastaGiris.Show();
            this.Hide();
        }
    }
}
