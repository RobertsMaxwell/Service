namespace Client
{
    partial class Form2
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
            this.browseButton = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.TextBox();
            this.setButton = new System.Windows.Forms.Button();
            this.targetIP = new System.Windows.Forms.TextBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(329, 34);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 0;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // filePath
            // 
            this.filePath.Location = new System.Drawing.Point(55, 34);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(261, 20);
            this.filePath.TabIndex = 1;
            // 
            // setButton
            // 
            this.setButton.Location = new System.Drawing.Point(137, 119);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(115, 29);
            this.setButton.TabIndex = 2;
            this.setButton.Text = "Set Background";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // targetIP
            // 
            this.targetIP.Location = new System.Drawing.Point(55, 72);
            this.targetIP.Name = "targetIP";
            this.targetIP.Size = new System.Drawing.Size(261, 20);
            this.targetIP.TabIndex = 3;
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.Location = new System.Drawing.Point(29, 73);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(20, 16);
            this.labelIP.TabIndex = 4;
            this.labelIP.Text = "IP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(19, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "File";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 160);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelIP);
            this.Controls.Add(this.targetIP);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.browseButton);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox filePath;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.TextBox targetIP;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label label1;
    }
}