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
    public partial class BransPaneli : Form
    {
        public BransPaneli()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void BransPaneli_Load(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Tbl_Branslar", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("INSERT INTO Tbl_Branslar (BransAd) VALUES (@bransAd)", baglanti);
            komut.Parameters.AddWithValue("@bransAd", txtBrans.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Branş Eklendi.","Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var baglanti = bgl.baglanti();

            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtId.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBrans.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("DELETE FROM Tbl_Branslar WHERE BransId=@bransId", baglanti);
            komut.Parameters.AddWithValue("@bransId", txtId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Branş Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("UPDATE Tbl_Branslar SET BransAd=@bransAd WHERE BransId=@bransId", baglanti);
            komut.Parameters.AddWithValue("@bransAd", txtBrans.Text);
            komut.Parameters.AddWithValue("@bransId", txtId.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Branş Bilgisi Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SekreterDetay sekreterDetay = new SekreterDetay();
            sekreterDetay.Show();
            this.Hide();
        }
    }
}
