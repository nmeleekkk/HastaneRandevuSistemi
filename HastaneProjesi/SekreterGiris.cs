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
    public partial class SekreterGiris : Form
    {
        public SekreterGiris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM Tbl_Sekreterler WHERE SekreterTC=@sekreterTC AND SekreterSifre=@sekreterSifre", baglanti);
            komut.Parameters.AddWithValue("@sekreterTC", mskTC.Text);
            komut.Parameters.AddWithValue("@sekreterSifre", txtSifre.Text);

            SQLiteDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                SekreterDetay sekreterDetay = new SekreterDetay();
                sekreterDetay.TCnumara=mskTC.Text;
                sekreterDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı bilgi girdiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            dr.Close();
            baglanti.Close();
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
            lblExit.ForeColor = Color.Maroon; //Eski rengine dön
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
