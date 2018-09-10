/** DormMealPlanCalculator - A9 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System.Windows;

namespace DormMealPlanCalculator
{
    /// <summary>
    /// Interaction logic for CalculatorOutput.xaml
    /// </summary>
    public partial class CalculatorOutput : Window
    {
        public CalculatorOutput()
        {
            InitializeComponent();
        }

        public CalculatorOutput(PlanCalculatorVM vm)
        {
            InitializeComponent();
            DataContext = vm;
        }
    }
}
