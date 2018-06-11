using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Data.SqlClient;
using System.Threading;
using System.Data.Common;


namespace Geologiya
{
    public partial class MainForm : Form
    {
        public static DannieDataClassesDataContext dcont;
        public static System.Data.Linq.Table<danie> tabDanie;
        public static System.Data.Linq.Table<User> tabUsers;

        enum QueryParam { Or, And, Combo };

        public MainForm()
        {
            ChooseVersion cv = new ChooseVersion();
            cv.ShowDialog();

            if (Util.language == "Русскоязычная")
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru-RU");
            else
            {
                Util.ReadCultureInfo();
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(Util.cultureInfo);
            }
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {


            ViewGrid.Author = ViewGrid.KeyWords = ViewGrid.Name = ViewGrid.Number = ViewGrid.Organization =
                ViewGrid.Pages = ViewGrid.Place = ViewGrid.Referat = ViewGrid.Sity = ViewGrid.Tema1 = ViewGrid.Tema2 =
                ViewGrid.Year = ReportView.Author = ReportView.KeyWords = ReportView.Name = ReportView.Number =
                ReportView.Organization = ReportView.Pages = ReportView.Place = ReportView.Referat = ReportView.Sity =
                ReportView.Tema1 = ReportView.Tema2 = ReportView.Year = ViewGrid.Images = ReportView.Images = true;

            label2.Visible = false;
            textBoxNumberTo.Enabled = false;

            FileInfo file = new FileInfo("config.ini");
            FileInfo fileUz = new FileInfo("configUz.ini");
            if (!file.Exists && !fileUz.Exists)
            {
                MessageBox.Show("Нет файла подключения!");
                NewConectToServerForm conf = new NewConectToServerForm();
                conf.ShowDialog();
            }

            Util.IsAuthotization = false;
            label1.Text = "Показанно 0 записей";

            cbSort.SelectedIndex = 0;

            MessageBox.Show("Сейчас будет выполненна загрузка данных. Это может занять некоторое время.");
        }

        private void GridSettings()
        {
            dGridView.Columns["ID"].Visible = false;

            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn(false);
            checkBox.Name = "check";
            dGridView.Columns.Add(checkBox);
            dGridView.Columns["check"].DisplayIndex = 0;
            dGridView.Columns["check"].HeaderText = "";
            dGridView.Columns["check"].Width = 20;

            dGridView.Columns["nomer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dGridView.Columns["tema1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dGridView.Columns["tema2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dGridView.Columns["Aftor"].Width = 200;
            dGridView.Columns["Naz"].Width = 300;
            dGridView.Columns["Org"].Width = 150;
            dGridView.Columns["Gorod"].Width = 80;
            dGridView.Columns["God"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dGridView.Columns["Str"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dGridView.Columns["Ilustr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dGridView.Columns["Slova"].Width = 180;
            dGridView.Columns["Referat"].Width = 180;
            dGridView.Columns["Mesto"].Width = 80;


            dGridView.Columns["nomer"].ReadOnly = dGridView.Columns["tema1"].ReadOnly = dGridView.Columns["tema2"].ReadOnly = dGridView.Columns["Aftor"].ReadOnly =
                dGridView.Columns["Naz"].ReadOnly = dGridView.Columns["Org"].ReadOnly = dGridView.Columns["Gorod"].ReadOnly = dGridView.Columns["God"].ReadOnly =
                dGridView.Columns["Str"].ReadOnly = dGridView.Columns["Ilustr"].ReadOnly = dGridView.Columns["Slova"].ReadOnly =
                dGridView.Columns["Referat"].ReadOnly = dGridView.Columns["Mesto"].ReadOnly = true;



            if (Util.language == "Русскоязычная")
            {
                dGridView.Columns["nomer"].HeaderText = "Номер";
                dGridView.Columns["tema1"].HeaderText = "Рубрика осн.";
                dGridView.Columns["tema2"].HeaderText = "Рубрики вспом.";
                dGridView.Columns["Aftor"].HeaderText = "Автор(ы)";
                dGridView.Columns["Naz"].HeaderText = "Название";
                dGridView.Columns["Org"].HeaderText = "Организация";
                dGridView.Columns["Gorod"].HeaderText = "Город";
                dGridView.Columns["God"].HeaderText = "Год";
                dGridView.Columns["Str"].HeaderText = "Страница";
                dGridView.Columns["Ilustr"].HeaderText = "Илюстрации";
                dGridView.Columns["Slova"].HeaderText = "Ключевые слова";
                dGridView.Columns["Referat"].HeaderText = "Реферат";
                dGridView.Columns["Mesto"].HeaderText = "Место";
            }
            else
            {
                dGridView.Columns["nomer"].HeaderText = "Рақами";
                dGridView.Columns["tema1"].HeaderText = "Асосий рукни.";
                dGridView.Columns["tema2"].HeaderText = "Қўшимча рукни";
                dGridView.Columns["Aftor"].HeaderText = "Муаллиф(лар)";
                dGridView.Columns["Naz"].HeaderText = "Номи";
                dGridView.Columns["Org"].HeaderText = "Ташкилот";
                dGridView.Columns["Gorod"].HeaderText = "Шаҳар";
                dGridView.Columns["God"].HeaderText = "Йил";
                dGridView.Columns["Str"].HeaderText = "Бетлар";
                dGridView.Columns["Ilustr"].HeaderText = "Илюстрациялар";
                dGridView.Columns["Slova"].HeaderText = "Асосий сўзлар";
                dGridView.Columns["Referat"].HeaderText = "Реферат";
                dGridView.Columns["Mesto"].HeaderText = "Сақлаш жойи";
            }

        }

        private void GridColVisibleSettings()
        {
            dGridView.Columns["nomer"].Visible = ViewGrid.Number;
            dGridView.Columns["tema1"].Visible = ViewGrid.Tema1;
            dGridView.Columns["tema2"].Visible = ViewGrid.Tema2;
            dGridView.Columns["Aftor"].Visible = ViewGrid.Author;
            dGridView.Columns["Naz"].Visible = ViewGrid.Name;
            dGridView.Columns["Org"].Visible = ViewGrid.Organization;
            dGridView.Columns["Gorod"].Visible = ViewGrid.Sity;
            dGridView.Columns["God"].Visible = ViewGrid.Year;
            dGridView.Columns["Str"].Visible = ViewGrid.Pages;
            dGridView.Columns["Ilustr"].Visible = ViewGrid.Images;
            dGridView.Columns["Slova"].Visible = ViewGrid.KeyWords;
            dGridView.Columns["Referat"].Visible = ViewGrid.Referat;
            dGridView.Columns["Mesto"].Visible = ViewGrid.Place;

        }


        private bool CheckedCheckBox()
        {
            foreach (var item in panel2.Controls)
            {
                System.Windows.Forms.CheckBox ch = item as System.Windows.Forms.CheckBox;
                if (ch != null)
                {
                    if (ch.Checked)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private void DelSpace(ref string str)
        {
            if (str[0] == ' ')
            {
                str = str.Substring(1);
            }
            if (str[str.Length - 1] == ' ')
            {
                str = str.Substring(0, str.Length - 1);
            }
        }


        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            // выборка всех записей
            var res = tabDanie.Where<danie>(wh => wh.ID > 0);

            // отфильтровывание по номеру
            if (checkBoxNumber.Checked)
            {
                if (!cbNumberTo.Checked)
                {

                    string[] mas = textBoxNumber.Text.Split(", ".ToCharArray()).Where(wh => !string.IsNullOrEmpty(wh) && !wh.Equals(",") && !wh.Equals(" ")).ToArray();
                    if (mas != null && mas.Length > 0)
                    {
                        int[] num = new int[mas.Length];
                        for (int i = 0; i < mas.Length; i++)
                        {
                            Int32.TryParse(mas[i], out num[i]);
                        }

                        res = res.Where<danie>(wh => num.Contains((int)wh.nomer));
                    }
                }
                else
                {
                    int numFrom, numTo;
                    if (Int32.TryParse(textBoxNumberFrom.Text, out numFrom) && Int32.TryParse(textBoxNumberTo.Text, out numTo))
                    {
                        res = res.Where<danie>(wh => wh.nomer >= numFrom && wh.nomer <= numTo);
                    }
                    else
                    {
                        MessageBox.Show("Неверно введен один из номеров!");
                    }
                }

            }

            //выборка по основной и вторичным Рубрикам
            if (checkBoxTema.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxTema.Text))
                {
                    res = res.Where<danie>(wh => wh.tema1.Contains(textBoxTema.Text) || wh.tema2.Contains(textBoxTema.Text));
                }
            }

            // выборка по автору
            if (checkBoxAutor.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxAutor.Text))
                {
                    res = res.Where<danie>(wh => wh.Aftor.Contains(textBoxAutor.Text));
                }
            }
            // выборка по наименованию
            if (checkBoxName.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxName.Text))
                {
                    res = res.Where<danie>(wh => wh.Naz.Contains(textBoxName.Text));
                }
            }
            // выборка по организации
            if (checkBoxOrg.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxOrg.Text))
                {
                    res = res.Where<danie>(wh => wh.Org.Contains(textBoxOrg.Text));
                }
            }
            // выборка по городу
            if (checkBoxSity.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxSity.Text))
                {
                    res = res.Where<danie>(wh => wh.Gorod.Contains(textBoxSity.Text));
                }
            }
            // выборка по году
            if (checkBoxYear.Checked)
            {
                if (radioButtonFixYear.Checked)
                {
                    int year;
                    if (Int32.TryParse(textBoxYear1.Text, out year))
                    {
                        res = res.Where<danie>(wh => wh.God == year);
                    }
                    else
                        MessageBox.Show("Неверно введен Год. " + "\"" + textBoxYear1.Text + "\"");
                }
                if (radioButtonMoreYear.Checked)
                {
                    int year1, year2;
                    if (Int32.TryParse(textBoxYear1.Text, out year1) && Int32.TryParse(textBoxYear2.Text, out year2))
                    {
                        res = res.Where<danie>(wh => wh.God >= year1 && wh.God <= year2);
                    }
                    else
                    {
                        MessageBox.Show("Проверьте правильность вводимых значений годов");
                    }
                }
            }


