/** DormMealPlanCalculator - A9 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.Windows;
using System.Windows.Controls;

namespace DormMealPlanCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PlanCalculatorVM pcVM = new PlanCalculatorVM();
        CalculatorOutput CO = null;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = pcVM;
        }

        // Function to handle Calculate Button Click event
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            pcVM.Calculate();
            if (CO == null)
            {
                CO = new CalculatorOutput(pcVM);

                CO.Closed += CalculatorOutput_Closed;
                CO.Show();
            }
        }

        private void CalculatorOutput_Closed(object sender, EventArgs e)
        {
            CO = null;
        }

        // Function to disable/enable button on combobox selection change
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BtnCalculate.IsEnabled = (pcVM.SelectedDorm != null && pcVM.SelectedMealPlan != null);
        }
    }
}
