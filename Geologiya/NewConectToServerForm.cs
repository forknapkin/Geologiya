using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace Geologiya
{
    public partial class NewConectToServerForm : Form
    {

        string conStr;

        public NewConectToServerForm()
        {
            InitializeComponent();
        }

        private void rbWinAuth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWinAuth.Checked == true)
            {
                label3.Enabled = label4.Enabled = tbLogin.Enabled = tbPassword.Enabled = false;
            }
            else
            {
                label3.Enabled = label4.Enabled = tbLogin.Enabled = tbPassword.Enabled = true;
            }
        }

        private void bTestConnect_Click(object sender, EventArgs e)
        {
            if (!(String.IsNullOrEmpty(tbCPUName.Text) && String.IsNullOrEmpty(tbServerName.Text) && String.IsNullOrEmpty(tbBaseName.Text)))
            {
                //@"Data Source=C3\SERVER1;Initial Catalog=Geolodiya;uid=sa;pwd=123";
                conStr = "Data Source=" + tbCPUName.Text + "\\" + tbServerName.Text + ";" + "Initial Catalog=" + tbBaseName.Text + ";";
                if (rbWinAuth.Checked)
                {
                    conStr += "Integrated Security=True";
                }
                if (rbServerAuth.Checked)
                {
                    if (!(String.IsNullOrEmpty(tbLogin.Text) && String.IsNullOrEmpty(tbPassword.Text)))
                    {
                        conStr += "uid = " + tbLogin.Text + ";" + "pwd = "+tbPassword.Text + ";";
                    }
                }
                //MessageBox.Show(conStr);

                SqlConnection con = new SqlConnection(conStr);

                try
                {
                    con.Open();
                    MessageBox.Show("Есть подключение!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Не могу подключиться! Неверные параметры подключения!");
                    //MessageBox.Show(ex.Message);
                    return;
                }
                finally
                {
                    conStr = String.Empty;
                    con.Close();
                }
                
            }
        }

        private void bOk_Click(object sender, EventArgs e)
        {
            conStr = "Data Source=" + tbCPUName.Text + "\\" + tbServerName.Text + ";" + "Initial Catalog=" + tbBaseName.Text + ";";
            if (rbWinAuth.Checked)
            {
                conStr += "Integrated Security=True";
            }
            if (rbServerAuth.Checked)
            {
                if (!(String.IsNullOrEmpty(tbLogin.Text) && String.IsNullOrEmpty(tbPassword.Text)))
                {
                    conStr += "uid = " + tbLogin.Text + ";" + "pwd = " + tbPassword.Text + ";";
                }
            }
            //MessageBox.Show(conStr);

            FileStream fs = new FileStream("config.ini", FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(conStr);
            writer.Close();
            this.Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
