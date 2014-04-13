namespace iTEC2014
{
    partial class ManagementForm
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
            this.itemLabel = new System.Windows.Forms.Label();
            this.browsePanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.itemPanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.addDataButton = new System.Windows.Forms.Button();
            this.itemHeaderPanel = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.categoryPanel = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addSetButton = new System.Windows.Forms.Button();
            this.categoryHeaderPanel = new System.Windows.Forms.Panel();
            this.categoryLabel = new System.Windows.Forms.Label();
            this.statusPanel = new System.Windows.Forms.Panel();
            this.viewItemsButton = new System.Windows.Forms.Button();
            this.viewUsersButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.descriptionLabel = new System.Windows.Forms.Label();
            this.managementLabel = new System.Windows.Forms.Label();
            this.browsePanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.itemHeaderPanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.categoryHeaderPanel.SuspendLayout();
            this.statusPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
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
            // browsePanel
            // 
            this.browsePanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(89)))), ((int)(((byte)(101)))));
            this.browsePanel.Controls.Add(this.panel4);
            this.browsePanel.Controls.Add(this.panel3);
            this.browsePanel.Location = new System.Drawing.Point(50, 101);
            this.browsePanel.Name = "browsePanel";
            this.browsePanel.Size = new System.Drawing.Size(700, 372);
            this.browsePanel.TabIndex = 35;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.itemPanel);
            this.panel4.Controls.Add(this.panel2);
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
            this.itemPanel.Size = new System.Drawing.Size(480, 262);
            this.itemPanel.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.addDataButton);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 312);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(480, 60);
            this.panel2.TabIndex = 3;
            // 
            // addDataButton
            // 
            this.addDataButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.addDataButton.FlatAppearance.BorderSize = 0;
            this.addDataButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addDataButton.Font = new System.Drawing.Font("Calibri", 13F);
            this.addDataButton.ForeColor = System.Drawing.Color.White;
            this.addDataButton.Location = new System.Drawing.Point(288, 10);
            this.addDataButton.Name = "addDataButton";
            this.addDataButton.Size = new System.Drawing.Size(180, 40);
            this.addDataButton.TabIndex = 8;
            this.addDataButton.Text = "Add Item";
            this.addDataButton.UseVisualStyleBackColor = false;
            this.addDataButton.Click += new System.EventHandler(this.addDataButtonClick);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.categoryPanel);
            this.panel3.Controls.Add(this.panel1);
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
            this.categoryPanel.Size = new System.Drawing.Size(220, 262);
            this.categoryPanel.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.addSetButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 312);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 60);
            this.panel1.TabIndex = 2;
            // 
            // addSetButton
            // 
            this.addSetButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.addSetButton.FlatAppearance.BorderSize = 0;
            this.addSetButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSetButton.Font = new System.Drawing.Font("Calibri", 13F);
            this.addSetButton.ForeColor = System.Drawing.Color.White;
            this.addSetButton.Location = new System.Drawing.Point(20, 10);
            this.addSetButton.Name = "addSetButton";
            this.addSetButton.Size = new System.Drawing.Size(180, 40);
            this.addSetButton.TabIndex = 8;
            this.addSetButton.Text = "Create Category";
            this.addSetButton.UseVisualStyleBackColor = false;
            this.addSetButton.Click += new System.EventHandler(this.addSetButtonClick);
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
            // statusPanel
            // 
            this.statusPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(77)))), ((int)(((byte)(89)))), ((int)(((byte)(101)))));
            this.statusPanel.Controls.Add(this.viewItemsButton);
            this.statusPanel.Controls.Add(this.viewUsersButton);
            this.statusPanel.Controls.Add(this.pictureBox1);
            this.statusPanel.Controls.Add(this.descriptionLabel);
            this.statusPanel.Controls.Add(this.managementLabel);
            this.statusPanel.Location = new System.Drawing.Point(50, 12);
            this.statusPanel.Name = "statusPanel";
            this.statusPanel.Size = new System.Drawing.Size(700, 83);
            this.statusPanel.TabIndex = 36;
            // 
            // viewItemsButton
            // 
            this.viewItemsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.viewItemsButton.FlatAppearance.BorderSize = 0;
            this.viewItemsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewItemsButton.Font = new System.Drawing.Font("Calibri", 13F);
            this.viewItemsButton.ForeColor = System.Drawing.Color.White;
            this.viewItemsButton.Location = new System.Drawing.Point(508, 45);
            this.viewItemsButton.Name = "viewItemsButton";
            this.viewItemsButton.Size = new System.Drawing.Size(180, 31);
            this.viewItemsButton.TabIndex = 33;
            this.viewItemsButton.Text = "View Items";
            this.viewItemsButton.UseVisualStyleBackColor = false;
            this.viewItemsButton.Click += new System.EventHandler(this.viewItemsButton_Click);
            // 
            // viewUsersButton
            // 
            this.viewUsersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.viewUsersButton.FlatAppearance.BorderSize = 0;
            this.viewUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewUsersButton.Font = new System.Drawing.Font("Calibri", 13F);
            this.viewUsersButton.ForeColor = System.Drawing.Color.White;
            this.viewUsersButton.Location = new System.Drawing.Point(508, 7);
            this.viewUsersButton.Name = "viewUsersButton";
            this.viewUsersButton.Size = new System.Drawing.Size(180, 31);
            this.viewUsersButton.TabIndex = 32;
            this.viewUsersButton.Text = "View Users";
            this.viewUsersButton.UseVisualStyleBackColor = false;
            this.viewUsersButton.Click += new System.EventHandler(this.viewUsersButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::iTEC2014.Properties.Resources.ManagementIcon;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.Location = new System.Drawing.Point(10, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(63, 63);
            this.pictureBox1.TabIndex = 29;
            this.pictureBox1.TabStop = false;
            // 
            // descriptionLabel
            // 
            this.descriptionLabel.Font = new System.Drawing.Font("Calibri", 13F);
            this.descriptionLabel.ForeColor = System.Drawing.Color.White;
            this.descriptionLabel.Location = new System.Drawing.Point(81, 49);
            this.descriptionLabel.Name = "descriptionLabel";
            this.descriptionLabel.Size = new System.Drawing.Size(350, 22);
            this.descriptionLabel.TabIndex = 31;
            this.descriptionLabel.Text = "Add or edit users and items.";
            this.descriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // managementLabel
            // 
            this.managementLabel.Font = new System.Drawing.Font("Calibri", 20F);
            this.managementLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(134)))), ((int)(((byte)(44)))));
            this.managementLabel.Location = new System.Drawing.Point(79, 8);
            this.managementLabel.Name = "managementLabel";
            this.managementLabel.Size = new System.Drawing.Size(350, 33);
            this.managementLabel.TabIndex = 30;
            this.managementLabel.Text = "MANAGEMENT";
            this.managementLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ManagementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 485);
            this.Controls.Add(this.statusPanel);
            this.Controls.Add(this.browsePanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ManagementForm";
            this.Text = "ManagementForm";
            this.browsePanel.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.itemHeaderPanel.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.categoryHeaderPanel.ResumeLayout(false);
            this.statusPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label itemLabel;
        private System.Windows.Forms.Panel browsePanel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel itemHeaderPanel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel categoryPanel;
        private System.Windows.Forms.Panel categoryHeaderPanel;
        private System.Windows.Forms.Label categoryLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button addSetButton;
        private System.Windows.Forms.Panel itemPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button addDataButton;
        private System.Windows.Forms.Panel statusPanel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label managementLabel;
        private System.Windows.Forms.Label descriptionLabel;
        private System.Windows.Forms.Button viewItemsButton;
        private System.Windows.Forms.Button viewUsersButton;


    }
}