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
    public partial class stok : Form
    {
       
        public stok()
        {
            InitializeComponent();
            
            btnSatis.Enabled = false;
            
        }
        public int firstwork=0;
        public int x;
        public int butonactive = 0;
        public int b1=0, b2=0;
        public int id;
        public void RefreshPage()
        {
            int j = 0;
            x = dataGridView1.Rows.Count;
            
            string[] stringsUrunler= new string[x];
            XmlDocument i = new XmlDocument();
            DataSet ds = new DataSet();
            XmlReader xmlReader;
            xmlReader = XmlReader.Create("stokveri.xml", new XmlReaderSettings());
            ds.ReadXml(xmlReader);
            dataGridView1.DataSource = ds.Tables[0];
            dataGridView1.Columns[0].HeaderText = "ID";
            dataGridView1.Columns[1].HeaderText = "Ürün Adı";
            dataGridView1.Columns[2].HeaderText = "Adet";
            dataGridView1.Columns[3].HeaderText = "Fiyat";
            dataGridView1.Columns[4].HeaderText = "Renk";
            dataGridView1.Columns[5].HeaderText = "Güncellenme Tarihi";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbUrun.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbAdet.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbFiyat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbRenk.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            List<string> list = new List<string>();
            list.Clear();
            if(firstwork == 0)
            {
                cbUrunSatis.Items.Clear();
                for(j= 0; j < x; j++)
                {
                    try
                    {
                        cbUrunSatis.Items.Add(dataGridView1.Rows[j].Cells[1].Value.ToString());
                        firstwork++;
                    }
                    catch (Exception)
                    {                       
                    }
                }
            }
            xmlReader.Close();  
        }
        XDocument xDoc = new XDocument();
        string directory_path = System.Windows.Forms.Application.StartupPath ;
        string file_path = System.Windows.Forms.Application.StartupPath + "//stokveri.xml";
        public int idbelirle()
        {
            return dataGridView1.Rows.Count;
        }
        private void stok_Load(object sender, EventArgs e)
        {
           xDoc = XDocument.Load(file_path);
            RefreshPage();  
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            tbUrun.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            tbAdet.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            tbFiyat.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            tbRenk.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            XDocument xDosya = XDocument.Load(@"stokveri.xml");
            XElement element = xDosya.Element("Urunler").Elements("Urun").FirstOrDefault(x=>x.Element("ID").Value==tbID.Text);
            if (element != null) 
            {
                element.SetElementValue("UrunAdı", tbUrun.Text);
                element.SetElementValue("Adet",tbAdet.Text);
                element.SetElementValue("Fiyat",tbFiyat.Text);
                element.SetElementValue("Renk",tbRenk.Text);
                element.SetElementValue("GuncellenmeTarihi", DateTime.Now.ToString());

                xDosya.Save(@"stokveri.xml");
            }
            RefreshPage();
        }

        private void stok_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnGuncelle_MouseDown(object sender, MouseEventArgs e)
        {
            btnGuncelle.BackColor = Color.FromArgb(234, 150, 116);
        }
        private void btnGuncelle_MouseUp(object sender, MouseEventArgs e)
        {
            btnGuncelle.BackColor = Color.FromArgb(252, 188, 128);
        }
        private void tbAdetSatis_TextChanged(object sender, EventArgs e)
        {
            if(b2==0)
            {
                butonactive++;
                b2++;
            }
            if(tbAdetSatis.Text == null)
            {
                btnSatis.Enabled = false;
                b2--;
            }
            if (butonactive == 2)
                btnSatis.Enabled = true;
            try
            {
                tbFiyatSatis.Text = (Convert.ToInt32(tbAdetSatis.Text) * Convert.ToInt32(tbMetreFiyatSatis.Text)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void btnSatis_Click(object sender, EventArgs e)
        {
            XDocument xDosya = XDocument.Load(@"stokveri.xml");
            XElement element = xDosya.Element("Urunler").Elements("Urun").FirstOrDefault(x => x.Element("UrunAdı").Value == cbUrunSatis.Text);
            int j,kalan;
            string temp;
            for (j = 0; j < dataGridView1.Rows.Count; j++)
            {
                if(dataGridView1.Rows[j].Cells[1].Value.ToString()!= cbUrunSatis.Text)
                {
                    continue;
                }
                temp = dataGridView1.Rows[j].Cells[2].Value.ToString();
                if (Convert.ToInt32(temp) >= Convert.ToInt32(tbAdetSatis.Text))
                {

                    var result = MessageBox.Show(cbUrunSatis.Text + " ürününün " + tbAdetSatis.Text + " adetini " + tbFiyatSatis.Text +" TL fiyata satılacaktır. \n Onaylıyor musunuz ?","Satışı onaylıyor musunuz ?",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(result == DialogResult.Yes)
                    {
                        kalan = Convert.ToInt32(temp)-Convert.ToInt32(tbAdetSatis.Text);
                        element.SetElementValue("Adet", kalan);
                        MessageBox.Show("Satış işlemi gerçekleşti.\n Stokta Kalan :" + kalan,"İşlem Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        xDosya.Save(@"stokveri.xml");
                        RefreshPage();
                    }
                    else
                    {
                        MessageBox.Show("Satış işlemi iptal edildi.","İşlem başarısız",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                    break;
                }
                else
                {
                    MessageBox.Show("Stokta yeteri kadar "+ cbUrunSatis.Text + " ürünü bulunmamaktadır.");
                    break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            UrunEkle u1 = new UrunEkle(Convert.ToInt32(dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value) );
            u1.Show();
            this.Hide();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            XDocument xDosya = XDocument.Load(@"stokveri.xml");
            xDosya.Root.Elements().Where(a => a.Element("ID").Value == tbID.Text).Remove();
            xDosya.Save(@"stokveri.xml");
            firstwork = 0;
            RefreshPage();
        }

        private void btnDetay_Click(object sender, EventArgs e)
        {
            kumas k1 = new kumas();
            k1.Show();
            this.Hide();
        }

        private void cbUrunSatis_Click(object sender, EventArgs e)
        {
            RefreshPage();
        }

        private void cbUrunSatis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(b1 == 0)
            {
                butonactive++;
                b1++;
            }
            if (butonactive == 2)
                btnSatis.Enabled = true;
            int x = dataGridView1.Rows.Count;
            int i = 0;
            for(i = 0;i< x;i++) 
            { 
                if(cbUrunSatis.Text == dataGridView1.Rows[i].Cells[1].Value.ToString()) 
                {
                    tbMetreFiyatSatis.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
                    break;
                }
            }
            tbAdetSatis.Text = "";
            tbFiyatSatis.Text = "";
        }
    }
}
