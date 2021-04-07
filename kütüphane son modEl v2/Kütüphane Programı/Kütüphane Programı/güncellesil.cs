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
    public partial class güncellesil : Form
    {
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source =C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
        bool değiştirkilit = false;
        int k = 0;

        public güncellesil()
        {
            InitializeComponent();
        }
        void grid1göster()
        {
            da = new OleDbDataAdapter("Select * from kitapEkle", con);
            ds = new DataSet();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select * from kitapEkle");
            da.Fill(ds, "kitapEkle");
            dataGridView1.DataSource = ds.Tables["kitapEkle"];
            con.Close();

        }
        void grid2göster()
        {
            da = new OleDbDataAdapter("Select * from ogrenciEkle", con);
            ds = new DataSet();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select * from ogrenciEkle");
            da.Fill(ds, "ogrenciEkle");
            dataGridView2.DataSource = ds.Tables["ogrenciEkle"];
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
                if (rd["alinanKitapID"].ToString() == textBox9.Text)
                {
                    k = 1;
                    
                }
                else
                {
                   
                }
            }

            rd.Close();
            con.Close();
        }
        public void ogrnumara()
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

                }
                else
                {

                }
            }

            rd.Close();
            con.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            panel2.BackColor = Color.Teal;
            panel1.BackColor = Color.IndianRed;
            label1.Text = "Kitap Adı :";
            label2.Text = "Kitap Yazarı :";
            label3.Text = "Kitap Türü :";
            label4.Text = "Kitap Sayfa Sayısı :";
            label5.Text = "Yayınevi :";
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            textBox6.Visible = true;
            textBox7.Visible = true;
            textBox8.Visible = true;
            if (radioButton1.Checked == true)
            {
                dataGridView1.Show();
                dataGridView2.Hide();
            da = new OleDbDataAdapter("Select * from kitapEkle", con);
            ds = new DataSet();
            con.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = con;
            cmd.CommandText = ("Select * from kitapEkle");
            da.Fill(ds, "kitapEkle");
            dataGridView1.DataSource = ds.Tables["kitapEkle"];
            con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Teal;
            panel2.BackColor = Color.IndianRed;
            label1.Text = "Numara :";
            label2.Text = "Öğrenci Adı:";  
            label3.Text = "Soyad :";
            label4.Text = "Öğrenci Bölüm:";
            label5.Text = "Sınıf :";
            label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox6.Visible = false;
            textBox7.Visible = false;
            textBox8.Visible = false;
            

            if (radioButton2.Checked == true)
            {
                dataGridView1.Hide();
                dataGridView2.Show();
                da = new OleDbDataAdapter("Select * from ogrenciEkle", con);
                ds = new DataSet();
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = con;
                cmd.CommandText = ("Select * from ogrenciEkle");
                da.Fill(ds, "ogrenciEkle");
                dataGridView2.DataSource = ds.Tables["ogrenciEkle"];
                con.Close();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
        }

        private void güncellesil_Load(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapAdi like '%" + textBox1.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciNumara like '" + textBox1.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapYazari like '" + textBox2.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciAd like '" + textBox2.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapTuru like '" + textBox3.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciSoyad like '" + textBox3.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapSayfaSayisi like '" + textBox4.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciSoyad like '" + textBox4.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapYayinevi like '" + textBox5.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciBolum like '" + textBox5.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapBasimYili like '" + textBox6.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciSoyad like '" + textBox6.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

        }
        

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {

                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapBasimYeri like '" + textBox7.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciSoyad like '" + textBox8.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (!değiştirkilit)
            {
                if (radioButton1.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from kitapEkle where kitapStokSayisi like '" + textBox8.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "kitapEkle");
                        dataGridView1.DataSource = ds.Tables["kitapEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
                else if (radioButton2.Checked == true)
                {
                    try
                    {
                        OleDbDataAdapter da = new OleDbDataAdapter("select * from ogrenciEkle where ogrenciSoyad like '" + textBox8.Text + "%'", con);
                        DataSet ds = new DataSet();
                        con.Open();
                        da.Fill(ds, "ogrenciEkle");
                        dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
                        con.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
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
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox9.Text != "")
                {
                    k = 0;
                    kitapnumara();
                    if (k != 1)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "update kitapEkle set kitapAdi='" + textBox1.Text + "',kitapYazari='" + textBox2.Text + "', kitapTuru='" + textBox3.Text + "',kitapSayfaSayisi='" + textBox4.Text + "',kitapYayinevi='" + textBox5.Text + "',kitapBasimYili='" + textBox6.Text + "',kitapBasimYeri='" + textBox7.Text + "',kitapStokSayisi='" + textBox8.Text + "' where kayıt_ID=" + Convert.ToInt32(textBox9.Text) + " ";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        grid1göster();
                    }
                    else if (k == 1)
                    {
                        MessageBox.Show("Güncellemek İstediğiniz Kitap Bir Öğrencide Var");
                    }
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Lütfen Tablodan Güncelleyeceğiniz Satırı Seçiniz");
                }
            }
            else if (radioButton2.Checked == true)
            {
                if (textBox1.Text!= textBox10.Text)
                {
                    numarakontrol();
                }
                
                if (textBox1.Text != "")
                {
                    if (textBox9.Text != "")
                    {
                        k = 0;
                        ogrnumara();
                        if (k != 1)
                        {
                            cmd = new OleDbCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "update ogrenciEkle set ogrenciNumara='" + textBox1.Text + "',ogrenciAd='" + textBox2.Text + "', ogrenciSoyad='" + textBox3.Text + "',ogrenciBolum='" + textBox4.Text + "',ogrenciSinif='" + textBox5.Text + "' where ogrenci_ID = " + textBox9.Text + " ";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            grid2göster();
                        }
                        else if (k == 1)
                        {
                            MessageBox.Show("Güncellemek İstediğiniz Öğrencide Bir Kitap Var");
                        }
                    }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Lütfen Tablodan Güncelleyeceğiniz Satırı Seçiniz");
                }

                }
                
            }

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            değiştirkilit = true;
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            textBox8.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            textBox9.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            değiştirkilit = false;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            değiştirkilit = true;
            textBox1.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView2.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView2.CurrentRow.Cells[5].Value.ToString();
            textBox5.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            textBox9.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();

            textBox10.Text = textBox1.Text;
            değiştirkilit = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (textBox9.Text != "")
                {
                    k = 0;
                    kitapnumara();
                    if (k != 1)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE FROM kitapEkle where kayıt_ID=" + Convert.ToInt32(textBox9.Text) + " ";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        grid1göster();
                    }
                    else if(k==1)
                    {
                        MessageBox.Show("Silmek İstediğiniz Kitap Bir Öğrencide Var Silemezsiniz");
                    }

                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Silinecek Birşey Seçmediniz");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();


            }
            else if (radioButton2.Checked == true)
            {
                if (textBox9.Text != "")
                {
                    k = 0;
                    ogrnumara();
                    if (k != 1)
                    {
                        cmd = new OleDbCommand();
                        con.Open();
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE FROM ogrenciEkle where ogrenci_ID=" + Convert.ToInt32(textBox9.Text) + " ";
                        cmd.ExecuteNonQuery();
                        con.Close();
                        grid2göster();
                    }
                    else if (k == 1)
                    {
                        MessageBox.Show("Silmek İstediğiniz Öğrencide Bir Kitap Var Silemezsiniz");
                    }
                }
                else if (textBox9.Text == "")
                {
                    MessageBox.Show("Silinecek Birşey Seçmediniz");
                }
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
            }
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            
        }
    }
}
