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
    public partial class DoktorGiris : Form
    {
        public DoktorGiris()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void DoktorGiris_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            SQLiteCommand komut = new SQLiteCommand("SELECT * FROM Tbl_Doktorlar WHERE DoktorTC=@doktorTC AND DoktorSifre=@doktorSifre", baglanti);
            komut.Parameters.AddWithValue("doktorTC", MskTC.Text);
            komut.Parameters.AddWithValue("doktorSifre", txtSifre.Text);
            SQLiteDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                DoktorDetay doktorDetay = new DoktorDetay();
                doktorDetay.TC = MskTC.Text;
                doktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Yanlış bilgi girdiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            dr.Close();
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
            lblExit.ForeColor = Color.Maroon; //Eski rengine dön
        }
    }
}
