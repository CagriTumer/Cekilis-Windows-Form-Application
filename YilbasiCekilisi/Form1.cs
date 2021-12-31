using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace YilbasiCekilisi
{
    public partial class Form1 : Form
    {
        List<Kisi> kisiListesi;
        public Form1()
        {
            InitializeComponent();
            kisiListesi = new List<Kisi>();
        }
        private void btnEkle_Click(object sender, EventArgs e)
        {
            //click oldugunda txtAd ve txtSoyad degerlerini alarak bir kişi oluşturup listeye ekleyiniz.
            //txtAd ve txtSoyad boş olmasın.
            //ve txt leri temizleyelim

            Kisi kisi = new Kisi()
            {
                Ad = txtAd.Text.Trim(),
                Soyad = txtSoyad.Text.Trim()
            };
            kisiListesi.Add(kisi);
            txtAd.Clear();
            txtSoyad.Clear();
            Listele();//listele() ctrl + nokta
            txtAd.Select();
        }
        private void Listele()
        {
            
            dgvKisiler.DataSource = null;
            dgvKisiler.DataSource = kisiListesi;
            dgvKisiler.Columns[0].Visible = false;
        }

        private void txtAd_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtAd.Text) && !string.IsNullOrEmpty(txtSoyad.Text))
            {
                btnEkle.Enabled = true;

            }
            else
            {
                btnEkle.Enabled = false;
            }
        }

        private void dgvKisiler_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode==Keys.Delete) && dgvKisiler.SelectedRows.Count>0)
            {
                //basılan tuş delete ve dgv de seçili satır var ise
                Kisi secilenKisi = (Kisi)dgvKisiler.SelectedRows[0].DataBoundItem;
                kisiListesi.Remove(secilenKisi);
                Listele();
                KisiVarMİ();


            }
        }

        private void btnCekilisYap_Click(object sender, EventArgs e)
        {
            lblKazanan.Text = "Kazanan : ";
            Random rnd = new Random();
            int talihliIndex = rnd.Next(kisiListesi.Count);
            Kisi kazananKisi = kisiListesi[talihliIndex];
            lblKazanan.Text += " " + kazananKisi.Ad + " " + kazananKisi.Soyad;

                
        }

        private void dgvKisiler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void dgvKisiler_SelectionChanged(object sender, EventArgs e)
        {
            KisiVarMİ();
        }

        private void KisiVarMİ()
        {
            if (dgvKisiler.Rows.Count > 0)
            {
                btnCekilisYap.Enabled = true;
            }
            else
            {
                btnCekilisYap.Enabled = false;

            }
        }

       
    }
}
