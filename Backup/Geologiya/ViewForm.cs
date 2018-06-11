using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Geologiya
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
        }

        private void ViewForm_Load(object sender, EventArgs e)
        {
            if (Util.ReportView)
            {
                numberCheckBox.Checked = ReportView.Number;
                tema1CheckBox.Checked = ReportView.Tema1;
                tema2CheckBox.Checked = ReportView.Tema2;
                authorCheckBox.Checked = ReportView.Author;
                nameCheckBox.Checked = ReportView.Name;
                organizationCheckBox.Checked = ReportView.Organization;
                sityCheckBox.Checked = ReportView.Sity;
                yearCheckBox.Checked = ReportView.Year;
                pagesCheckBox.Checked = ReportView.Pages;
                imagesCheckBox.Checked = ReportView.Images;
                keyWordsCheckBox.Checked = ReportView.KeyWords;
                referatCheckBox.Checked = ReportView.Referat;
                placeCheckBox.Checked = ReportView.Place;
            }
            else
            {
                numberCheckBox.Checked = ViewGrid.Number;
                tema1CheckBox.Checked = ViewGrid.Tema1;
                tema2CheckBox.Checked = ViewGrid.Tema2;
                authorCheckBox.Checked = ViewGrid.Author;
                nameCheckBox.Checked = ViewGrid.Name;
                organizationCheckBox.Checked = ViewGrid.Organization;
                sityCheckBox.Checked = ViewGrid.Sity;
                yearCheckBox.Checked = ViewGrid.Year;
                pagesCheckBox.Checked = ViewGrid.Pages;
                imagesCheckBox.Checked = ViewGrid.Images;
                keyWordsCheckBox.Checked = ViewGrid.KeyWords;
                referatCheckBox.Checked = ViewGrid.Referat;
                placeCheckBox.Checked = ViewGrid.Place;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (Util.ReportView)
            {
                ReportView.Number = numberCheckBox.Checked;
                ReportView.Tema1 = tema1CheckBox.Checked;
                ReportView.Tema2 = tema2CheckBox.Checked;
                ReportView.Author = authorCheckBox.Checked;
                ReportView.Name = nameCheckBox.Checked;
                ReportView.Organization = organizationCheckBox.Checked;
                ReportView.Sity = sityCheckBox.Checked;
                ReportView.Year = yearCheckBox.Checked;
                ReportView.Pages = pagesCheckBox.Checked;
                ReportView.Images = imagesCheckBox.Checked;
                ReportView.KeyWords = keyWordsCheckBox.Checked;
                ReportView.Referat = referatCheckBox.Checked;
                ReportView.Place = placeCheckBox.Checked;
            }
            else
            {
                ViewGrid.Number = numberCheckBox.Checked;
                ViewGrid.Tema1 = tema1CheckBox.Checked;
                ViewGrid.Tema2 = tema2CheckBox.Checked;
                ViewGrid.Author = authorCheckBox.Checked;
                ViewGrid.Name = nameCheckBox.Checked;
                ViewGrid.Organization = organizationCheckBox.Checked;
                ViewGrid.Sity = sityCheckBox.Checked;
                ViewGrid.Year = yearCheckBox.Checked;
                ViewGrid.Pages = pagesCheckBox.Checked;
                ViewGrid.Images = imagesCheckBox.Checked;
                ViewGrid.KeyWords = keyWordsCheckBox.Checked;
                ViewGrid.Referat = referatCheckBox.Checked;
                ViewGrid.Place = placeCheckBox.Checked;
            }
            Close();
        }




    }
}
