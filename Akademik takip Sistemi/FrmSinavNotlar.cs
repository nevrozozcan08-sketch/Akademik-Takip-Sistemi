using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; // SQL işlemleri için gerekli kütüphane.

namespace AkademikTakipSistemi
{   
    public partial class FrmSinavNotlar : Form
    {   
        // Sınav notları formunu başlatır ve not listesini yükler.
        public FrmSinavNotlar()
        {
            InitializeComponent();
            Listele(); //Not kayıtlarını ekrana getirir.
        }


        //SQL server veri tabanı bağlantısı.
        SqlConnection baglanti = new SqlConnection(@"Data Source=NEVROZ\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");

    
// Veritabanındaki not kayıtlarını listeleyip DataGridView e aktarır.
void Listele() 
        {
            baglanti.Open(); // Veritabanı bağlantısını aç.

            // Not , öğrenci ve ders  bilgilerini birleştırerek listele.
            SqlCommand komut = new SqlCommand(@"
SELECT 
    Tbl_Notlar.NotID,
    Tbl_Ogrenciler.AdSoyad AS 'Ad Soyad',
    Tbl_Dersler.DersAd AS 'Ders',
    Tbl_Notlar.Vize,
    Tbl_Notlar.Final,
    Tbl_Notlar.Ortalama,
    Tbl_Notlar.Durum
FROM Tbl_Notlar
LEFT JOIN Tbl_Ogrenciler ON Tbl_Notlar.OgrenciID = Tbl_Ogrenciler.id
LEFT JOIN Tbl_Dersler ON Tbl_Notlar.DersID = Tbl_Dersler.DersID", baglanti);


            // Sorgu sonucunu DataGridView e aktar.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close(); // Veritabanı bağlantısını kapat.
        }
    

        private void FrmSinavNotlar_Load(object sender, EventArgs e)
        {
            // Form açıldığında not listesini ekrana yükler.
            
            Listele();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmSinavNotlar_Load_1(object sender, EventArgs e)
        {
           Listele();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lblOgrenciEkle_Click(object sender, EventArgs e)
        {

        }

        // Not ekleme formunu açar.
        private void btnNotEkle_Click(object sender, EventArgs e) 
        {
            FrmNotEkle fr = new FrmNotEkle();
            fr.ShowDialog(); // Not ekleme penceresi kapanana kadar bekler.
            Listele();       // Pencere kapanınca listeyi yeniler, yeni not hemen görünür.
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}