using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_1_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string currentNumber = "";
        private string previousExpression = "";
        private char currentOperation = ' ';
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Number_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            currentNumber += button.Content.ToString();
            UpdateDisplay();
        }
        private void UpdateDisplay()
        {
            currentNumberTextBox.Text = currentNumber;
            previousExpressionTextBox.Text = previousExpression;
        }
        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (!string.IsNullOrEmpty(currentNumber))
            {
                Calculate();
                previousExpression = currentNumber;
                currentOperation = button.Content.ToString()[0];
                currentNumber = "";
                UpdateDisplay();
            }
        }
        private void Result_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(currentNumber))
            {
                Calculate();
                previousExpression = "";
                currentOperation = ' ';
                UpdateDisplay();
            }
        }
        private void CE_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            UpdateDisplay();
        }
        private void C_Click(object sender, RoutedEventArgs e)
        {
            currentNumber = "";
            previousExpression = "";
            currentOperation = ' ';
            UpdateDisplay();
        }
        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            if (currentNumber.Length > 0)
            {
                currentNumber = currentNumber.Substring(0, currentNumber.Length - 1);
                UpdateDisplay();
            }
        }
        private void Calculate()
        {
            if (!string.IsNullOrEmpty(previousExpression) && !string.IsNullOrEmpty(currentNumber))
            {
                double num1 = Convert.ToDouble(previousExpression);
                double num2 = Convert.ToDouble(currentNumber);

                switch (currentOperation)
                {
                    case '+':
                        currentNumber = (num1 + num2).ToString();
                        break;
                    case '-':
                        currentNumber = (num1 - num2).ToString();
                        break;
                    case '*':
                        currentNumber = (num1 * num2).ToString();
                        break;
                    case '/':
                        if (num2 != 0)
                            currentNumber = (num1 / num2).ToString();
                        else
                            currentNumber = "Error";
                        break;

                }
            }
        }
    }
}
