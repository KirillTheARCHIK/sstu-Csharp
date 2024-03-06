using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;
using Numerical_Analysis.Tasks;

namespace Numerical_Analysis
{
    public partial class MenuForm : Form
    {
        ILogger<MenuForm> logger;
        public MenuForm(ILogger<MenuForm> logger)
        {
            this.logger = logger;
            Program.logger = logger;
            InitializeComponent();
        }

        private void buttonTask1_1_Click(object sender, EventArgs e)
        {
            new Form1_1().ShowDialog();
        }

        private void buttonTask1_2_Click(object sender, EventArgs e)
        {
            new Form1_2().ShowDialog();
        }

        private void buttonMathFunctions_Click(object sender, EventArgs e)
        {
            new MathFunctionForm().ShowDialog();
        }
    }
}
