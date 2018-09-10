using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace Assignment5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        VM vm = new VM();
        const int DECIMAL_PLACES_ALLOWED = 3;  // Maximum number of decimal places permitted for input
        const string DECIMAL_CHAR = ".";
        const string NUMBER_REGEX = "[0-9]";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void btnCheck_Click(object sender, RoutedEventArgs e)
        {
            vm.checkAnswer();
           
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex(NUMBER_REGEX).IsMatch(e.Text);
            bool isKeyDecimal = (e.Text == DECIMAL_CHAR);
            string inputText = vm.UserAnswer.ToString();
            // isInValidDecimal: true if input is invalid input (has more than 3 decimal numbers), false otherwise
            bool isInValidDecimal = (vm.UserAnswer.ToString().Contains(DECIMAL_CHAR) &&
                (((inputText.Length - inputText.IndexOf(DECIMAL_CHAR)) > DECIMAL_PLACES_ALLOWED) || isKeyDecimal));

            // if input is not a valid decimal => (e.Hanlded = true)
            e.Handled = (!(isInputTextNumber || isKeyDecimal) || isInValidDecimal);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            vm.GenerateRandomNumber();
        }
    }
}
