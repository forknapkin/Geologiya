namespace Geologiya
{
    partial class NewConectToServerForm
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
            this.bTestConnect = new System.Windows.Forms.Button();
            this.tbCPUName = new System.Windows.Forms.TextBox();
            this.tbServerName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbWinAuth = new System.Windows.Forms.RadioButton();
            this.rbServerAuth = new System.Windows.Forms.RadioButton();
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbBaseName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bOk = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя компьютера";
            // 
            // bTestConnect
            // 
            this.bTestConnect.Location = new System.Drawing.Point(172, 360);
            this.bTestConnect.Name = "bTestConnect";
            this.bTestConnect.Size = new System.Drawing.Size(75, 23);
            this.bTestConnect.TabIndex = 1;
            this.bTestConnect.Text = "Test";
            this.bTestConnect.UseVisualStyleBackColor = true;
            this.bTestConnect.Click += new System.EventHandler(this.bTestConnect_Click);
            // 
            // tbCPUName
            // 
            this.tbCPUName.Location = new System.Drawing.Point(12, 35);
            this.tbCPUName.Name = "tbCPUName";
            this.tbCPUName.Size = new System.Drawing.Size(160, 20);
            this.tbCPUName.TabIndex = 2;
            // 
            // tbServerName
            // 
            this.tbServerName.Location = new System.Drawing.Point(12, 78);
            this.tbServerName.Name = "tbServerName";
            this.tbServerName.Size = new System.Drawing.Size(160, 20);
            this.tbServerName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Имя сервера";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbPassword);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tbLogin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rbServerAuth);
            this.groupBox1.Controls.Add(this.rbWinAuth);
            this.groupBox1.Location = new System.Drawing.Point(15, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(244, 181);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Аутентификация";
            // 
            // rbWinAuth
            // 
            this.rbWinAuth.AutoSize = true;
            this.rbWinAuth.Checked = true;
            this.rbWinAuth.Location = new System.Drawing.Point(31, 28);
            this.rbWinAuth.Name = "rbWinAuth";
            this.rbWinAuth.Size = new System.Drawing.Size(156, 17);
            this.rbWinAuth.TabIndex = 0;
            this.rbWinAuth.TabStop = true;
            this.rbWinAuth.Text = "Аутентификация Windows";
            this.rbWinAuth.UseVisualStyleBackColor = true;
            this.rbWinAuth.CheckedChanged += new System.EventHandler(this.rbWinAuth_CheckedChanged);
            // 
            // rbServerAuth
            // 
            this.rbServerAuth.AutoSize = true;
            this.rbServerAuth.Location = new System.Drawing.Point(31, 51);
            this.rbServerAuth.Name = "rbServerAuth";
            this.rbServerAuth.Size = new System.Drawing.Size(169, 17);
            this.rbServerAuth.TabIndex = 1;
            this.rbServerAuth.Text = "Аутентификация на сервере";
            this.rbServerAuth.UseVisualStyleBackColor = true;
            // 
            // tbLogin
            // 
            this.tbLogin.Enabled = false;
            this.tbLogin.Location = new System.Drawing.Point(31, 89);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(160, 20);
            this.tbLogin.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(31, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Login";
            // 
            // tbPassword
            // 
            this.tbPassword.Enabled = false;
            this.tbPassword.Location = new System.Drawing.Point(31, 129);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(160, 20);
            this.tbPassword.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Enabled = false;
            this.label4.Location = new System.Drawing.Point(31, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Password";
            // 
            // tbBaseName
            // 
            this.tbBaseName.Location = new System.Drawing.Point(15, 323);
            this.tbBaseName.Name = "tbBaseName";
            this.tbBaseName.Size = new System.Drawing.Size(160, 20);
            this.tbBaseName.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 307);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Имя Базы";
            // 
            // bOk
            // 
            this.bOk.Location = new System.Drawing.Point(72, 418);
            this.bOk.Name = "bOk";
            this.bOk.Size = new System.Drawing.Size(75, 23);
            this.bOk.TabIndex = 8;
            this.bOk.Text = "Ok";
            this.bOk.UseVisualStyleBackColor = true;
            this.bOk.Click += new System.EventHandler(this.bOk_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Location = new System.Drawing.Point(172, 418);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // NewConectToServerForm
            // 
            this.AcceptButton = this.bOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(284, 462);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bOk);
            this.Controls.Add(this.tbBaseName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tbServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbCPUName);
            this.Controls.Add(this.bTestConnect);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 500);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 500);
            this.Name = "NewConectToServerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Соединение с сервером";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTestConnect;
        private System.Windows.Forms.TextBox tbCPUName;
        private System.Windows.Forms.TextBox tbServerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbWinAuth;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbServerAuth;
        private System.Windows.Forms.TextBox tbBaseName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bOk;
        private System.Windows.Forms.Button bCancel;
    }
}