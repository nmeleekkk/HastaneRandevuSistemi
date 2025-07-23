namespace HastaneProjesi
{
    partial class Login
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pctrHastaGirisi = new System.Windows.Forms.PictureBox();
            this.pctrDoktorGirisi = new System.Windows.Forms.PictureBox();
            this.pctrSekreterGirisi = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrHastaGirisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDoktorGirisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrSekreterGirisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, -4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(196, 197);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(632, 31);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(130, 130);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(232, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "T.C. SAĞLIK BAKANLIĞI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(192, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(429, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "SERİNKÖY DEVLET HASTANESİ";
            // 
            // pctrHastaGirisi
            // 
            this.pctrHastaGirisi.Image = ((System.Drawing.Image)(resources.GetObject("pctrHastaGirisi.Image")));
            this.pctrHastaGirisi.Location = new System.Drawing.Point(116, 262);
            this.pctrHastaGirisi.Name = "pctrHastaGirisi";
            this.pctrHastaGirisi.Size = new System.Drawing.Size(174, 171);
            this.pctrHastaGirisi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrHastaGirisi.TabIndex = 4;
            this.pctrHastaGirisi.TabStop = false;
            this.pctrHastaGirisi.Click += new System.EventHandler(this.pctrHastaGirisi_Click);
            // 
            // pctrDoktorGirisi
            // 
            this.pctrDoktorGirisi.Image = ((System.Drawing.Image)(resources.GetObject("pctrDoktorGirisi.Image")));
            this.pctrDoktorGirisi.Location = new System.Drawing.Point(320, 262);
            this.pctrDoktorGirisi.Name = "pctrDoktorGirisi";
            this.pctrDoktorGirisi.Size = new System.Drawing.Size(174, 171);
            this.pctrDoktorGirisi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrDoktorGirisi.TabIndex = 5;
            this.pctrDoktorGirisi.TabStop = false;
            this.pctrDoktorGirisi.Click += new System.EventHandler(this.pctrDoktorGirisi_Click);
            // 
            // pctrSekreterGirisi
            // 
            this.pctrSekreterGirisi.Image = ((System.Drawing.Image)(resources.GetObject("pctrSekreterGirisi.Image")));
            this.pctrSekreterGirisi.Location = new System.Drawing.Point(527, 262);
            this.pctrSekreterGirisi.Name = "pctrSekreterGirisi";
            this.pctrSekreterGirisi.Size = new System.Drawing.Size(174, 171);
            this.pctrSekreterGirisi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctrSekreterGirisi.TabIndex = 6;
            this.pctrSekreterGirisi.TabStop = false;
            this.pctrSekreterGirisi.Click += new System.EventHandler(this.pctrSekreterGirisi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(149, 452);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Hasta Girişi";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(350, 452);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 18);
            this.label4.TabIndex = 8;
            this.label4.Text = "Doktor Girişi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(557, 452);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Sekreter Girişi";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(786, 11);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(25, 25);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 10;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.ClientSize = new System.Drawing.Size(824, 554);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pctrSekreterGirisi);
            this.Controls.Add(this.pctrDoktorGirisi);
            this.Controls.Add(this.pctrHastaGirisi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrHastaGirisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrDoktorGirisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pctrSekreterGirisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pctrHastaGirisi;
        private System.Windows.Forms.PictureBox pctrDoktorGirisi;
        private System.Windows.Forms.PictureBox pctrSekreterGirisi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}

