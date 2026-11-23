namespace AkademikTakipSistemi
{
    partial class FrmDersProgrami
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
            this.lblOgrenciSec = new System.Windows.Forms.Label();
            this.cmbOgrenci = new System.Windows.Forms.ComboBox();
            this.dataGridViewDersProgrami = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDersProgrami)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOgrenciSec
            // 
            this.lblOgrenciSec.AutoSize = true;
            this.lblOgrenciSec.Location = new System.Drawing.Point(103, 44);
            this.lblOgrenciSec.Name = "lblOgrenciSec";
            this.lblOgrenciSec.Size = new System.Drawing.Size(82, 16);
            this.lblOgrenciSec.TabIndex = 0;
            this.lblOgrenciSec.Text = "Öğrenci seç:";
            this.lblOgrenciSec.Click += new System.EventHandler(this.label1_Click);
            // 
            // cmbOgrenci
            // 
            this.cmbOgrenci.FormattingEnabled = true;
            this.cmbOgrenci.Location = new System.Drawing.Point(191, 44);
            this.cmbOgrenci.Name = "cmbOgrenci";
            this.cmbOgrenci.Size = new System.Drawing.Size(121, 24);
            this.cmbOgrenci.TabIndex = 1;
            // 
            // dataGridViewDersProgrami
            // 
            this.dataGridViewDersProgrami.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDersProgrami.Location = new System.Drawing.Point(38, 124);
            this.dataGridViewDersProgrami.Name = "dataGridViewDersProgrami";
            this.dataGridViewDersProgrami.RowHeadersWidth = 51;
            this.dataGridViewDersProgrami.RowTemplate.Height = 24;
            this.dataGridViewDersProgrami.Size = new System.Drawing.Size(716, 250);
            this.dataGridViewDersProgrami.TabIndex = 2;
            // 
            // FrmDersProgrami
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dataGridViewDersProgrami);
            this.Controls.Add(this.cmbOgrenci);
            this.Controls.Add(this.lblOgrenciSec);
            this.Name = "FrmDersProgrami";
            this.Text = "FrmDersProgrami";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDersProgrami)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblOgrenciSec;
        private System.Windows.Forms.ComboBox cmbOgrenci;
        private System.Windows.Forms.DataGridView dataGridViewDersProgrami;
    }
}