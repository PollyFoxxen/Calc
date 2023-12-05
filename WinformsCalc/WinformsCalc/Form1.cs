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
        private string currentInput = "";
        private double currentResult = 0;
        private char lastOperator;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnNumInput(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            currentInput += button.Text;
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            if (string.IsNullOrEmpty(currentInput))
            {
                outputText.Text = currentResult.ToString();
            } else
            {
                outputText.Text = currentInput;
            }
        }

        private void btnEquals_Click(object sender, EventArgs e)
        {
            PerformOperation();
            lastOperator = '\0';
            currentInput = "";
            UpdateDisplay();
        }

        private void btnDivision_Click(object sender, EventArgs e)

        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(currentInput))
            {
                PerformOperation();
                lastOperator = button.Text[0];
                currentInput = "";
            }

            else if (lastOperator != '\0')
            {
                lastOperator = button.Text[0];
            }
                UpdateDisplay();
        }

        private void btnClear_click(object sender, EventArgs e)
        {
            currentInput = "";
            currentResult = 0;
            lastOperator = '\0';
            UpdateDisplay();
        }

        private void PerformOperation()
        {
            if (!string.IsNullOrEmpty(currentInput))
            {
                double inputNumber = double.Parse(currentInput);

                switch (lastOperator)
                {
                    case '+':
                        currentResult += inputNumber;
                        break;
                    case '-':
                        currentResult -= inputNumber;
                        break;
                    case '/':
                        currentResult /= inputNumber;
                        break;
                    case '\0':
                        currentResult = inputNumber;
                        break;
                }
            }
        }

        private void btnOperator_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (!string.IsNullOrEmpty(currentInput))
            {
                PerformOperation();
                lastOperator = button.Text[0];
                currentInput = "";
            }
            else if(lastOperator != '\0')
            {
                lastOperator = button.Text[0];
            }

            UpdateDisplay();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //btnDivision_Click(sender, e);
        }

       

    }
}
