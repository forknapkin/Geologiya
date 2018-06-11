namespace Geologiya
{
    partial class DupletForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DupletForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.dupletGrid = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dupletGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.AccessibleDescription = null;
            this.panel2.AccessibleName = null;
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BackgroundImage = null;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.EditButton);
            this.panel2.Controls.Add(this.CancelButton);
            this.panel2.Font = null;
            this.panel2.Name = "panel2";
            // 
            // button1
            // 
            this.button1.AccessibleDescription = null;
            this.button1.AccessibleName = null;
            resources.ApplyResources(this.button1, "button1");
            this.button1.BackgroundImage = null;
            this.button1.Font = null;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EditButton
            // 
            this.EditButton.AccessibleDescription = null;
            this.EditButton.AccessibleName = null;
            resources.ApplyResources(this.EditButton, "EditButton");
            this.EditButton.BackgroundImage = null;
            this.EditButton.Font = null;
            this.EditButton.Name = "EditButton";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.AccessibleDescription = null;
            this.CancelButton.AccessibleName = null;
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.BackgroundImage = null;
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Font = null;
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // dupletGrid
            // 
            this.dupletGrid.AccessibleDescription = null;
            this.dupletGrid.AccessibleName = null;
            this.dupletGrid.AllowUserToAddRows = false;
            resources.ApplyResources(this.dupletGrid, "dupletGrid");
            this.dupletGrid.BackgroundImage = null;
            this.dupletGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dupletGrid.Font = null;
            this.dupletGrid.MultiSelect = false;
            this.dupletGrid.Name = "dupletGrid";
            // 
            // DupletForm
            // 
            this.AccessibleDescription = null;
            this.AccessibleName = null;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = null;
            this.Controls.Add(this.dupletGrid);
            this.Controls.Add(this.panel2);
            this.Font = null;
            this.Icon = null;
            this.Name = "DupletForm";
            this.Load += new System.EventHandler(this.DupletForm_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dupletGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dupletGrid;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button CancelButton;

    }
}