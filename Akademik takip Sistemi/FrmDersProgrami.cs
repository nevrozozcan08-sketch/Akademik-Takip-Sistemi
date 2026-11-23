using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
namespace AkademikTakipSistemi
{
    public partial class FrmDersProgrami : Form
    {
        SqlConnection baglanti = new SqlConnection(
"Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");
       
          
            public FrmDersProgrami()
        {
            InitializeComponent();

            OgrencileriGetir();

            cmbOgrenci.SelectedIndexChanged += cmbOgrenci_SelectedIndexChanged;

            if (cmbOgrenci.SelectedValue != null)
            {
                DersProgramiGetir(Convert.ToInt32(cmbOgrenci.SelectedValue));
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

        void DersProgramiGetir(int ogrenciID)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT dp.Gun AS [Gün], dp.Saat, d.DersAd AS [Ders], " +
                "dn.DanismanAdSoyad AS [Öğretim Elemanı], dp.Derslik " +
                "FROM Tbl_Ogrenciler o " +
                "INNER JOIN Tbl_DersProgrami dp ON o.BolumID = dp.BolumID " +
                "INNER JOIN Tbl_Dersler d ON dp.DersID = d.DersID " +
                "INNER JOIN Tbl_Danismanlar dn ON dp.DanismanID = dn.DanismanID " +
                "WHERE o.id = @p1 " +
                "AND dp.Sinif = TRY_CONVERT(INT, LEFT(o.Sinif, 1)) " +
                "AND dp.Donem = N'Bahar' " +
                "ORDER BY CASE dp.Gun " +
                "WHEN N'Pazartesi' THEN 1 WHEN N'Salı' THEN 2 WHEN N'Çarşamba' THEN 3 " +
                "WHEN N'Perşembe' THEN 4 WHEN N'Cuma' THEN 5 ELSE 6 END, dp.Saat",
                baglanti);

            da.SelectCommand.Parameters.AddWithValue("@p1", ogrenciID);

            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridViewDersProgrami.DataSource = dt;
        }
        private void cmbOgrenci_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedValue != null && cmbOgrenci.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                int ogrenciID = Convert.ToInt32(cmbOgrenci.SelectedValue);
                DersProgramiGetir(ogrenciID);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
