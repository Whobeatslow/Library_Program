using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace Kütüphane_Programı
{
    public partial class topluekle : Form
    {
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\User1\\Desktop\\kutuphane1.mdb");
        OleDbDataAdapter da;
        OleDbCommand cmd;
        DataSet ds;
        OleDbDataReader rd;
        int sayı = 0;
        double toplam = 0;
        public topluekle()
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
            dataGridView1.DataSource = ds.Tables["ogrenciEkle"];
            con.Close();
        }
        public void kitapkontrol()
        {
            progressBar1.Value = 0;
            int a = (Convert.ToInt16(dataGridView1.RowCount.ToString()) - 1);
            progressBar1.Maximum = a;
            OleDbCommand cmd = new OleDbCommand();
            con.Open();
            cmd.CommandText = "Select * from kitapEkle";
            cmd.Connection = con;
            OleDbDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                sayı++;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        if (row.Cells[0].Value.ToString() == rd[1].ToString() && row.Cells[1].Value.ToString() == rd[2].ToString())
                        {
                            cmd = new OleDbCommand("Update kitapEkle set kitapStokSayisi=kitapStokSayisi+" + row.Cells[7].Value.ToString() + " where kitapAdi = '" + row.Cells[0].Value.ToString() + "' and kitapYazari = '" + row.Cells[1].Value.ToString() + "'", con);
                            cmd.ExecuteNonQuery();
                            
                                dataGridView1.Rows.RemoveAt(row.Index);
                                dataGridView1.Refresh();
                            if (Convert.ToInt16(dataGridView1.RowCount - 1)!=-1)
                            {
                                progressBar1.Step = 1;
                                progressBar1.PerformStep();
                                if (progressBar1.Value == a)
                                {
                                    MessageBox.Show("Toplu Ekleme Başarıyla Tamamlandı");
                                    
                                }
                            }
                            
                        }
                    }
                }
            }
            rd.Close();
            con.Close();
            grid1göster();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm = new Form1();
            frm.Show();

        }
        public void numarakontrol()
        {
            progressBar1.Value = 0;
            if (Convert.ToInt16(dataGridView1.RowCount - 1) != 0)
            {
                int a = (Convert.ToInt16(dataGridView1.RowCount.ToString()) - 1);
                progressBar1.Maximum = a;
                OleDbCommand cmd = new OleDbCommand();
                con.Open();
                cmd.CommandText = "Select * from ogrenciEkle";
                cmd.Connection = con;
                OleDbDataReader rd = cmd.ExecuteReader();
                while (rd.Read())
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            if (row.Cells[0].Value.ToString() == rd["ogrenciNumara"].ToString())
                            {
                                dataGridView1.Rows.RemoveAt(row.Index);
                                dataGridView1.Refresh();
                                progressBar1.Step = 1;
                                progressBar1.PerformStep();
                                if (progressBar1.Value == a)
                                {
                                    MessageBox.Show("Toplu Ekleme Başarıyla Tamamlandı");
                                    
                                }

                            }
                        }
                    }
                }
                rd.Close();
                con.Close();
                grid2göster();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";
                openFileDialog1.FilterIndex = 3;

                openFileDialog1.Multiselect = false; 
                openFileDialog1.Title = "Excel Dosyası Seçiniz";  
                openFileDialog1.InitialDirectory = @"Desktop";

                if (openFileDialog1.ShowDialog() == DialogResult.OK) 
                {
                    string pathName = openFileDialog1.FileName;
                    
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;
                    switch (extension)
                    {
                        case ".xls":
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                        case ".xlsx":
                            strConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + pathName + ";Extended Properties='Excel 12.0;HDR=Yes;IMEX=1;'";
                            break;
                        default:
                            strConn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1;'";
                            break;
                    }
                    
                OleDbConnection cnnxls = new OleDbConnection(strConn);
                    cnnxls.Open();
                    string tableSheetName = (string)cnnxls.GetSchema("tables", new string[] { null, null, null, "TABLE" }).Rows[0]["TABLE_NAME"];
                    cnnxls.Close();
                    string sheetName = tableSheetName;
                    OleDbDataAdapter oda = new OleDbDataAdapter(string.Format("select * from [{0}]", sheetName), cnnxls);
                    oda.Fill(tbContainer);

                    dataGridView1.DataSource = tbContainer;
                }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(dataGridView1.RowCount - 1) != 0)
            {
                progressBar1.Value = 0;
                int a = (Convert.ToInt16(dataGridView1.RowCount.ToString()) - 1);
                progressBar1.Maximum = a;
                kitapkontrol();


                if (Convert.ToInt16(dataGridView1.RowCount - 1) <= 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd = new OleDbCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "insert into kitapEkle(kitapAdi,kitapYazari,kitapTuru,kitapSayfaSayisi,kitapYayinevi,kitapBasimYili,kitapBasimYeri,kitapStokSayisi,kitapOkunmaSayisi) values ('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','" + row.Cells[5].Value.ToString() + "','" + row.Cells[6].Value.ToString() + "','" + row.Cells[7].Value.ToString() + "','0')";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            if (Convert.ToInt16(dataGridView1.RowCount - 1) != 0)
                            {
                                progressBar1.Step = 1;
                                progressBar1.PerformStep();

                                if (progressBar1.Value == a)
                                {
                                    MessageBox.Show("Toplu Ekleme Başarıyla Tamamlandı");

                                }
                            }

                        }
                    }
                }
                grid1göster();
            }
        }

        private void topluekle_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt16(dataGridView1.RowCount - 1) != 0)
            {
                numarakontrol();
                progressBar1.Value = 0;
                int a = (Convert.ToInt16(dataGridView1.RowCount.ToString()) - 1);
                progressBar1.Maximum = a;


                if (Convert.ToInt16(dataGridView1.RowCount - 1) <= 0)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd = new OleDbCommand();
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandText = "insert into ogrenciEkle(ogrenciNumara,ogrenciSinif,ogrenciAd,ogrenciSoyad,ogrenciBolum,ogrenciOkunanKitap) values ('" + row.Cells[0].Value.ToString() + "','" + row.Cells[1].Value.ToString() + "','" + row.Cells[2].Value.ToString() + "','" + row.Cells[3].Value.ToString() + "','" + row.Cells[4].Value.ToString() + "','0')";
                            cmd.ExecuteNonQuery();
                            con.Close();
                            if (Convert.ToInt16(dataGridView1.RowCount - 1) != 0)
                            {
                                progressBar1.Step = 1;
                                progressBar1.PerformStep();
                                if (progressBar1.Value == a)
                                {
                                    MessageBox.Show("Toplu Ekleme Başarıyla Tamamlandı");
                                }
                            }

                        }
                    }
                }
                grid2göster();
            }
        }
    }
}
