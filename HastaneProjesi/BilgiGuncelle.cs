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
    public partial class BilgiGuncelle : Form
    {
        public BilgiGuncelle()
        {
            InitializeComponent();
        }

        public string TCno;

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BilgiGuncelle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;

            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM Tbl_Hastalar WHERE HastaTC = @hastaTC", baglanti);
            komut.Parameters.AddWithValue("@hastaTC", mskTC.Text);
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTelefon.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
                cmbCinsiyet.Text = dr[6].ToString();
            }
            dr.Close();
            baglanti.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            using (var baglanti = bgl.baglanti())
            {
                SQLiteCommand komut2 = new SQLiteCommand("UPDATE Tbl_Hastalar SET HastaAd=@hastaAd, HastaSoyad=@hastaSoyad, HastaTelefon=@hastaTelefon, HastaSifre=@hastaSifre, HastaCinsiyet=@hastaCinsiyet WHERE HastaTC=@hastaTC", baglanti);
                komut2.Parameters.AddWithValue("@hastaAd", txtAd.Text);
                komut2.Parameters.AddWithValue("@hastaSoyad", txtSoyad.Text);
                komut2.Parameters.AddWithValue("@hastaTelefon", mskTelefon.Text);
                komut2.Parameters.AddWithValue("@hastaSifre", txtSifre.Text);
                komut2.Parameters.AddWithValue("@hastaCinsiyet", cmbCinsiyet.Text);
                komut2.Parameters.AddWithValue("@hastaTC", mskTC.Text);

                komut2.ExecuteNonQuery();
                baglanti.Close();
            }
            MessageBox.Show("Bilgileriniz Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
