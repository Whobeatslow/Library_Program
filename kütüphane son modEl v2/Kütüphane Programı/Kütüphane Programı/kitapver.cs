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
    public partial class kitapver : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        OleDbDataReader rd;
        int c = 0;
        int d = 1;
        int k = 1;
        public kitapver()
        {
            InitializeComponent();
        }
        public void kitapeksilt()
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from kitapEkle";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (rd["kitapAdi"].ToString()== textBox4.Text&&rd["kitapStokSayisi"].ToString()!="0")
                {
                    MessageBox.Show("stoktan eksiltiliyor");
                    cmd = new OleDbCommand("Update kitapEkle set kitapStokSayisi=kitapStokSayisi - 1  where kitapAdi = '" + textBox4.Text + "'", con);
                    cmd.ExecuteNonQuery();
                }
                
            }
            rd.Close();
            con.Close();   
        }
        public void kitapnumara() 
        {
             OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from alinanKitap";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            k = 0;
                while (rd.Read())
                {
                    if (rd["ogrenciNumarasi"].ToString() == textBox1.Text)
                    {

                        k = 1;
                        c = 1;
                    }
                    else
                    {
                        k = 0;
                        c = 1;
                    }
                }
            
            rd.Close();
            con.Close();       
        }
        public void kitapkontrol()
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from kitapEkle";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            
            while (rd.Read())
            {
                if (textBox4.Text == rd["kitapAdi"].ToString() && Convert.ToInt16(rd["kitapStokSayisi"].ToString()) != 0)
                {
                    textBox2.Text = rd["kayıt_ID"].ToString();
                    cmd = new OleDbCommand("insert into alinanKitap (ogrenciNumarasi,ogrenciSinif,alinanKitapAdi,alisTarihi,ogrenciBolum,alinanKitapID) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + comboBox2.Text + "',"+textBox2.Text+")", con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla Kaydedildi");
                    c++;
                }
                else if (textBox4.Text == rd["kitapAdi"].ToString() && Convert.ToInt16(rd["kitapStokSayisi"].ToString()) == 0)
                {
                    d = 0;
                    c++;
                }
            }
            rd.Close();
            con.Close();
            kitapeksilt();
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
            if (textBox5.Text == "") textBox5.BackColor = Color.Red;
            if (comboBox2.Text == "") comboBox2.BackColor = Color.Red;
            if (comboBox1.Text == "") comboBox1.BackColor = Color.Red;
            if (textBox1.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                kitapnumara();
                if (k == 0)
                {
                    kitapkontrol();
                }
                else if (k == 1)
                {
                    MessageBox.Show("Bu Numaralı Öğrenci Zaten Kitap Almış!");
                }
                if (d==0)
                {
                    MessageBox.Show("kitap stokta bulunmuyor");
                }
                if (c == 0)
                {
                    MessageBox.Show("Böyle bir kitap bulunmuyor");
                }

                if (textBox1.Text=="")
                {
                    MessageBox.Show("Kitap Stokta Yok");
                }
                    
                
            }
            else if (textBox1.Text == "" || comboBox1.Text == "" || comboBox2.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Boş Bırakmayınız");
                
            }
        }

        private void kitapver_Load(object sender, EventArgs e)
        {
           
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from ogrenciEkle";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (textBox1.Text == rd[1].ToString())
                {
                    comboBox2.Text = rd["ogrenciBolum"].ToString();
                    comboBox1.Text = rd["ogrenciSinif"].ToString();
                    DateTime tarih = DateTime.Today;
                    textBox5.Text = tarih.ToShortDateString();
                    textBox5.Enabled = false;
                }
            }
            if (textBox5.Text=="")
            {
                    MessageBox.Show("Yazdığınız Öğrenci Numarası Hakkında Bilgi Bulunamadı");
            }

            rd.Close();
            con.Close();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox4.SelectionStart;
                textBox4.Text = textBox4.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox4.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") textBox1.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "") textBox4.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "") textBox5.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "") comboBox1.BackColor = Color.White;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "") comboBox2.BackColor = Color.White;
        }
    }
}
