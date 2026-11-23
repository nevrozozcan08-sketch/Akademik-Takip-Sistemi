namespace AkademikTakipSistemi
{
    partial class FrmRaporlar
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea7 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend7 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea8 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend8 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.cmbOgrenci = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewRapor = new System.Windows.Forms.DataGridView();
            this.chartDersBaşarı = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartGenelBasari = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dataGridViewDonemOrt = new System.Windows.Forms.DataGridView();
            this.dataGridViewKalanDersler = new System.Windows.Forms.DataGridView();
            this.dataGridViewAktsOzet = new System.Windows.Forms.DataGridView();
            this.lblAgno = new System.Windows.Forms.Label();
            this.dataGridViewDevamsizlik = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDersBaşarı)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGenelBasari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonemOrt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKalanDersler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAktsOzet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevamsizlik)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1144, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "PDF Olarak İndir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnPdf_Click);
            // 
            // cmbOgrenci
            // 
            this.cmbOgrenci.FormattingEnabled = true;
            this.cmbOgrenci.Location = new System.Drawing.Point(268, 31);
            this.cmbOgrenci.Name = "cmbOgrenci";
            this.cmbOgrenci.Size = new System.Drawing.Size(121, 24);
            this.cmbOgrenci.TabIndex = 3;
            this.cmbOgrenci.Text = "Öğrenci seç";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(153, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 18);
            this.label1.TabIndex = 4;
            this.label1.Text = "Öğrenci seç:";
            // 
            // dataGridViewRapor
            // 
            this.dataGridViewRapor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRapor.Location = new System.Drawing.Point(211, 86);
            this.dataGridViewRapor.Name = "dataGridViewRapor";
            this.dataGridViewRapor.RowHeadersWidth = 51;
            this.dataGridViewRapor.RowTemplate.Height = 24;
            this.dataGridViewRapor.Size = new System.Drawing.Size(1150, 250);
            this.dataGridViewRapor.TabIndex = 5;
            this.dataGridViewRapor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewRapor_CellContentClick);
            // 
            // chartDersBaşarı
            // 
            chartArea7.Name = "ChartArea1";
            this.chartDersBaşarı.ChartAreas.Add(chartArea7);
            legend7.Name = "Legend1";
            this.chartDersBaşarı.Legends.Add(legend7);
            this.chartDersBaşarı.Location = new System.Drawing.Point(12, 600);
            this.chartDersBaşarı.Name = "chartDersBaşarı";
            series7.ChartArea = "ChartArea1";
            series7.Legend = "Legend1";
            series7.Name = "Series1";
            this.chartDersBaşarı.Series.Add(series7);
            this.chartDersBaşarı.Size = new System.Drawing.Size(450, 250);
            this.chartDersBaşarı.TabIndex = 6;
            this.chartDersBaşarı.Text = "chartDersBaşarı";
            // 
            // chartGenelBasari
            // 
            chartArea8.Name = "ChartArea1";
            this.chartGenelBasari.ChartAreas.Add(chartArea8);
            legend8.Name = "Legend1";
            this.chartGenelBasari.Legends.Add(legend8);
            this.chartGenelBasari.Location = new System.Drawing.Point(496, 600);
            this.chartGenelBasari.Name = "chartGenelBasari";
            series8.ChartArea = "ChartArea1";
            series8.Legend = "Legend1";
            series8.Name = "Series1";
            this.chartGenelBasari.Series.Add(series8);
            this.chartGenelBasari.Size = new System.Drawing.Size(450, 250);
            this.chartGenelBasari.TabIndex = 7;
            this.chartGenelBasari.Text = "chartGenelBasari";
            this.chartGenelBasari.Click += new System.EventHandler(this.chartGenelBasari_Click);
            // 
            // dataGridViewDonemOrt
            // 
            this.dataGridViewDonemOrt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDonemOrt.Location = new System.Drawing.Point(-4, 355);
            this.dataGridViewDonemOrt.Name = "dataGridViewDonemOrt";
            this.dataGridViewDonemOrt.RowHeadersWidth = 51;
            this.dataGridViewDonemOrt.RowTemplate.Height = 24;
            this.dataGridViewDonemOrt.Size = new System.Drawing.Size(440, 170);
            this.dataGridViewDonemOrt.TabIndex = 8;
            // 
            // dataGridViewKalanDersler
            // 
            this.dataGridViewKalanDersler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewKalanDersler.Location = new System.Drawing.Point(442, 355);
            this.dataGridViewKalanDersler.Name = "dataGridViewKalanDersler";
            this.dataGridViewKalanDersler.RowHeadersWidth = 51;
            this.dataGridViewKalanDersler.RowTemplate.Height = 24;
            this.dataGridViewKalanDersler.Size = new System.Drawing.Size(735, 170);
            this.dataGridViewKalanDersler.TabIndex = 9;
            // 
            // dataGridViewAktsOzet
            // 
            this.dataGridViewAktsOzet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAktsOzet.Location = new System.Drawing.Point(1183, 355);
            this.dataGridViewAktsOzet.Name = "dataGridViewAktsOzet";
            this.dataGridViewAktsOzet.RowHeadersWidth = 51;
            this.dataGridViewAktsOzet.RowTemplate.Height = 24;
            this.dataGridViewAktsOzet.Size = new System.Drawing.Size(547, 170);
            this.dataGridViewAktsOzet.TabIndex = 10;
            // 
            // lblAgno
            // 
            this.lblAgno.AutoSize = true;
            this.lblAgno.Location = new System.Drawing.Point(35, 546);
            this.lblAgno.Name = "lblAgno";
            this.lblAgno.Size = new System.Drawing.Size(49, 16);
            this.lblAgno.TabIndex = 11;
            this.lblAgno.Text = "AGNO:";
            // 
            // dataGridViewDevamsizlik
            // 
            this.dataGridViewDevamsizlik.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDevamsizlik.Location = new System.Drawing.Point(968, 600);
            this.dataGridViewDevamsizlik.Name = "dataGridViewDevamsizlik";
            this.dataGridViewDevamsizlik.RowHeadersWidth = 51;
            this.dataGridViewDevamsizlik.RowTemplate.Height = 24;
            this.dataGridViewDevamsizlik.Size = new System.Drawing.Size(753, 170);
            this.dataGridViewDevamsizlik.TabIndex = 12;
            // 
            // FrmRaporlar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1733, 853);
            this.Controls.Add(this.dataGridViewDevamsizlik);
            this.Controls.Add(this.lblAgno);
            this.Controls.Add(this.dataGridViewAktsOzet);
            this.Controls.Add(this.dataGridViewKalanDersler);
            this.Controls.Add(this.dataGridViewDonemOrt);
            this.Controls.Add(this.chartGenelBasari);
            this.Controls.Add(this.chartDersBaşarı);
            this.Controls.Add(this.dataGridViewRapor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbOgrenci);
            this.Controls.Add(this.button1);
            this.Name = "FrmRaporlar";
            this.Text = "Raporlar";
            this.Load += new System.EventHandler(this.FrmRaporlar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRapor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDersBaşarı)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGenelBasari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDonemOrt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewKalanDersler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAktsOzet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDevamsizlik)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbOgrenci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewRapor;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDersBaşarı;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGenelBasari;
        private System.Windows.Forms.DataGridView dataGridViewDonemOrt;
        private System.Windows.Forms.DataGridView dataGridViewKalanDersler;
        private System.Windows.Forms.DataGridView dataGridViewAktsOzet;
        private System.Windows.Forms.Label lblAgno;
        private System.Windows.Forms.DataGridView dataGridViewDevamsizlik;
    }
}