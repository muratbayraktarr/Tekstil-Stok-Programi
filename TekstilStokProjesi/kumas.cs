using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TekstilStokProjesi
{
    public partial class kumas : Form
    {
        public kumas()
        {
            InitializeComponent();
        }

        private void btnSaksoni_Click(object sender, EventArgs e)
        {
            Saksoni s1 = new Saksoni("Saksoni", 150, "Turuncu");
            s1.ozellik = "Saxony’ ve merinos yapaklarından yapılan ştrayhgarn ipliklerden çeşitli örgü ve desenlerde dokunan, yumuşak ve açık dokulu kumaşlardır. Elbiselik ve paltoluk kumaş olarak kullanılırlar. Hafif ve orta gramajlar için 2/2 dimi örgü ile 12 Nm ve daha ince ştrayhgarn iplikler uygundur.";
            pictureBox1.Image = Image.FromFile(@"..\..\Images\Saksoni.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            s1.KaliteAtayici = "S2";
            tbUrunAdi.Text = s1.urunadi;
            tbRenk.Text = s1.renk;
            label1.Text = "Ortalama Metre Fiyatı : " + s1.metrefiyat+ " TL";
            tbOzellik.Text = s1.ozellik;
            s1.mesaj();
        }

        private void btnFresko_Click(object sender, EventArgs e)
        {
            Fresko f1 = new Fresko();
            f1.urunadi = "Fresko";
            f1.metrefiyat = 100;
            f1.renk = "Gri";
            f1.KaliteAtayici = "S1";
            f1.ozellik = "Yüksek bükümlü ipliklerin, katlandıktan sonra, bezayağı örgüde ve düşük sıklıklarda dokunmasıyla elde edilen sert tutumlu, hafif gramajlı kumaşlardır. Kumaşa kırçıl ya da kumlu bir renk etkisi vermek için muline iplikler de kullanılabilir.";
            label1.Text = "Ortalama Metre Fiyatı : " + f1.metrefiyat + " TL";

            tbUrunAdi.Text = f1.urunadi;
            tbRenk.Text = f1.renk;
            tbOzellik.Text = f1.ozellik;
            pictureBox1.Image = Image.FromFile(@"..\..\Images\Fresko.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            f1.mesaj();
        }

        private void btnEtamin_Click(object sender, EventArgs e)
        {
            Etamin e1 = new Etamin("Etamin",95,"Mavi");
            e1.ozellik = "Elek bezi olarak da bilinen bu kumaş ince ve seyrek dokuludur.\r\nEtamin bağlantı, bezayağı bağlantıdan bazı bağlantı noktalarının çıkarılması veya bezayağı bağlantıya bazı bağlantı noktalarının ilave edilmesiyle elde edilir. Etamin bağlantı, dokuma kumaşta delikli, gözenekli bir yapı meydana getirir.";
            tbUrunAdi.Text = e1.urunadi;
            tbRenk.Text = e1.renk;
            tbOzellik.Text = e1.ozellik;
            label1.Text = "Ortalama Metre Fiyatı : " + e1.metrefiyat + " TL"; 
            pictureBox1.Image = Image.FromFile(@"..\..\Images\Etamin.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            e1.mesaj();
        }

        private void btnVual_Click(object sender, EventArgs e)
        {
            Vual v1 = new Vual("Vual", 120, "Kahverengi");
            v1.ozellik = "Vual Kumaş 60/1 numara gibi ince olan %100 pamuktan üretilmiş, hafif, rahat bir tekstil ham maddesidir. Kelime anlamı olarak Fransızca dan gelen “vual”  ince örtü anlamını taşımaktadır. Parlak ve kaygan yapıya sahip olduğu için ipek kumaşa benzetilir. İnce numaralı ve seyrek dokunarak elde edilir. Vual kumaş çeşitleri desenleri, renkleri ve kullanıldığı alanlar bakımında zenginlik gösterir.";
            tbUrunAdi.Text= v1.urunadi;
            tbRenk.Text = v1.renk;
            tbOzellik.Text = v1.ozellik;
            label1.Text = "Ortalama Metre Fiyatı : " + v1.metrefiyat + " TL"; 
            pictureBox1.Image = Image.FromFile(@"..\..\Images\Vual.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            v1.mesaj();
        }

        private void btnBasma_Click(object sender, EventArgs e)
        {
            Basma b1 = new Basma("Basma", 80, "Renkli");
            b1.ozellik = "Çeşitli basit ve karmaşık desenlerin, baskı yoluyla, pamuklu bezayağı kumaşa uygulanmasıyla elde edilen desenli kumaşlara basma adı verilmektedir. Dokunmasında 20 numaradan (Ne) 36 numaraya kadar çeşitli iplikler kullanıldığı gibi, pamuklu/polyester, pamuk/viskon karışımı ipliklerden yapılmış kumaşlar da baskı yoluyla renklendirilebilirler.";
            tbUrunAdi.Text = b1.urunadi;
            tbRenk.Text = b1.renk;
            tbOzellik.Text = b1.ozellik;
            label1.Text = "Ortalama Metre Fiyatı : " + b1.metrefiyat + " TL";
            pictureBox1.Image = Image.FromFile(@"..\..\Images\Basma.jpg");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            b1.mesaj();
        }

        private void kumas_FormClosed(object sender, FormClosedEventArgs e)
        {
            stok s1 = new stok();
            s1.Show();
            this.Hide();
        }
    }
}
