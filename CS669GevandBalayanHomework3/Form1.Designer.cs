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
            this.btnPrewitt = new System.Windows.Forms.Button();
            this.txtPrewittThreshold = new System.Windows.Forms.TextBox();
            this.btnLaplace = new System.Windows.Forms.Button();
            this.txtLaplaceThreshold = new System.Windows.Forms.TextBox();
            this.btnRoberts = new System.Windows.Forms.Button();
            this.txtRobertsThreshold = new System.Windows.Forms.TextBox();
            this.btnRobinson = new System.Windows.Forms.Button();
            this.txtRobinsonThreshold = new System.Windows.Forms.TextBox();
            this.btnKirsh = new System.Windows.Forms.Button();
            this.txtKirshThreshold = new System.Windows.Forms.TextBox();
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
            // btnPrewitt
            // 
            this.btnPrewitt.Location = new System.Drawing.Point(12, 102);
            this.btnPrewitt.Name = "btnPrewitt";
            this.btnPrewitt.Size = new System.Drawing.Size(75, 23);
            this.btnPrewitt.TabIndex = 7;
            this.btnPrewitt.Text = "Prewitt";
            this.btnPrewitt.UseVisualStyleBackColor = true;
            this.btnPrewitt.Click += new System.EventHandler(this.btnPrewitt_Click);
            // 
            // txtPrewittThreshold
            // 
            this.txtPrewittThreshold.Location = new System.Drawing.Point(93, 104);
            this.txtPrewittThreshold.Name = "txtPrewittThreshold";
            this.txtPrewittThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtPrewittThreshold.TabIndex = 8;
            // 
            // btnLaplace
            // 
            this.btnLaplace.Location = new System.Drawing.Point(12, 131);
            this.btnLaplace.Name = "btnLaplace";
            this.btnLaplace.Size = new System.Drawing.Size(75, 23);
            this.btnLaplace.TabIndex = 9;
            this.btnLaplace.Text = "Laplace";
            this.btnLaplace.UseVisualStyleBackColor = true;
            this.btnLaplace.Click += new System.EventHandler(this.btnLaplace_Click);
            // 
            // txtLaplaceThreshold
            // 
            this.txtLaplaceThreshold.Location = new System.Drawing.Point(93, 133);
            this.txtLaplaceThreshold.Name = "txtLaplaceThreshold";
            this.txtLaplaceThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtLaplaceThreshold.TabIndex = 10;
            // 
            // btnRoberts
            // 
            this.btnRoberts.Location = new System.Drawing.Point(12, 160);
            this.btnRoberts.Name = "btnRoberts";
            this.btnRoberts.Size = new System.Drawing.Size(75, 23);
            this.btnRoberts.TabIndex = 11;
            this.btnRoberts.Text = "Roberts";
            this.btnRoberts.UseVisualStyleBackColor = true;
            this.btnRoberts.Click += new System.EventHandler(this.btnRoberts_Click);
            // 
            // txtRobertsThreshold
            // 
            this.txtRobertsThreshold.Location = new System.Drawing.Point(93, 162);
            this.txtRobertsThreshold.Name = "txtRobertsThreshold";
            this.txtRobertsThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtRobertsThreshold.TabIndex = 12;
            // 
            // btnRobinson
            // 
            this.btnRobinson.Location = new System.Drawing.Point(12, 189);
            this.btnRobinson.Name = "btnRobinson";
            this.btnRobinson.Size = new System.Drawing.Size(75, 23);
            this.btnRobinson.TabIndex = 13;
            this.btnRobinson.Text = "Robinson";
            this.btnRobinson.UseVisualStyleBackColor = true;
            this.btnRobinson.Click += new System.EventHandler(this.btnRobinson_Click);
            // 
            // txtRobinsonThreshold
            // 
            this.txtRobinsonThreshold.Location = new System.Drawing.Point(93, 191);
            this.txtRobinsonThreshold.Name = "txtRobinsonThreshold";
            this.txtRobinsonThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtRobinsonThreshold.TabIndex = 14;
            // 
            // btnKirsh
            // 
            this.btnKirsh.Location = new System.Drawing.Point(12, 218);
            this.btnKirsh.Name = "btnKirsh";
            this.btnKirsh.Size = new System.Drawing.Size(75, 23);
            this.btnKirsh.TabIndex = 15;
            this.btnKirsh.Text = "Kirsh";
            this.btnKirsh.UseVisualStyleBackColor = true;
            this.btnKirsh.Click += new System.EventHandler(this.btnKirsh_Click);
            // 
            // txtKirshThreshold
            // 
            this.txtKirshThreshold.Location = new System.Drawing.Point(93, 220);
            this.txtKirshThreshold.Name = "txtKirshThreshold";
            this.txtKirshThreshold.Size = new System.Drawing.Size(26, 20);
            this.txtKirshThreshold.TabIndex = 16;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 616);
            this.Controls.Add(this.txtKirshThreshold);
            this.Controls.Add(this.btnKirsh);
            this.Controls.Add(this.txtRobinsonThreshold);
            this.Controls.Add(this.btnRobinson);
            this.Controls.Add(this.txtRobertsThreshold);
            this.Controls.Add(this.btnRoberts);
            this.Controls.Add(this.txtLaplaceThreshold);
            this.Controls.Add(this.btnLaplace);
            this.Controls.Add(this.txtPrewittThreshold);
            this.Controls.Add(this.btnPrewitt);
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
        private System.Windows.Forms.Button btnPrewitt;
        private System.Windows.Forms.TextBox txtPrewittThreshold;
        private System.Windows.Forms.Button btnLaplace;
        private System.Windows.Forms.TextBox txtLaplaceThreshold;
        private System.Windows.Forms.Button btnRoberts;
        private System.Windows.Forms.TextBox txtRobertsThreshold;
        private System.Windows.Forms.Button btnRobinson;
        private System.Windows.Forms.TextBox txtRobinsonThreshold;
        private System.Windows.Forms.Button btnKirsh;
        private System.Windows.Forms.TextBox txtKirshThreshold;
    }
}

