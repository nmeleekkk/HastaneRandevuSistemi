using System.Windows.Forms;

namespace HastaneProjesi
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pctrHastaGirisi_Click(object sender, System.EventArgs e)
        {
            HastaGiris hastaGiris = new HastaGiris();
            hastaGiris.Show();
            this.Hide();
        }

        private void pctrDoktorGirisi_Click(object sender, System.EventArgs e)
        {
            DoktorGiris doktorGiris = new DoktorGiris();
            doktorGiris.Show();
            this.Hide();
        }

        private void pctrSekreterGirisi_Click(object sender, System.EventArgs e)
        {
            SekreterGiris sekreterGiris = new SekreterGiris();
            sekreterGiris.Show();
            this.Hide();
        }

        private void Login_Load(object sender, System.EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }
    }
}
