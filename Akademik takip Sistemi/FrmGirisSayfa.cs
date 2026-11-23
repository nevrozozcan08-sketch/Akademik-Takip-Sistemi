using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AkademikTakipSistemi
{
    public partial class FrmAnaMenu : Form
    {
        // Ana menü formunu başlatır.
        public FrmAnaMenu()
        {
            InitializeComponent();


            // Form açıldığında saat bilgisi hemen ekrana yazdırılır.
            lblsaat.Text = DateTime.Now.ToString("HH:mm");

            // Timer başlatılır ve saat her dakika güncellenir.
            timer1.Start();

        }

        //Öğrenci işlemleri formunu açar.
        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            FrmOgrenci_islemleri fr = new FrmOgrenci_islemleri();

            this.Hide();
            fr.ShowDialog();
            this.Show();
        }

        // Not işlemleri formunu açar.
        private void btnNotlar_Click(object sender, EventArgs e)
        {
            FrmSinavNotlar fr = new FrmSinavNotlar();
            fr.Show();
        }

        // Ders işlemleri formunu açar.
        private void btnDersler_Click(object sender, EventArgs e)
        {
            FrmDersler fr = new FrmDersler();
            fr.Show();
        }

        // Rapor işlemleri formunu açar.
        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRaporlar fr = new FrmRaporlar();
            fr.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        // Saat bilgisini her Timer çalıştığında günceller.
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblsaat.Text = DateTime.Now.ToString(" HH:mm");
        }

        private void label1_Click_2(object sender, EventArgs e)
        {


        }

        private void btnDanışmanİşlemleri_Click(object sender, EventArgs e)
        {
            FrmDersAtama frm = new FrmDersAtama();
            frm.Show();
        }

        private void btnDersEkle_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ders ekle butonu çalışıyor.");
        }

        
            private void btnBolumler_Click(object sender, EventArgs e)
        {
            FrmBolumler fr = new FrmBolumler();
            fr.Show();
        }

        
private void btnDersProgrami_Click(object sender, EventArgs e)
        {
            FrmDersProgrami frm = new FrmDersProgrami();
            frm.ShowDialog();
        }

        
            private void button1_Click(object sender, EventArgs e)
            {
                FrmDanismanGorusu frm = new FrmDanismanGorusu();
                frm.ShowDialog();
            }
        }
    }
    
    

