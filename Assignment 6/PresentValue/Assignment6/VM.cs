/** PresentValue - A6 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Assignment6
{
    class VM : INotifyPropertyChanged
    {
        bool mode;
        decimal futureVal;
        decimal numYrs;
        decimal intRate;
        decimal presentbalance;

        public bool Mode
        {
            get { return mode; }
            set { mode = value; NotifyChanged(); }
        }

        public decimal FutureValue
        {   get { return futureVal; }
            set { futureVal = value; NotifyChanged(); }
        }

        public decimal NumYears
        {
            get { return numYrs; }
            set { numYrs = value; NotifyChanged(); }
        }

        public decimal InterestRate
        {
            get { return intRate; }
            set { intRate = value; NotifyChanged(); }
        }

        public decimal PresentValue
        {
            get { return presentbalance; }
            set { presentbalance = value; NotifyChanged(); }
        }

        public VM()
        {
            Mode = true;
        }

        public void CalcPresentValue()
        {
            Mode = false;
            decimal _interestRate = InterestRate / 100;
            decimal presentValue = CalcPresentValueOfDeposit((decimal)FutureValue, _interestRate, (double)NumYears);
            PresentValue = Math.Round((decimal)presentValue, 2);
        }

        public decimal CalcPresentValueOfDeposit(decimal futureValue, decimal interestRate, double years)
        {
            return futureValue / (decimal)Math.Pow((double)(1 + interestRate), years);
        }

        public void Reload()
        {
            InterestRate = Decimal.Zero;
            NumYears = Decimal.Zero;
            FutureValue = Decimal.Zero;
            Mode = true;
            PresentValue = Decimal.Zero;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
