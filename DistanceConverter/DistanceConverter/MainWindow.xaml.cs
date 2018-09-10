/** DistanceConverter - A4 - Group4
 * Vishal V.    8205031
 * Gevindu M.
 * Rahul M.     8258980
 * Ramandeep K.
 * Gurjinder S.
 */
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace DistanceConverter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>    

    public partial class MainWindow : Window
    {
        DistanceConverterVM dcVM = new DistanceConverterVM();
        const int DECIMAL_PLACES_ALLOWED = 3;  // Maximum number of decimal places permitted for input
        const string DECIMAL_CHAR = ".";
        const string NUMBER_REGEX = "[0-9]";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = dcVM;
        }

        // Function to render list box items (distance units) for to and from units listbox
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] units = { dcVM.YARD_UNIT_LABEL, dcVM.FEET_UNIT_LABEL, dcVM.INCHES_UNIT_LABEL };
            foreach (string unit in units)
            {
                LbFromUnit.Items.Add(unit);
                LbToUnit.Items.Add(unit);
            }
        }

        // Function to validate input number
        private void TbDistance_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex(NUMBER_REGEX).IsMatch(e.Text);
            bool isKeyDecimal = (e.Text == DECIMAL_CHAR);
            string inputText = TbDistance.Text;
            // isInValidDecimal: true if input is invalid input (has more than 3 decimal numbers), false otherwise
            bool isInValidDecimal = (TbDistance.Text.Contains(DECIMAL_CHAR) &&
                (((inputText.Length - inputText.IndexOf(DECIMAL_CHAR)) > DECIMAL_PLACES_ALLOWED) || isKeyDecimal));

            // if input is not a valid decimal => (e.Hanlded = true)
            e.Handled = (!(isInputTextNumber || isKeyDecimal) || isInValidDecimal);
        }

        // Function to handle Text Change Event for TextBox
        private void TbDistance_TextChanged(object sender, TextChangedEventArgs e)
        {
            dcVM.LblDistance = string.Empty;
            BtnConvert.IsEnabled = (TbDistance.Text != string.Empty);
        }

        // Function to handle click event for Convert Distance button
        private void BtnConvert_Click(object sender, RoutedEventArgs e)
        {
            dcVM.ConvertDistance();
        }
    }
}
