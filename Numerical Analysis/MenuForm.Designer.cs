
namespace Numerical_Analysis
{
    partial class MenuForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonTask1_1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonTask1_2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonTask1_1
            // 
            this.buttonTask1_1.Location = new System.Drawing.Point(15, 25);
            this.buttonTask1_1.Name = "buttonTask1_1";
            this.buttonTask1_1.Size = new System.Drawing.Size(75, 23);
            this.buttonTask1_1.TabIndex = 0;
            this.buttonTask1_1.Text = "Задание 1";
            this.buttonTask1_1.UseVisualStyleBackColor = true;
            this.buttonTask1_1.Click += new System.EventHandler(this.buttonTask1_1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Практика 1";
            // 
            // buttonTask1_2
            // 
            this.buttonTask1_2.Location = new System.Drawing.Point(15, 54);
            this.buttonTask1_2.Name = "buttonTask1_2";
            this.buttonTask1_2.Size = new System.Drawing.Size(75, 23);
            this.buttonTask1_2.TabIndex = 0;
            this.buttonTask1_2.Text = "Задание 2";
            this.buttonTask1_2.UseVisualStyleBackColor = true;
            this.buttonTask1_2.Click += new System.EventHandler(this.buttonTask1_2_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTask1_2);
            this.Controls.Add(this.buttonTask1_1);
            this.Name = "MenuForm";
            this.Text = "Меню";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTask1_1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonTask1_2;
    }
}

