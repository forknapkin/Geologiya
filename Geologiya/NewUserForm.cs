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
    public partial class NewUserForm : Form
    {
        public NewUserForm()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (tbPass1.Text == tbPass2.Text && !String.IsNullOrEmpty(tbPass1.Text) && !String.IsNullOrEmpty(tbPass2.Text) && !String.IsNullOrEmpty(tbLogin.Text))
            {
                User user = new User
                {
                    Password = tbPass1.Text,
                    UserName = tbLogin.Text
                };

                MainForm.dcont.Users.InsertOnSubmit(user);
                MainForm.dcont.SubmitChanges();
                this.Close();

            }
            else
            {
                MessageBox.Show("Проверьте правильность заполнения полей!");
            }
        }
    }
}
