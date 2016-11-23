namespace VK_Saver_Desktop
{
    partial class PicturesOfAlbum
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PicturesOfAlbum));
            this.PicturesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.LoadMoreButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PicturesPanel
            // 
            this.PicturesPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.PicturesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PicturesPanel.Location = new System.Drawing.Point(0, 0);
            this.PicturesPanel.Name = "PicturesPanel";
            this.PicturesPanel.Size = new System.Drawing.Size(669, 404);
            this.PicturesPanel.TabIndex = 0;
            // 
            // LoadMoreButton
            // 
            this.LoadMoreButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.LoadMoreButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadMoreButton.Location = new System.Drawing.Point(0, 371);
            this.LoadMoreButton.Name = "LoadMoreButton";
            this.LoadMoreButton.Size = new System.Drawing.Size(669, 33);
            this.LoadMoreButton.TabIndex = 0;
            this.LoadMoreButton.Text = "Load more...";
            this.LoadMoreButton.UseVisualStyleBackColor = true;
            this.LoadMoreButton.Click += new System.EventHandler(this.LoadMoreButton_Click);
            // 
            // PicturesOfAlbum
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 404);
            this.Controls.Add(this.LoadMoreButton);
            this.Controls.Add(this.PicturesPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PicturesOfAlbum";
            this.Text = "PicturesOfAlbum";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel PicturesPanel;
        private System.Windows.Forms.Button LoadMoreButton;
    }
}