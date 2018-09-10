/** PayRates - A10 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System.Windows;

namespace PayRates
{
    /// <summary>
    /// Interaction logic for Output.xaml
    /// </summary>
    public partial class Output : Window
    {
        public Output()
        {
            InitializeComponent();
        }

        public Output(PayRatesVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
