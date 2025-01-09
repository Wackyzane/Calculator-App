namespace Calculator_App
{
    public partial class Form1 : Form
    {
        private string currentNumber = String.Empty;
        private string lastNumber = String.Empty;
        private string function = String.Empty;
        private string lastFunction = String.Empty;
        private decimal lastResult = 0;
        private bool resetNumber = false;
        

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
            if (function == String.Empty && currentNumber == lastResult.ToString()) // Repeat last Action
            {
                function = lastFunction;
                currentNumber = lastNumber;
            }
            else if (function == String.Empty && currentNumber != lastResult.ToString()) function = lastFunction; // Assume last function
            if (currentNumber == String.Empty) currentNumber = "0"; // Assume user meant 0 if no number inputted

            EquationDisplay.Text = lastResult.ToString() + " " + function + " " + currentNumber + " = ";
            GetTotal();

            if (function != "") lastFunction = function;
            function = "";
            resetNumber = true;
            lastNumber = currentNumber;
            currentNumber = lastResult.ToString();

            Display.Text = currentNumber;
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            if (Display.Text == "0") // Full Reset Calculator
            {
                lastResult = 0;
                function = String.Empty;
                lastFunction = String.Empty;
                lastNumber = String.Empty;
                EquationDisplay.Text = String.Empty;
                resetNumber = false;
            }
            else Display.Text = "0"; // Reset only current number, not equation
            currentNumber = String.Empty;
        }

        private void GetTotal()
        {
            if (currentNumber == String.Empty) return;
            if (function == "") lastResult = Convert.ToDecimal(currentNumber);
            else if (function == "+") lastResult += Convert.ToDecimal(currentNumber);
            else if (function == "-") lastResult -= Convert.ToDecimal(currentNumber);
            else if (function == "*") lastResult *= Convert.ToDecimal(currentNumber);
            else if (function == "/") lastResult /= Convert.ToDecimal(currentNumber);
            //lastResult = Math.Round(lastResult, 15);
        }

        private void UpdateDisplay()
        {
            Display.Text = lastResult.ToString();
            EquationDisplay.Text = lastResult.ToString() + " " + function;
            currentNumber = "";
        }

        private void UpdateCurrentNumber(char number)
        {
            if (resetNumber)
            {
                currentNumber = String.Empty;
                resetNumber = false;
            }
            if (number == '.' && currentNumber == String.Empty) currentNumber = "0"; // Add A 0 before the Decimal

            if (currentNumber == "0") currentNumber = number.ToString(); // Remove 0 Before other numbers, IE 01 = 1
            else currentNumber += number;

            //currentNumber = number.ToString();
            Display.Text = currentNumber;
        }
    }
}
