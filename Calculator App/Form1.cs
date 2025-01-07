namespace Calculator_App
{
    using System.Collections.Generic;
    public partial class Form1 : Form
    {
        private string currentNumber = String.Empty;
        private string function = String.Empty;
        private bool resetCurrentNumber = true;
        private double lastResult = 0d;
        

        public Form1()
        {
            InitializeComponent();
        }

        private void Num0_Click(object sender, EventArgs e)
        {

            UpdateCurrentNumber('0');
        }

        private void Num1_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('1');
        }

        private void Num2_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('2');
        }

        private void Num3_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('3');
        }

        private void Num4_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('4');
        }

        private void Num5_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('5');
        }

        private void Num6_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('6');
        }

        private void Num7_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('7');
        }

        private void Num8_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('8');
        }

        private void Num9_Click(object sender, EventArgs e)
        {
            UpdateCurrentNumber('9');
        }

        private void DecimalButton_Click(object sender, EventArgs e)
        {
            if (currentNumber.Contains('.')) return;
            UpdateCurrentNumber('.');
        }

        private void AdditionButton_Click(object sender, EventArgs e)
        {
            GetTotal();
            function = "+";
            UpdateDisplay();
        }

        private void SubtractButton_Click(object sender, EventArgs e)
        {
            GetTotal();
            function = "-";
            UpdateDisplay();
        }

        private void MultiplyButton_Click(object sender, EventArgs e)
        {
            GetTotal();
            function = "*";
            UpdateDisplay();
        }

        private void DivideButton_Click(object sender, EventArgs e)
        {
            GetTotal();
            function = "/";
            UpdateDisplay();
        }

        private void EqualsButton_Click(object sender, EventArgs e)
        {
            if (function == "") return;
            if (currentNumber == String.Empty) currentNumber = "0";

            EquationDisplay.Text = lastResult.ToString() + " " + function + " " + currentNumber + " = ";
            GetTotal();
            Display.Text = lastResult.ToString();
            resetCurrentNumber = true;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0")
            {
                lastResult = 0d;
                function = "";
                EquationDisplay.Text = String.Empty;
            }
            else Display.Text = "0";
            currentNumber = String.Empty;
        }

        private void GetTotal()
        {
            if (currentNumber == String.Empty) return;
            if (resetCurrentNumber) return;
            if (function == "") lastResult = Convert.ToDouble(currentNumber);
            else if (function == "+") lastResult += Convert.ToDouble(currentNumber);
            else if (function == "-") lastResult -= Convert.ToDouble(currentNumber);
            else if (function == "*") lastResult *= Convert.ToDouble(currentNumber);
            else if (function == "/") lastResult /= Convert.ToDouble(currentNumber);
        }

        private void UpdateDisplay()
        {
            Display.Text = lastResult.ToString();
            EquationDisplay.Text = lastResult.ToString() + " " + function;
            currentNumber = "";
        }

        private void UpdateCurrentNumber(char number)
        {
            if (number == '.' && currentNumber == String.Empty) currentNumber = "0";

            if (currentNumber == "0") currentNumber = number.ToString();
            else currentNumber += number;
            if (resetCurrentNumber)
            {
                resetCurrentNumber = false;
                currentNumber = number.ToString();
            }

            Display.Text = currentNumber;
        }
    }
}
