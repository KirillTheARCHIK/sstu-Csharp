using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numerical_Analysis.Tasks;

namespace Numerical_Analysis
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void buttonTask1_1_Click(object sender, EventArgs e)
        {
            new Form1_1().ShowDialog();
        }
    }
}
