using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting; // Grafik işlemleri için kullanılır.
using System.Data.SqlClient;
using System.Drawing.Printing;

namespace AkademikTakipSistemi
{
    public partial class FrmRaporlar : Form

    {   // SQL server veritabanı bağlantısı.
        SqlConnection baglanti = new SqlConnection(@"Data Source=NEVROZ\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");

        // Raporlar formunu başlatır. 
     
            public FrmRaporlar()
            {
            InitializeComponent();

            this.Load += FrmRaporlar_Load;
                cmbOgrenci.SelectedIndexChanged += cmbOgrenci_SelectedIndexChanged;
            }


        Bitmap raporResmi;

        private void btnPdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF Dosyası|*.pdf";
            save.Title = "Raporu PDF Olarak Kaydet";
            save.FileName = "Ogrenci_Raporu.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                raporResmi = new Bitmap(this.Width, this.Height);
                this.DrawToBitmap(raporResmi, new Rectangle(0, 0, this.Width, this.Height));

                PrintDocument pd = new PrintDocument();
                pd.PrinterSettings.PrinterName = "Microsoft Print to PDF";
                pd.PrinterSettings.PrintToFile = true;
                pd.PrinterSettings.PrintFileName = save.FileName;

                pd.PrintPage += Pd_PrintPage;
                pd.Print();

                MessageBox.Show("PDF başarıyla kaydedildi.");
            }
        }

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(raporResmi, 0, 0, e.PageBounds.Width, e.PageBounds.Height);
        }
        private void FrmRaporlar_Load(object sender, EventArgs e)
        {
            OgrencileriGetir();
        }

        private void cmbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedValue == null)
                return;

            int ogrenciID;

            if (int.TryParse(cmbOgrenci.SelectedValue.ToString(), out ogrenciID))
            {
                RaporGetir(ogrenciID);
            }
        }

      
            void RaporGetir(int ogrenciID)
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT bdp.AkademikYil AS [Akademik Yıl], bdp.Donem AS [Dönem], " +
                    "bdp.DersAdi AS [Ders], bdp.Kredi, bdp.AKTS, n.Ortalama, " +
                    "CASE WHEN n.Ortalama >= 90 THEN 'AA' " +
                    "WHEN n.Ortalama >= 80 THEN 'BA' " +
                    "WHEN n.Ortalama >= 70 THEN 'BB' " +
                    "WHEN n.Ortalama >= 60 THEN 'CB' " +
                    "WHEN n.Ortalama >= 50 THEN 'CC' ELSE 'FF' END AS [Harf Notu], " +
                    "CASE WHEN dv.DevamsizlikDurumu IS NOT NULL THEN dv.DevamsizlikDurumu " +
