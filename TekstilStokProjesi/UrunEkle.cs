using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace TekstilStokProjesi
{
    public partial class UrunEkle : Form
    {
        public UrunEkle(int id)
        {
            InitializeComponent();
            idz = id;
        }
        public int idz;
        stok s1 = new stok();
        private void UrunEkle_Load(object sender, EventArgs e)
        {

        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (tbUrunEkle.Text != null && tbAdetEkle.Text != null && tbFiyatEkle.Text != null && tbRenkEkle.Text != null)
            {
                XDocument xDosya = XDocument.Load(@"stokveri.xml");
                    idz++;
                    xDosya.Element("Urunler").Add(
                        new XElement("Urun",
                        new XElement("ID", idz),
                        new XElement("UrunAdı", tbUrunEkle.Text),
                        new XElement("Adet", tbAdetEkle.Text),
                        new XElement("Fiyat", tbFiyatEkle.Text),
                        new XElement("Renk", tbRenkEkle.Text),
                        new XElement("GuncellenmeTarihi", DateTime.Now.ToString())
                        ));
                xDosya.Save(@"stokveri.xml");
                s1.Show();
                s1.RefreshPage();
                
                this.Close();
            }
            else
                MessageBox.Show("Lütfen tüm kutucukları doldurun.");
        }

        private void UrunEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            s1.Show();
            s1.RefreshPage();
        }
    }
}
