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
    public partial class AuthorizationForm : Form
    {
        public AuthorizationForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AuthorizationForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            User us = new User
            {
                UserName = tbLogin.Text,
                Password = tbPass.Text
            };
            Util.IsAuthotization = MainForm.tabUsers.Contains<User>(us);
            //MessageBox.Show(Util.IsAuthotization.ToString());
            this.Close();
        }
    }
}
