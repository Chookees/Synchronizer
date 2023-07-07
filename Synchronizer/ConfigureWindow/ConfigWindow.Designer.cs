namespace az.Synchronizer
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
            this.popUpWhenExternalConnected = new System.Windows.Forms.CheckBox();
            this.showWindowOnChanges = new System.Windows.Forms.CheckBox();
            this.showCurrentProgressAsTooltip = new System.Windows.Forms.CheckBox();
            this.settingShowWarning = new System.Windows.Forms.CheckBox();
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
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(963, 116);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration File";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 31);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Source:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 16;
            this.label3.Text = "Target:";
            // 
            // targetBtn
            // 
            this.targetBtn.Location = new System.Drawing.Point(908, 69);
            this.targetBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(47, 25);
            this.targetBtn.TabIndex = 20;
            this.targetBtn.Text = "...";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // srcTxtBox
            // 
            this.srcTxtBox.Location = new System.Drawing.Point(69, 27);
            this.srcTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.srcTxtBox.Name = "srcTxtBox";
            this.srcTxtBox.ReadOnly = true;
            this.srcTxtBox.Size = new System.Drawing.Size(829, 22);
            this.srcTxtBox.TabIndex = 17;
            // 
            // targetTxtBox
            // 
            this.targetTxtBox.Location = new System.Drawing.Point(69, 69);
            this.targetTxtBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.targetTxtBox.Name = "targetTxtBox";
            this.targetTxtBox.ReadOnly = true;
            this.targetTxtBox.Size = new System.Drawing.Size(829, 22);
            this.targetTxtBox.TabIndex = 19;
            // 
            // sourceBtn
            // 
            this.sourceBtn.Location = new System.Drawing.Point(908, 27);
            this.sourceBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourceBtn.Name = "sourceBtn";
            this.sourceBtn.Size = new System.Drawing.Size(47, 25);
            this.sourceBtn.TabIndex = 18;
            this.sourceBtn.Text = "...";
            this.sourceBtn.UseVisualStyleBackColor = true;
            this.sourceBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(879, 332);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(100, 28);
            this.cancelBtn.TabIndex = 22;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(763, 332);
            this.saveBtn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(108, 27);
            this.saveBtn.TabIndex = 21;
            this.saveBtn.Text = "Save and Exit";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.popUpWhenExternalConnected);
            this.groupBox2.Controls.Add(this.showWindowOnChanges);
            this.groupBox2.Controls.Add(this.showCurrentProgressAsTooltip);
            this.groupBox2.Controls.Add(this.settingShowWarning);
            this.groupBox2.Controls.Add(this.startAutoBox);
            this.groupBox2.Location = new System.Drawing.Point(16, 139);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(963, 185);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings";
            // 
            // popUpWhenExternalConnected
            // 
            this.popUpWhenExternalConnected.AutoSize = true;
            this.popUpWhenExternalConnected.Location = new System.Drawing.Point(12, 138);
            this.popUpWhenExternalConnected.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.popUpWhenExternalConnected.Name = "popUpWhenExternalConnected";
            this.popUpWhenExternalConnected.Size = new System.Drawing.Size(270, 20);
            this.popUpWhenExternalConnected.TabIndex = 4;
            this.popUpWhenExternalConnected.Text = "Show Popup when external drive is ready";
            this.popUpWhenExternalConnected.UseVisualStyleBackColor = true;
            this.popUpWhenExternalConnected.CheckedChanged += new System.EventHandler(this.popUpWhenExternalConnected_CheckedChanged);
            // 
            // showWindowOnChanges
            // 
            this.showWindowOnChanges.AutoSize = true;
            this.showWindowOnChanges.Location = new System.Drawing.Point(12, 110);
            this.showWindowOnChanges.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showWindowOnChanges.Name = "showWindowOnChanges";
            this.showWindowOnChanges.Size = new System.Drawing.Size(340, 20);
            this.showWindowOnChanges.TabIndex = 3;
            this.showWindowOnChanges.Text = "Show popup window when changes have been found";
            this.showWindowOnChanges.UseVisualStyleBackColor = true;
            this.showWindowOnChanges.CheckedChanged += new System.EventHandler(this.showWindowOnChanges_CheckedChanged);
            // 
            // showCurrentProgressAsTooltip
            // 
            this.showCurrentProgressAsTooltip.AutoSize = true;
            this.showCurrentProgressAsTooltip.Location = new System.Drawing.Point(12, 81);
            this.showCurrentProgressAsTooltip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showCurrentProgressAsTooltip.Name = "showCurrentProgressAsTooltip";
            this.showCurrentProgressAsTooltip.Size = new System.Drawing.Size(223, 20);
            this.showCurrentProgressAsTooltip.TabIndex = 2;
            this.showCurrentProgressAsTooltip.Text = "Show current Progress of Backup";
            this.showCurrentProgressAsTooltip.UseVisualStyleBackColor = true;
            this.showCurrentProgressAsTooltip.CheckedChanged += new System.EventHandler(this.showCurrentProgressAsTooltip_CheckedChanged);
            // 
            // settingShowWarning
            // 
            this.settingShowWarning.AutoSize = true;
            this.settingShowWarning.Location = new System.Drawing.Point(12, 53);
            this.settingShowWarning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.settingShowWarning.Name = "settingShowWarning";
            this.settingShowWarning.Size = new System.Drawing.Size(261, 20);
            this.settingShowWarning.TabIndex = 1;
            this.settingShowWarning.Text = "Show a Warning when backup is >10GB";
            this.settingShowWarning.UseVisualStyleBackColor = true;
            this.settingShowWarning.CheckedChanged += new System.EventHandler(this.settingShowWarning_CheckedChanged);
            // 
            // startAutoBox
            // 
            this.startAutoBox.AutoSize = true;
            this.startAutoBox.Location = new System.Drawing.Point(12, 25);
            this.startAutoBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startAutoBox.Name = "startAutoBox";
            this.startAutoBox.Size = new System.Drawing.Size(164, 20);
            this.startAutoBox.TabIndex = 0;
            this.startAutoBox.Text = "Auto start with Windows";
            this.startAutoBox.UseVisualStyleBackColor = true;
            this.startAutoBox.CheckedChanged += new System.EventHandler(this.startAutoBox_CheckedChanged);
            // 
            // ConfigWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(995, 373);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.saveBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.CheckBox showWindowOnChanges;
        private System.Windows.Forms.CheckBox showCurrentProgressAsTooltip;
        private System.Windows.Forms.CheckBox settingShowWarning;
        private System.Windows.Forms.CheckBox startAutoBox;
        private System.Windows.Forms.CheckBox popUpWhenExternalConnected;
    }
}