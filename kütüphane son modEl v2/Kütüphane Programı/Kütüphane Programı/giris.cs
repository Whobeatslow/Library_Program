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
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\User1\\Desktop\\kutuphane1.mdb");

        OleDbCommand komut = new OleDbCommand();
        OleDbDataAdapter adtr = new OleDbDataAdapter();
        DataSet ds = new DataSet();
        OleDbDataReader rd;
        

        private void button1_Click(object sender, EventArgs e)
        {
            
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "select * from KullaniciSifre";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                if (textBox1.Text == rd["KullaniciAd"].ToString() && textBox2.Text == rd["Sifre"].ToString())
                {

                    Form1 fnm = new Form1();
                    fnm.Show();
                    this.Visible = false;

                }
                else
                {
                    MessageBox.Show("Kullanıcı Adı Veya Şifre Yanlış");
                }

            }
            rd.Close();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && textBox4.Text != "")
            {
                OleDbCommand cmd = new OleDbCommand();
                con.Open();
                cmd.CommandText = "select * from KullaniciSifre";
                cmd.Connection = con;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    if (textBox2.Text == rd["Sifre"].ToString())
                    {
                        if (textBox3.Text == textBox4.Text)
                        {


                            if (textBox3.Text != rd["Sifre"].ToString() || textBox4.Text != rd["Sifre"].ToString())
                            {
                                cmd = new OleDbCommand();

                                cmd.Connection = con;
                                cmd.CommandText = "update KullaniciSifre set Sifre = '" + textBox3.Text + "' ";
                                cmd.ExecuteNonQuery();
                                DialogResult ok = MessageBox.Show("Başarılı Bir Şekilde Şifreniz Değiştirilmiştir Giriş Menüsüne Aktarılıyorsunuz !", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                if (ok == DialogResult.OK)
                                {
                                    Form1 fnm = new Form1();
                                    fnm.Show();
                                    this.Hide();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Yeni Şifre İle Eski Şifre Birbirinin Aynısı !!!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Girmiş Oldugunuz Yeni Şifreler BİRBİRİYLE UYUŞMUYOR");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Girmiş Oldugunuz Şifre Kayıtlı Değil");
                    }
                }
                con.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
