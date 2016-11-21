namespace VK_Saver_Desktop
{
    partial class AuthForm
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
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.CountLabel = new System.Windows.Forms.Label();
            this.AlbumsList = new System.Windows.Forms.ListBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.CaptchBox = new System.Windows.Forms.PictureBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.Location = new System.Drawing.Point(90, 46);
            this.LoginBox.Name = "LoginBox";
            this.LoginBox.Size = new System.Drawing.Size(153, 20);
            this.LoginBox.TabIndex = 0;
            // 
            // PassBox
            // 
            this.PassBox.Location = new System.Drawing.Point(90, 72);
            this.PassBox.Name = "PassBox";
            this.PassBox.PasswordChar = '*';
            this.PassBox.Size = new System.Drawing.Size(153, 20);
            this.PassBox.TabIndex = 1;
            // 
            // LogLabel
            // 
            this.LogLabel.AutoSize = true;
            this.LogLabel.Location = new System.Drawing.Point(12, 53);
            this.LogLabel.Name = "LogLabel";
            this.LogLabel.Size = new System.Drawing.Size(33, 13);
            this.LogLabel.TabIndex = 2;
            this.LogLabel.Text = "Login";
            // 
            // PassLabel
            // 
            this.PassLabel.AutoSize = true;
            this.PassLabel.Location = new System.Drawing.Point(12, 75);
            this.PassLabel.Name = "PassLabel";
            this.PassLabel.Size = new System.Drawing.Size(53, 13);
            this.PassLabel.TabIndex = 3;
            this.PassLabel.Text = "Password";
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(90, 98);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(75, 23);
            this.SubmitButton.TabIndex = 4;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // CountLabel
            // 
            this.CountLabel.AutoSize = true;
            this.CountLabel.Location = new System.Drawing.Point(227, 9);
            this.CountLabel.Name = "CountLabel";
            this.CountLabel.Size = new System.Drawing.Size(35, 13);
            this.CountLabel.TabIndex = 5;
            this.CountLabel.Text = "label1";
            // 
            // AlbumsList
            // 
            this.AlbumsList.Enabled = false;
            this.AlbumsList.FormattingEnabled = true;
            this.AlbumsList.Location = new System.Drawing.Point(15, 127);
            this.AlbumsList.Name = "AlbumsList";
            this.AlbumsList.Size = new System.Drawing.Size(120, 95);
            this.AlbumsList.TabIndex = 6;
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(168, 159);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 7;
            this.DownloadButton.Text = "DownLoad";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // CaptchBox
            // 
            this.CaptchBox.Location = new System.Drawing.Point(162, 200);
            this.CaptchBox.Name = "CaptchBox";
            this.CaptchBox.Size = new System.Drawing.Size(100, 50);
            this.CaptchBox.TabIndex = 8;
            this.CaptchBox.TabStop = false;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Location = new System.Drawing.Point(56, 230);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(100, 20);
            this.CaptchaTextBox.TabIndex = 9;
            this.CaptchaTextBox.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(42, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.CaptchBox);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.AlbumsList);
            this.Controls.Add(this.CountLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.LoginBox);
            this.Name = "AuthForm";
            this.Text = "Form1";
            
            ((System.ComponentModel.ISupportInitialize)(this.CaptchBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label CountLabel;
        private System.Windows.Forms.ListBox AlbumsList;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.PictureBox CaptchBox;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.Button button1;
    }
}

