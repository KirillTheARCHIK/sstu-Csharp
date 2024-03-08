
namespace Numerical_Analysis
{
    partial class MathFunctionForm
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
            this.textBoxF = new System.Windows.Forms.TextBox();
            this.ErrorLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.variablesFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.labelFx = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxFpVariable = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.labelFpx = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Функция:";
            // 
            // textBoxF
            // 
            this.textBoxF.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxF.Location = new System.Drawing.Point(3, 16);
            this.textBoxF.Name = "textBoxF";
            this.textBoxF.Size = new System.Drawing.Size(239, 26);
            this.textBoxF.TabIndex = 1;
            this.textBoxF.TextChanged += new System.EventHandler(this.textBoxF_TextChanged);
            // 
            // ErrorLabel
            // 
            this.ErrorLabel.AutoSize = true;
            this.ErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.ErrorLabel.Location = new System.Drawing.Point(3, 45);
            this.ErrorLabel.Name = "ErrorLabel";
            this.ErrorLabel.Size = new System.Drawing.Size(47, 13);
            this.ErrorLabel.TabIndex = 2;
            this.ErrorLabel.Text = "Ошибка";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Значения переменных:";
            // 
            // variablesFlowLayoutPanel
            // 
            this.variablesFlowLayoutPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.variablesFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.variablesFlowLayoutPanel.Location = new System.Drawing.Point(3, 74);
            this.variablesFlowLayoutPanel.Name = "variablesFlowLayoutPanel";
            this.variablesFlowLayoutPanel.Size = new System.Drawing.Size(239, 80);
            this.variablesFlowLayoutPanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.textBoxF);
            this.flowLayoutPanel1.Controls.Add(this.ErrorLabel);
            this.flowLayoutPanel1.Controls.Add(this.label2);
            this.flowLayoutPanel1.Controls.Add(this.variablesFlowLayoutPanel);
            this.flowLayoutPanel1.Controls.Add(this.labelFx);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(248, 426);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // labelFx
            // 
            this.labelFx.AutoSize = true;
            this.labelFx.Location = new System.Drawing.Point(3, 157);
            this.labelFx.Name = "labelFx";
            this.labelFx.Size = new System.Drawing.Size(177, 13);
            this.labelFx.TabIndex = 5;
            this.labelFx.Text = "Значение функции в точке =         ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxFpVariable);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.labelFpx);
            this.groupBox1.Location = new System.Drawing.Point(3, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(239, 66);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Дифференцирование";
            // 
            // textBoxFpVariable
            // 
            this.textBoxFpVariable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxFpVariable.Location = new System.Drawing.Point(101, 17);
            this.textBoxFpVariable.Name = "textBoxFpVariable";
            this.textBoxFpVariable.Size = new System.Drawing.Size(23, 23);
            this.textBoxFpVariable.TabIndex = 7;
            this.textBoxFpVariable.TextChanged += new System.EventHandler(this.textBoxFpVariable_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "По переменной:";
            // 
            // labelFpx
            // 
            this.labelFpx.AutoSize = true;
            this.labelFpx.Location = new System.Drawing.Point(6, 40);
            this.labelFpx.Name = "labelFpx";
            this.labelFpx.Size = new System.Drawing.Size(179, 13);
            this.labelFpx.TabIndex = 5;
            this.labelFpx.Text = "Значение производной в точке =  ";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(3, 245);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 100);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Интегрирование";
            // 
            // MathFunctionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "MathFunctionForm";
            this.Text = "MathFunctionForm";
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxF;
        private System.Windows.Forms.Label ErrorLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.FlowLayoutPanel variablesFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label labelFx;
        private System.Windows.Forms.Label labelFpx;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFpVariable;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}