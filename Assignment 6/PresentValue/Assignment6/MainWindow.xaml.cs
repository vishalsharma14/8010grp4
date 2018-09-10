/** PresentValue - A6 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System.Text.RegularExpressions;
using System.Windows;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int DECIMAL_PLACES_ALLOWED = 3;  // Maximum number of decimal places permitted for input
        const string DECIMAL_CHAR = ".";
        const string NUMBER_REGEX = "[0-9]";

        VM vm = new VM();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = vm;
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            vm.CalcPresentValue();
        }

        private void BtnReload_Click(object sender, RoutedEventArgs e)
        {
            vm.Reload();
        }

        private void TextBox_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex(NUMBER_REGEX).IsMatch(e.Text);
            bool isKeyDecimal = (e.Text == DECIMAL_CHAR);
            string inputText = TbFutureValue.Text;
            // isInValidDecimal: true if input is invalid input (has more than 3 decimal numbers), false otherwise
            bool isInValidDecimal = (TbFutureValue.Text.Contains(DECIMAL_CHAR) &&
                (((inputText.Length - inputText.IndexOf(DECIMAL_CHAR)) > DECIMAL_PLACES_ALLOWED) || isKeyDecimal));

            // if input is not a valid decimal => (e.Hanlded = true)
            e.Handled = (!(isInputTextNumber || isKeyDecimal) || isInValidDecimal);
        }
    }
}
