namespace AkademikTakipSistemi
{
    partial class FrmDanismanGorusu
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
            this.lblOgrenci = new System.Windows.Forms.Label();
            this.cmbOgrenci = new System.Windows.Forms.ComboBox();
            this.lblDanısman = new System.Windows.Forms.Label();
            this.txtGorus = new System.Windows.Forms.TextBox();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblOgrenci
            // 
            this.lblOgrenci.AutoSize = true;
            this.lblOgrenci.Location = new System.Drawing.Point(70, 48);
            this.lblOgrenci.Name = "lblOgrenci";
            this.lblOgrenci.Size = new System.Drawing.Size(82, 16);
            this.lblOgrenci.TabIndex = 0;
            this.lblOgrenci.Text = "Öğrenci seç:";
            // 
            // cmbOgrenci
            // 
            this.cmbOgrenci.FormattingEnabled = true;
            this.cmbOgrenci.Location = new System.Drawing.Point(155, 47);
            this.cmbOgrenci.Name = "cmbOgrenci";
            this.cmbOgrenci.Size = new System.Drawing.Size(121, 24);
            this.cmbOgrenci.TabIndex = 1;
            this.cmbOgrenci.SelectedIndexChanged += new System.EventHandler(this.cmbOgrenci_SelectedIndexChanged);
            // 
            // lblDanısman
            // 
            this.lblDanısman.AutoSize = true;
            this.lblDanısman.Location = new System.Drawing.Point(35, 140);
            this.lblDanısman.Name = "lblDanısman";
            this.lblDanısman.Size = new System.Drawing.Size(117, 16);
            this.lblDanısman.TabIndex = 2;
            this.lblDanısman.Text = "Danışman Görüşü:";
            // 
            // txtGorus
            // 
            this.txtGorus.Location = new System.Drawing.Point(158, 140);
            this.txtGorus.Multiline = true;
            this.txtGorus.Name = "txtGorus";
            this.txtGorus.Size = new System.Drawing.Size(550, 250);
            this.txtGorus.TabIndex = 3;
            this.txtGorus.TextChanged += new System.EventHandler(this.txtGorus_TextChanged);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Location = new System.Drawing.Point(590, 48);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(95, 43);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = true;
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // FrmDanismanGorusu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnKaydet);
            this.Controls.Add(this.txtGorus);
            this.Controls.Add(this.lblDanısman);
            this.Controls.Add(this.cmbOgrenci);
            this.Controls.Add(this.lblOgrenci);
            this.Name = "FrmDanismanGorusu";
            this.Text = "FrmDanismanGorusu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOgrenci;
        private System.Windows.Forms.ComboBox cmbOgrenci;
        private System.Windows.Forms.Label lblDanısman;
        private System.Windows.Forms.TextBox txtGorus;
        private System.Windows.Forms.Button btnKaydet;
    }
}