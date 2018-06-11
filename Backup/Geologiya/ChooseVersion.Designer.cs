namespace Geologiya
{
    partial class ChooseVersion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.OK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "Русскоязычная",
            "Ўзбекча"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(50, 12);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(110, 21);
            this.comboBoxLanguage.TabIndex = 0;
            this.comboBoxLanguage.Text = "Русскоязычная";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(65, 39);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(80, 21);
            this.OK.TabIndex = 1;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // ChooseVersion
            // 
            this.AcceptButton = this.OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 69);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.comboBoxLanguage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChooseVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Версия";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Button OK;
    }
}