            // выборка по ключевым словам 
            // выполняет ExComboQuery
            /* 
            if (checkBoxWords.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxKeyWords.Text))
                {
                    string[] keywords = textBoxKeyWords.Text.Split(',');
                    string query = String.Empty;

                    if (rbAndKW.Checked)
                    {
                        GetQuery(keywords, QueryParam.And, out query, "");
                        res = res.Where<danie>(query, keywords.ToList(), "");

                    }
                    else if (rbOrKW.Checked)
                    {
                        GetQuery(keywords, QueryParam.Or, out query, "");
                        res = res.Where<danie>(query, keywords.ToList());
                    }
                    else if (rbComboKW.Checked)
                    {
                        GetComboQuery(textBoxKeyWords.Text, out query, true);
                        res = res.Where<danie>(query, keywords.ToList());
                    }
                }
            }
            */

            // исключение к ключевым словам
            // выполняет ExComboQuery
            /*if (checkBoxExeptionWords.Checked)
            {
                //if (!string.IsNullOrEmpty(textBoxExeptionWords.Text))
                //{
                if (!String.IsNullOrEmpty(textBoxExeptionWords.Text))
                {
                    string[] keywords = textBoxExeptionWords.Text.Split(',');
                    string query = "";

                    if (rbAndExKW.Checked)
                    {
                        GetQuery(keywords, QueryParam.And, out query, "!");
                    
                        res = res.Where<danie>(query, keywords.ToList());
                    }
                    else if (rbOrExKW.Checked)
                    {
                        GetQuery(keywords, QueryParam.Or, out query, "!");
                        res = res.Where<danie>(query, keywords.ToList());
                    }
                    else if (rbComboExKW.Checked)
                    {
                        GetComboQuery(textBoxExeptionWords.Text, out query, false);
                        
                        res = res.Where<danie>(query, keywords.ToList());
                        
                    }
                    //MessageBox.Show(res.ToString());
                    //if (keywords.Length > 0)
                    //{
                    //    DelSpace(ref keywords[0]);

                    //    query += "!(Slova.Contains(\"" + keywords[0] + "\")";
                    //    for (int i = 1; i < keywords.Length; i++)
                    //    {
                    //        DelSpace(ref keywords[i]);
                    //        query += " || Slova.Contains(\"" + keywords[i] + "\")";
                    //    }
                    //    query += ")";
                    //    res = res.Where<danie>(query, keywords.ToList());
                    //}
                }
                //}
            }*/

