namespace az.Synchronizer
{
    partial class SetUpWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetUpWindow));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.srcTxtBox = new System.Windows.Forms.TextBox();
            this.sourceBtn = new System.Windows.Forms.Button();
            this.targetTxtBox = new System.Windows.Forms.TextBox();
            this.targetBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.continueBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target:";
            // 
            // srcTxtBox
            // 
            this.srcTxtBox.Location = new System.Drawing.Point(59, 52);
            this.srcTxtBox.Name = "srcTxtBox";
            this.srcTxtBox.ReadOnly = true;
            this.srcTxtBox.Size = new System.Drawing.Size(263, 20);
            this.srcTxtBox.TabIndex = 2;
            this.srcTxtBox.TextChanged += new System.EventHandler(this.srcTxtBox_TextChanged);
            // 
            // sourceBtn
            // 
            this.sourceBtn.Location = new System.Drawing.Point(328, 52);
            this.sourceBtn.Name = "sourceBtn";
            this.sourceBtn.Size = new System.Drawing.Size(35, 20);
            this.sourceBtn.TabIndex = 3;
            this.sourceBtn.Text = "...";
            this.sourceBtn.UseVisualStyleBackColor = true;
            this.sourceBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // targetTxtBox
            // 
            this.targetTxtBox.Location = new System.Drawing.Point(59, 86);
            this.targetTxtBox.Name = "targetTxtBox";
            this.targetTxtBox.ReadOnly = true;
            this.targetTxtBox.Size = new System.Drawing.Size(263, 20);
            this.targetTxtBox.TabIndex = 4;
            this.targetTxtBox.TextChanged += new System.EventHandler(this.targetTxtBox_TextChanged);
            // 
            // targetBtn
            // 
            this.targetBtn.Location = new System.Drawing.Point(328, 86);
            this.targetBtn.Name = "targetBtn";
            this.targetBtn.Size = new System.Drawing.Size(35, 20);
            this.targetBtn.TabIndex = 5;
            this.targetBtn.Text = "...";
            this.targetBtn.UseVisualStyleBackColor = true;
            this.targetBtn.Click += new System.EventHandler(this.OpenFileDialog);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(131, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 6;
            this.label3.Text = "Setup";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Synchronizer.Properties.Resources.sync1;
            this.pictureBox1.Location = new System.Drawing.Point(206, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // continueBtn
            // 
            this.continueBtn.Enabled = false;
            this.continueBtn.Location = new System.Drawing.Point(155, 145);
            this.continueBtn.Name = "continueBtn";
            this.continueBtn.Size = new System.Drawing.Size(75, 23);
            this.continueBtn.TabIndex = 8;
            this.continueBtn.Text = "Continue";
            this.continueBtn.UseVisualStyleBackColor = true;
            this.continueBtn.Click += new System.EventHandler(this.continueBtn_Click);
            // 
            // SetUpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 180);
            this.Controls.Add(this.continueBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.targetBtn);
            this.Controls.Add(this.targetTxtBox);
            this.Controls.Add(this.sourceBtn);
            this.Controls.Add(this.srcTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SetUpWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setup";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox srcTxtBox;
        private System.Windows.Forms.Button sourceBtn;
        private System.Windows.Forms.TextBox targetTxtBox;
        private System.Windows.Forms.Button targetBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button continueBtn;
    }
}