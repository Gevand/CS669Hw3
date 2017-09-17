namespace CS669GevandBalayanHomework3
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
            this.pictInput = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCanny = new System.Windows.Forms.Button();
            this.btnSobel = new System.Windows.Forms.Button();
            this.prgLoader = new System.Windows.Forms.ProgressBar();
            this.txtCannyThreshold = new System.Windows.Forms.TextBox();
            this.txtSobelThreshold = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictInput)).BeginInit();
            this.SuspendLayout();
            // 
            // pictInput
            // 
            this.pictInput.Location = new System.Drawing.Point(125, 41);
            this.pictInput.Name = "pictInput";
            this.pictInput.Size = new System.Drawing.Size(537, 592);
            this.pictInput.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictInput.TabIndex = 0;
            this.pictInput.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCanny
            // 
            this.btnCanny.Location = new System.Drawing.Point(12, 41);
            this.btnCanny.Name = "btnCanny";
            this.btnCanny.Size = new System.Drawing.Size(75, 26);
            this.btnCanny.TabIndex = 2;
            this.btnCanny.Text = "Canny";
            this.btnCanny.UseVisualStyleBackColor = true;
            this.btnCanny.Click += new System.EventHandler(this.btnCanny_Click);
            // 
            // btnSobel
            // 
            this.btnSobel.Location = new System.Drawing.Point(12, 73);
            this.btnSobel.Name = "btnSobel";
            this.btnSobel.Size = new System.Drawing.Size(75, 23);
            this.btnSobel.TabIndex = 3;
            this.btnSobel.Text = "Sobel";
            this.btnSobel.UseVisualStyleBackColor = true;
            this.btnSobel.Click += new System.EventHandler(this.btnSobel_Click);
            // 
            // prgLoader
            // 
            this.prgLoader.Location = new System.Drawing.Point(125, 12);
            this.prgLoader.Name = "prgLoader";
            this.prgLoader.Size = new System.Drawing.Size(537, 23);
            this.prgLoader.TabIndex = 4;
            // 
            // txtCannyThreshold
            // 
            this.txtCannyThreshold.Location = new System.Drawing.Point(93, 45);
            this.txtCannyThreshold.Name = "txtCannyThreshold";
            this.txtCannyThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtCannyThreshold.TabIndex = 5;
            // 
            // txtSobelThreshold
            // 
            this.txtSobelThreshold.Location = new System.Drawing.Point(93, 75);
            this.txtSobelThreshold.Name = "txtSobelThreshold";
            this.txtSobelThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtSobelThreshold.TabIndex = 6;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 616);
            this.Controls.Add(this.txtSobelThreshold);
            this.Controls.Add(this.txtCannyThreshold);
            this.Controls.Add(this.prgLoader);
            this.Controls.Add(this.btnSobel);
            this.Controls.Add(this.btnCanny);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictInput);
            this.Name = "Form1";
            this.Text = "Gevand Balayan Homework 3";
            ((System.ComponentModel.ISupportInitialize)(this.pictInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictInput;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCanny;
        private System.Windows.Forms.Button btnSobel;
        private System.Windows.Forms.ProgressBar prgLoader;
        private System.Windows.Forms.TextBox txtCannyThreshold;
        private System.Windows.Forms.TextBox txtSobelThreshold;
    }
}

