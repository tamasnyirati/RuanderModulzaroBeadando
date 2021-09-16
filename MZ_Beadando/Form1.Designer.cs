
namespace MZ_Beadando
{
    partial class Form1
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
            this.FuvartFelvesz_btn = new System.Windows.Forms.Button();
            this.FuvartTorol_btn = new System.Windows.Forms.Button();
            this.Fuvar_lbx = new System.Windows.Forms.ListBox();
            this.Kilepes_btn = new System.Windows.Forms.Button();
            this.FuvAdatokMent_btn = new System.Windows.Forms.Button();
            this.arKalk_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fuvarok: ";
            // 
            // FuvartFelvesz_btn
            // 
            this.FuvartFelvesz_btn.Location = new System.Drawing.Point(16, 167);
            this.FuvartFelvesz_btn.Name = "FuvartFelvesz_btn";
            this.FuvartFelvesz_btn.Size = new System.Drawing.Size(75, 23);
            this.FuvartFelvesz_btn.TabIndex = 2;
            this.FuvartFelvesz_btn.Text = "Felvesz";
            this.FuvartFelvesz_btn.UseVisualStyleBackColor = true;
            this.FuvartFelvesz_btn.Click += new System.EventHandler(this.FuvartFelvesz_btn_Click);
            // 
            // FuvartTorol_btn
            // 
            this.FuvartTorol_btn.Location = new System.Drawing.Point(123, 167);
            this.FuvartTorol_btn.Name = "FuvartTorol_btn";
            this.FuvartTorol_btn.Size = new System.Drawing.Size(75, 23);
            this.FuvartTorol_btn.TabIndex = 3;
            this.FuvartTorol_btn.Text = "Töröl";
            this.FuvartTorol_btn.UseVisualStyleBackColor = true;
            this.FuvartTorol_btn.Click += new System.EventHandler(this.FuvartTorol_btn_Click);
            // 
            // Fuvar_lbx
            // 
            this.Fuvar_lbx.FormattingEnabled = true;
            this.Fuvar_lbx.Location = new System.Drawing.Point(71, 39);
            this.Fuvar_lbx.Name = "Fuvar_lbx";
            this.Fuvar_lbx.Size = new System.Drawing.Size(342, 108);
            this.Fuvar_lbx.TabIndex = 4;
            this.Fuvar_lbx.Click += new System.EventHandler(this.Fuvar_lbx_Click);
            this.Fuvar_lbx.DoubleClick += new System.EventHandler(this.Fuvar_lbx_DoubleClick);
            // 
            // Kilepes_btn
            // 
            this.Kilepes_btn.Location = new System.Drawing.Point(16, 223);
            this.Kilepes_btn.Name = "Kilepes_btn";
            this.Kilepes_btn.Size = new System.Drawing.Size(75, 23);
            this.Kilepes_btn.TabIndex = 5;
            this.Kilepes_btn.Text = "Kilépés";
            this.Kilepes_btn.UseVisualStyleBackColor = true;
            this.Kilepes_btn.Click += new System.EventHandler(this.Kilepes_btn_Click);
            // 
            // FuvAdatokMent_btn
            // 
            this.FuvAdatokMent_btn.Location = new System.Drawing.Point(123, 223);
            this.FuvAdatokMent_btn.Name = "FuvAdatokMent_btn";
            this.FuvAdatokMent_btn.Size = new System.Drawing.Size(132, 23);
            this.FuvAdatokMent_btn.TabIndex = 6;
            this.FuvAdatokMent_btn.Text = "Fuvar adatok mentése fájlba";
            this.FuvAdatokMent_btn.UseVisualStyleBackColor = true;
            this.FuvAdatokMent_btn.Click += new System.EventHandler(this.FuvAdatokMent_btn_Click);
            // 
            // arKalk_btn
            // 
            this.arKalk_btn.Location = new System.Drawing.Point(300, 223);
            this.arKalk_btn.Name = "arKalk_btn";
            this.arKalk_btn.Size = new System.Drawing.Size(75, 23);
            this.arKalk_btn.TabIndex = 7;
            this.arKalk_btn.Text = "Árkalkuláció";
            this.arKalk_btn.UseVisualStyleBackColor = true;
            this.arKalk_btn.Click += new System.EventHandler(this.arKalk_btn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 258);
            this.Controls.Add(this.arKalk_btn);
            this.Controls.Add(this.FuvAdatokMent_btn);
            this.Controls.Add(this.Kilepes_btn);
            this.Controls.Add(this.Fuvar_lbx);
            this.Controls.Add(this.FuvartTorol_btn);
            this.Controls.Add(this.FuvartFelvesz_btn);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button FuvartFelvesz_btn;
        private System.Windows.Forms.Button FuvartTorol_btn;
        private System.Windows.Forms.ListBox Fuvar_lbx;
        private System.Windows.Forms.Button Kilepes_btn;
        private System.Windows.Forms.Button FuvAdatokMent_btn;
        private System.Windows.Forms.Button arKalk_btn;
    }
}

