namespace SteamSentryTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthForm));
            this.AuthLabel = new System.Windows.Forms.Label();
            this.AuthcodeBox = new System.Windows.Forms.TextBox();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.CancalButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AuthLabel
            // 
            this.AuthLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.AuthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthLabel.Location = new System.Drawing.Point(0, 0);
            this.AuthLabel.Margin = new System.Windows.Forms.Padding(0);
            this.AuthLabel.Name = "AuthLabel";
            this.AuthLabel.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.AuthLabel.Size = new System.Drawing.Size(437, 40);
            this.AuthLabel.TabIndex = 0;
            this.AuthLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.AuthLabel.Click += new System.EventHandler(this.AuthLabel_Click);
            // 
            // AuthcodeBox
            // 
            this.AuthcodeBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthcodeBox.Location = new System.Drawing.Point(182, 35);
            this.AuthcodeBox.MaxLength = 5;
            this.AuthcodeBox.Name = "AuthcodeBox";
            this.AuthcodeBox.Size = new System.Drawing.Size(73, 24);
            this.AuthcodeBox.TabIndex = 1;
            this.AuthcodeBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AuthcodeBox.TextChanged += new System.EventHandler(this.AuthcodeBox_TextChanged);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ConfirmButton.Location = new System.Drawing.Point(124, 68);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(92, 28);
            this.ConfirmButton.TabIndex = 2;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // CancalButton
            // 
            this.CancalButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancalButton.Location = new System.Drawing.Point(222, 68);
            this.CancalButton.Name = "CancalButton";
            this.CancalButton.Size = new System.Drawing.Size(92, 28);
            this.CancalButton.TabIndex = 3;
            this.CancalButton.Text = "Cancel";
            this.CancalButton.UseVisualStyleBackColor = true;
            this.CancalButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // AuthForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(437, 105);
            this.Controls.Add(this.CancalButton);
            this.Controls.Add(this.ConfirmButton);
            this.Controls.Add(this.AuthcodeBox);
            this.Controls.Add(this.AuthLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AuthForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Input";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AuthLabel;
        private System.Windows.Forms.TextBox AuthcodeBox;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.Button CancalButton;
    }
}