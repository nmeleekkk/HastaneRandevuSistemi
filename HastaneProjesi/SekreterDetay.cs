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
using System.Data.Entity.Core.Metadata.Edm;

namespace HastaneProjesi
{
    public partial class SekreterDetay : Form
    {
        public SekreterDetay()
        {
            InitializeComponent();
        }

        public string TCnumara;

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void SekreterDetay_Load(object sender, EventArgs e)
        {
            lblTC.Text = TCnumara;
            var baglanti = bgl.baglanti();

            //Ad Soyad Çekme
            SQLiteCommand komut = new SQLiteCommand("SELECT SekreterAdSoyad FROM Tbl_Sekreterler WHERE SekreterTC=@sekreterTC", baglanti);
            komut.Parameters.AddWithValue("@sekreterTC", lblTC.Text);
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0].ToString();
            }
            dr.Close();
            baglanti.Close();

            //Branşları Datagride Aktarma
            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Tbl_Branslar", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();

            //Doktorları Listeye Aktarma
            DataTable dt2 = new DataTable();
            SQLiteDataAdapter da2 = new SQLiteDataAdapter("SELECT (DoktorAd || ' ' || DoktorSoyad) AS 'Doktorlar', DoktorBrans FROM Tbl_Doktorlar", baglanti);
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;
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

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            int durum = chkDurum.Checked ? 1 : 0;

            SQLiteCommand komutkaydet = new SQLiteCommand("INSERT into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor, RandevuDurum) VALUES (@randevuTarih, @randevuSaat, @randevuBrans, @randevuDoktor, @randevuDurum)", baglanti);
            komutkaydet.Parameters.AddWithValue("@randevuTarih", mskTarih.Text);
            komutkaydet.Parameters.AddWithValue("@randevuSaat", mskSaat.Text);
            komutkaydet.Parameters.AddWithValue("@randevuBrans", cmbBrans.Text);
            komutkaydet.Parameters.AddWithValue("@randevuDoktor", cmbDoktor.Text);
            komutkaydet.Parameters.AddWithValue("@randevuDurum", durum);

            komutkaydet.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Randevu oluşturuldu.");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            cmbDoktor.Items.Clear();

            SQLiteCommand komut = new SQLiteCommand("SELECT DoktorAd, DoktorSoyad FROM Tbl_Doktorlar WHERE DoktorBrans=@doktorBrans", baglanti);
            komut.Parameters.AddWithValue("@doktorBrans", cmbBrans.Text.Trim());
            SQLiteDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbDoktor.Items.Add(dr[0] + " " + dr[1]);
            }
            dr.Close();
            baglanti.Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("INSERT INTO Tbl_Duyurular (Duyuru) VALUES (@duyuru)", baglanti);
            komut.Parameters.AddWithValue("@duyuru", rchDuyuru.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            DoktorPaneli doktorPaneli = new DoktorPaneli();
            doktorPaneli.Show();
            this.Hide();
        }

        private void btnBransPanel_Click(object sender, EventArgs e)
        {
            BransPaneli bransPaneli = new BransPaneli();
            bransPaneli.Show();
            this.Hide();
        }

        private void btnListe_Click(object sender, EventArgs e)
        {
            RandevuListesi randevuListesi = new RandevuListesi();
            randevuListesi.Show();
            this.Hide();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            Duyurular duyurular = new Duyurular();
            duyurular.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SekreterGiris sekreterGiris = new SekreterGiris();
            sekreterGiris.Show();
            this.Hide();
        }
    }
}
