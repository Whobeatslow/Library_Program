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
    public partial class kitapal : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        OleDbDataReader rd;
        int k = 0;
        public kitapal()
        {
            InitializeComponent();
        }
        public void kontrol() 
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from alinanKitap";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (textBox1.Text == rd["ogrenciNumarasi"].ToString() && rd["alinanKitapAdi"].ToString() ==comboBox1.Text)
                {
                    textBox2.Text = rd["alinanKitapID"].ToString();
                    k = 1;
                }
            }
            rd.Close();
            con.Close();
        }
        public void kitapteslim()
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update kitapEkle set kitapStokSayisi=kitapStokSayisi +1  where kitapAdi = '" + comboBox1.Text + "'and kayıt_ID =" +textBox2.Text+"";
            cmd.ExecuteNonQuery();
            MessageBox.Show("stoğa ekleniyor");
            con.Close();
        }
        public void kitapokuma()
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update kitapEkle set kitapOkunmaSayisi=kitapOkunmaSayisi +1  where kitapAdi = '" + comboBox1.Text + "' and kayıt_ID =" + textBox2.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ogrkitap()
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from ogrenciEkle,alinanKitap";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();

            while (rd.Read())
            {
                if (rd["ogrenciOkunanKitap"] == null)
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.CommandText = "Update ogrenciEkle set ogrenciOkunanKitap = 0  where alinanKitap.ogrenciNumarasi = " + textBox1.Text + " and (alinanKitap.alinanKitapAdi = kitapAdi) = '" + comboBox1.Text + "'and kayıt_ID =" + textBox2.Text + "";
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            rd.Close();
            con.Close();
        }
        public void okunankitaps() 
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = "Update ogrenciEkle set ogrenciOkunanKitap = ogrenciOkunanKitap +1  where ogrenciNumara = " + textBox1.Text + "";
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 anaekran = new Form1();
            anaekran.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.BackColor = Color.Red;
            if (textBox4.Text == "") textBox4.BackColor = Color.Red;
            if (textBox3.Text == "") textBox3.BackColor = Color.Red;
            if (comboBox1.Text == "") comboBox1.BackColor = Color.Red;
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                kontrol();
                if (k==0)
                {
                    MessageBox.Show("girdiğiniz kitap alınan kitaplarda yok", "Hata!");
                }
                else if (k ==1)
                {
                kitapokuma();
                ogrkitap();
                okunankitaps();
                kitapteslim();
                cmd = new OleDbCommand();
                con.Open();
                cmd.Connection = con;
                cmd.CommandText= "DELETE from alinanKitap where ogrenciNumarasi =" + textBox1.Text + " and alinanKitapAdi ='"+comboBox1.Text+ "'and alinanKitapID =" + textBox2.Text + "";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Başarıyla Kaydedildi");
                }
                
                
                
            }
            else if (textBox1.Text == "" || comboBox1.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Boş Bırakmayınız");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from alinanKitap";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (textBox1.Text == rd[1].ToString())
                {
                    comboBox1.Items.Add(rd["alinanKitapAdi"].ToString());
                    textBox3.Text = rd["alisTarihi"].ToString();
                    DateTime tarih = DateTime.Today;   
                    textBox4.Text = tarih.ToShortDateString();
                    textBox4.Enabled = false;
                }
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Yazdığınız Öğrenci Numarası Hakkında Bilgi Bulunamadı");
            }

            rd.Close();
            con.Close();
        }

        private void kitapal_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
         
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") textBox1.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "") comboBox1.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "") textBox3.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "") textBox4.BackColor = Color.White;
        }
    }
}
