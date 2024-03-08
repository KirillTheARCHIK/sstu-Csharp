using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            _Refresh();
        }

        void _Refresh()
        {
            Program.logger.Log(LogLevel.Information, "Refresh()");
            mathFunction = new MathFunction(textBoxF.Text, true);
            RefreshVariables();
            ErrorLabel.Text = "";
            labelFx.Text = "";
            labelFpx.Text = "";
            if (mathFunction.variables.Count <= 1)
            {
                if (mathFunction.variables.Count >= 1)
                {
                    textBoxFpVariable.Text = mathFunction.variables.ElementAt(0).ToString();
                }
                textBoxFpVariable.Enabled = false;
            }
            else
            {
                textBoxFpVariable.Enabled = true;
            }
            try
            {
                if (variableValues.All(entry => entry.Value != null))
                {
                    var fx = mathFunction.ResolveExpression(variableValues);
                    labelFx.Text = $"Значение функции в точке = {Math.Round(fx, 3)}";
                    labelFpx.Text = $"Значение производной в точке = {Math.Round(mathFunction.GetDerivative(variableValues, textBoxFpVariable.Text[0]), 3)}";
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

        private void textBoxF_TextChanged(object sender, EventArgs e)
        {
            lastSelectedVariableTextBox = ' ';
            _Refresh();
        }

        private void textBoxFpVariable_TextChanged(object sender, EventArgs e)
        {
            if (textBoxFpVariable.Text.Length > 1)
            {
                textBoxFpVariable.Text = textBoxFpVariable.Text.Substring(0, 1);
            }
            lastSelectedVariableTextBox = ' ';
            _Refresh();
        }
    }
}
