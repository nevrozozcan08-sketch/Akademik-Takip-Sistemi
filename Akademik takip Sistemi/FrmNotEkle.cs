using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace AkademikTakipSistemi
{
    public partial class FrmNotEkle : Form
    {
        TextBox araKutusu;
        DataGridView notTablosu;
        // Veritabanı bağlantısı sağlanıyor.
        SqlConnection baglanti = new SqlConnection(@"Data Source=NEVROZ\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True;Pooling=False;Encrypt=True;TrustServerCertificate=True");
        public FrmNotEkle() // Form başlatıldığında çalışır.
        {
            InitializeComponent();
            foreach (Control c in this.Controls)
            {
                if (c is TextBox)
                {
                    TextBox t = (TextBox)c;

                    // Sol üstteki arama kutusu
                    if (t.Location.X < 300 && t.Location.Y < 100)
                    {
                        t.TextChanged += AraKutusu_TextChanged;
                        break;
                    }
                }
            }

            araKutusu = new TextBox();
            araKutusu.Location = new Point(150, 35);
            araKutusu.Width = 220;
            araKutusu.TextChanged += AraKutusu_TextChanged;
            this.Controls.Add(araKutusu);

            notTablosu  = this.Controls.OfType<DataGridView>().FirstOrDefault();

        }
        
            private void AraKutusu_TextChanged(object sender, EventArgs e)
        {
            TextBox ara = sender as TextBox;

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT n.NotID, o.AdSoyad, d.DersAd AS Ders, n.Vize, n.Final, n.Ortalama " +
                "FROM Tbl_Notlar n " +
                "INNER JOIN Tbl_Ogrenciler o ON n.OgrenciID = o.id " +
                "INNER JOIN Tbl_Dersler d ON n.DersID = d.DersID " +
                "WHERE o.AdSoyad LIKE @p1", baglanti);

            da.SelectCommand.Parameters.AddWithValue("@p1", "%" + ara.Text + "%");

            DataTable dt = new DataTable();
            da.Fill(dt);

            foreach (Control c in this.Controls)
            {
                if (c is DataGridView)
                {
                    ((DataGridView)c).DataSource = dt;
                    break;
                }
            }
        }
        
        
        private void label1_Click(object sender, EventArgs e)// Şuan aktif işlem yok .Etikete  tıklanınca çalişir.
        {


        }

        private void FrmNotEkle_Load(object sender, EventArgs e) // Forma açıldığında öğrenci ve ders listelerini yükler.
        {    // Form ait öğrenci listesini yükle.
            SqlDataAdapter da1 = new SqlDataAdapter("SELECT id, AdSoyad FROM Tbl_Ogrenciler", baglanti);
            DataTable dt1 = new DataTable(); // Verileri geçici tabloya aktar.
            da1.Fill(dt1);
            
            // Öğrenci bilgilerini ComboBox a bağla.
            cmbOgrenci.DataSource = dt1;
            cmbOgrenci.DisplayMember = "AdSoyad";
            cmbOgrenci.ValueMember = "id";
            
            // Ders listesini ComboBox a yükle.
            SqlDataAdapter da2 = new SqlDataAdapter("SELECT DersID, DersAd FROM Tbl_Dersler", baglanti);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);

            // Ders bilgilerini ComboBox a bağla.
            cmbDers.DataSource = dt2;
            cmbDers.DisplayMember = "DersAd";
            cmbDers.ValueMember = "DersID";
            
        }
        // Vize %40 + Final %60 ile ortalamayı hesaplar.
        // Hem "Hesapla" hem "Kaydet" bu metodu kullanır, böylece iki yerde farklı sonuç çıkmaz.
        double OrtalamaHesapla(double vize, double final)
        {
            return (vize * 0.4) + (final * 0.6);
        }

        // Bir not kutusunu okur: sayı mı ve 0-100 arasında mı kontrol eder.
        // Hatalıysa kullanıcıya mesaj gösterir, kutuyu seçer ve false döner.
        bool NotOku(TextBox kutu, string notAdi, out double deger)
        {
            string metin = kutu.Text.Trim().Replace(',', '.'); // 75,5 ve 75.5 ikisi de kabul edilir

            if (!double.TryParse(metin, NumberStyles.Float, CultureInfo.InvariantCulture, out deger))
            {
                MessageBox.Show(notAdi + " notu sayı olmalıdır.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kutu.Focus();
                kutu.SelectAll();
                return false;
            }

            if (deger < 0 || deger > 100)
            {
                MessageBox.Show(notAdi + " notu 0 ile 100 arasında olmalıdır.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                kutu.Focus();
                kutu.SelectAll();
                return false;
            }

            return true;
        }

        // Vize ve final notlarını kontrol edip ortalamayı ve geçme/kalma durumunu gösterir.
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            double vize, final;
            if (!NotOku(txtVize, "Vize", out vize)) return;
            if (!NotOku(txtFinal, "Final", out final)) return;

            double ortalama = OrtalamaHesapla(vize, final);

            // Ortalamayı yazdır
            txtOrtalama.Text = ortalama.ToString("0.00"); // Virgülden sonra 2 hane gösterir

            // Geçme Kalma Durumu
            if (ortalama >= 50)
            {
                txtDurum.Text = "Geçti";
                txtDurum.BackColor = Color.Green; // Görsel ipucu
                txtDurum.ForeColor = Color.White;
            }
            else
            {
                txtDurum.Text = "Kaldı";
                txtDurum.BackColor = Color.Red;
                txtDurum.ForeColor = Color.White;
            }
        }


        //Not bilgilerini kontrol edip veritabanına kaydeder.
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.SelectedValue == null || cmbDers.SelectedValue == null)
            {
                MessageBox.Show("Lütfen öğrenci ve ders seçiniz.", "Eksik Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            double vize, final;
            if (!NotOku(txtVize, "Vize", out vize)) return;
            if (!NotOku(txtFinal, "Final", out final)) return;

            double ort = OrtalamaHesapla(vize, final);

            SqlCommand komut = new SqlCommand("INSERT INTO Tbl_Notlar (OgrenciID, DersID, Vize, Final, Ortalama, Durum) VALUES (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);

            // ComboBox'tan seçilen gizli ID'leri alıyoruz
            komut.Parameters.AddWithValue("@p1", cmbOgrenci.SelectedValue);
            komut.Parameters.AddWithValue("@p2", cmbDers.SelectedValue);
            komut.Parameters.AddWithValue("@p3", vize);
            komut.Parameters.AddWithValue("@p4", final);
            komut.Parameters.AddWithValue("@p5", Math.Round(ort, 2));
            komut.Parameters.AddWithValue("@p6", ort >= 50 ? "Geçti" : "Kaldı");

            try
            {
                baglanti.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Not başarıyla kaydedildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Not kaydedilemedi: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close(); // Hata olsa bile bağlantı kapanır.
            }
        }
    }
}
