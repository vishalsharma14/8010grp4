/** MassAndWeight - A3 - Group4
 * Vishal V.    8205031
 * Gevindu M.
 * Rahul M.     8258980
 * Ramandeep K.
 * Gurjinder S.
 */
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Mass_and_Weight
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MassWeightVM mwVM = new MassWeightVM();

        const int DECIMAL_PLACES_ALLOWED = 3;  // Maximum number of decimal places permitted for input
        const string DECIMAL_CHAR = ".";
        const string NUMBER_REGEX = "[0-9]";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = mwVM;
        }

        // Function to validate input number
        private void TbInputMass_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex(NUMBER_REGEX).IsMatch(e.Text);
            bool isKeyDecimal = (e.Text == DECIMAL_CHAR);
            string inputText = TbInputMass.Text;
            // isInValidDecimal: true if input is invalid input (has more than 3 decimal numbers), false otherwise
            bool isInValidDecimal = (TbInputMass.Text.Contains(DECIMAL_CHAR) &&
                (((inputText.Length - inputText.IndexOf(DECIMAL_CHAR)) > DECIMAL_PLACES_ALLOWED) || isKeyDecimal));

            // if input is not a valid decimal => (e.Hanlded = true)
            if (!(isInputTextNumber || isKeyDecimal) || isInValidDecimal)
                e.Handled = true;
        }

        // Function to handle Text Change Event for TextBox (to disable CalculateWeight button)
        private void TbInputMass_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (TbInputMass.Text != string.Empty)
            {
                BtnCalculateWeight.IsEnabled = true;
            }
            else
            {
                BtnCalculateWeight.IsEnabled = false;
            }
        }

        // Function to handle click event for Calculate weight button
        private void BtnCalculateWeight_Click(object sender, RoutedEventArgs e)
        {
            mwVM.ConvertMassToWeight(); // Converts input mass to weight and updates binded value
        }
    }
}
