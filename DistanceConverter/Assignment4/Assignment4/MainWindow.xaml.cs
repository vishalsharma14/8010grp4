using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Assignment4
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LbBox.Items.Add(new ListItem { measurement="Yards" });
            LbBox.Items.Add(new ListItem { measurement = "Feet" });
            LbBox.Items.Add(new ListItem { measurement = "Inches" });

            LbBox2.Items.Add(new ListItem { measurement = "Yards" });
            LbBox2.Items.Add(new ListItem { measurement = "Feet" });
            LbBox2.Items.Add(new ListItem { measurement = "Inches" });

            ChangeColor.ItemsSource = typeof(Colors).GetProperties();
        }

         public void Create()
        {
                string strFrom = LbBox.SelectedItem.ToString();
                float inputNumber = float.Parse(Tbdistance.Text);
                string strTo = LbBox2.SelectedItem.ToString();

                float result = 0;

                if (strFrom == "Yards" && strTo == "Feet")
                    result = inputNumber * 3;
                else if (strFrom == "Yards" && strTo == "Inches")
                    result = inputNumber * 36;
                else if (strFrom == "Feet" && strTo == "Yards")
                    result = inputNumber / 3;
                else if (strFrom == "Feet" && strTo == "Inches")
                    result = inputNumber * 12;
                else if (strFrom == "Inches" && strTo == "Feet")
                    result = inputNumber / 12;
                else if (strFrom == "Inches" && strTo == "Yards")
                    result = inputNumber / 36;
                else if (strFrom == "Inches" && strTo == "Inches" || strFrom == "Yards" && strTo == "Yards" || strFrom == "Feet" && strTo == "Feet")
                    result = inputNumber;

                TxtDisplay.Text = result.ToString()+" "+strTo;
            
        }

        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
           Create();
        }

        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            Tbdistance.Text = string.Empty;
            TxtDisplay.Text = string.Empty;
            LbBox.SelectedIndex = 0;
            LbBox2.SelectedIndex = 0;
        }

        private void Tbdistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tbdistance.Text != string.Empty)
            {
                BtnConvert.IsEnabled = true;
                BtnClear.IsEnabled = true;
            }
            else
            {
                BtnConvert.IsEnabled = false;
                BtnClear.IsEnabled = false;
                TxtDisplay.Text = string.Empty;
                LbBox.SelectedIndex = 0;
                LbBox2.SelectedIndex = 0;
            }
        }

        private void Tbdistance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex(NUMBER_REGEX).IsMatch(e.Text);
            bool isKeyDecimal = (e.Text == DECIMAL_CHAR);
            string inputText = Tbdistance.Text;
            // isInValidDecimal: true if input is invalid input (has more than 3 decimal numbers), false otherwise
            bool isInValidDecimal = (Tbdistance.Text.Contains(DECIMAL_CHAR) &&
                (((inputText.Length - inputText.IndexOf(DECIMAL_CHAR)) > DECIMAL_PLACES_ALLOWED) || isKeyDecimal));

            // if input is not a valid decimal => (e.Hanlded = true)
            if (!(isInputTextNumber || isKeyDecimal) || isInValidDecimal)
                e.Handled = true;
        }

        private void ChangeColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Color selectedColor = (Color)(ChangeColor.SelectedItem as PropertyInfo).GetValue(1,null);
            Background = new SolidColorBrush(color: selectedColor);
        }
    }
}
