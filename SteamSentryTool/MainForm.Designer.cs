namespace SteamSentryTool
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SelectorButton = new System.Windows.Forms.Button();
            this.SelectorGrouper = new System.Windows.Forms.GroupBox();
            this.SelectorBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.CheckButton = new System.Windows.Forms.Button();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.UsernameLabel = new System.Windows.Forms.Label();
            this.CredsGrouper = new System.Windows.Forms.GroupBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.SelectorCancelButton = new System.Windows.Forms.Button();
            this.WorkingBar = new System.Windows.Forms.ProgressBar();
            this.SelectorGrouper.SuspendLayout();
            this.CredsGrouper.SuspendLayout();
            this.SuspendLayout();
            // 
            // SelectorButton
            // 
            this.SelectorButton.Location = new System.Drawing.Point(404, 18);
            this.SelectorButton.Name = "SelectorButton";
            this.SelectorButton.Size = new System.Drawing.Size(44, 22);
            this.SelectorButton.TabIndex = 0;
            this.SelectorButton.Text = "...";
            this.SelectorButton.UseVisualStyleBackColor = true;
            this.SelectorButton.Click += new System.EventHandler(this.SelectorButton_Click);
            // 
            // SelectorGrouper
            // 
            this.SelectorGrouper.Controls.Add(this.SelectorCancelButton);
            this.SelectorGrouper.Controls.Add(this.SelectorBox);
            this.SelectorGrouper.Controls.Add(this.SelectorButton);
            this.SelectorGrouper.Location = new System.Drawing.Point(12, 12);
            this.SelectorGrouper.Name = "SelectorGrouper";
            this.SelectorGrouper.Size = new System.Drawing.Size(501, 53);
            this.SelectorGrouper.TabIndex = 1;
            this.SelectorGrouper.TabStop = false;
            this.SelectorGrouper.Text = "Sentry File";
            // 
            // SelectorBox
            // 
            this.SelectorBox.Location = new System.Drawing.Point(6, 19);
            this.SelectorBox.Name = "SelectorBox";
            this.SelectorBox.ReadOnly = true;
            this.SelectorBox.Size = new System.Drawing.Size(392, 20);
            this.SelectorBox.TabIndex = 1;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(8, 50);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(59, 13);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password :";
            // 
            // CheckButton
            // 
            this.CheckButton.Location = new System.Drawing.Point(6, 73);
            this.CheckButton.Name = "CheckButton";
            this.CheckButton.Size = new System.Drawing.Size(242, 32);
            this.CheckButton.TabIndex = 3;
            this.CheckButton.Text = "Check";
            this.CheckButton.UseVisualStyleBackColor = true;
            this.CheckButton.Click += new System.EventHandler(this.CheckButton_Click);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Location = new System.Drawing.Point(73, 47);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.PasswordChar = '•';
            this.PasswordBox.Size = new System.Drawing.Size(422, 20);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.Click += new System.EventHandler(this.PasswordBox_Click);
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(73, 21);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(422, 20);
            this.UsernameBox.TabIndex = 1;
            this.UsernameBox.Click += new System.EventHandler(this.UsernameBox_Click);
            // 
            // UsernameLabel
            // 
            this.UsernameLabel.AutoSize = true;
            this.UsernameLabel.Location = new System.Drawing.Point(6, 24);
            this.UsernameLabel.Name = "UsernameLabel";
            this.UsernameLabel.Size = new System.Drawing.Size(61, 13);
            this.UsernameLabel.TabIndex = 0;
            this.UsernameLabel.Text = "Username :";
            // 
            // CredsGrouper
            // 
            this.CredsGrouper.Controls.Add(this.AddButton);
            this.CredsGrouper.Controls.Add(this.CheckButton);
            this.CredsGrouper.Controls.Add(this.PasswordLabel);
            this.CredsGrouper.Controls.Add(this.UsernameLabel);
            this.CredsGrouper.Controls.Add(this.UsernameBox);
            this.CredsGrouper.Controls.Add(this.PasswordBox);
            this.CredsGrouper.Location = new System.Drawing.Point(12, 98);
            this.CredsGrouper.Name = "CredsGrouper";
            this.CredsGrouper.Size = new System.Drawing.Size(501, 115);
            this.CredsGrouper.TabIndex = 5;
            this.CredsGrouper.TabStop = false;
            this.CredsGrouper.Text = "Credentials";
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(254, 73);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(241, 32);
            this.AddButton.TabIndex = 6;
            this.AddButton.Text = "Create";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // SelectorCancelButton
            // 
            this.SelectorCancelButton.Enabled = false;
            this.SelectorCancelButton.Location = new System.Drawing.Point(451, 18);
            this.SelectorCancelButton.Name = "SelectorCancelButton";
            this.SelectorCancelButton.Size = new System.Drawing.Size(44, 22);
            this.SelectorCancelButton.TabIndex = 2;
            this.SelectorCancelButton.Text = "X";
            this.SelectorCancelButton.UseVisualStyleBackColor = true;
            this.SelectorCancelButton.Click += new System.EventHandler(this.SelectorCancelButton_Click);
            // 
            // WorkingBar
            // 
            this.WorkingBar.Location = new System.Drawing.Point(12, 71);
            this.WorkingBar.MarqueeAnimationSpeed = 50;
            this.WorkingBar.Name = "WorkingBar";
            this.WorkingBar.Size = new System.Drawing.Size(501, 21);
            this.WorkingBar.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 225);
            this.Controls.Add(this.WorkingBar);
            this.Controls.Add(this.CredsGrouper);
            this.Controls.Add(this.SelectorGrouper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SteamSentryTool v1.0.0   (Created by Shravan Rajinikanth)";
            this.SelectorGrouper.ResumeLayout(false);
            this.SelectorGrouper.PerformLayout();
            this.CredsGrouper.ResumeLayout(false);
            this.CredsGrouper.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SelectorButton;
        private System.Windows.Forms.GroupBox SelectorGrouper;
        private System.Windows.Forms.TextBox SelectorBox;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label UsernameLabel;
        private System.Windows.Forms.Button CheckButton;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.GroupBox CredsGrouper;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button SelectorCancelButton;
        private System.Windows.Forms.ProgressBar WorkingBar;
    }
}

