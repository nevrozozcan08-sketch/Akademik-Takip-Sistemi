using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkademikTakipSistemi
{
    public partial class FrmDanismanGorusu : Form
    {
        SqlConnection baglanti = new SqlConnection(
"Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");


        public FrmDanismanGorusu()
        {
            InitializeComponent();
            OgrencileriGetir();
        }


        private void cmbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedValue != null &&
                cmbOgrenci.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int ogrenciID = Convert.ToInt32(cmbOgrenci.SelectedValue);
                DanismanGorusuOlustur(ogrenciID);
            }
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
        void DanismanGorusuOlustur(int ogrenciID)
        {
            SqlDataAdapter da = new SqlDataAdapter(
    "SELECT o.AdSoyad, o.Sinif, n.Ortalama, bdp.AKTS, d.DersAd, " +
    "CASE WHEN n.Ortalama < 50 THEN 1 ELSE 0 END AS Kaldi " +
    "FROM Tbl_Ogrenciler o " +
    "LEFT JOIN Tbl_Notlar n ON o.id = n.OgrenciID " +
    "LEFT JOIN Tbl_Dersler d ON n.DersID = d.DersID " +
    "LEFT JOIN Tbl_BolumDersPlani bdp ON bdp.DersAdi = d.DersAd AND bdp.BolumID = o.BolumID " +
    "WHERE o.id = @p1",
    baglanti);

            da.SelectCommand.Parameters.AddWithValue("@p1", ogrenciID);

            DataTable dt = new DataTable();
            da.Fill(dt);

            if (dt.Rows.Count == 0) return;

            string adSoyad = dt.Rows[0]["AdSoyad"].ToString();
            string sinif = dt.Rows[0]["Sinif"].ToString();

            double toplam = 0;
            int sayac = 0;
            int toplamAkts = 0;
            int tamamlananAkts = 0;

            List<string> kalanDersler = new List<string>();

            double toplamKatsayiAkts = 0;
            int ToplamAkts = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Ortalama"] != DBNull.Value && row["AKTS"] != DBNull.Value)
                {
                    double ort = Convert.ToDouble(row["Ortalama"]);
                    int akts = Convert.ToInt32(row["AKTS"]);

                    string harf = "";

                    if (ort >= 90) harf = "AA";
                    else if (ort >= 80) harf = "BA";
                    else if (ort >= 70) harf = "BB";
                    else if (ort >= 60) harf = "CB";
                    else if (ort >= 50) harf = "CC";
                    else harf = "FF";

                    double katsayi = 0;

                    if (harf == "AA") katsayi = 4.00;
                    else if (harf == "BA") katsayi = 3.50;
                    else if (harf == "BB") katsayi = 3.00;
                    else if (harf == "CB") katsayi = 2.50;
                    else if (harf == "CC") katsayi = 2.00;
                    else if (harf == "FF") katsayi = 0.00;

                    toplamKatsayiAkts += katsayi * akts;
                    toplamAkts += akts;
                }
            }

            double agno = toplamAkts > 0 ? toplamKatsayiAkts / toplamAkts : 0;
            SqlDataAdapter daDev = new SqlDataAdapter(
    "SELECT o.AdSoyad, o.Sinif, n.Ortalama, bdp.AKTS, d.DersAd, " +
    "CASE WHEN n.Ortalama < 50 THEN 1 ELSE 0 END AS Kaldi " +
    "FROM Tbl_Ogrenciler o " +
    "LEFT JOIN Tbl_Notlar n ON o.id = n.OgrenciID " +
    "LEFT JOIN Tbl_Dersler d ON n.DersID = d.DersID " +
    "LEFT JOIN Tbl_BolumDersPlani bdp ON bdp.DersAdi = d.DersAd AND bdp.BolumID = o.BolumID " +
    "WHERE o.id = @p2",
    baglanti);


            daDev.SelectCommand.Parameters.AddWithValue("@p2", ogrenciID);

            DataTable dtDev = new DataTable();
            daDev.Fill(dtDev);

            List<string> devamsizlikDersleri = new List<string>();

            foreach (DataRow row in dtDev.Rows)
            {
                devamsizlikDersleri.Add(row["DersAd"].ToString());
            }
            int kalanAkts = toplamAkts - tamamlananAkts;
            string gorus = "";

            gorus += adSoyad + " isimli öğrenci " + sinif + " düzeyinde öğrenimine devam etmektedir. ";
            gorus += "Öğrencinin genel başarı ortalaması " + agno.ToString("0.00") + " olarak hesaplanmıştır. ";

            if (tamamlananAkts > 0)
            {
                gorus += "Tamamladığı AKTS değeri " + tamamlananAkts + ", kalan AKTS değeri ise " + kalanAkts + " olarak görülmektedir. ";
            }

            if (kalanDersler.Count > 0)
            {
                gorus += "Öğrencinin gelecek dönem alttan alması gereken dersler: ";
                gorus += string.Join(", ", kalanDersler.Distinct());
                gorus += ". ";
            }
            else
            {
                gorus += "Öğrencinin başarısız dersi bulunmamaktadır. ";
            }

            if (devamsizlikDersleri.Count > 0)
            {
                gorus += "Ayrıca öğrencinin devamsızlık nedeniyle başarısız olduğu dersler: ";
                gorus += string.Join(", ", devamsizlikDersleri.Distinct());
                gorus += ". Sonraki dönemlerde ders devam durumuna dikkat etmesi önerilir. ";
            }

            gorus += "Danışman tarafından öğrencinin ders seçimlerinde bu bilgiler dikkate alınarak yönlendirilmesi uygun görülmektedir.";

            txtGorus.Text = gorus;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGorus_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            SqlCommand komut = new SqlCommand(
            "UPDATE Tbl_Ogrenciler SET DanismanGorusu=@gorus WHERE id=@id",
            baglanti);

            komut.Parameters.AddWithValue("@gorus", txtGorus.Text);
            komut.Parameters.AddWithValue("@id", cmbOgrenci.SelectedValue);

            komut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Danışman görüşü kaydedildi.");
        }
    }
}