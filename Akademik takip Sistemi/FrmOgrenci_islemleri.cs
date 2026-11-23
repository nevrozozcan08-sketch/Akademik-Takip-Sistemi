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
    public partial class FrmOgrenci_islemleri : Form
    {  
        // Veritabanı bağlantısı sağlar.
       SqlConnection baglanti = new SqlConnection("Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");
        int id; // Öğrenci ID bilgisi tutar .
        
        // Öğrenci kayıtlarını veritabanından getirip listeler.
        void Listele()

        {
            
            // Öğrenci tablosundaki tüm kayıtları çeker.
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Ogrenciler", baglanti);

        
            DataTable dt = new DataTable(); // Gelen verileri geçici tabloya aktarır.


            try
            {
                da.Fill(dt); // Verileri DataTable içine doldurur.
            }
            catch
            {
                // Veritabanı bağlanmazsa hata mesajı göster.
                MessageBox.Show("Veritabanı bağlantısı kurulamadı.");
            }

            // Gelen verileri DataGridView üzerinde göster.
            dataGridView1.DataSource = dt;
        }
       
        
        public FrmOgrenci_islemleri() // Öğrenci işlemleri formunu başlatır.
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        // form açıldığında öğrenci listesini yükler.
        private void Form1_Load(object sender, EventArgs e)
        { 
            // Öğrenci kayıtlarını ekrana getirir.
            Listele();
        }


        // Yeni öğrenci kaydı ekler.
        private void button1_Click(object sender, EventArgs e)
        {
            
            if (txtAdSoyad.Text == "" || txtNumara.Text == "" || txtSinif.Text == "" || txtFakulte.Text == "")
            {
                MessageBox.Show("Lütfen tüm alanları eksiksiz doldurunuz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; 
            }

            baglanti.Open(); // Veritabanı bağlantısı aç.

            
            // Öğrenci bilgilerini veritabanına eklemek içi SQL sorgusu oluştur.
            SqlCommand komut = new SqlCommand("insert into Tbl_Ogrenciler (AdSoyad, OgrenciNo, Sinif, Fakulte) values (@p1, @p2, @p3, @p4)", baglanti);

            int id;// ID gösterir.
           
           // TextBoxlardan alınan bilgileri SQL parametlerine aktar. 
            komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p2", txtNumara.Text);
            komut.Parameters.AddWithValue("@p3", txtSinif.Text);
            komut.Parameters.AddWithValue("@p4", txtFakulte.Text);

            // Ekleme sorgusunu çalıştırır.
            komut.ExecuteNonQuery();

            
            baglanti.Close();

            
            MessageBox.Show("Öğrenci Sisteme Eklendi!");

            
            Listele();
            {
                txtAdSoyad.Text = "";
                txtNumara.Text = "";
                txtSinif.Text = "";
                txtFakulte.Text = "";
                txtAdSoyad.Focus(); // İmleci tekrar Ad kutusuna odaklar, yazmaya hazır olur.
            }
        }

        
            private void btnSil_Click(object sender, EventArgs e)
        {
            // 1. SEÇİM KONTROLÜ (Eğer id 0 ise veya boşsa seçim yapılmamış demektir)
            if (id == 0)
            {
                MessageBox.Show("Lütfen silinecek öğrenciyi listeden seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ONAY SORUSU 
            DialogResult secim = MessageBox.Show("Bu öğrenciyi silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Eğer kullanıcı 'Evet' derse silme işlemini yap
            if (secim == DialogResult.Yes)
            {
                baglanti.Open();
                SqlCommand komut = new SqlCommand("Delete From Tbl_Ogrenciler where id=@k1", baglanti);
                komut.Parameters.AddWithValue("@k1", id); 
                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Öğrenci Silindi");
                Listele(); // Listeyi yenile

                // Kutuları temizle
                txtAdSoyad.Text = "";
                txtNumara.Text = "";
                txtSinif.Text = "";
                txtFakulte.Text = "";
                id = 0; // Seçimi boşa düşür
            }
        }
        


        
            private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                // Başlığa veya boş satıra tıklanırsa işlem yapma
                if (e.RowIndex == -1 || dataGridView1.Rows[e.RowIndex].Cells[0].Value == DBNull.Value)
                    return;

                int secilen = dataGridView1.SelectedCells[0].RowIndex;

                // ID'yi al
                id = int.Parse(dataGridView1.Rows[secilen].Cells[0].Value.ToString());

                // Diğerlerini doldur
                txtAdSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
                txtNumara.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
                txtSinif.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
                txtFakulte.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            }
            catch (Exception)
            {
           
            }
        }
        

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1. SEÇİM KONTROLÜ
            if (id == 0)
            {
                MessageBox.Show("Lütfen güncellenecek öğrenciyi listeden seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. ONAY SORUSU
            DialogResult secim = MessageBox.Show("Öğrenci bilgilerini güncellemek istediğinize emin misiniz?", "Güncelleme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (secim == DialogResult.Yes)
            {
                baglanti.Open();

               
                SqlCommand komut = new SqlCommand("Update Tbl_Ogrenciler set AdSoyad=@p1, OgrenciNo=@p2, Sinif=@p3, Fakulte=@p4 where id=@p5", baglanti);

                komut.Parameters.AddWithValue("@p1", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@p2", txtNumara.Text);
                komut.Parameters.AddWithValue("@p3", txtSinif.Text);
                komut.Parameters.AddWithValue("@p4", txtFakulte.Text);
                komut.Parameters.AddWithValue("@p5", id); // Seçilen ID'yi kullan

                komut.ExecuteNonQuery();
                baglanti.Close();

                MessageBox.Show("Öğrenci Bilgileri Güncellendi");
                Listele();

                // 3. KUTULARI TEMİZLEME 
                txtAdSoyad.Text = "";
                txtNumara.Text = "";
                txtSinif.Text = "";
                txtFakulte.Text = "";
                id = 0;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void btnSil_Click_1(object sender, EventArgs e)
        {


            {
                txtAdSoyad.Text = "";
                txtNumara.Text = "";
                txtSinif.Text = "";
                txtFakulte.Text = "";
                txtAdSoyad.Focus(); // İmleci tekrar Ad kutusuna odaklar, yazmaya hazır olur.
            }
            baglanti.Open(); 

            SqlCommand komut = new SqlCommand("Delete From Tbl_Ogrenciler where OgrenciID=@k1", baglanti);

            
            komut.Parameters.AddWithValue("@k1", id);

            komut.ExecuteNonQuery(); // İşlemi yap
            baglanti.Close();

            MessageBox.Show("Öğrenci Silindi");
            Listele(); // Listeyi yenile ki silinen gitsin.
        }

        private void lbl_Sınıf_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Numara_Click(object sender, EventArgs e)
        {

        }

        private void txtNumara_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
