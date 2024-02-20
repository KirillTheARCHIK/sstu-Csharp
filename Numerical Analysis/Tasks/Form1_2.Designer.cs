
namespace Numerical_Analysis.Tasks
{
    partial class Form1_2
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxSinX = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxSinEps = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxSinAns = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxSinCount = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "sin(x)";
            // 
            // textBoxSinX
            // 
            this.textBoxSinX.Location = new System.Drawing.Point(68, 10);
            this.textBoxSinX.Name = "textBoxSinX";
            this.textBoxSinX.Size = new System.Drawing.Size(60, 20);
            this.textBoxSinX.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(12, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "x";
            // 
            // textBoxSinEps
            // 
            this.textBoxSinEps.Location = new System.Drawing.Point(163, 10);
            this.textBoxSinEps.Name = "textBoxSinEps";
            this.textBoxSinEps.Size = new System.Drawing.Size(60, 20);
            this.textBoxSinEps.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "eps";
            // 
            // textBoxSinAns
            // 
            this.textBoxSinAns.Location = new System.Drawing.Point(310, 10);
            this.textBoxSinAns.Name = "textBoxSinAns";
            this.textBoxSinAns.ReadOnly = true;
            this.textBoxSinAns.Size = new System.Drawing.Size(100, 20);
            this.textBoxSinAns.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(229, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 20);
            this.button1.TabIndex = 4;
            this.button1.Text = "Посчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxSinCount
            // 
            this.textBoxSinCount.Location = new System.Drawing.Point(416, 10);
            this.textBoxSinCount.Name = "textBoxSinCount";
            this.textBoxSinCount.ReadOnly = true;
            this.textBoxSinCount.Size = new System.Drawing.Size(66, 20);
            this.textBoxSinCount.TabIndex = 3;
            // 
            // Form1_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxSinCount);
            this.Controls.Add(this.textBoxSinAns);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxSinEps);
            this.Controls.Add(this.textBoxSinX);
            this.Controls.Add(this.label1);
            this.Name = "Form1_2";
            this.Text = "Form1_2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSinX;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxSinEps;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxSinAns;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxSinCount;
    }
}