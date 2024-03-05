using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numerical_Analysis
{
    public partial class MathFunctionForm : Form
    {
        ILogger logger;
        public MathFunctionForm(ILogger logger)
        {
            this.logger = logger;
            InitializeComponent();
        }

        void _Refresh()
        {
            MathFunction mathFunction = new MathFunction(textBox1.Text, true);
            try
            {
                var fx = mathFunction.ResolveExpression(new Dictionary<char, double> {
                    {'x',  0}
                });
            }
            catch (Exception)
            {
                ErrorLabel.Text = "Неверно задана функция";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            _Refresh();
        }
    }
}
