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
    public partial class kitapekle : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
            OleDbDataAdapter da;
            OleDbCommand cmd;
            DataSet ds;
        OleDbDataReader rd;
    
        public kitapekle()
        {
            
            InitializeComponent();
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
                if (textBox1.Text == rd[1].ToString()&&textBox2.Text == rd[2].ToString())
                {
                    MessageBox.Show("kitap zaten ekli stok sayısı arttırılıyor");
                   cmd = new OleDbCommand("Update kitapEkle set kitapStokSayisi=kitapStokSayisi+"+ textBox8.Text +" where kitapAdi = '"+textBox1.Text+"' and kitapYazari = '"+textBox2.Text+"'" , con);
                   cmd.ExecuteNonQuery();
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
            cmd.CommandText=("Select * from kitapEkle");
            OleDbDataReader dr = cmd.ExecuteReader();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.BackColor = Color.Red;
            if (textBox2.Text == "") textBox2.BackColor = Color.Red;
            if (textBox4.Text == "") textBox4.BackColor = Color.Red;
            if (textBox5.Text == "") textBox5.BackColor = Color.Red;
            if (textBox6.Text == "") textBox6.BackColor = Color.Red;
            if (textBox7.Text == "") textBox7.BackColor = Color.Red;
            if (textBox8.Text == "") textBox8.BackColor = Color.Red;
            if (comboBox1.Text == "") comboBox1.BackColor = Color.Red;


            if (textBox1.Text != "" && textBox2.Text!=""&& comboBox1.Text!=""&& textBox4.Text!=""&& textBox5.Text!=""&& textBox6.Text!=""&& textBox7.Text!=""&&textBox8.Text!= "")
            {
                kitapkontrol();
                if (textBox1.Text!="")
                {
                con.Open();
                OleDbCommand cmd =new OleDbCommand ("insert into kitapEkle(kitapAdi,kitapYazari,kitapTuru,kitapSayfaSayisi,kitapYayinevi,kitapBasimYili,kitapBasimYeri,kitapStokSayisi,kitapOkunmaSayisi) values ('" + textBox1.Text + "' , '" + textBox2.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','"+textBox8.Text+"','0')",con);
                cmd.ExecuteNonQuery();
                con.Close();
                kayıtekle();
                }
                
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = "";
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
            }
            else if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "" || textBox5.Text == ""|| textBox6.Text ==""|| textBox7.Text=="")
            {
                MessageBox.Show("Boş Bırakmayınız!");
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != "") textBox6.BackColor = Color.White;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox1.SelectionStart;
                textBox1.Text = textBox1.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox1.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox2.SelectionStart;
                textBox2.Text = textBox2.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox2.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox5.SelectionStart;
                textBox5.Text = textBox5.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox5.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
                int satirbaslangic = textBox7.SelectionStart;
                textBox7.Text = textBox7.Text.Insert(satirbaslangic, e.KeyChar.ToString().ToUpper());
                textBox7.Select(satirbaslangic + 1, 0);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "") textBox1.BackColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "") textBox2.BackColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text != "") comboBox1.BackColor = Color.White;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.Text != "") textBox4.BackColor = Color.White;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (textBox5.Text != "") textBox5.BackColor = Color.White;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox7.Text != "") textBox7.BackColor = Color.White;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text != "") textBox8.BackColor = Color.White;
        }
    }
}
