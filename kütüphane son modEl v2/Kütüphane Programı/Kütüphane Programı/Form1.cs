using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Kütüphane_Programı
{
    public partial class Form1 : Form
    {
        int rgb = 30;
        int sayac = 0;
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        private bool mouseDown;
        private Point lastLocation;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
        public Form1()
        {
            InitializeComponent();
        }
        void grid2() 
        {
            da = new OleDbDataAdapter("Select * from alinanKitap where alistarihi+15<=Date()", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "alinanKitap");
            dataGridView2.DataSource = ds.Tables["alinanKitap"];
            con.Close();
            if (dataGridView2.RowCount - 1 > 0 )
            {
                label6.Text = "Getirilme Süresi Geçmiş Kitaplar Var : " + (Convert.ToInt16(dataGridView2.RowCount - 1).ToString());
                label6.Show();
            }
            else
            {
                label6.Visible = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            kitapekle frm = new kitapekle();
            frm.Show(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ogrenciekle frm2 = new ogrenciekle();
            frm2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            kitapal frm3 = new kitapal();
            frm3.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            kitapver frm4 = new kitapver();
            frm4.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
            if (comboBox1.Text == "Kitap")
            {
                if (textBox1.Text == "")
                {
                    da = new OleDbDataAdapter("Select kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı' from kitapEkle", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı' from kitapEkle");
                    da.Fill(ds, "kitapEkle");
                    dataGridView1.DataSource = ds.Tables["kitapEkle"];
                    con.Close();
                }
                else
                {
                    da = new OleDbDataAdapter("Select kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı' from kitapEkle where kitapAdi like '%" + textBox1.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı' from kitapEkle where kitapAdi like '%" + textBox1.Text + "%'");
                    da.Fill(ds, "kitapEkle");
                    dataGridView1.DataSource = ds.Tables["kitapEkle"];
                    con.Close();

                }


            }
            else if (comboBox1.Text == "Öğrenci")
            {
                if (textBox1.Text != "")
                {
                    da = new OleDbDataAdapter("Select ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle where ogrenciAd like '%" + textBox1.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle where ogrenciAd like '%" + textBox1.Text + "%'");
                    da.Fill(ds, "ogrenciEkle");
                    dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                    con.Close();
                }
                else
                {
                    da = new OleDbDataAdapter("Select ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle");
                    da.Fill(ds, "ogrenciEkle");
                    dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                    con.Close();
                }
            }
            else if (comboBox1.Text == "Yazar")
            {
                if (textBox1.Text != "")
                {
                    da = new OleDbDataAdapter("Select distinct(kitapYazari) AS 'Kitap Yazarları' from kitapEkle where kitapYazari like '%" + textBox1.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select distinct(kitapYazari) AS 'Kitap Yazarları' from kitapEkle where kitapYazari like '%" + textBox1.Text + "%'");
                    da.Fill(ds, "kitapEkle");
                    dataGridView1.DataSource = ds.Tables["kitapEkle"];
                    con.Close();
                }
                else
                {
                    da = new OleDbDataAdapter("Select distinct(kitapYazari) AS 'Kitap Yazarları' from kitapEkle ", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select distinct(kitapYazari) AS 'Kitap Yazarları' from kitapEkle");
                    da.Fill(ds, "kitapEkle");
                    dataGridView1.DataSource = ds.Tables["kitapEkle"];
                    con.Close();
                }
            }
            else if (comboBox1.Text == "Verilen Kitap")
            {
                if (textBox1.Text == "")
                {
                    da = new OleDbDataAdapter("Select ogrenciNumarasi as 'Öğrenci Numarası',ogrenciSinif as 'Öğrencinin Sınıfı',alinanKitapAdi as 'Aldığı Kitap Adı',alisTarihi as 'Aldığı Tarih', ogrenciBolum as 'Öğrencinin Bölümü' from alinanKitap", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select ogrenciNumarasi as 'Öğrenci Numarası',ogrenciSinif as 'Öğrencinin Sınıfı',alinanKitapAdi as 'Aldığı Kitap Adı',alisTarihi as 'Aldığı Tarih', ogrenciBolum as 'Öğrencinin Bölümü' from alinanKitap");
                    da.Fill(ds, "alinanKitap");
                    dataGridView1.DataSource = ds.Tables["alinanKitap"];
                    con.Close();
                }
                else
                {
                    
                    da = new OleDbDataAdapter("Select ogrenciNumarasi as 'Öğrenci Numarası',ogrenciSinif as 'Öğrencinin Sınıfı',alinanKitapAdi as 'Aldığı Kitap Adı',alisTarihi as 'Aldığı Tarih', ogrenciBolum as 'Öğrencinin Bölümü' from alinanKitap where alinanKitapAdi like '%" + textBox1.Text + "'", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select ogrenciNumarasi as 'Öğrenci Numarası',ogrenciSinif as 'Öğrencinin Sınıfı',alinanKitapAdi as 'Aldığı Kitap Adı',alisTarihi as 'Aldığı Tarih', ogrenciBolum as 'Öğrencinin Bölümü' from alinanKitap where alinanKitapAdi like '%" + textBox1.Text + " '");
                    da.Fill(ds, "alinanKitap");
                    dataGridView1.DataSource = ds.Tables["alinanKitap"];
                    con.Close();

                }
            }
            else if (comboBox1.Text == "En Çok Kitap Okuyan Öğrenciler")
            {
                if (textBox1.Text == "")
                {
                    da = new OleDbDataAdapter("Select top 10 ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle order by ogrenciOkunanKitap desc", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select top 10 ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle order by ogrenciOkunanKitap desc");
                    da.Fill(ds, "ogrenciEkle");
                    dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                    con.Close();
                }
                else
                {
                    da = new OleDbDataAdapter("Select top 10 ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle where ogrenciAd like '%" + textBox1.Text + "%'", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select top 10 ogrenciNumara AS 'Öğrenci Numarası',ogrenciSinif AS 'Öğrenci Sınıfı',ogrenciAd AS 'Öğrenci Adı',ogrenciSoyad AS 'Öğrenci Soyadı',ogrenciBolum AS 'Öğrenci Bölümü',ogrenciOkunanKitap AS 'Okuduğu Kitap Sayısı' from ogrenciEkle where ogrenciAd like '%" + textBox1.Text + " %'");
                    da.Fill(ds, "ogrenciEkle");
                    dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                    con.Close();

                }
                
                


            }
            else if (comboBox1.Text == "En Çok Okunan Kitaplar")
            {
                if (textBox1.Text == "")
                {
                    da = new OleDbDataAdapter("Select top 10 kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı' from kitapEkle order by kitapOkunmaSayisi desc", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select top 10 kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı'from kitapEkle order by kitapOkunmaSayisi desc");
                    da.Fill(ds, "kitapEkle");
                    dataGridView1.DataSource = ds.Tables["kitapEkle"];
                    con.Close();
                }
                else
                {
                    da = new OleDbDataAdapter("Select top 10 kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı'from kitapEkle where kitapAdi like '%" + textBox1.Text + "%' order by kitapOkunmaSayisi desc ", con);
                    ds = new DataSet();
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    cmd.CommandText = ("Select top 10 kitapAdi as 'Kitap Adı',kitapYazari as 'Kitap Yazarı' ,kitapTuru as 'Kitap Türü',kitapYayinevi as 'Kitap Yayınevi',kitapBasimYili as 'Kitabın Basım Yılı',kitapStokSayisi as 'Stok Sayısı',kitapOkunmaSayisi as 'Okunma Sayısı' from kitapEkle where kitapAdi like '%" + textBox1.Text + "%' order by kitapOkunmaSayisi desc");
                    da.Fill(ds, "kitapEkle");
                    dataGridView1.DataSource = ds.Tables["kitapEkle"];
                    con.Close();

                }                
            }
            else if (comboBox1.Text == "Kitapları Getirmekte Geç Kalanlar")
            {
                if (textBox1.Text == "")
                {
                    da = new OleDbDataAdapter("Select ogrenciNumarasi as 'Öğrenci Numarası',ogrenciSinif as 'Öğrencinin Sınıfı',alinanKitapAdi as 'Aldığı Kitap Adı',alisTarihi as 'Aldığı Tarih', ogrenciBolum as 'Öğrencinin Bölümü' from alinanKitap where alistarihi+15<=Date()", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "alinanKitap");
                    dataGridView1.DataSource = ds.Tables["alinanKitap"];
                    con.Close();
                }
                else
                {
                    da = new OleDbDataAdapter("Select ogrenciNumarasi as 'Öğrenci Numarası',ogrenciSinif as 'Öğrencinin Sınıfı',alinanKitapAdi as 'Aldığı Kitap Adı',alisTarihi as 'Aldığı Tarih', ogrenciBolum as 'Öğrencinin Bölümü' from alinanKitap where alisTarihi+" + textBox1.Text+"<=Date()", con);
                    ds = new DataSet();
                    con.Open();
                    da.Fill(ds, "alinanKitap");
                    dataGridView1.DataSource = ds.Tables["alinanKitap"];
                    con.Close();

                }

                
            }
            label2.Text = "Listelenen Kayıt Sayısı : " + (Convert.ToInt16(dataGridView1.RowCount - 1).ToString()); 
        }

        
        private void button6_Click(object sender, EventArgs e)
        {
            güncellesil güncel = new güncellesil();
            this.Hide();
            güncel.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            label6.Hide();
            grid2();
            timer1.Interval = 2000;
            timer1.Start();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);
                this.Update();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            topluekle yeni = new topluekle();
            yeni.Show();

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rgb--;
            if (rgb >=0)
            {
                if (rgb %2 == 0)
                {
                    label6.ForeColor = Color.Red;
                }
                else if (rgb % 2 == 1)
                {
                    label6.ForeColor = Color.White;
                }
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
