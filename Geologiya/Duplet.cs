using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;
using System.Collections;
using System.Data.SqlClient;

namespace Geologiya
{
    public partial class Duplet : Form
    {
        public static DannieDataClassesDataContext context = new DannieDataClassesDataContext(Util.GetConnectionString());
        public static Table<danie> danieTab;

        DataGridViewCheckBoxColumn delCol = new DataGridViewCheckBoxColumn(false);

        public Duplet()
        {
            InitializeComponent();
            danieTab = context.GetTable<danie>();
        }

        /*private void GridSettings()
        {
            dupletGrid.Columns["ID"].Visible = false;

            dupletGrid.Columns["nomer"].HeaderText = "Номер";
            dupletGrid.Columns["nomer"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dupletGrid.Columns["tema1"].HeaderText = "Рубрика осн.";
            dupletGrid.Columns["tema1"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dupletGrid.Columns["tema2"].HeaderText = "Рубрики вспом.";
            dupletGrid.Columns["tema2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dupletGrid.Columns["Aftor"].HeaderText = "Автор(ы)";
            dupletGrid.Columns["Aftor"].Width = 200;

            dupletGrid.Columns["Naz"].HeaderText = "Название";
            dupletGrid.Columns["Naz"].Width = 300;

            dupletGrid.Columns["Org"].HeaderText = "Организация";
            dupletGrid.Columns["Org"].Width = 150;

            dupletGrid.Columns["Gorod"].HeaderText = "Город";
            dupletGrid.Columns["Gorod"].Width = 80;

            dupletGrid.Columns["God"].HeaderText = "Год";
            dupletGrid.Columns["God"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dupletGrid.Columns["Str"].HeaderText = "Страница";
            dupletGrid.Columns["Str"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dupletGrid.Columns["Ilustr"].HeaderText = "Илюстраций";
            dupletGrid.Columns["Ilustr"].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            dupletGrid.Columns["Slova"].HeaderText = "Ключевые слова";
            dupletGrid.Columns["Slova"].Width = 180;

            dupletGrid.Columns["Referat"].HeaderText = "Реферат";
            dupletGrid.Columns["Referat"].Width = 180;

            dupletGrid.Columns["Mesto"].HeaderText = "Место";
            dupletGrid.Columns["Mesto"].Width = 80;

        }*/

       private void Duplet_Load(object sender, EventArgs e) 
        {
            DataSet ds = new DataSet();
            DataTable tab = new DataTable("dbo.danie");
            ds.Tables.Add(tab);

            SqlConnection con= new SqlConnection(Util.GetConnectionString());

            string com = "SELECT * FROM danie WHERE (nomer IN " +
                "(SELECT nomer FROM dbo.danie " +
                "GROUP BY nomer " +
                "HAVING (COUNT(nomer) > 1))) " +
                "ORDER BY nomer";
            SqlCommand comand = new SqlCommand(com, con);
            SqlDataAdapter adapt = new SqlDataAdapter(com, con);

           try
            {
                con.Open();
                adapt.Fill(ds, "dbo.danie");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            {
                con.Close();
            }


        }

       private void Duplet_Shown(object sender, EventArgs e)
        {
            dupletGrid.DataSource = tab;
            dupletGrid.Columns["ID"].Visible = false;
            dupletGrid.Columns.Add(delCol);
            delCol.HeaderText = "delete";
            delCol.Name = "delCol";
            dupletGrid.Columns["delCol"].DisplayIndex = 0;
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
                MessageBox.Show("Выбирете запись!");
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            inserting insf = new inserting();
            insf.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void deleteRec(int IDRec)
        {
            var res = danieTab.Where(wh => wh.ID == IDRec).SingleOrDefault();
            context.danies.DeleteOnSubmit(res);
            context.SubmitChanges();
        }
    }
}
