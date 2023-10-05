namespace RichTextScreensaver
{
    partial class SettingsForm
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
            this.openFileDlg1 = new System.Windows.Forms.OpenFileDialog();
            this.btn_selectFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // openFileDlg1
            // 
            this.openFileDlg1.FileName = "openFileDlg1";
            this.openFileDlg1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDlg1_FileOk);
            // 
            // btn_selectFile
            // 
            this.btn_selectFile.Location = new System.Drawing.Point(377, 39);
            this.btn_selectFile.Name = "btn_selectFile";
            this.btn_selectFile.Size = new System.Drawing.Size(75, 23);
            this.btn_selectFile.TabIndex = 0;
            this.btn_selectFile.Text = "Select File";
            this.btn_selectFile.UseVisualStyleBackColor = true;
            this.btn_selectFile.Click += new System.EventHandler(this.btn_selectFile_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 41);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(359, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Specify path to RTF file:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(396, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "You can create a RTF file using \"WordPad\" wich comes preinstalled wit Windows.";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 211);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_selectFile);
            this.Name = "SettingsForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.On_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDlg1;
        private System.Windows.Forms.Button btn_selectFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}