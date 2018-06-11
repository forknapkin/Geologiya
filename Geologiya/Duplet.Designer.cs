namespace Geologiya
{
    partial class Duplet
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
            this.button1 = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.dupletGrid = new System.Windows.Forms.DataGridView();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dupletGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(23, 438);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Удалить выбранные";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(168, 438);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(93, 23);
            this.EditButton.TabIndex = 8;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // dupletGrid
            // 
            this.dupletGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dupletGrid.Location = new System.Drawing.Point(12, 28);
            this.dupletGrid.Name = "dupletGrid";
            this.dupletGrid.Size = new System.Drawing.Size(639, 393);
            this.dupletGrid.StandardTab = true;
            this.dupletGrid.TabIndex = 7;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(541, 439);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // OKbutton
            // 
            this.OKbutton.Location = new System.Drawing.Point(443, 438);
            this.OKbutton.Name = "OKbutton";
            this.OKbutton.Size = new System.Drawing.Size(75, 23);
            this.OKbutton.TabIndex = 5;
            this.OKbutton.Text = "OK";
            this.OKbutton.UseVisualStyleBackColor = true;
            // 
            // Duplet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 491);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.dupletGrid);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKbutton);
            this.Name = "Duplet";
            this.Text = "Повторяющиеся записи";
            ((System.ComponentModel.ISupportInitialize)(this.dupletGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.DataGridView dupletGrid;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKbutton;
    }
}