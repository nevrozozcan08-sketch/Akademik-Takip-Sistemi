namespace AkademikTakipSistemi
{
    partial class FrmBolumler
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
            this.btnYapayZeka = new System.Windows.Forms.Button();
            this.btnSiber = new System.Windows.Forms.Button();
            this.btnYazılım = new System.Windows.Forms.Button();
            this.btnBilgisayar = new System.Windows.Forms.Button();
            this.dataGridViewOgrenciler = new System.Windows.Forms.DataGridView();
            this.dataGridViewBolumDersleri = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOgrenciler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBolumDersleri)).BeginInit();
            this.SuspendLayout();
            // 
            // btnYapayZeka
            // 
            this.btnYapayZeka.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYapayZeka.Location = new System.Drawing.Point(912, 44);
            this.btnYapayZeka.Name = "btnYapayZeka";
            this.btnYapayZeka.Size = new System.Drawing.Size(180, 50);
            this.btnYapayZeka.TabIndex = 0;
            this.btnYapayZeka.Text = "Yapay Zeka Mühendisliği";
            this.btnYapayZeka.UseVisualStyleBackColor = true;
            // 
            // btnSiber
            // 
            this.btnSiber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnSiber.Location = new System.Drawing.Point(652, 44);
            this.btnSiber.Name = "btnSiber";
            this.btnSiber.Size = new System.Drawing.Size(180, 50);
            this.btnSiber.TabIndex = 1;
            this.btnSiber.Text = "Siber Güvenlik Mühendisliği";
            this.btnSiber.UseVisualStyleBackColor = true;
            // 
            // btnYazılım
            // 
            this.btnYazılım.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnYazılım.Location = new System.Drawing.Point(373, 44);
            this.btnYazılım.Name = "btnYazılım";
            this.btnYazılım.Size = new System.Drawing.Size(180, 50);
            this.btnYazılım.TabIndex = 2;
            this.btnYazılım.Text = "Yazılım Mühendisliği";
            this.btnYazılım.UseVisualStyleBackColor = true;
            // 
            // btnBilgisayar
            // 
            this.btnBilgisayar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnBilgisayar.Location = new System.Drawing.Point(103, 44);
            this.btnBilgisayar.Name = "btnBilgisayar";
            this.btnBilgisayar.Size = new System.Drawing.Size(180, 50);
            this.btnBilgisayar.TabIndex = 3;
            this.btnBilgisayar.Text = "Bilgisayar Mühendisliği";
            this.btnBilgisayar.UseVisualStyleBackColor = true;
            this.btnBilgisayar.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridViewOgrenciler
            // 
            this.dataGridViewOgrenciler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOgrenciler.Location = new System.Drawing.Point(15, 118);
            this.dataGridViewOgrenciler.Name = "dataGridViewOgrenciler";
            this.dataGridViewOgrenciler.RowHeadersWidth = 51;
            this.dataGridViewOgrenciler.RowTemplate.Height = 24;
            this.dataGridViewOgrenciler.Size = new System.Drawing.Size(850, 500);
            this.dataGridViewOgrenciler.TabIndex = 4;
            // 
            // dataGridViewBolumDersleri
            // 
            this.dataGridViewBolumDersleri.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBolumDersleri.Location = new System.Drawing.Point(903, 118);
            this.dataGridViewBolumDersleri.Name = "dataGridViewBolumDersleri";
            this.dataGridViewBolumDersleri.RowHeadersWidth = 51;
            this.dataGridViewBolumDersleri.RowTemplate.Height = 24;
            this.dataGridViewBolumDersleri.Size = new System.Drawing.Size(850, 500);
            this.dataGridViewBolumDersleri.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(1228, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 18);
            this.label1.TabIndex = 6;
            this.label1.Text = "Bölüm Ders Planı";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "Bölümdeki Öğrenciler";
            // 
            // FrmBolumler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 753);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewBolumDersleri);
            this.Controls.Add(this.dataGridViewOgrenciler);
            this.Controls.Add(this.btnBilgisayar);
            this.Controls.Add(this.btnYazılım);
            this.Controls.Add(this.btnSiber);
            this.Controls.Add(this.btnYapayZeka);
            this.Name = "FrmBolumler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmBolumler";
            this.Load += new System.EventHandler(this.FrmBolumler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOgrenciler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBolumDersleri)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnYapayZeka;
        private System.Windows.Forms.Button btnSiber;
        private System.Windows.Forms.Button btnYazılım;
        private System.Windows.Forms.Button btnBilgisayar;
        private System.Windows.Forms.DataGridView dataGridViewOgrenciler;
        private System.Windows.Forms.DataGridView dataGridViewBolumDersleri;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}