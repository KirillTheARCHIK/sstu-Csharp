
namespace Numerical_Analysis.Tasks
{
    partial class Form1_1
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
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFloat1 = new System.Windows.Forms.TextBox();
            this.textBoxFloat2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxDouble1 = new System.Windows.Forms.TextBox();
            this.textBoxDouble2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(172, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Float";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Погрешность суммы 1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Погрешность суммы 2";
            // 
            // textBoxFloat1
            // 
            this.textBoxFloat1.Location = new System.Drawing.Point(140, 30);
            this.textBoxFloat1.Name = "textBoxFloat1";
            this.textBoxFloat1.Size = new System.Drawing.Size(194, 20);
            this.textBoxFloat1.TabIndex = 2;
            // 
            // textBoxFloat2
            // 
            this.textBoxFloat2.Location = new System.Drawing.Point(140, 52);
            this.textBoxFloat2.Name = "textBoxFloat2";
            this.textBoxFloat2.Size = new System.Drawing.Size(194, 20);
            this.textBoxFloat2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(215, 111);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Сумма";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Double";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(340, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Погрешность суммы 1";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(340, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Погрешность суммы 2";
            // 
            // textBoxDouble1
            // 
            this.textBoxDouble1.Location = new System.Drawing.Point(468, 30);
            this.textBoxDouble1.Name = "textBoxDouble1";
            this.textBoxDouble1.Size = new System.Drawing.Size(226, 20);
            this.textBoxDouble1.TabIndex = 2;
            // 
            // textBoxDouble2
            // 
            this.textBoxDouble2.Location = new System.Drawing.Point(468, 52);
            this.textBoxDouble2.Name = "textBoxDouble2";
            this.textBoxDouble2.Size = new System.Drawing.Size(226, 20);
            this.textBoxDouble2.TabIndex = 2;
            // 
            // Form1_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDouble2);
            this.Controls.Add(this.textBoxFloat2);
            this.Controls.Add(this.textBoxDouble1);
            this.Controls.Add(this.textBoxFloat1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1_1";
            this.Text = "Form1_1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFloat1;
        private System.Windows.Forms.TextBox textBoxFloat2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxDouble1;
        private System.Windows.Forms.TextBox textBoxDouble2;
    }
}