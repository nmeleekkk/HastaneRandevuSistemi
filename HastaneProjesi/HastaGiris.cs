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
    public partial class HastaGiris : Form
    {
        public HastaGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void LnkUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            HastaKayit hastaKayit = new HastaKayit();
            hastaKayit.Show();
            this.Hide();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM Tbl_Hastalar WHERE HastaTC = @hastaTC AND HastaSifre = @hastaSifre", baglanti);
            komut.Parameters.AddWithValue("@hastaSifre",txtSifre.Text);
            komut.Parameters.AddWithValue("@hastaTC",MskTC.Text);

            SQLiteDataReader komutdr = komut.ExecuteReader();

            if (komutdr.Read())
            {
                HastaDetay hastaDetay = new HastaDetay();
                hastaDetay.tc=MskTC.Text;
                hastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı şifre!!!");
            }
            komutdr.Close();
            baglanti.Close();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void lblExit_MouseEnter(object sender, EventArgs e)
        {
            lblExit.ForeColor = Color.Black;
            lblExit.Font = new Font(lblExit.Font, FontStyle.Bold);
        }

        private void lblExit_MouseLeave(object sender, EventArgs e)
        {
            lblExit.ForeColor=Color.Maroon; //Eski rengine dön
        }
    }
}
