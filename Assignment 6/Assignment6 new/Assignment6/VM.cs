using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Assignment6
{
    class VM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        bool btnMode;
        public bool BtnMode
        {
            get
            {
                return btnMode;
            }
            set
            {
                btnMode = value;
                NotifyChanged();
            }
        }

        decimal futureVal;
        public decimal FutureValue
        {   get
            {
                return futureVal;
            }
            set
            {
                futureVal = value;
                NotifyChanged();
            }
        }
        decimal numYrs;
        public decimal NumYears
        {
            get
            {
                return numYrs;
            }
            set
            {
                numYrs = value;
                NotifyChanged();
            }
        }
        decimal intRate;
        public decimal interestRate
        {
            get
            {
                return intRate;
            }
            set
            {
                intRate = value;
                NotifyChanged();
            }
        }
        decimal Presentbalance;
        public decimal PresentValue
        {
            get
            {
                return Presentbalance;
            }
            set
            {
                Presentbalance = value;
                NotifyChanged();
            }
        }
        public VM()
        {
            btnMode = true;
        }
        public void CalcPresentValue()
        {
            BtnMode = false;
            interestRate /=100;
            PresentValue = (decimal)FutureValue /
                    (decimal)Math.Pow((double)
                    (1 + interestRate), (double)NumYears);
            PresentValue = Math.Round((decimal)PresentValue, 2);
        }
        public void Reload()
        {
            interestRate = Decimal.Zero;
            NumYears = Decimal.Zero;
            FutureValue = Decimal.Zero;
            BtnMode = true;
        }
    }
}
