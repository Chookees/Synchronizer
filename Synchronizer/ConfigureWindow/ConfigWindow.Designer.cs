namespace Synchronizer
{
    partial class ConfigWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigWindow));
            this.targetBtn = new System.Windows.Forms.Button();
            this.targetTxtBox = new System.Windows.Forms.TextBox();
            this.sourceBtn = new System.Windows.Forms.Button();
            this.srcTxtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.saveBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // targetBtn
            // 
            this.targetBtn.Location = new System.Drawing.Point(342, 73);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(35, 20);
            this.targetBtn.TabIndex = 11;
            this.targetBtn.Text = "...";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // targetTxtBox
            // 
            this.targetTxtBox.Location = new System.Drawing.Point(73, 73);
            this.targetTxtBox.Name = "targetTxtBox";
            this.targetTxtBox.ReadOnly = true;
            this.targetTxtBox.Size = new System.Drawing.Size(263, 20);
            this.targetTxtBox.TabIndex = 10;
            // 
            // sourceBtn
            // 
            this.sourceBtn.Location = new System.Drawing.Point(342, 39);
            this.sourceBtn.Name = "sourceBtn";
            this.sourceBtn.Size = new System.Drawing.Size(35, 20);
            this.sourceBtn.TabIndex = 9;
            this.sourceBtn.Text = "...";
            this.sourceBtn.UseVisualStyleBackColor = true;
            this.sourceBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // srcTxtBox
            // 
            this.srcTxtBox.Location = new System.Drawing.Point(73, 39);
            this.srcTxtBox.Name = "srcTxtBox";
            this.srcTxtBox.ReadOnly = true;
            this.srcTxtBox.Size = new System.Drawing.Size(263, 20);
            this.srcTxtBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Target:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Source:";
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(73, 99);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(81, 22);
            this.saveBtn.TabIndex = 12;
            this.saveBtn.Text = "Save and Exit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(160, 98);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 13;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 156);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.targetBtn);
            this.Controls.Add(this.targetTxtBox);
            this.Controls.Add(this.sourceBtn);
            this.Controls.Add(this.srcTxtBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button targetBtn;
        private System.Windows.Forms.TextBox targetTxtBox;
        private System.Windows.Forms.Button sourceBtn;
        private System.Windows.Forms.TextBox srcTxtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button cancelBtn;
    }
}