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
        MathFunction mathFunction;
        Dictionary<char, double?> variableValues;
        char lastSelectedVariableTextBox;
        public MathFunctionForm()
        {
            InitializeComponent();
            variableValues = new Dictionary<char, double?>();
        }

        void _Refresh()
        {
            mathFunction = new MathFunction(textBox1.Text, true);
            RefreshVariables();
            ErrorLabel.Text = "";
            labelFx.Text = "";
            labelFpx.Text = "";
            try
            {
                if (variableValues.All(entry => entry.Value != null))
                {
                    var fx = mathFunction.ResolveExpression(variableValues);
                    labelFx.Text = $"Значение функции в точке = {fx}";
                    labelFpx.Text = mathFunction.GetDerivative(variableValues, variableValues.First().Key).ToString();
                }
            }
            catch (Exception e)
            {
                ErrorLabel.Text = e.Message;
            }
        }

        void RefreshVariables()
        {
            variablesFlowLayoutPanel.Controls.Clear();
            variableValues = variableValues.Where(pair => mathFunction.variables.Contains(pair.Key)).ToDictionary(i => i.Key, i => i.Value);
            foreach (var variable in mathFunction.variables)
            {
                FlowLayoutPanel row = new FlowLayoutPanel();
                row.AutoSize = true;
                row.Margin = new Padding(0);
                //row.BackColor = Color.Red;
                Label label = new Label();
                label.Font = new Font(label.Font.FontFamily, 12);
                label.Text = variable.ToString();
                label.AutoSize = true;
                TextBox textBox = new TextBox();
                textBox.Width = 50;
                if (variableValues.ContainsKey(variable))
                {
                    textBox.Text = variableValues[variable].ToString();
                }
                textBox.TextChanged += delegate (object sender, EventArgs e)
                {
                    double newValue;
                    if (double.TryParse((sender as TextBox).Text, out newValue) && (!variableValues.ContainsKey(variable) || newValue != variableValues[variable]))
                    {
                        variableValues[variable] = newValue;
                        lastSelectedVariableTextBox = variable;
                        _Refresh();
                    }
                };
                row.Controls.Add(label);
                row.Controls.Add(textBox);
                variablesFlowLayoutPanel.Controls.Add(row);
                if (variable == lastSelectedVariableTextBox)
                {
                    textBox.Focus();
                    textBox.Select(textBox.Text.Length, 0);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            lastSelectedVariableTextBox = ' ';
            _Refresh();
        }
    }
}
