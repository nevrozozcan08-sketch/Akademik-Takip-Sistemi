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
    public partial class FrmBolumler : Form
    {
        SqlConnection baglanti = new SqlConnection(
"Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");
        void BolumOgrencileriGetir(int bolumID)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT o.id, o.Numara, o.AdSoyad AS Ogrenci, o.Sinif,"+
                "b.BolumAdi AS Bolum, d.DanismanAdSoyad AS Danisman, d.Unvan " +
                "FROM Tbl_Ogrenciler o " +
                "INNER JOIN Tbl_Bolumler b ON o.BolumID = b.BolumID " +
                "LEFT JOIN Tbl_Danismanlar d ON o.DanismanID = d.DanismanID " +
                "WHERE o.BolumID = @p1 " +
                "ORDER BY o.Sinif, o.AdSoyad",
                baglanti);

            da.SelectCommand.Parameters.AddWithValue("@p1", bolumID);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewOgrenciler.DataSource = dt;
            dataGridViewOgrenciler.Columns["id"].Visible = false;
        }
        void BolumDersPlaniGetir(int bolumID)
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT AkademikYil AS [Akademik Yıl], Donem AS [Dönem], DersAdi AS [Ders Adı], Kredi, AKTS " +
                "FROM Tbl_BolumDersPlani " +
                "WHERE BolumID = @p1 " +
                "ORDER BY AkademikYil, CASE WHEN Donem = N'Güz' THEN 1 ELSE 2 END, DersAdi",
                baglanti);

            da.SelectCommand.Parameters.AddWithValue("@p1", bolumID);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridViewBolumDersleri.DataSource = dt;
        }
        public FrmBolumler()
        {
            InitializeComponent();

            dataGridViewOgrenciler.CellDoubleClick += dataGridViewOgrenciler_CellDoubleClick;
        
            this.WindowState = FormWindowState.Maximized;

            dataGridViewOgrenciler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewBolumDersleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void btnBilgisayar_Click(object sender, EventArgs e)
        {
          
            BolumOgrencileriGetir(1);
            BolumDersPlaniGetir(1);
        }
        private void button4_Click(object sender, EventArgs e)
        {
           
            BolumOgrencileriGetir(1);
            BolumDersPlaniGetir(1);

        }
        private void dataGridViewOgrenciler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int ogrenciID = Convert.ToInt32(dataGridViewOgrenciler.Rows[e.RowIndex].Cells["id"].Value);

                FrmOgrenciDetay detay = new FrmOgrenciDetay(ogrenciID);
                detay.Show();
            }
        }
        private void FrmBolumler_Load(object sender, EventArgs e)
        {

        }
    }
}