"WHEN n.Ortalama >= 50 THEN 'Geçti' ELSE 'Kaldı' END AS Durum, " +
"ISNULL(dv.DevamsizlikSayisi, 0) AS [Devamsızlık] " +
                    "FROM Tbl_Ogrenciler o " +
                   
                    "INNER JOIN Tbl_BolumDersPlani bdp ON o.BolumID = bdp.BolumID " +
                    "LEFT JOIN Tbl_Dersler d ON d.DersAd = bdp.DersAdi " +
                    "LEFT JOIN Tbl_Notlar n ON n.OgrenciID = o.id AND n.DersID = d.DersID " +
                    "LEFT JOIN Tbl_Devamsizlik dv ON dv.OgrenciID = o.id AND dv.DersID = d.DersID " +
                    "WHERE o.id = @p1 " +
                    "AND (TRY_CONVERT(INT, LEFT(bdp.AkademikYil,4)) - 2023 + 1) <= TRY_CONVERT(INT, LEFT(o.Sinif,1)) " +
                    "ORDER BY bdp.AkademikYil, CASE WHEN bdp.Donem = N'Güz' THEN 1 ELSE 2 END, bdp.DersAdi",
                    baglanti);

                da.SelectCommand.Parameters.AddWithValue("@p1", ogrenciID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridViewRapor.DataSource = dt;
            SqlDataAdapter daDevamsizlik = new SqlDataAdapter(
    "SELECT dv.AkademikYil AS [Akademik Yıl], " +
    "dv.Donem AS [Dönem], " +
    "ISNULL(d.DersAd, 'Ders Bulunamadı') AS [Ders], " +
    "dv.DevamsizlikSayisi AS [Devamsızlık], " +
    "dv.DevamsizlikDurumu AS [Durum] " +
    "FROM Tbl_Devamsizlik dv " +
    "LEFT JOIN Tbl_Dersler d ON dv.DersID = d.DersID " +
    "WHERE dv.OgrenciID = @p1",
    baglanti);

            daDevamsizlik.SelectCommand.Parameters.AddWithValue("@p1", ogrenciID);

            DataTable dtDevamsizlik = new DataTable();
            daDevamsizlik.Fill(dtDevamsizlik);

            dataGridViewDevamsizlik.DataSource = dtDevamsizlik;


            // 1) DÖNEM ORTALAMALARI
            DataTable dtDonem = new DataTable();
            dtDonem.Columns.Add("Akademik Yıl");
            dtDonem.Columns.Add("Dönem");
            dtDonem.Columns.Add("Dönem Ortalaması");

            var donemGruplari = dt.AsEnumerable()
                .Where(r => r["Ortalama"] != DBNull.Value)
                .GroupBy(r => new
                {
                    Yil = r["Akademik Yıl"].ToString(),
                    Donem = r["Dönem"].ToString()
                });

            foreach (var grup in donemGruplari)
            {
                double ort = grup.Average(r => Convert.ToDouble(r["Ortalama"]));
                dtDonem.Rows.Add(grup.Key.Yil, grup.Key.Donem, ort.ToString("0.00"));
            }

            dataGridViewDonemOrt.DataSource = dtDonem;


            // 2) KALDIĞI DERSLER
            DataTable dtKalan = new DataTable();
            dtKalan.Columns.Add("Akademik Yıl");
            dtKalan.Columns.Add("Dönem");
            dtKalan.Columns.Add("Ders");
            dtKalan.Columns.Add("Ortalama");
            dtKalan.Columns.Add("Harf Notu");

            foreach (DataRow row in dt.Rows)
            {
                if (row["Ortalama"] != DBNull.Value)
                {
                    double ort = Convert.ToDouble(row["Ortalama"]);

                    if (ort < 50)
                    {
                        dtKalan.Rows.Add(
                            row["Akademik Yıl"],
                            row["Dönem"],
                            row["Ders"],
                            ort.ToString("0.00"),
                            row["Harf Notu"]
                        );
                    }
                }
            }

            dataGridViewKalanDersler.DataSource = dtKalan;


            // 3) AKTS ÖZETİ
            DataTable dtAkts = new DataTable();
            dtAkts.Columns.Add("Akademik Yıl");
            dtAkts.Columns.Add("Toplam AKTS");
            dtAkts.Columns.Add("Tamamlanan AKTS");
            dtAkts.Columns.Add("Kalan AKTS");

            var yilGruplari = dt.AsEnumerable()
                .GroupBy(r => r["Akademik Yıl"].ToString());

            foreach (var grup in yilGruplari)
            {
                int ToplamAkts = grup.Sum(r => Convert.ToInt32(r["AKTS"]));

                int TamamlananAkts = grup
                    .Where(r => r["Ortalama"] != DBNull.Value && Convert.ToDouble(r["Ortalama"]) >= 50)
                    .Sum(r => Convert.ToInt32(r["AKTS"]));

                int KalanAkts = ToplamAkts - TamamlananAkts;

                dtAkts.Rows.Add(grup.Key, ToplamAkts, TamamlananAkts, KalanAkts);
            }

            dataGridViewAktsOzet.DataSource = dtAkts;


            // 4) AGN0

            double toplamKatsayiAkts = 0;
            int toplamAkts4luk = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Harf Notu"] != DBNull.Value)
                {
                    string harf = row["Harf Notu"].ToString();
                    int akts = Convert.ToInt32(row["AKTS"]);

                    double katsayi = 0;

                    if (harf == "AA") katsayi = 4.00;
                    else if (harf == "BA") katsayi = 3.50;
                    else if (harf == "BB") katsayi = 3.00;
                    else if (harf == "CB") katsayi = 2.50;
                    else if (harf == "CC") katsayi = 2.00;
                    else if (harf == "DC") katsayi = 1.50;
                    else if (harf == "DD") katsayi = 1.00;
                    else if (harf == "FD") katsayi = 0.50;
                    else if (harf == "FF") katsayi = 0.00;

                    toplamKatsayiAkts += katsayi * akts;
                    toplamAkts4luk += akts;
                }
            }
            double agno = toplamAkts4luk > 0
    ? toplamKatsayiAkts / toplamAkts4luk
    : 0;
            lblAgno.Text = " AGNO:" + agno.ToString("0.00") + " / 4.00";
          

            chartDersBaşarı.Series.Clear();
                chartDersBaşarı.Series.Add("Ders Ortalamaları");
                chartDersBaşarı.Series["Ders Ortalamaları"].ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chartDersBaşarı.ChartAreas[0].AxisX.Interval = 1;
            chartDersBaşarı.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartDersBaşarı.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Arial", 8);

            chartDersBaşarı.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            chartDersBaşarı.ChartAreas[0].AxisX.ScaleView.Size = 8;

            chartDersBaşarı.ChartAreas[0].AxisY.Minimum = 0;
            chartDersBaşarı.ChartAreas[0].AxisY.Maximum = 100;

            double toplam = 0;
                int sayac = 0;
            double toplamAkts = 0;
            double tamamlananAkts = 0;
            int basariliDers = 0;
            int kalanDers = 0;

            double guzToplam = 0;
            int guzSayac = 0;

            double baharToplam = 0;
            int baharSayac = 0;


            foreach (DataRow row in dt.Rows)
                {
                    if (row["Ortalama"] != DBNull.Value)
                    {
                        string ders = row["Ders"].ToString();
                        double ort = Convert.ToDouble(row["Ortalama"]);

                        chartDersBaşarı.Series["Ders Ortalamaları"].Points.AddXY(ders, ort);

                        toplam += ort;
                        sayac++;
                    int akts = Convert.ToInt32(row["AKTS"]);
                    toplamAkts += akts;

                    if (ort >= 50)
                    {
                        tamamlananAkts += akts;
                        basariliDers++;
                    }
                    else
                    {
                        kalanDers++;
                    }

                    string donem = row["Dönem"].ToString();

                    if (donem == "Güz")
                    {
                        guzToplam += ort;
                        guzSayac++;
                    }
                    else if (donem == "Bahar")
                    {
                        baharToplam += ort;
                        baharSayac++;
                    }


                }
                }

                double genelOrtalama = sayac > 0 ? toplam / sayac : 0;
            double guzOrt = guzSayac > 0 ? guzToplam / guzSayac : 0;
            double baharOrt = baharSayac > 0 ? baharToplam / baharSayac : 0;
            double kalanAkts = toplamAkts - tamamlananAkts;

            
            

            chartGenelBasari.Series.Clear();
                chartGenelBasari.Series.Add("Genel Ortalama");
                chartGenelBasari.Series["Genel Ortalama"].ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

                chartGenelBasari.Series["Genel Ortalama"].Points.AddXY("Genel Ortalama", genelOrtalama);
            }
        
        void OgrencileriGetir()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT id, AdSoyad FROM Tbl_Ogrenciler WHERE BolumID = 1",
                baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);

            cmbOgrenci.DataSource = dt;
            cmbOgrenci.DisplayMember = "AdSoyad";
            cmbOgrenci.ValueMember = "id";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewRapor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chartGenelBasari_Click(object sender, EventArgs e)
        {

        }
    }
    }


      

