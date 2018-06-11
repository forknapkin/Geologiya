namespace Geologiya
{
    partial class AuthorizationForm
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
            this.tbLogin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbLogin
            // 
            this.tbLogin.Location = new System.Drawing.Point(43, 39);
            this.tbLogin.Name = "tbLogin";
            this.tbLogin.Size = new System.Drawing.Size(140, 20);
            this.tbLogin.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Логин";
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(30, 127);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 4;
            this.OkButton.Text = "Ok";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(43, 89);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(140, 20);
            this.tbPass.TabIndex = 3;
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(132, 127);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // AuthorizationForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 182);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbLogin);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(245, 220);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(245, 220);
            this.Name = "AuthorizationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Авторизация";
            this.Load += new System.EventHandler(this.AuthorizationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.Button CancelButton;
    }
}