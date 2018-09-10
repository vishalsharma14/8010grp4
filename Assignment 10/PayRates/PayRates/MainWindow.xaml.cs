/** PayRates - A10 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.Windows;

namespace PayRates
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PayRatesVM prVM = new PayRatesVM();
        Output O = null;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = prVM;
        }

        private void Btn_Max_Click(object sender, RoutedEventArgs e)
        {
            prVM.Output(prVM.MAXIMUM);
            ShowOutputWindow();
        }

        private void Btn_Min_Click(object sender, RoutedEventArgs e)
        {
            prVM.Output(prVM.MINIMUM);
            ShowOutputWindow();
        }

        private void ShowOutputWindow()
        {
            if (O == null)
            {
                O = new Output(prVM)
                {
                    WindowStartupLocation = WindowStartupLocation.CenterOwner // Not Working!
                };

                O.Closed += CalculatorOutput_Closed;
                O.Show();
            }
        }

        private void CalculatorOutput_Closed(object sender, EventArgs e)
        {
            O = null;
        }
    }
}
