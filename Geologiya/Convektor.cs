using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace Geologiya
{
    public partial class Convektor : Form
    {
        private string puti;
        private string puti1 = Util.GetConnectionString();
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        private string www, sep;
        
        public string[] www1;
        public string[] www2;
        public string[] www3;
        public string[] www4;
        public string[] www5;
        public string[] www6;
        public string[] www7;

        public string x1 = "";
        public string x2 = "";
        public string x3 = "";
        public string x4 = "";
        public string x5 = "";
        public string x6 = "";
        public string x7 = "";
        public string x8 = "";
        public string x9 = "";
        public string x10 = "";
        public string x11 = "";
        public string x12 = "";
        public string x13 = "";
        public string x14 = "";

        string refetat = "Реферат :";
        string images = "Иллюстрации : ";
        string organization = "Организация-разработчик : ";
        string listnumber = "стр.";
        string place = "Место хранения :";
        string y6 = "  ";
        string y7 = ".";
        string y8 = " ";

        public int x = 3, xx = 1,x777=0;
        private string nom = "";
        ArrayList Zapis1 = new ArrayList();

        string[] stringSeparators = new string[] { "Рубрика : " };
        string[] stringSeparators1 = new string[] { "стр." };
        string[] stringSeparators2 = new string[] { "Реферат : " };
        string[] stringSeparators3 = new string[] { "Иллюстрации :" };
        string[] stringSeparators4 = new string[] { "Место хранения :" };
        string[] stringSeparators5 = new string[] { "Организация-разработчик :" };
        string[] stringSeparators6 = new string[] { "  " };
        string[] stringSeparators7 = new string[] { "Рубрика : " };
        string[] stringSeparators8 = new string[] { ". " };
        public Convektor()
        {
            InitializeComponent();
        }

        private void Convektor_Load(object sender, EventArgs e)
        {
            //dataGridView1.Columns.Add("Column1", "№ ошибочних данных");
            //dataGridView1.Width = 300;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader sr = new
                                       StreamReader(openFileDialog1.FileName);
                    puti = openFileDialog1.FileName;
                    MessageBox.Show(puti); //sr.ReadToEnd()
                    //chs.iso = puti;
                    sr.Close();
                    //chs.redeiso();
                    FileStream FS = new FileStream(puti, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    StreamReader SR = new StreamReader(FS, System.Text.Encoding.GetEncoding(1251));
                    www = SR.ReadToEnd();//Запись всего файла
                    //sep = www.Replace(@"  ", "##");
                    SR.Close();

                    //textBox1.Text = www;
                    www1 = www.Split(stringSeparators, StringSplitOptions.None);
                    //x = Nd.StopStroka(www);
                    //textBox1.Text = www1[0];
                    //Расфасовка по столбцам
                    nom = www1[0].Trim();
                    for (int i = 1; i < www1.Length; i++)
                    {
                        try
                        {
                            string yy = www1[i];
                            www2 = yy.Split(stringSeparators6, StringSplitOptions.None);
                            if (www2[0].Length > 4)
                            {
                                x1 = www2[0].Substring(0, 2);
                                if (www2[0].Length > 8)
                                    x2 = www2[0].Substring(4, 6);
                                else
                                {
                                    x2 = www2[0].Substring(4, 2);
                                }
                            }
                            else
                            {
                                x1 = www2[0];
                            }
                            //int eeeee = www2[1].IndexOf(y7);
                            //int eeee = www2[1].IndexOf(y8);
                            if (www2[1].IndexOf(y7) < 21 && www2[1].IndexOf(y8) > 0 && www2[1].IndexOf(y7) > 0)
                            {
                                x3 = www2[1].Trim();
                                x4 = www2[2].Trim();
                                xx = 3;
                            }
                            else
                            {
                                x3 = "";
                                x4 = www2[1].Trim();
                                xx = 2;
                            }

                            if (www2[xx].IndexOf(organization) > 0)
                            {
                                www3 = www2[xx].Split(stringSeparators5, StringSplitOptions.None);
                                x5 = www3[1].Trim();
                                xx = xx + 1;
                            }
                            for (int j = 2; j < 7; j++)
                            {
                                try
                                {
                                    int wwwwww = Convert.ToInt32(www2[j]);
                                    if (www2[j - 1].Length < 30)
                                    {
                                        x6 = www2[j - 1].Trim();
                                        xx = xx + 1;
                                    }
                                    x7 = www2[j].Trim();
                                    xx = xx + 1;
                                    //int wq= www2[j + 2].IndexOf(y4);
                                    if (www2[j + 1].Length < 13)
                                    {
                                        x8 = www2[j + 1].Substring(3, www2[j + 1].Length - 3);
                                        xx = xx + 1;
                                    }
                                    x = j;
                                    break;
                                }
                                catch (Exception)
                                {

                                }
                            }
                            for (int j = x; j < www2.Length; j++)
                            {
                                if (www2[j].IndexOf(images) > 0)
                                {
                                    x = j;
                                    www4 = www2[j].Split(stringSeparators3, StringSplitOptions.None);
                                    x9 = www4[1].Trim();
                                    xx = j + 1; break;
                                }
                            }
                            x = xx;
                            if (www2[xx].IndexOf("тр. ") > 0 || www2[xx].IndexOf(". ") > 0)
                            {
                                if (www2[xx].IndexOf(". ") > 0)
                                {
                                    www4 = www2[xx].Split(stringSeparators8, StringSplitOptions.None);
                                    x10 = www4[1].Trim();
                                    //xx = xx + 1;
                                }
                                if (www2[xx].IndexOf("тр. ") > 0)
                                {
                                    www4 = www2[xx].Split(stringSeparators1, StringSplitOptions.None);
                                    x10 = www4[1].Trim();
                                    //
                                }
                                xx = xx + 1;
                            }
                            else
                            {
                                x10 = www2[xx].Trim();
                                xx = xx + 1;
                            }
                            if (www2[xx].IndexOf(refetat) > 0)
                            {
                                www5 = www2[xx].Split(stringSeparators2, StringSplitOptions.None);
                                x11 = www5[1].Trim();
                                xx = xx + 1;
                            }
                            if (www2[xx].IndexOf(place) > 0)
                            {
                                www6 = www2[xx].Split(stringSeparators4, StringSplitOptions.None);
                                //x12 = www6[0].Trim();
                                x12 = www6[1].Trim();
                                xx = xx + 1;
                            }
                            x13 = www2[xx].Trim();
                            try
                            {
                                if (x13 == "" || Convert.ToInt32(x13) > 0)
                                {
                                    //www7 = www2;
                                    SqlConnection connection = new SqlConnection(puti1);
                                    connection.Open();
                                    SqlCommand com = new SqlCommand
                                    (" INSERT INTO danie (nomer , tema1 , tema2 , Aftor , Naz , Org , Gorod , God , Str , Ilustr , Slova , Referat , Mesto ) VALUES ('" + nom + "','" + x1 + "','" + x2 + "','" + x3 + "','" + x4 + "','" + x5 + "','" + x6 + "','" + x7 + "','" + x8 + "','" + x9 + "','" + x10 + "','" + x11 + "','" + x12 + "' )", connection);
                                    SqlDataAdapter da = new SqlDataAdapter();
                                    DataSet ds = new DataSet();
                                    da.SelectCommand = com;
                                    da.Fill(ds);
                                    connection.Close();
                                    x1 = x2 = x3 = x4 = x5 = x6 = x7 = x8 = x9 = x10 = x11 = x12 = string.Empty;
                                    nom = x13;
                                }
                            }
                            catch (Exception)
                            {
                                Zapis1.Add(nom);
                                nom = www2[www2.Length - 2];
                                nom = nom.Trim();
                            }

                        }
                        catch (Exception)
                        {
                            MessageBox.Show(nom);
                        }

                    }
                    MessageBox.Show("Конец записи");
                    foreach (var list in Zapis1)
                    {
                        dataGridView1.Rows.Add(Zapis1[x777]);
                        x777++;
                    }
                    //dataGridView1.Rows.Add(dataGridView1.Columns.Count(Zapis1));
                }
                catch (Exception)
                {

                }
                //
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(puti1);
            connection.Open();
            SqlCommand com = new SqlCommand
            (" INSERT INTO danie (nomer , tema1 , tema2 , Aftor , Naz , Org , Gorod , God , Str , Ilustr , Slova , Referat , Mesto ) VALUES ('" + textBoxNumber.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "'," + textBoxYear.Text + ",'" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox11.Text + "','" + textBox13.Text + "' )", connection);
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet ds = new DataSet();
            da.SelectCommand = com;
            da.Fill(ds);
            connection.Close();
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text =
            textBox6.Text = textBoxYear.Text = textBox8.Text = textBox9.Text = textBox10.Text =
            textBox11.Text = textBoxNumber.Text = textBox13.Text = textBox1.Text = string.Empty;
        }
    }
}
