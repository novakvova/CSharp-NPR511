namespace MyWinForms
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
            btnOk = new Button();
            txtPath = new TextBox();
            label1 = new Label();
            txtFileContent = new TextBox();
            SuspendLayout();
            // 
            // btnOk
            // 
            btnOk.Location = new Point(539, 30);
            btnOk.Name = "btnOk";
            btnOk.Size = new Size(222, 57);
            btnOk.TabIndex = 0;
            btnOk.Text = "Прочитати вміст файлу";
            btnOk.UseVisualStyleBackColor = true;
            btnOk.Click += btnOk_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(28, 56);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(452, 31);
            txtPath.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 19);
            label1.Name = "label1";
            label1.Size = new Size(198, 25);
            label1.TabIndex = 2;
            label1.Text = "Вкажіть шлях до файлу";
            // 
            // txtFileContent
            // 
            txtFileContent.Location = new Point(28, 109);
            txtFileContent.Multiline = true;
            txtFileContent.Name = "txtFileContent";
            txtFileContent.ScrollBars = ScrollBars.Vertical;
            txtFileContent.Size = new Size(733, 315);
            txtFileContent.TabIndex = 3;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 454);
            Controls.Add(txtFileContent);
            Controls.Add(label1);
            Controls.Add(txtPath);
            Controls.Add(btnOk);
            Name = "Form1";
            Text = "Наша форма";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOk;
        private TextBox txtPath;
        private Label label1;
        private TextBox txtFileContent;
    }
}
