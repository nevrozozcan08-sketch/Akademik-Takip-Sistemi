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
    public partial class FrmLogin : Form
    {  // veritabanı baglantısı sağlar
        SqlConnection baglanti = new SqlConnection(
"Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

       
        
            
        
            
            //giriş butonuna tıkladiğinda çalişir
           private void btnGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            // Girilen kullanıcı adı ve şifreyi veritabanındaki kullanıcılarla karşılaştıran SQL sorgusu oluşturulur.
            SqlCommand komut = new SqlCommand(
                "SELECT COUNT(*) FROM Tbl_Kullanicilar WHERE KullaniciAdi=@p1 AND Sifre=@p2",
                baglanti);

            komut.Parameters.AddWithValue("@p1", txtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            int sonuc = Convert.ToInt32(komut.ExecuteScalar());

            baglanti.Close();
           
            //kullanıcı bilgileri doğruysa anamenü açilir.
            if (sonuc > 0)
            {
                FrmAnaMenu ana = new FrmAnaMenu();
                ana.Show();
                this.Hide();//giriş ekranı gizler.
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı!");
            }
        }
    }
            }
        
        
    
    

