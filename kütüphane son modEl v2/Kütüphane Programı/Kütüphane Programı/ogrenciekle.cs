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
    public partial class ogrenciekle : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        OleDbDataReader rd;
        public ogrenciekle()
        {
            InitializeComponent();
        }
        public void numarakontrol()
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
                    MessageBox.Show("Girdiginiz Numarada Bir Öğrenci Kaydı Bulunmakta Lütfen Numarayı Kontrol Edip Tekrar Giriniz");
                    textBox1.Text = "";

                }
            }
            rd.Close();
            con.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 anaekran = new Form1();
            anaekran.Show();
        }
        void kayıtekle()
        {
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select * from ogrenciEkle");
            OleDbDataReader dr = cmd.ExecuteReader();
            con.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.BackColor = Color.Red;
            if (textBox2.Text == "") textBox2.BackColor = Color.Red;
            if (textBox3.Text == "") textBox3.BackColor = Color.Red;
            if (comboBox2.Text == "") comboBox2.BackColor = Color.Red;
            if (comboBox1.Text == "") comboBox1.BackColor = Color.Red;



            if (textBox1.Text == "" || textBox3.Text == "" ||textBox2.Text == "" || comboBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Boş Bırakmayınız");
            }

            numarakontrol();



            if (textBox1.Text == "" || textBox3.Text == "" || textBox2.Text == "" || comboBox2.Text == "" || comboBox1.Text == "")
            {

            }
            else
            {
                DialogResult yesno = MessageBox.Show("Girmiş Oldugunuz Bilgileri Kaydetmek İstediginize Eminmisiniz", "", MessageBoxButtons.YesNo);
                if (yesno == DialogResult.Yes)
                {



                    if (textBox1.Text != "" || textBox3.Text != "" || textBox2.Text == "" || comboBox2.Text == "" || comboBox1.Text == "")
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "insert into ogrenciEkle (ogrenciNumara,ogrenciSinif,ogrenciAd,ogrenciSoyad,ogrenciBolum,ogrenciOkunanKitap) values ('" + textBox1.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + comboBox2.Text + "','0')";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        textBox1.Text = "";
                        textBox3.Text = "";
                        textBox2.Text = "";
                        comboBox1.Text = "";
                        comboBox2.Text = "";
                        MessageBox.Show("Öğrenci Kaydı Başarılı Bir Şekilde Tamamlanmıstır", "Kayıt Başarılı", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    DialogResult yesno1 = MessageBox.Show("Ana Menüye Geri Dönmek İstermisiniz", "", MessageBoxButtons.YesNo);
                    if (yesno1 == DialogResult.Yes)
                    {
                        Form1 fnm = new Form1();
                        fnm.Show();
                        this.Hide();

                    }




                }
            }
            
            }
        

 

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar)&& !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox2.SelectionStart;
                textBox2.Text = textBox2.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox2.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox3.SelectionStart;
                textBox3.Text = textBox3.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox3.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") textBox1.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "") textBox2.BackColor = Color.White;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox3.Text != "") textBox3.BackColor = Color.White;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text != "") comboBox2.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "") comboBox1.BackColor = Color.White;
        }
    }
}
