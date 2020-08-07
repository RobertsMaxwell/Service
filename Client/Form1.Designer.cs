namespace Client
{
    partial class Form1
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
            this.startButton = new System.Windows.Forms.Button();
            this.targetIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundButton = new System.Windows.Forms.Button();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(178, 167);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(126, 54);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Open Notepad";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // targetIP
            // 
            this.targetIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.targetIP.Location = new System.Drawing.Point(114, 239);
            this.targetIP.Name = "targetIP";
            this.targetIP.Size = new System.Drawing.Size(245, 21);
            this.targetIP.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 240);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "IP";
            // 
            // backgroundButton
            // 
            this.backgroundButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backgroundButton.Location = new System.Drawing.Point(178, 53);
            this.backgroundButton.Name = "backgroundButton";
            this.backgroundButton.Size = new System.Drawing.Size(126, 56);
            this.backgroundButton.TabIndex = 3;
            this.backgroundButton.Text = "Set Background";
            this.backgroundButton.UseVisualStyleBackColor = true;
            this.backgroundButton.Click += new System.EventHandler(this.backgroundButton_Click);
            // 
            // messageBox
            // 
            this.messageBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.messageBox.Location = new System.Drawing.Point(114, 266);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(245, 21);
            this.messageBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(43, 266);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Message";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 322);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.backgroundButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetIP);
            this.Controls.Add(this.startButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button backgroundButton;
        public System.Windows.Forms.TextBox targetIP;
        public System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Label label2;
    }
}

