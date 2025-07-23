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
    public partial class RandevuListesi : Form
    {
        public RandevuListesi()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void RandevuListesi_Load(object sender, EventArgs e)
        {
            var baglanti = bgl.baglanti();

            DataTable dt = new DataTable();
            SQLiteDataAdapter da = new SQLiteDataAdapter("SELECT * FROM Tbl_Randevular", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            SekreterDetay sekreterDetay = new SekreterDetay();
            sekreterDetay.Show();
            this.Hide();
        }
    }
}
