namespace Geologiya
{
    partial class NewUserForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.tbPass1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPass2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Логин";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(23, 163);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 1;
            this.buttonOk.Text = "Ok";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(23, 29);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(183, 20);
            this.tbLogin.TabIndex = 2;
            // 
            // tbPass1
            // 
            this.tbPass1.Location = new System.Drawing.Point(23, 70);
            this.tbPass1.Name = "tbPass1";
            this.tbPass1.PasswordChar = '*';
            this.tbPass1.Size = new System.Drawing.Size(183, 20);
            this.tbPass1.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Пароль";
            // 
            // tbPass2
            // 
            this.tbPass2.Location = new System.Drawing.Point(23, 112);
            this.tbPass2.Name = "tbPass2";
            this.tbPass2.PasswordChar = '*';
            this.tbPass2.Size = new System.Drawing.Size(183, 20);
            this.tbPass2.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Повторите пароль";
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(131, 163);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 7;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // NewUserForm
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(234, 207);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.tbPass2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbPass1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbLogin);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(250, 245);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(250, 245);
            this.Name = "NewUserForm";
            this.Text = "Новый пользователь";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.TextBox tbPass1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPass2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCancel;
    }
}