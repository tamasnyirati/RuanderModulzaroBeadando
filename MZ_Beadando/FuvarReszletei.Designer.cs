
namespace MZ_Beadando
{
    partial class FuvarReszletei
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
            this.fuvarReszlet_ListBox = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fuvarReszlet_ListBox
            // 
            this.fuvarReszlet_ListBox.FormattingEnabled = true;
            this.fuvarReszlet_ListBox.Location = new System.Drawing.Point(53, 104);
            this.fuvarReszlet_ListBox.Name = "fuvarReszlet_ListBox";
            this.fuvarReszlet_ListBox.Size = new System.Drawing.Size(536, 95);
            this.fuvarReszlet_ListBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(252, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "A kiválasztott fuvar részletei";
            // 
            // FuvarReszletei
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(685, 245);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fuvarReszlet_ListBox);
            this.Name = "FuvarReszletei";
            this.Text = "FuvarReszletei";
            this.Load += new System.EventHandler(this.FuvarReszletei_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox fuvarReszlet_ListBox;
        private System.Windows.Forms.Label label1;
    }
}