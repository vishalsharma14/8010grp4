/** AdditionTutor - A5 - Group4
 * Vishal V.    8205031
 * Gevindu M.
 * Rahul M.     8258980
 * Ramandeep K.
 * Gurjinder S.
 */
using System.Text.RegularExpressions;
using System.Windows;

namespace AdditionTutor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AdditionTutorVM aTVM = new AdditionTutorVM();
        const string NUMBER_REGEX = "[0-9]";

        public MainWindow()
        {
            InitializeComponent();
            DataContext = aTVM;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TbInput.Text = null;  // To hide default value (0) of Binded Variable (type int)
        }

        // Function to validate input on PreviewTextInput Event
        private void TbInput_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            bool isInputTextNumber = new Regex(NUMBER_REGEX).IsMatch(e.Text);

            // if input is not integer => (e.Hanlded = true)
            e.Handled = !isInputTextNumber;
        }

        // Function to Enable submit button on TextChanged Event
        private void TbInput_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            BtnSubmit.IsEnabled = !(TbInput.Text == null || TbInput.Text == string.Empty);
        }

        // Function to evaluate user input for quiz on submit button click
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            aTVM.EvaluateQuiz();
        }

        // Function to display new quiz to user
        private void BtnNewQuiz_Click(object sender, RoutedEventArgs e)
        {
            aTVM.NewQuiz();
            TbInput.Text = null;  // To hide default value (0) of Binded Variable (type int)
        }
    }
}
