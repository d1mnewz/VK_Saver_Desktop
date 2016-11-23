namespace VK_Saver_Desktop
{
    partial class CaptchaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptchaForm));
            this.CaptchaPictureBox = new System.Windows.Forms.PictureBox();
            this.CaptchaTextBox = new System.Windows.Forms.TextBox();
            this.SendCaptchaButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // CaptchaPictureBox
            // 
            this.CaptchaPictureBox.Location = new System.Drawing.Point(50, 12);
            this.CaptchaPictureBox.Name = "CaptchaPictureBox";
            this.CaptchaPictureBox.Size = new System.Drawing.Size(178, 70);
            this.CaptchaPictureBox.TabIndex = 0;
            this.CaptchaPictureBox.TabStop = false;
            // 
            // CaptchaTextBox
            // 
            this.CaptchaTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptchaTextBox.Location = new System.Drawing.Point(86, 102);
            this.CaptchaTextBox.Name = "CaptchaTextBox";
            this.CaptchaTextBox.Size = new System.Drawing.Size(100, 24);
            this.CaptchaTextBox.TabIndex = 1;
            // 
            // SendCaptchaButton
            // 
            this.SendCaptchaButton.Location = new System.Drawing.Point(197, 104);
            this.SendCaptchaButton.Name = "SendCaptchaButton";
            this.SendCaptchaButton.Size = new System.Drawing.Size(75, 23);
            this.SendCaptchaButton.TabIndex = 2;
            this.SendCaptchaButton.Text = "button1";
            this.SendCaptchaButton.UseVisualStyleBackColor = true;
            this.SendCaptchaButton.Click += new System.EventHandler(this.SendCaptchaButton_Click);
            // 
            // CaptchaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 138);
            this.Controls.Add(this.SendCaptchaButton);
            this.Controls.Add(this.CaptchaTextBox);
            this.Controls.Add(this.CaptchaPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CaptchaForm";
            this.Text = "CaptchaForm";
            ((System.ComponentModel.ISupportInitialize)(this.CaptchaPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox CaptchaPictureBox;
        private System.Windows.Forms.TextBox CaptchaTextBox;
        private System.Windows.Forms.Button SendCaptchaButton;
    }
}