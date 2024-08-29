namespace RdsTextCompare1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSelectFile1 = new Button();
            btnSelectFile2 = new Button();
            rtbFileContent1 = new RichTextBox();
            rtbFileContent2 = new RichTextBox();
            btnCompare = new Button();
            SuspendLayout();
            // 
            // btnSelectFile1
            // 
            btnSelectFile1.Location = new Point(127, 29);
            btnSelectFile1.Name = "btnSelectFile1";
            btnSelectFile1.Size = new Size(201, 47);
            btnSelectFile1.TabIndex = 0;
            btnSelectFile1.Text = "Dosya Seç";
            btnSelectFile1.UseVisualStyleBackColor = true;
            btnSelectFile1.Click += btnSelectFile1_Click;
            // 
            // btnSelectFile2
            // 
            btnSelectFile2.Location = new Point(559, 29);
            btnSelectFile2.Name = "btnSelectFile2";
            btnSelectFile2.Size = new Size(205, 47);
            btnSelectFile2.TabIndex = 1;
            btnSelectFile2.Text = "Dosya Seç";
            btnSelectFile2.UseVisualStyleBackColor = true;
            btnSelectFile2.Click += btnSelectFile2_Click;
            // 
            // rtbFileContent1
            // 
            rtbFileContent1.Location = new Point(12, 98);
            rtbFileContent1.Name = "rtbFileContent1";
            rtbFileContent1.Size = new Size(412, 406);
            rtbFileContent1.TabIndex = 2;
            rtbFileContent1.Text = "";
            // 
            // rtbFileContent2
            // 
            rtbFileContent2.Location = new Point(463, 98);
            rtbFileContent2.Name = "rtbFileContent2";
            rtbFileContent2.Size = new Size(412, 406);
            rtbFileContent2.TabIndex = 3;
            rtbFileContent2.Text = "";
            rtbFileContent2.TextChanged += rtbFileContent2_TextChanged_1;
            // 
            // btnCompare
            // 
            btnCompare.Location = new Point(331, 565);
            btnCompare.Name = "btnCompare";
            btnCompare.Size = new Size(202, 38);
            btnCompare.TabIndex = 4;
            btnCompare.Text = "Karşılaştır";
            btnCompare.UseVisualStyleBackColor = true;
            btnCompare.Click += btnCompare_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(892, 701);
            Controls.Add(btnCompare);
            Controls.Add(rtbFileContent2);
            Controls.Add(rtbFileContent1);
            Controls.Add(btnSelectFile2);
            Controls.Add(btnSelectFile1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button btnSelectFile1;
        private Button btnSelectFile2;
        private RichTextBox rtbFileContent1;
        private RichTextBox rtbFileContent2;
        private Button btnCompare;
    }
}
