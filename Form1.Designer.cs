
namespace StudentsDB
{
    partial class Form1
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.StudentDeleteButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.SortByNameButton = new System.Windows.Forms.Button();
            this.SortByYearButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 78);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(776, 360);
            this.dataGridView1.TabIndex = 0;
            // 
            // StudentDeleteButton
            // 
            this.StudentDeleteButton.Location = new System.Drawing.Point(309, 36);
            this.StudentDeleteButton.Name = "StudentDeleteButton";
            this.StudentDeleteButton.Size = new System.Drawing.Size(75, 23);
            this.StudentDeleteButton.TabIndex = 1;
            this.StudentDeleteButton.Text = "Удалить";
            this.StudentDeleteButton.UseVisualStyleBackColor = true;
            this.StudentDeleteButton.Click += new System.EventHandler(this.StudentDeleteButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 36);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(291, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // SortByNameButton
            // 
            this.SortByNameButton.Location = new System.Drawing.Point(419, 12);
            this.SortByNameButton.Name = "SortByNameButton";
            this.SortByNameButton.Size = new System.Drawing.Size(174, 23);
            this.SortByNameButton.TabIndex = 3;
            this.SortByNameButton.Text = "Отсортировать по ФИО";
            this.SortByNameButton.UseVisualStyleBackColor = true;
            this.SortByNameButton.Click += new System.EventHandler(this.SortByNameButton_Click);
            // 
            // SortByYearButton
            // 
            this.SortByYearButton.Location = new System.Drawing.Point(599, 12);
            this.SortByYearButton.Name = "SortByYearButton";
            this.SortByYearButton.Size = new System.Drawing.Size(174, 23);
            this.SortByYearButton.TabIndex = 3;
            this.SortByYearButton.Text = "Отсортировать по классу";
            this.SortByYearButton.UseVisualStyleBackColor = true;
            this.SortByYearButton.Click += new System.EventHandler(this.SortByYearButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SortByYearButton);
            this.Controls.Add(this.SortByNameButton);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.StudentDeleteButton);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button StudentDeleteButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Button SortByNameButton;
        private System.Windows.Forms.Button SortByYearButton;
    }
}

