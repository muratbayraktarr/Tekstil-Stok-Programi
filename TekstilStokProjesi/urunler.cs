using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TekstilStokProjesi
{
    public class Message
    {
        public virtual void mesaj()
        {
            MessageBox.Show("Burası Çalışmaz Aşağıda Override var !!");
        }
    }
    abstract public class urunler : Message
    {
        public string urunadi { get; set; }
        public int metrefiyat { get; set; }
        public string renk { get; set; }
        public string ozellik { get; set; }
        
    }
    
    public class Saksoni : urunler
    {
        private string kalite;
        public string KaliteAtayici
        {
            get { return kalite; }
            set { kalite = value; }
        }
        public Saksoni()
        {
            //Overload metoda örnektir 
        }
        public Saksoni(string name,int price,string color) 
        {
            this.metrefiyat = price;
            this.renk = color;
            this.urunadi = name;

        }
        public override void mesaj()
        {
            MessageBox.Show("Şuan Saksoni kumaşını görüntülemektesiniz.");
        }
    }
    public class Fresko : urunler
    {
        private string kalite;
        public Fresko()
        {
            

        }
        public string KaliteAtayici 
        { 
            get { return kalite; } 
            set { kalite = value; }
        }
        
        public Fresko(string name, int price, string color)
        {
            this.metrefiyat = price;
            this.renk = color;
            this.urunadi = name;


        }
        public override void mesaj()
        {
            MessageBox.Show("Şuan Fresko kumaşını görüntülemektesiniz.");
        }
    }
    public class Etamin : urunler
    {
        public Etamin(string name, int price, string color)
        {
            this.metrefiyat = price;
            this.renk = color;
            this.urunadi = name;

        }
        public override void mesaj()
        {
            MessageBox.Show("Şuan Etamin kumaşını görüntülemektesiniz.");
        }
    }
    public class Vual : urunler
    {
        public Vual(string name, int price, string color)
        {
            this.metrefiyat = price;
            this.renk = color;
            this.urunadi = name;

        }
        public override void mesaj()
        {
            MessageBox.Show("Şuan Vual kumaşını görüntülemektesiniz.");
        }
    }
    public class Basma : urunler
    {
        public Basma(string name, int price, string color)
        {
            this.metrefiyat = price;
            this.renk = color;
            this.urunadi = name;

        }
        public override void mesaj()
        {
            MessageBox.Show("Şuan Basma kumaşını görüntülemektesiniz.");
        }
    }
}
