using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Geologiya
{
    public partial class inserting : Form
    {

        public inserting()
        {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Util.ID.ToString());

            if (Util.Insert) // Insert
            {
                int N, Year;

                Int32.TryParse(textBoxNumber.Text, out N);
                Int32.TryParse(textBoxYear.Text, out Year);

                danie d = new danie
                {
                    Aftor = textBoxAutor.Text,
                    God = Year,
                    Gorod = textBoxSity.Text,
                    Ilustr = textBoxImages.Text,
                    Mesto = textBoxPlace.Text,
                    Naz = textBoxName.Text,
                    nomer = N,
                    Org = textBoxOrg.Text,
                    Referat = textBoxReferat.Text,
                    Slova = textBoxKeyWords.Text,
                    Str = textBoxStr.Text,
                    tema1 = textBoxTema1.Text,
                    tema2 = textBoxTema2.Text
                };

                //MainForm mf = new MainForm();
                //mf.dGridView.Rows.Add(d);


                MainForm.dcont.danies.InsertOnSubmit(d);
                
            }
            else // Update
            {
                int N, Year;

                Int32.TryParse(textBoxNumber.Text, out N);
                Int32.TryParse(textBoxYear.Text, out Year);

                var res = MainForm.tabDanie.Where(wh => wh.ID == Util.ID).FirstOrDefault();

                res.Naz = textBoxName.Text;
                res.Aftor = textBoxAutor.Text;
                res.Ilustr = textBoxImages.Text;
                res.Slova = textBoxKeyWords.Text;
                res.Org = textBoxOrg.Text;
                res.Mesto = textBoxPlace.Text;

                res.nomer = N;

                res.Referat = textBoxReferat.Text;
                res.Gorod = textBoxSity.Text;
                res.Str = textBoxStr.Text;
                res.tema1 = textBoxTema1.Text;
                res.tema2 = textBoxTema2.Text;

                res.God = Year;

            }
            MainForm.dcont.SubmitChanges();
            Close();
        }

        private void inserting_Load(object sender, EventArgs e)
        {
            if (Util.Insert) // Insert
            {
                textBoxName.Text = textBoxAutor.Text = textBoxImages.Text = textBoxKeyWords.Text =
                textBoxOrg.Text = textBoxPlace.Text = textBoxNumber.Text = textBoxReferat.Text =
                textBoxSity.Text = textBoxStr.Text = textBoxTema1.Text = textBoxTema2.Text =
                textBoxYear.Text = String.Empty;
            }
            else // Update
            {
                var res = MainForm.tabDanie.Where(wh => wh.ID == Util.ID).FirstOrDefault();

                textBoxName.Text = res.Naz;
                textBoxAutor.Text = res.Aftor;
                textBoxImages.Text = res.Ilustr;
                textBoxKeyWords.Text = res.Slova;
                textBoxOrg.Text = res.Org;
                textBoxPlace.Text = res.Mesto;
                textBoxNumber.Text = res.nomer.ToString();
                textBoxReferat.Text = res.Referat;
                textBoxSity.Text = res.Gorod;
                textBoxStr.Text = res.Str;
                textBoxTema1.Text = res.tema1;
                textBoxTema2.Text = res.tema2;
                textBoxYear.Text = res.God.ToString();
            }
        }

    }
}
