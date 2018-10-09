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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {

            InitializeComponent();
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;
            equalsButton.Click += EqualsButton_Click;
        }

        private void EqualsButton_Click(object sender, RoutedEventArgs e)
        {
            double newNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Substraction:
                        result = SimpleMath.Substract(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiply(lastNumber, newNumber);
                        break;
                    case SelectedOperator.Divison:
                        result = SimpleMath.Divide(lastNumber, newNumber);
                        break;
                }

                resultLabel.Content = result.ToString();
            }
        }

        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber / 100;
                resultLabel.Content = lastNumber.ToString();
            }
        }


        private void OperationButton_Click (object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if(sender == multiplyButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            if (sender == divideButton)
            {
                selectedOperator = SelectedOperator.Divison;
            }
            if (sender == plusButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender == substractButton)
            {
                selectedOperator = SelectedOperator.Substraction;
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
        }

        private void CommaButton_Click(object sender, RoutedEventArgs e)
        {
            if (resultLabel.Content.ToString().Contains("."))
            {
            
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}.";
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedValue = 0;
            if (sender == zeroButton) selectedValue = 0;
            if (sender == oneButton) selectedValue = 1;
            if (sender == twoButton) selectedValue = 2;
            if (sender == threeButton) selectedValue = 3;
            if (sender == fourButton) selectedValue = 4;
            if (sender == fiveButton) selectedValue = 5;
            if (sender == sixButton) selectedValue = 6;
            if (sender == sevenButton) selectedValue = 7;
            if (sender == eightButton) selectedValue = 8;
            if (sender == nineButton) selectedValue = 9;

            if (resultLabel.Content.ToString() == "0"){
                resultLabel.Content = $"{selectedValue}";
            }
            else{
                resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
            }
        }
    }
}

public enum SelectedOperator
{
    Addition,
    Substraction,
    Multiplication,
    Divison
}

public class SimpleMath
{
    public static double Add(double number1, double number2)
    {
        return number1 + number2;
    }
    public static double Substract(double number1, double number2)
    {
        return number1 - number2;
    }
    public static double Multiply(double number1, double number2)
    {
        return number1 * number2;
    }
    public static double Divide(double number1, double number2)
    {
        if (number2 == 0)
        {
            MessageBox.Show("Division by 0 is immposibble", "Wrong operation", MessageBoxButton.OK,MessageBoxImage.Exclamation);
            return 0;
        }
        return number1 / number2;
    
    }
}