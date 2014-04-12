namespace iTEC2014
{
    partial class UserBrowseForm
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
            this.welcomeMessageLabel = new System.Windows.Forms.Label();
            this.welcomeHeaderLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.browsePanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.itemHeaderPanel = new System.Windows.Forms.Panel();
            this.itemLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.categoryPanel = new System.Windows.Forms.Panel();
            this.categoryHeaderPanel = new System.Windows.Forms.Panel();
            this.categoryLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusPanel.SuspendLayout();
            this.browsePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.itemHeaderPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.categoryHeaderPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // welcomeMessageLabel
            // 
            this.welcomeMessageLabel.Font = new System.Drawing.Font("Calibri", 13F);
            this.welcomeMessageLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeMessageLabel.Location = new System.Drawing.Point(81, 49);
            this.welcomeMessageLabel.Name = "welcomeMessageLabel";
            this.welcomeMessageLabel.Size = new System.Drawing.Size(500, 22);
            this.welcomeMessageLabel.TabIndex = 31;
            this.welcomeMessageLabel.Text = "\"Lorem ipsum dolor sit amet!\" - Albert Einstein";
            this.welcomeMessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // welcomeHeaderLabel
            // 
            this.welcomeHeaderLabel.Font = new System.Drawing.Font("Calibri", 20F);
            this.welcomeHeaderLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.welcomeHeaderLabel.Location = new System.Drawing.Point(79, 8);
            this.welcomeHeaderLabel.Name = "welcomeHeaderLabel";
            this.welcomeHeaderLabel.Size = new System.Drawing.Size(425, 33);
            this.welcomeHeaderLabel.TabIndex = 30;
            this.welcomeHeaderLabel.Text = "WELCOME, PLACEHOLDER!";
            this.welcomeHeaderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::iTEC2014.Properties.Resources.WelcomeIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(89)))), ((int)(((byte)(101)))));
            this.statusPanel.Controls.Add(this.pointsLabel);
            this.statusPanel.Controls.Add(this.pictureBox1);
            this.statusPanel.Controls.Add(this.welcomeMessageLabel);
            this.statusPanel.Controls.Add(this.welcomeHeaderLabel);
            this.statusPanel.Location = new System.Drawing.Point(50, 12);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(700, 83);
            this.statusPanel.TabIndex = 32;
            // 
            // pointsLabel
            // 
            this.pointsLabel.Font = new System.Drawing.Font("Calibri", 13F);
            this.pointsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.pointsLabel.Location = new System.Drawing.Point(587, 49);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(101, 22);
            this.pointsLabel.TabIndex = 32;
            this.pointsLabel.Text = "POINTS: 0";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // browsePanel
            // 
            this.browsePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(89)))), ((int)(((byte)(101)))));
            this.browsePanel.Controls.Add(this.panel4);
            this.browsePanel.Controls.Add(this.panel3);
            this.browsePanel.Location = new System.Drawing.Point(50, 101);
            this.browsePanel.Name = "browsePanel";
            this.browsePanel.Size = new System.Drawing.Size(700, 372);
            this.browsePanel.TabIndex = 33;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.itemPanel);
            this.panel4.Controls.Add(this.itemHeaderPanel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(220, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 372);
            this.panel4.TabIndex = 1;
            // 
            // itemPanel
            // 
            this.itemPanel.AutoScroll = true;
            this.itemPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemPanel.Location = new System.Drawing.Point(0, 50);
            this.itemPanel.Name = "itemPanel";
            this.itemPanel.Size = new System.Drawing.Size(480, 322);
            this.itemPanel.TabIndex = 2;
            // 
            // itemHeaderPanel
            // 
            this.itemHeaderPanel.Controls.Add(this.itemLabel);
            this.itemHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.itemHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.itemHeaderPanel.Name = "itemHeaderPanel";
            this.itemHeaderPanel.Size = new System.Drawing.Size(480, 50);
            this.itemHeaderPanel.TabIndex = 1;
            // 
            // itemLabel
            // 
            this.itemLabel.Font = new System.Drawing.Font("Calibri", 17F);
            this.itemLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.itemLabel.Location = new System.Drawing.Point(10, 10);
            this.itemLabel.Name = "itemLabel";
            this.itemLabel.Size = new System.Drawing.Size(458, 30);
            this.itemLabel.TabIndex = 31;
            this.itemLabel.Text = "ITEM";
            this.itemLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.categoryPanel);
            this.panel3.Controls.Add(this.categoryHeaderPanel);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 372);
            this.panel3.TabIndex = 0;
            // 
            // categoryPanel
            // 
            this.categoryPanel.AutoScroll = true;
            this.categoryPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.categoryPanel.Location = new System.Drawing.Point(0, 50);
            this.categoryPanel.Name = "categoryPanel";
            this.categoryPanel.Size = new System.Drawing.Size(220, 322);
            this.categoryPanel.TabIndex = 1;
            // 
            // categoryHeaderPanel
            // 
            this.categoryHeaderPanel.Controls.Add(this.categoryLabel);
            this.categoryHeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.categoryHeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.categoryHeaderPanel.Name = "categoryHeaderPanel";
            this.categoryHeaderPanel.Size = new System.Drawing.Size(220, 50);
            this.categoryHeaderPanel.TabIndex = 0;
            // 
            // categoryLabel
            // 
            this.categoryLabel.Font = new System.Drawing.Font("Calibri", 17F);
            this.categoryLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.categoryLabel.Location = new System.Drawing.Point(10, 10);
            this.categoryLabel.Name = "categoryLabel";
            this.categoryLabel.Size = new System.Drawing.Size(200, 30);
            this.categoryLabel.TabIndex = 31;
            this.categoryLabel.Text = "CATEGORY";
            this.categoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UserBrowseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.browsePanel);
            this.Controls.Add(this.statusPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserBrowseForm";
            this.Text = "UserBrowseForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusPanel.ResumeLayout(false);
            this.browsePanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.itemHeaderPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.categoryHeaderPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label welcomeMessageLabel;
        private System.Windows.Forms.Label welcomeHeaderLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.Panel browsePanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel categoryHeaderPanel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.Panel itemHeaderPanel;
        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Panel categoryPanel;
    }
}