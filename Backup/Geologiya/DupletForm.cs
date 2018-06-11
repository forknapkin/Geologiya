using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Collections;

namespace Geologiya
{
    public partial class DupletForm : Form
    {
        public static DannieDataClassesDataContext context = new DannieDataClassesDataContext(Util.GetConnectionString());
        public static Table<danie> danieTab;

        DataGridViewCheckBoxColumn delCol = new DataGridViewCheckBoxColumn(false);

        public DupletForm()
        {
            InitializeComponent();
            danieTab = context.GetTable<danie>();
        }

        void dupletRecord() 
        {
            DataSet ds = new DataSet();
            DataTable tab = new DataTable("danie");
            ds.Tables.Add(tab);

            SqlConnection con = new SqlConnection(Util.GetConnectionString());
            string com = "SELECT * FROM danie WHERE (nomer IN " +
                "(SELECT nomer FROM danie " +
                "GROUP BY nomer " +
                "HAVING (COUNT(nomer) > 1))) " +
                "ORDER BY nomer";

            SqlDataAdapter adapt = new SqlDataAdapter(com, con);

            try
            {
                con.Open();
                adapt.Fill(tab);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }

            dupletGrid.DataSource = tab;
        }
        public void DupletForm_Load(object sender, EventArgs e)
        {
            dupletRecord();
            dupletGrid.Columns["ID"].Visible = false;

            DataGridViewCheckBoxColumn checkBox = new DataGridViewCheckBoxColumn(false);
            checkBox.Name = "check";
            dupletGrid.Columns.Add(checkBox);
            dupletGrid.Columns["check"].DisplayIndex = 0;
            dupletGrid.Columns["check"].HeaderText = "";
            dupletGrid.Columns["check"].Width = 20;

            dupletGrid.Columns["nomer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dupletGrid.Columns["tema1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dupletGrid.Columns["tema2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dupletGrid.Columns["Aftor"].Width = 200;
            dupletGrid.Columns["Naz"].Width = 300;
            dupletGrid.Columns["Org"].Width = 150;
            dupletGrid.Columns["Gorod"].Width = 80;
            dupletGrid.Columns["God"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dupletGrid.Columns["Str"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dupletGrid.Columns["Ilustr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dupletGrid.Columns["Slova"].Width = 180;
            dupletGrid.Columns["Referat"].Width = 180;
            dupletGrid.Columns["Mesto"].Width = 80;


            dupletGrid.Columns["nomer"].ReadOnly = dupletGrid.Columns["tema1"].ReadOnly = dupletGrid.Columns["tema2"].ReadOnly = dupletGrid.Columns["Aftor"].ReadOnly =
                dupletGrid.Columns["Naz"].ReadOnly = dupletGrid.Columns["Org"].ReadOnly = dupletGrid.Columns["Gorod"].ReadOnly = dupletGrid.Columns["God"].ReadOnly =
                dupletGrid.Columns["Str"].ReadOnly = dupletGrid.Columns["Ilustr"].ReadOnly = dupletGrid.Columns["Slova"].ReadOnly =
                dupletGrid.Columns["Referat"].ReadOnly = dupletGrid.Columns["Mesto"].ReadOnly = true;

            if (Util.language == "Русскоязычная")
            {
                dupletGrid.Columns["nomer"].HeaderText = "Номер";
                dupletGrid.Columns["tema1"].HeaderText = "Рубрика осн.";
                dupletGrid.Columns["tema2"].HeaderText = "Рубрики вспом.";
                dupletGrid.Columns["Aftor"].HeaderText = "Автор(ы)";
                dupletGrid.Columns["Naz"].HeaderText = "Название";
                dupletGrid.Columns["Org"].HeaderText = "Организация";
                dupletGrid.Columns["Gorod"].HeaderText = "Город";
                dupletGrid.Columns["God"].HeaderText = "Год";
                dupletGrid.Columns["Str"].HeaderText = "Страница";
                dupletGrid.Columns["Ilustr"].HeaderText = "Илюстрации";
                dupletGrid.Columns["Slova"].HeaderText = "Ключевые слова";
                dupletGrid.Columns["Referat"].HeaderText = "Реферат";
                dupletGrid.Columns["Mesto"].HeaderText = "Место";
            }
            else
            {
                dupletGrid.Columns["nomer"].HeaderText = "Рақами";
                dupletGrid.Columns["tema1"].HeaderText = "Асосий рукни.";
                dupletGrid.Columns["tema2"].HeaderText = "Қўшимча рукни";
                dupletGrid.Columns["Aftor"].HeaderText = "Муаллиф(лар)";
                dupletGrid.Columns["Naz"].HeaderText = "Номи";
                dupletGrid.Columns["Org"].HeaderText = "Ташкилот";
                dupletGrid.Columns["Gorod"].HeaderText = "Шаҳар";
                dupletGrid.Columns["God"].HeaderText = "Йил";
                dupletGrid.Columns["Str"].HeaderText = "Бетлар";
                dupletGrid.Columns["Ilustr"].HeaderText = "Илюстрациялар";
                dupletGrid.Columns["Slova"].HeaderText = "Асосий сўзлар";
                dupletGrid.Columns["Referat"].HeaderText = "Реферат";
                dupletGrid.Columns["Mesto"].HeaderText = "Сақлаш жойи";
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                Util.ID = (int)dupletGrid["ID", dupletGrid.CurrentRow.Index].Value;
                Util.Insert = false;
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            inserting insf = new inserting();
            insf.ShowDialog();
            dupletRecord();
        }

        void deleteRec(int IDRec)
        {
            var res = danieTab.Where(wh => wh.ID == IDRec).SingleOrDefault();
            context.danies.DeleteOnSubmit(res);
            context.SubmitChanges();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            for (int i = 0; i < dupletGrid.Rows.Count; i++)
            {
                if ((bool)dupletGrid.Rows[i].Cells["check"].EditedFormattedValue == true)
                    {
                        try
                        {
                            int id = (int)dupletGrid["ID", dupletGrid.Rows[i].Index].Value;
                            dupletGrid.Rows.RemoveAt(dupletGrid.Rows[i].Index);
                            deleteRec(id);
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
                    }
            }

            dupletRecord();
            this.Cursor = Cursors.Default;
        }
    }
}
