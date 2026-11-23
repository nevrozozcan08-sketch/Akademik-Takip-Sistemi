namespace AkademikTakipSistemi
{
    partial class FrmAnaMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnOgrenci = new System.Windows.Forms.Button();
            this.btnRaporlar = new System.Windows.Forms.Button();
            this.btnNotlar = new System.Windows.Forms.Button();
            this.btnDersler = new System.Windows.Forms.Button();
            this.lblsaat = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnDanışmanİşlemleri = new System.Windows.Forms.Button();
            this.btnBolumler = new System.Windows.Forms.Button();
            this.btnDersProgrami = new System.Windows.Forms.Button();
            this.btnDanismanGorusu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnOgrenci
            // 
            this.btnOgrenci.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnOgrenci.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOgrenci.Location = new System.Drawing.Point(73, 31);
            this.btnOgrenci.Name = "btnOgrenci";
            this.btnOgrenci.Size = new System.Drawing.Size(249, 188);
            this.btnOgrenci.TabIndex = 0;
            this.btnOgrenci.Text = "🎓 ÖĞRENCİ İŞLEMLERİ";
            this.toolTip1.SetToolTip(this.btnOgrenci, "Öğrenci ekleme,silme ve güncelleme işlemleri");
            this.btnOgrenci.UseVisualStyleBackColor = false;
            this.btnOgrenci.Click += new System.EventHandler(this.btnOgrenci_Click);
            // 
            // btnRaporlar
            // 
            this.btnRaporlar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRaporlar.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRaporlar.Location = new System.Drawing.Point(715, 256);
            this.btnRaporlar.Name = "btnRaporlar";
            this.btnRaporlar.Size = new System.Drawing.Size(232, 188);
            this.btnRaporlar.TabIndex = 1;
            this.btnRaporlar.Text = "📊 RAPORLAR";
            this.toolTip1.SetToolTip(this.btnRaporlar, "Rapor görüntüleme işlemleri");
            this.btnRaporlar.UseVisualStyleBackColor = false;
            this.btnRaporlar.Click += new System.EventHandler(this.btnRaporlar_Click);
            // 
            // btnNotlar
            // 
            this.btnNotlar.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnNotlar.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnNotlar.Location = new System.Drawing.Point(388, 256);
            this.btnNotlar.Name = "btnNotlar";
            this.btnNotlar.Size = new System.Drawing.Size(247, 188);
            this.btnNotlar.TabIndex = 2;
            this.btnNotlar.Text = "NOT İŞLEMLERİ";
            this.toolTip1.SetToolTip(this.btnNotlar, "Not girişi ve hesaplama işlemleri");
            this.btnNotlar.UseVisualStyleBackColor = false;
            this.btnNotlar.Click += new System.EventHandler(this.btnNotlar_Click);
            // 
            // btnDersler
            // 
            this.btnDersler.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDersler.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDersler.Location = new System.Drawing.Point(90, 256);
            this.btnDersler.Name = "btnDersler";
            this.btnDersler.Size = new System.Drawing.Size(232, 188);
            this.btnDersler.TabIndex = 3;
            this.btnDersler.Text = "📚 DERS İŞLEMLERİ";
            this.toolTip1.SetToolTip(this.btnDersler, "Ders ekleme ve düzenleme işlemleri");
            this.btnDersler.UseVisualStyleBackColor = false;
            this.btnDersler.Click += new System.EventHandler(this.btnDersler_Click);
            // 
            // lblsaat
            // 
            this.lblsaat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblsaat.Location = new System.Drawing.Point(656, 442);
            this.lblsaat.Name = "lblsaat";
            this.lblsaat.Size = new System.Drawing.Size(100, 24);
            this.lblsaat.TabIndex = 4;
            this.lblsaat.Text = "20 : 45";
            this.lblsaat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblsaat.Click += new System.EventHandler(this.label1_Click_2);
            // 
            // btnDanışmanİşlemleri
            // 
            this.btnDanışmanİşlemleri.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDanışmanİşlemleri.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDanışmanİşlemleri.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDanışmanİşlemleri.Location = new System.Drawing.Point(388, 31);
            this.btnDanışmanİşlemleri.Name = "btnDanışmanİşlemleri";
            this.btnDanışmanİşlemleri.Size = new System.Drawing.Size(262, 188);
            this.btnDanışmanİşlemleri.TabIndex = 5;
            this.btnDanışmanİşlemleri.Text = "DANIŞMAN İŞLEMLERİ";
            this.btnDanışmanİşlemleri.UseVisualStyleBackColor = false;
            this.btnDanışmanİşlemleri.Click += new System.EventHandler(this.btnDanışmanİşlemleri_Click);
            // 
            // btnBolumler
            // 
            this.btnBolumler.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBolumler.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBolumler.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnBolumler.Location = new System.Drawing.Point(697, 33);
            this.btnBolumler.Name = "btnBolumler";
            this.btnBolumler.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnBolumler.Size = new System.Drawing.Size(262, 188);
            this.btnBolumler.TabIndex = 6;
            this.btnBolumler.Text = "BÖLÜMLER";
            this.btnBolumler.UseVisualStyleBackColor = false;
            this.btnBolumler.Click += new System.EventHandler(this.btnBolumler_Click);
            // 
            // btnDersProgrami
            // 
            this.btnDersProgrami.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDersProgrami.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDersProgrami.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDersProgrami.Location = new System.Drawing.Point(985, 33);
            this.btnDersProgrami.Name = "btnDersProgrami";
            this.btnDersProgrami.Size = new System.Drawing.Size(262, 180);
            this.btnDersProgrami.TabIndex = 7;
            this.btnDersProgrami.Text = "DERS PROGRAMI";
            this.btnDersProgrami.UseVisualStyleBackColor = false;
            this.btnDersProgrami.Click += new System.EventHandler(this.btnDersProgrami_Click);
            // 
            // btnDanismanGorusu
            // 
            this.btnDanismanGorusu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDanismanGorusu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDanismanGorusu.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDanismanGorusu.Location = new System.Drawing.Point(985, 256);
            this.btnDanismanGorusu.Name = "btnDanismanGorusu";
            this.btnDanismanGorusu.Size = new System.Drawing.Size(262, 180);
            this.btnDanismanGorusu.TabIndex = 8;
            this.btnDanismanGorusu.Text = "DANIŞMAN GÖRÜŞÜ";
            this.btnDanismanGorusu.UseVisualStyleBackColor = false;
            this.btnDanismanGorusu.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmAnaMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InfoText;
            this.ClientSize = new System.Drawing.Size(1278, 503);
            this.Controls.Add(this.btnDanismanGorusu);
            this.Controls.Add(this.btnDersProgrami);
            this.Controls.Add(this.btnBolumler);
            this.Controls.Add(this.btnDanışmanİşlemleri);
            this.Controls.Add(this.lblsaat);
            this.Controls.Add(this.btnDersler);
            this.Controls.Add(this.btnNotlar);
            this.Controls.Add(this.btnRaporlar);
            this.Controls.Add(this.btnOgrenci);
            this.Font = new System.Drawing.Font("Symbol", 8.25F);
            this.Name = "FrmAnaMenu";
            this.Text = "Akademik Takip Sistemi";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOgrenci;
        private System.Windows.Forms.Button btnRaporlar;
        private System.Windows.Forms.Button btnNotlar;
        private System.Windows.Forms.Button btnDersler;
        private System.Windows.Forms.Label lblsaat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnDanışmanİşlemleri;
        private System.Windows.Forms.Button btnBolumler;
        private System.Windows.Forms.Button btnDersProgrami;
        private System.Windows.Forms.Button btnDanismanGorusu;
    }
}