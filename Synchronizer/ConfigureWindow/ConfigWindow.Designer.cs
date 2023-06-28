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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.targetBtn = new System.Windows.Forms.Button();
            this.srcTxtBox = new System.Windows.Forms.TextBox();
            this.targetTxtBox = new System.Windows.Forms.TextBox();
            this.sourceBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.backupAutoBox = new System.Windows.Forms.CheckBox();
            this.startAutoBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.targetBtn);
            this.groupBox1.Controls.Add(this.srcTxtBox);
            this.groupBox1.Controls.Add(this.targetTxtBox);
            this.groupBox1.Controls.Add(this.sourceBtn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 103);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Target:";
            // 
            // targetBtn
            // 
            this.targetBtn.Location = new System.Drawing.Point(321, 56);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(35, 20);
            this.targetBtn.TabIndex = 20;
            this.targetBtn.Text = "...";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // srcTxtBox
            // 
            this.srcTxtBox.Location = new System.Drawing.Point(52, 22);
            this.srcTxtBox.Name = "srcTxtBox";
            this.srcTxtBox.ReadOnly = true;
            this.srcTxtBox.Size = new System.Drawing.Size(263, 20);
            this.srcTxtBox.TabIndex = 17;
            // 
            // targetTxtBox
            // 
            this.targetTxtBox.Location = new System.Drawing.Point(52, 56);
            this.targetTxtBox.Name = "targetTxtBox";
            this.targetTxtBox.ReadOnly = true;
            this.targetTxtBox.Size = new System.Drawing.Size(263, 20);
            this.targetTxtBox.TabIndex = 19;
            // 
            // sourceBtn
            // 
            this.sourceBtn.Location = new System.Drawing.Point(321, 22);
            this.sourceBtn.Name = "sourceBtn";
            this.sourceBtn.Size = new System.Drawing.Size(35, 20);
            this.sourceBtn.TabIndex = 18;
            this.sourceBtn.Text = "...";
            this.sourceBtn.UseVisualStyleBackColor = true;
            this.sourceBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(312, 277);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(225, 278);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(81, 22);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "Save and Exit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox4);
            this.groupBox2.Controls.Add(this.checkBox3);
            this.groupBox2.Controls.Add(this.backupAutoBox);
            this.groupBox2.Controls.Add(this.startAutoBox);
            this.groupBox2.Location = new System.Drawing.Point(12, 121);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(375, 150);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(9, 89);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(66, 17);
            this.checkBox4.TabIndex = 3;
            this.checkBox4.Text = "<empty>";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(9, 66);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(66, 17);
            this.checkBox3.TabIndex = 2;
            this.checkBox3.Text = "<empty>";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // backupAutoBox
            // 
            this.backupAutoBox.AutoSize = true;
            this.backupAutoBox.Location = new System.Drawing.Point(9, 43);
            this.backupAutoBox.Name = "backupAutoBox";
            this.backupAutoBox.Size = new System.Drawing.Size(15, 14);
            this.backupAutoBox.TabIndex = 1;
            this.backupAutoBox.UseVisualStyleBackColor = true;
            this.backupAutoBox.Text = "Automatically start backup on changes(Work In Progress)";
            // 
            // startAutoBox
            // 
            this.startAutoBox.AutoSize = true;
            this.startAutoBox.Location = new System.Drawing.Point(9, 20);
            this.startAutoBox.Name = "startAutoBox";
            this.startAutoBox.Size = new System.Drawing.Size(140, 17);
            this.startAutoBox.TabIndex = 0;
            this.startAutoBox.Text = "Auto start with Windows";
            this.startAutoBox.UseVisualStyleBackColor = true;
            this.startAutoBox.CheckedChanged += new System.EventHandler(this.startAutoBox_CheckedChanged);
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 312);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Configuration";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button targetBtn;
        private System.Windows.Forms.TextBox srcTxtBox;
        private System.Windows.Forms.TextBox targetTxtBox;
        private System.Windows.Forms.Button sourceBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox backupAutoBox;
        private System.Windows.Forms.CheckBox startAutoBox;
    }
}