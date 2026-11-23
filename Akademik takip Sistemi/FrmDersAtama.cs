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
    public partial class FrmDersAtama : Form
    {
        int secilenID = 0;
        SqlConnection baglanti = new SqlConnection("Data Source=NEVROZ\\SQLEXPRESS02;Initial Catalog=OkulOtomasyon;Integrated Security=True");


        public FrmDersAtama()
        {
            InitializeComponent();

            FrmDersAtama_Load(null, null);
            dataGridView1.CellClick += dataGridView_CellClick;

            btnDersGüncelleme.Click -= btnDersSil_Click;
            btnDersGüncelleme.Click -= btnDersGuncelle_Click;
            btnDersGüncelleme.Click += btnDersGuncelle_Click;

            Listele();
        }


        private void FrmDersAtama_Load(object sender, EventArgs e)
        {
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;
            cmbOgrenci.Items.Clear();
            cmbDers.Items.Clear();

            SqlCommand komut1 = new SqlCommand("SELECT AdSoyad FROM Tbl_Ogrenciler", baglanti);
            baglanti.Open();
            SqlDataReader dr = komut1.ExecuteReader();

            while (dr.Read())
            {
                cmbOgrenci.Items.Add(dr["AdSoyad"].ToString());
            }

            baglanti.Close();

            SqlCommand komut2 = new SqlCommand("SELECT DersAd FROM Tbl_Dersler", baglanti);
            baglanti.Open();
            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                cmbDers.Items.Add(dr2["DersAd"].ToString());
            }

            baglanti.Close();

        }

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT od.ID, o.AdSoyad AS Ogrenci, d.DersAd AS Ders " +
                "FROM Tbl_OgrenciDers od " +
                "INNER JOIN Tbl_Ogrenciler o ON od.OgrenciID = o.id " +
                "INNER JOIN Tbl_Dersler d ON od.DersID = d.DersID",
                baglanti);

            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

         
        }

        private void cmbDers_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            if (cmbOgrenci.Text == "" || cmbDers.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci ve ders seçiniz.");
                return;
            }

            baglanti.Open();

            SqlCommand ogrenciKomut = new SqlCommand(
                "SELECT id FROM Tbl_Ogrenciler WHERE AdSoyad=@p1", baglanti);
            ogrenciKomut.Parameters.AddWithValue("@p1", cmbOgrenci.Text);
            int ogrenciID = Convert.ToInt32(ogrenciKomut.ExecuteScalar());

            SqlCommand dersKomut = new SqlCommand(
                "SELECT DersID FROM Tbl_Dersler WHERE DersAd=@p2", baglanti);
            dersKomut.Parameters.AddWithValue("@p2", cmbDers.Text);
            int dersID = Convert.ToInt32(dersKomut.ExecuteScalar());

            SqlCommand ekleKomut = new SqlCommand(
                "INSERT INTO Tbl_OgrenciDers (OgrenciID, DersID) VALUES (@p3, @p4)", baglanti);
            ekleKomut.Parameters.AddWithValue("@p3", ogrenciID);
            ekleKomut.Parameters.AddWithValue("@p4", dersID);
            ekleKomut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Ders öğrenciye başarıyla eklendi.");
            Listele();
        }

        private void btnDersSil_Click(object sender, EventArgs e)
        {
            if (secilenID == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz öğrenci-ders kaydını tablodan seçiniz.");
                return;
            }

            baglanti.Open();

            SqlCommand silKomut = new SqlCommand(
                "DELETE FROM Tbl_OgrenciDers WHERE ID=@p1", baglanti);

            silKomut.Parameters.AddWithValue("@p1", secilenID);
            silKomut.ExecuteNonQuery();

            baglanti.Close();

            MessageBox.Show("Seçilen ders kaydı silindi.");
            secilenID = 0;
            Listele();
        }
           
            private void btnDersGuncelle_Click(object sender, EventArgs e)
        {
    
            MessageBox.Show("GÜNCELLEME METODUNA GİRDİ");

         
            
            if (secilenID == 0)
            {
                MessageBox.Show("Lütfen güncellemek istediğiniz kaydı tablodan seçiniz.");
                return;
            }

            if (cmbOgrenci.Text == "" || cmbDers.Text == "")
            {
                MessageBox.Show("Lütfen öğrenci ve ders seçiniz.");
                return;
            }

            baglanti.Open();

            SqlCommand ogrenciKomut = new SqlCommand(
                "SELECT id FROM Tbl_Ogrenciler WHERE AdSoyad=@p1", baglanti);
            ogrenciKomut.Parameters.AddWithValue("@p1", cmbOgrenci.Text);
            int ogrenciID = Convert.ToInt32(ogrenciKomut.ExecuteScalar());

            SqlCommand dersKomut = new SqlCommand(
                "SELECT DersID FROM Tbl_Dersler WHERE DersAd=@p2", baglanti);
            dersKomut.Parameters.AddWithValue("@p2", cmbDers.Text);
            int dersID = Convert.ToInt32(dersKomut.ExecuteScalar());

            SqlCommand komut = new SqlCommand(
                "UPDATE Tbl_OgrenciDers SET OgrenciID=@p3, DersID=@p4 WHERE ID=@p5", baglanti);

            komut.Parameters.AddWithValue("@p3", ogrenciID);
            komut.Parameters.AddWithValue("@p4", dersID);
            komut.Parameters.AddWithValue("@p5", secilenID);

            komut.ExecuteNonQuery();
            baglanti.Close();

            MessageBox.Show("Ders kaydı başarıyla güncellendi.");
            Listele();
        }
        
        
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                secilenID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value);

                cmbOgrenci.Text = dataGridView1.Rows[e.RowIndex].Cells["Ogrenci"].Value.ToString();
                cmbDers.Text = dataGridView1.Rows[e.RowIndex].Cells["Ders"].Value.ToString();
            }

        }
    }
}