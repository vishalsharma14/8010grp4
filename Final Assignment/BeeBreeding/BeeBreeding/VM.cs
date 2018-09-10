/** BeeBreeding - FinalAssignment - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BeeBreeding
{
    class VM : INotifyPropertyChanged
    {
        private int _firstNum;
        private int _secondNum;
        private int _distance;
        private string _outputLabel;

        private Grid grid = new Grid();

        public int FirstNum
        {
            get { return _firstNum; }
            set { _firstNum = value; Calculate(); OnNotifyChanged(); }
        }

        public int SecondNum
        {
            get { return _secondNum; }
            set { _secondNum = value; Calculate(); OnNotifyChanged(); }
        }

        public int Distance
        {
            get { return _distance; }
            set { _distance = value; OnNotifyChanged(); }
        }

        public string OutputLabel
        {
            get { return _outputLabel; }
            set { _outputLabel = value; OnNotifyChanged(); }
        }

        public void Calculate()
        {
            if(FirstNum!=0 && SecondNum!=0)
            {
                Distance = grid.FindDistance(FirstNum, SecondNum);
                OutputLabel = "Visible";
            }
            else
            {
                OutputLabel = "Hidden";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
