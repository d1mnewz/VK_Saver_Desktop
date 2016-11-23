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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.LoginBox = new System.Windows.Forms.TextBox();
            this.PassBox = new System.Windows.Forms.TextBox();
            this.LogLabel = new System.Windows.Forms.Label();
            this.PassLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.AlbumsList = new System.Windows.Forms.ListBox();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.CurrentTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.IdTextBox = new System.Windows.Forms.TextBox();
            this.AlbumsByUserIdButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LoginBox
            // 
            this.LoginBox.BackColor = System.Drawing.Color.White;
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
            this.PassBox.Enter += new System.EventHandler(this.PassBox_Enter);
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
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Location = new System.Drawing.Point(227, 9);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(47, 13);
            this.TimeLabel.TabIndex = 5;
            this.TimeLabel.Text = "4:20 AM";
            // 
            // AlbumsList
            // 
            this.AlbumsList.Enabled = false;
            this.AlbumsList.FormattingEnabled = true;
            this.AlbumsList.Location = new System.Drawing.Point(12, 155);
            this.AlbumsList.Name = "AlbumsList";
            this.AlbumsList.Size = new System.Drawing.Size(120, 95);
            this.AlbumsList.TabIndex = 6;
            this.AlbumsList.DoubleClick += new System.EventHandler(this.AlbumsList_DoubleClick);
            // 
            // DownloadButton
            // 
            this.DownloadButton.Location = new System.Drawing.Point(199, 227);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(75, 23);
            this.DownloadButton.TabIndex = 7;
            this.DownloadButton.Text = "DownLoad";
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // CurrentTimeTimer
            // 
            this.CurrentTimeTimer.Interval = 1000;
            this.CurrentTimeTimer.Tick += new System.EventHandler(this.CurrentTimeTimer_Tick);
            // 
            // IdTextBox
            // 
            this.IdTextBox.Location = new System.Drawing.Point(12, 130);
            this.IdTextBox.Name = "IdTextBox";
            this.IdTextBox.Size = new System.Drawing.Size(120, 20);
            this.IdTextBox.TabIndex = 9;
            // 
            // AlbumsByUserIdButton
            // 
            this.AlbumsByUserIdButton.Location = new System.Drawing.Point(168, 130);
            this.AlbumsByUserIdButton.Name = "AlbumsByUserIdButton";
            this.AlbumsByUserIdButton.Size = new System.Drawing.Size(75, 23);
            this.AlbumsByUserIdButton.TabIndex = 10;
            this.AlbumsByUserIdButton.Text = "Get Albums";
            this.AlbumsByUserIdButton.UseVisualStyleBackColor = true;
            this.AlbumsByUserIdButton.Click += new System.EventHandler(this.AlbumsByUserIdButton_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.AlbumsByUserIdButton);
            this.Controls.Add(this.IdTextBox);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.AlbumsList);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.PassLabel);
            this.Controls.Add(this.LogLabel);
            this.Controls.Add(this.PassBox);
            this.Controls.Add(this.LoginBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.Text = "VK AlbumSaver tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox LoginBox;
        private System.Windows.Forms.TextBox PassBox;
        private System.Windows.Forms.Label LogLabel;
        private System.Windows.Forms.Label PassLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.ListBox AlbumsList;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.Timer CurrentTimeTimer;
        private System.Windows.Forms.TextBox IdTextBox;
        private System.Windows.Forms.Button AlbumsByUserIdButton;
    }
}

