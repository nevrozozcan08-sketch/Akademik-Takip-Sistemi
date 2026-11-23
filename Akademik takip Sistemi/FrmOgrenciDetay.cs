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
    public partial class FrmOgrenciDetay : Form
    {
        int ogrenciID;
        SqlConnection baglanti = new SqlConnection(
    "Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");
        public FrmOgrenciDetay( int id)
        {
       
            InitializeComponent();

            ogrenciID= id;

            

         

            dataGridView1.Location = new Point(20, 55);
            dataGridView1.Size = new Size(1040, 480);
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;

            
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            OgrenciDersleriniGetir();
        }
       
        
        
            void OgrenciDersleriniGetir()
            {
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT " +
                    "bdp.AkademikYil AS [Akademik Yıl], " +
                    "bdp.Donem AS [Dönem], " +
                    "bdp.DersAdi AS [Ders], " +
                    "bdp.Kredi, bdp.AKTS, " +

                    "CASE WHEN (TRY_CONVERT(INT, LEFT(bdp.AkademikYil,4)) - 2023 + 1) <= TRY_CONVERT(INT, LEFT(o.Sinif,1)) THEN n.Vize ELSE NULL END AS Vize, " +
                    "CASE WHEN (TRY_CONVERT(INT, LEFT(bdp.AkademikYil,4)) - 2023 + 1) <= TRY_CONVERT(INT, LEFT(o.Sinif,1)) THEN n.Final ELSE NULL END AS Final, " +
                    "CASE WHEN (TRY_CONVERT(INT, LEFT(bdp.AkademikYil,4)) - 2023 + 1) <= TRY_CONVERT(INT, LEFT(o.Sinif,1)) THEN n.Ortalama ELSE NULL END AS Ortalama, " +

                    "CASE " +
                    "WHEN (TRY_CONVERT(INT, LEFT(bdp.AkademikYil,4)) - 2023 + 1) > TRY_CONVERT(INT, LEFT(o.Sinif,1)) THEN 'Henüz Almadı' " +
                    "WHEN n.Ortalama >= 90 THEN 'AA' " +
                    "WHEN n.Ortalama >= 80 THEN 'BA' " +
                    "WHEN n.Ortalama >= 70 THEN 'BB' " +
                    "WHEN n.Ortalama >= 60 THEN 'CB' " +
                    "WHEN n.Ortalama >= 50 THEN 'CC' " +
                    "ELSE 'FF' END AS [Harf Notu], " +

                    "CASE " +
                    "WHEN (TRY_CONVERT(INT, LEFT(bdp.AkademikYil,4)) - 2023 + 1) > TRY_CONVERT(INT, LEFT(o.Sinif,1)) THEN 'Alacak' " +
                    "WHEN n.Ortalama >= 50 THEN 'Geçti' " +
                    "ELSE 'Kaldı' END AS Durum " +

                    "FROM Tbl_Ogrenciler o " +
                    "INNER JOIN Tbl_BolumDersPlani bdp ON o.BolumID = bdp.BolumID " +
                    "LEFT JOIN Tbl_Dersler d ON d.DersAd = bdp.DersAdi " +
                    "LEFT JOIN Tbl_Notlar n ON n.OgrenciID = o.id AND n.DersID = d.DersID " +
                    "WHERE o.id = @p1 " +
                    "ORDER BY bdp.AkademikYil, CASE WHEN bdp.Donem = N'Güz' THEN 1 ELSE 2 END, bdp.DersAdi",
                    baglanti);

                da.SelectCommand.Parameters.AddWithValue("@p1", ogrenciID);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        private void FrmOgrenciDetay_Load(object sender, EventArgs e)
        {

        }
    }
    }
        
    