            // выборка по реферату
            if (checkBoxReferat.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxReferat.Text))
                {
                    res = res.Where<danie>(wh => wh.Referat.Contains(textBoxReferat.Text));
                }
            }

            // выборка по месту хранения
            if (checkBoxPlace.Checked)
            {
                if (!String.IsNullOrEmpty(textBoxPlace.Text))
                {
                    res = res.Where<danie>(wh => wh.Mesto.Contains(textBoxPlace.Text));
                }
            }

            if (cbSort.SelectedIndex == 0)
            {
                res = res.OrderBy(ob => ob.nomer);
            }
            else
            {
                res = res.OrderBy(ob => ob.God);
            }
            
            res.ToList();


            //MessageBox.Show(res.ToString());
            /*FileStream stream = new FileStream(@"query.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(res.ToString());
            writer.WriteLine();
            foreach (DbParameter par in dcont.GetCommand(res).Parameters)
                writer.WriteLine(par.Value);
            writer.Close();
            */
            try
            {
                // Сложный запрос
                /*if (rbComboKW.Checked && checkBoxWords.Checked)
                
                    dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, String.Empty);
                    */
               if (checkBoxWords.Checked && checkBoxExeptionWords.Checked && checkBoxAutor.Checked)
                {
                    if (rbAndKW.Checked && rbAndExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " AND ", " AND ", dcont.GetCommand(res), false, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbAndKW.Checked && rbOrExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " AND ", " OR ", dcont.GetCommand(res), false, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbAndKW.Checked && rbComboExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " AND ", String.Empty, dcont.GetCommand(res), false, true, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbOrKW.Checked && rbAndExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " OR ", " AND ", dcont.GetCommand(res), false, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbOrKW.Checked && rbOrExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " OR ", " OR ", dcont.GetCommand(res), false, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbOrKW.Checked && rbComboExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " OR ", String.Empty, dcont.GetCommand(res), false, true, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbComboKW.Checked && rbAndExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, String.Empty, " AND ", dcont.GetCommand(res), true, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbComboKW.Checked && rbOrExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, String.Empty, " OR ", dcont.GetCommand(res), true, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    else if (rbComboKW.Checked && rbComboExKW.Checked)
                        dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, String.Empty, String.Empty, dcont.GetCommand(res), true, true, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    //start from decompil
                    else
                    {
                        if (!this.rbComboKW.Checked || !this.rbComboExKW.Checked)
                            return;
                        this.dGridView.DataSource = (object)Util.MultiQueryResult(this.textBoxKeyWords.Text, this.textBoxExeptionWords.Text, string.Empty, string.Empty, MainForm.dcont.GetCommand((IQueryable)res), true, true, this.textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    }
                    //end from decompil
                }

                else if (checkBoxWords.Checked && checkBoxExeptionWords.Checked)
               {
                   if (rbAndKW.Checked && rbAndExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " AND ", " AND ", dcont.GetCommand(res), false, false, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbAndKW.Checked && rbOrExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " AND ", " OR ", dcont.GetCommand(res), false, false, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbAndKW.Checked && rbComboExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " AND ", String.Empty, dcont.GetCommand(res), false, true, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbOrKW.Checked && rbAndExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " OR ", " AND ", dcont.GetCommand(res), false, false, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbOrKW.Checked && rbOrExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " OR ", " OR ", dcont.GetCommand(res), false, false, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbOrKW.Checked && rbComboExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, " OR ", String.Empty, dcont.GetCommand(res), false, true, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbComboKW.Checked && rbAndExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, String.Empty, " AND ", dcont.GetCommand(res), true, false, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbComboKW.Checked && rbOrExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, String.Empty, " OR ", dcont.GetCommand(res), true, false, string.Empty, this.cbxAccuracySearch.Checked);
                   else if (rbComboKW.Checked && rbComboExKW.Checked)
                       dGridView.DataSource = Util.MultiQueryResult(textBoxKeyWords.Text, textBoxExeptionWords.Text, String.Empty, String.Empty, dcont.GetCommand(res), true, true, string.Empty, this.cbxAccuracySearch.Checked);
                    //start from decompil
                    else
                    {
                        if (!this.rbComboKW.Checked || !this.rbComboExKW.Checked)
                            return;
                        this.dGridView.DataSource = (object)Util.MultiQueryResult(this.textBoxKeyWords.Text, this.textBoxExeptionWords.Text, string.Empty, string.Empty, MainForm.dcont.GetCommand((IQueryable)res), true, true, string.Empty, this.cbxAccuracySearch.Checked);
                    }
                    //end from decompil
                }

                else if (checkBoxWords.Checked && checkBoxAutor.Checked)
                {
                    if (rbComboKW.Checked)
                    {
                        dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, String.Empty, dcont.GetCommand(res), true, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    }
                    else if (rbAndKW.Checked)
                    {
                        dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, " AND ", dcont.GetCommand(res), false, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    }
                    else
                    {
                        if (!rbOrKW.Checked)
                            return;
                        dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, " OR ", dcont.GetCommand(res), false, false, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    }
                }
                else if (checkBoxExeptionWords.Checked && checkBoxAutor.Checked)
                {
                    if (rbComboExKW.Checked)
                    {
                        dGridView.DataSource = Util.ComboQueryResult(textBoxExeptionWords.Text, String.Empty, dcont.GetCommand(res), true, true, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    }
                    else if (rbAndExKW.Checked)
                    {
                        dGridView.DataSource = Util.ComboQueryResult(textBoxExeptionWords.Text, " AND ", dcont.GetCommand(res), false, true, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    }
                    else
                    {
                        if (!rbOrExKW.Checked)
                            return;
                    }
                    dGridView.DataSource = Util.ComboQueryResult(textBoxExeptionWords.Text, " OR ", dcont.GetCommand(res), false, true, textBoxAutor.Text, this.cbxAccuracySearch.Checked);
                    
                }
                else if (checkBoxWords.Checked)
                    {
                        if (rbComboKW.Checked)
                        {
                            dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, String.Empty, dcont.GetCommand(res), true, false, string.Empty, this.cbxAccuracySearch.Checked);
                        }
                        else if (rbAndKW.Checked)
                        {
                            dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, " AND ", dcont.GetCommand(res), false, false, string.Empty, this.cbxAccuracySearch.Checked);
                        }
                        else 
                        {
                        if (!rbOrKW.Checked)
                            return;
                            dGridView.DataSource = Util.ComboQueryResult(textBoxKeyWords.Text, " OR ", dcont.GetCommand(res), false, false, string.Empty, this.cbxAccuracySearch.Checked);
                        }
                    }

                 else if (checkBoxExeptionWords.Checked)
                    {
                        if (rbComboExKW.Checked)
                        {
                            dGridView.DataSource = Util.ComboQueryResult(textBoxExeptionWords.Text, String.Empty, dcont.GetCommand(res), true, true, string.Empty, this.cbxAccuracySearch.Checked);
                        }
                        else if (rbAndExKW.Checked)
                        {
                            dGridView.DataSource = Util.ComboQueryResult(textBoxExeptionWords.Text, " AND ", dcont.GetCommand(res), false, true, string.Empty, this.cbxAccuracySearch.Checked);
                        }
                        else 
                        {
                        if (!rbOrExKW.Checked)
                            return;
                            dGridView.DataSource = Util.ComboQueryResult(textBoxExeptionWords.Text, " OR ", dcont.GetCommand(res), false, true, string.Empty, this.cbxAccuracySearch.Checked);
                        }
                    }
                    
                    else if (checkBoxAutor.Checked)
                    {
                        if (!String.IsNullOrEmpty(textBoxAutor.Text))
                        {
                            dGridView.DataSource = Util.AuthorQueryResult(textBoxAutor.Text, dcont.GetCommand(res));
                        }
                    }

                    else if (!checkBoxWords.Checked && !checkBoxExeptionWords.Checked && !checkBoxAutor.Checked)
                    {
                        dGridView.DataSource = res;
                    }
                

               
            }
            catch
            {
                MessageBox.Show("Некорректно введены параметры запроса");
            }
            finally
            {
                this.Cursor = Cursors.Default;
                label1.Text = dGridView.Rows.Count.ToString() + " записей";
            }
        }


        private void GetComboQuery(string p, out string query, bool ex)
        {

            p = p.Replace("(", " ( ");
            p = p.Replace(")", " ) ");
            p = p.Replace("&", " && ");
            p = p.Replace("|", " || ");
            string[] mas = p.Split(' ');

            string[] paramQuery = mas.Where(wh => wh != string.Empty).ToArray();
            p = "";
            string contains = "";
            if(ex)
                contains = "(Slova.Contains(\"";
            else
                contains = "!(Slova.Contains(\"";
            for (int i = 0; i < paramQuery.Length; i++)
            {
                //p = p.Replace(paramQuery[i], "Slova.Contains(\"" + paramQuery[i] + "\")");
                switch (paramQuery[i])
                {
                    case "(":
                    case ")":
                    case "&&":
                    case "||":
                        p = p + " " + paramQuery[i] + " ";
                        break;
                    default:
                        p = p + "(" + contains + " " + paramQuery[i] + "\"))"  + "||" + contains + "." + paramQuery[i] + "\"))"
                            + "||" + contains + paramQuery[i] + "\")))";
                        break;
                }
            }
            /*if (!ex)
            {
                p = p.Insert(p.IndexOf('('), "!");
                
            }
            //MessageBox.Show(p);*/
            query = p;
        }


        private void GetQuery(string[] keywords, QueryParam queryParam, out string query, string sign)
        {
            query = "";
            if (keywords.Length > 0)
            {
                if (queryParam == QueryParam.Or)
                {

                    DelSpace(ref keywords[0]);

                    query = sign + "((Slova.Contains(\"" + " " + keywords[0] + "\") || Slova.Contains(\"." + keywords[0] + "\"))" + "|| Slova.Contains(\"" + keywords[0] + "\"))";
                    for (int i = 1; i < keywords.Length; i++)
                    {
                        DelSpace(ref keywords[i]);
                        query += " || (Slova.Contains(\"" + " " + keywords[i] + "\") || Slova.Contains(\"." + keywords[i] + "\"))" + "|| Slova.Contains(\"" + keywords[0] + "\"))";
                    }
                    query += ")";

                }
                else if (queryParam == QueryParam.And)
                {
                    DelSpace(ref keywords[0]);

                    query = sign + "((Slova.Contains(\"" + " " + keywords[0] + "\") || Slova.Contains(\"." + keywords[0] + "\"))" + "|| Slova.Contains(\"" + keywords[0] + "\"))";
                    for (int i = 1; i < keywords.Length; i++)
                    {
                        DelSpace(ref keywords[i]);
                        query += " && (Slova.Contains(\"" + " " + keywords[i] + "\") || Slova.Contains(\"." + keywords[i] + "\"))" + "|| Slova.Contains(\"" + keywords[0] + "\"))";
                    }
                    query += ")";
                }

            }

        }



        public void InsertToBase()
        {
            danie d = new danie
            {
                Aftor = "123",
                God = 1234,
                Gorod = "qwe",
                Ilustr = "2",
                Mesto = "qwe"
            };
            dcont.danies.InsertOnSubmit(d);
            dcont.SubmitChanges();
        }

        public void UpdateToBase()
        {
            var q = tabDanie.Where(wh => wh.ID == 2).FirstOrDefault();
            q.Ilustr = "6";
            dcont.SubmitChanges();
        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            dcont.SubmitChanges();
            this.Cursor = Cursors.Default;
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.CheckBox chb = (System.Windows.Forms.CheckBox)sender;
            switch (chb.Name)
            {
                case "checkBoxAutor":
                    textBoxAutor.Enabled = !textBoxAutor.Enabled;
                    break;
                    ;
                case "checkBoxName":
                    textBoxName.Enabled = !textBoxName.Enabled;
                    break;
                case "checkBoxNumber":
                    textBoxNumber.Enabled = !textBoxNumber.Enabled;
                    cbNumberTo.Enabled = !cbNumberTo.Enabled;
                    if (!chb.Checked)
                    {
                        cbNumberTo.Enabled = cbNumberTo.Checked = textBoxNumberTo.Enabled = textBoxNumberFrom.Visible = false;
                    }
                    else
                    {

                    }
                    break;
                case "checkBoxOrg":
                    textBoxOrg.Enabled = !textBoxOrg.Enabled;
                    break;
                case "checkBoxPlace":
                    textBoxPlace.Enabled = !textBoxPlace.Enabled;
                    break;
                case "checkBoxReferat":
                    textBoxReferat.Enabled = !textBoxReferat.Enabled;
                    break;
                case "checkBoxSity":
                    textBoxSity.Enabled = !textBoxSity.Enabled;
                    break;

                case "checkBoxTema":
                    textBoxTema.Enabled = !textBoxTema.Enabled;
                    break;
                case "checkBoxWords":
                    textBoxKeyWords.Enabled = !textBoxKeyWords.Enabled;
                    groupBoxKW.Enabled = !groupBoxKW.Enabled;
                    break;
                case "checkBoxYear":
                    textBoxYear1.Enabled = !textBoxYear1.Enabled;
                    textBoxYear2.Enabled = !textBoxYear2.Enabled;
                    radioButtonFixYear.Enabled = !radioButtonFixYear.Enabled;
                    radioButtonMoreYear.Enabled = !radioButtonMoreYear.Enabled;
                    break;
                case "checkBoxExeptionWords":
                    textBoxExeptionWords.Enabled = !textBoxExeptionWords.Enabled;
                    groupBoxExKW.Enabled = !groupBoxExKW.Enabled;
                    break;
                default:
                    break;
            }
        }

        private void radioButtonFixYear_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonFixYear.Checked)
            {
                labelYear2.Visible = false;
                textBoxYear2.Visible = false; ;
                labelYear1.Text = "Год";
            }
            else
            {
                labelYear1.Text = "С года";
                labelYear2.Visible = true;
                textBoxYear2.Visible = true;
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            FormSettings();

            if (!Util.ReadConStr())
            {
                MessageBox.Show("Ошибка при подключении! Проверьте работу сервера и параметры подключения! \n\nПриложение будет закрыто!");
                System.Environment.Exit(0);
            }

            try
            {
                dcont = new DannieDataClassesDataContext(Util.GetConnectionString());
                tabDanie = dcont.GetTable<danie>();
                tabUsers = dcont.GetTable<User>();

                dGridView.DataSource = tabDanie.OrderByDescending(ob => ob.nomer).ToList();

                GridSettings();

                label1.Text = dGridView.Rows.Count.ToString() + " записей";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при получении данных! Проверьте работу сервера и параметры подключения! \n\nПриложение будет закрыто! \n" + ex.Message);
                System.Environment.Exit(0);
            }


            this.Cursor = Cursors.Default;

        }



        private void buttonUpdateOrInsert_Click(object sender, EventArgs e)
        {
            Button but = (Button)sender;

            if (but.Name == buttonUpdate.Name)
            {
                try
                {
                    Util.ID = (int)dGridView["ID", dGridView.CurrentRow.Index].Value;
                    Util.Insert = false;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show("Выбирете запись!");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                Util.Insert = true;
            }

            inserting insf = new inserting();
            insf.ShowDialog();
            this.Cursor = Cursors.WaitCursor;
            dcont.SubmitChanges();
            dGridView.DataSource = tabDanie;
            this.Cursor = Cursors.Default;
        }


        private void buttonDelete_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                int id = (int)dGridView["ID", dGridView.CurrentRow.Index].Value;

                dGridView.Rows.RemoveAt(dGridView.CurrentRow.Index);

                //var res = tab.Where(wh => wh.ID == id).SingleOrDefault();

                //dcont.danies.DeleteOnSubmit(res);
                //dcont.SubmitChanges();
            }
            catch (NullReferenceException ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Не выбрана запись для удаления!");
                return;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            var res = tabDanie.Where<danie>(wh => wh.ID > 0);

            if (cbSort.SelectedIndex == 0)
            {
                res = res.OrderBy(ob => ob.nomer);
            }
            else
            {
                res = res.OrderBy(ob => ob.God);
            }

            res.ToList();

            dGridView.DataSource = res;
            label1.Text = dGridView.Rows.Count.ToString() + " записей";
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            dcont.SubmitChanges();
            Close();
        }

        private void menuItemConvector_Click(object sender, EventArgs e)
        {
            Convektor conv = new Convektor();
            conv.ShowDialog();
        }

        private void buttonWordReport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Формирование отчета может занять продолжительное время! Это зависит от количества записей!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            this.Cursor = Cursors.WaitCursor;

            object oMissing = System.Reflection.Missing.Value;
            object oEndOfDoc = "endofdoc";
            //object oRng = "endofdoc";
            Microsoft.Office.Interop.Word._Application oWord;
            Microsoft.Office.Interop.Word._Document oDoc;
            oWord = new Microsoft.Office.Interop.Word.Application();
            //oWord.Visible = true;
            oDoc = oWord.Documents.Add(ref oMissing, ref oMissing,
          ref oMissing, ref oMissing);
            //Insert a paragraph at the beginning of the document.
            Microsoft.Office.Interop.Word.Paragraph oPara1;
            oPara1 = oDoc.Content.Paragraphs.Add(ref oMissing);
            //string sss = "";
            //int wqe;

            string rec = "";
            for (int i = 0; i < dGridView.Rows.Count; i++)
            {
                if ((bool)dGridView.Rows[i].Cells["check"].EditedFormattedValue == true)
                {
                    //rec = rec + "\n" + "\n" + i.ToString();

                    //rec = rec + "\n" + "\n" + "Номер: " + dGridView["nomer", i].Value.ToString() +
                    //    "\n" + "Автор : " + dGridView["Aftor", i].Value.ToString() + "\n" +
                    //    "Название " + dGridView["Naz", i].Value.ToString() + "\n" +
                    //    "Год " + dGridView["God", i].Value.ToString() + "\t" + "Город: " + dGridView["Gorod", i].Value.ToString() + "\n" +
                    //    "Место хранения " + dGridView["Mesto", i].Value.ToString() + "\t" + "Страница " + dGridView["Str", i].Value.ToString() + "\n" +
                    //    "Органицация: " + dGridView["Org", i].Value.ToString();

                    rec += "\n\n";
                    if (ReportView.Number)
                    {
                        rec += "Номер: " + dGridView["nomer", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Author)
                    {
                        rec += "Автор: " + dGridView["Aftor", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Name)
                    {
                        rec += "Название: " + dGridView["Naz", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Sity)
                    {
                        rec += "Город: " + dGridView["Gorod", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Year)
                    {
                        rec += "Год: " + dGridView["God", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Tema1 || ReportView.Tema2)
                    {
                        rec += "Рубрика: " + dGridView["tema1", i].Value.ToString() + " " + dGridView["tema2", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Organization)
                    {
                        rec += "Организация: " + dGridView["Org", i].Value.ToString() + "\n";
                    }
                    if (ReportView.KeyWords)
                    {
                        rec += "Ключевые слова: " + dGridView["Slova", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Referat)
                    {
                        rec += "Реферат: " + "\n" + dGridView["Referat", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Pages)
                    {
                        rec += "Страниц: " + dGridView["Str", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Images)
                    {
                        rec += "Иллюстрации: " + dGridView["Ilustr", i].Value.ToString() + "\n";
                    }
                    if (ReportView.Place)
                    {
                        rec += "Место хранения: " + dGridView["Mesto", i].Value.ToString() + "\n";
                    }
                }
            }
            this.Cursor = Cursors.Default;
            oPara1.Range.Text = rec;//vidword
            oWord.Visible = true;
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            checkBoxAutor.Checked = checkBoxName.Checked = checkBoxNumber.Checked = checkBoxOrg.Checked = checkBoxPlace.Checked =
                checkBoxReferat.Checked = checkBoxSity.Checked = checkBoxTema.Checked = checkBoxWords.Checked = checkBoxYear.Checked =
                checkBoxExeptionWords.Checked = false;
            textBoxAutor.Text = textBoxExeptionWords.Text = textBoxKeyWords.Text = textBoxName.Text = textBoxNumber.Text =
                textBoxOrg.Text = textBoxPlace.Text = textBoxReferat.Text = textBoxSity.Text = textBoxTema.Text =
                textBoxYear1.Text = textBoxYear2.Text = String.Empty;
        }

        private void menuItemSQLConnect_Click(object sender, EventArgs e)
        {
            NewConectToServerForm newCon = new NewConectToServerForm();
            newCon.ShowDialog();
        }

        private void menuItemSelectUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AuthorizationForm af = new AuthorizationForm();
            af.ShowDialog();
            FormSettings();
        }

        private void FormSettings()
        {

            buttonAdd.Visible = buttonDelete.Visible = buttonUpdate.Visible = menuItemConvector.Visible =
                menuItemSQLConnect.Visible = menuItemUsers.Visible = menuItemExitAdmin.Visible = menuDuplicate.Visible = Util.IsAuthotization;

        }

        private void menuItemExitAdmin_Click(object sender, EventArgs e)
        {
            Util.IsAuthotization = false;
            FormSettings();
        }

        private void menuItemUsers_Click(object sender, EventArgs e)
        {
            NewUserForm nuf = new NewUserForm();
            nuf.ShowDialog();
        }

        private void viewMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            if (item.Name == reportToolStripMenuItem.Name)
            {
                Util.ReportView = true;
            }
            else
            {
                Util.ReportView = false;
            }

            ViewForm vf = new ViewForm();
            vf.ShowDialog();

            GridColVisibleSettings();
        }

        private void userHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpForm hf = new HelpForm();
            hf.ShowDialog();
        }

        private void cbNumberTo_CheckStateChanged(object sender, EventArgs e)
        {
            textBoxNumberTo.Enabled = label2.Visible = cbNumberTo.Checked;
        }

        private void menuDuplicate_Click(object sender, EventArgs e)
        {
            DupletForm df = new DupletForm();
            df.ShowDialog();
            FormSettings();
        }

        private void cbNumberTo_CheckedChanged(object sender, EventArgs e)
        {
            textBoxNumberFrom.Visible = textBoxNumberFrom.Enabled = textBoxNumberTo.Enabled = cbNumberTo.Checked;
            textBoxNumber.Visible = !cbNumberTo.Checked;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGridView.Rows.Count; i++)
            {
                dGridView.Rows[i].Cells["check"].Value = true;
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dGridView.Rows.Count; i++)
            {
                dGridView.Rows[i].Cells["check"].Value = false;
            }
        }

        private void tsmiCreateCopy_Click(object sender, EventArgs e)
        {
            
        }
    }
}
