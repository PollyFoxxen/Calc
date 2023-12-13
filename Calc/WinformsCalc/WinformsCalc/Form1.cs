using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformsCalc
{
    public partial class Form1 : Form
    {
        private string _currentInput = "";
        private double _currentResult = 0;
        private char _lastOperator;
        private string _resultText;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumInput(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _currentInput += button.Text;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (!string.IsNullOrEmpty(_resultText))
            {
                outputText.Text = _resultText;
            }
            else if (string.IsNullOrEmpty(_currentInput))
            {
                outputText.Text = _currentResult.ToString();
            }
            else
            {
                outputText.Text = _currentInput;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            PerformOperation();
            _lastOperator = '\0';
            _currentInput = "";
            UpdateDisplay();
        }

        private void btnClear_click(object sender, EventArgs e)
        {
            _currentInput = "";
            _currentResult = 0;
            _lastOperator = '\0';
            UpdateDisplay();
        }

        private void PerformOperation()
        {
            if (!string.IsNullOrEmpty(_currentInput))
            {
                double inputNumber = double.Parse(_currentInput);


                switch (_lastOperator)
                {
                    case '+':
                        _currentResult += inputNumber;
                        break;
                    case '-':
                        _currentResult -= inputNumber;
                        break;
                    case '/':
                        _currentResult /= inputNumber;
                        break;
                    case '*':
                        _currentResult *= inputNumber;
                        break;
                    case '\0':
                        _currentResult = inputNumber;
                        break;
                }
            }
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(_currentInput))
            {
                PerformOperation();
                _lastOperator = button.Text[0];
                _currentInput = "";
            }
            else if (_lastOperator != '\0')
            {
                _lastOperator = button.Text[0];
            }

            UpdateDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btnNanna_Click(object sender, EventArgs e)
        {
            outputText.Text = "Sejt, ik?";
        }
    }
}
