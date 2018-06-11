using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace Geologiya
{
    public partial class ChooseVersion : Form
    {
        public ChooseVersion()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            Util.language = comboBoxLanguage.Text;
            this.Close();
        }
    }
}
