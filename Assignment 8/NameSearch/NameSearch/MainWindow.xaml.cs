/** NameSearch - A8 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
 using System.Windows;

namespace NameSearch
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NameSearchVM nsVM = new NameSearchVM();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = nsVM;
        }
    }
}
