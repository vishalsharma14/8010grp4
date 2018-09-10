/** DormMealPlanCalculator - A9 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DormMealPlanCalculator
{
    public class PlanCalculatorVM : INotifyPropertyChanged
    {
        private List<string> _dorms = new List<string>();
        private string _selectedDorm;
        private List<string> _mealPlans = new List<string>();
        private string _selectedMealPlan;
        private decimal _dormPrice;
        private decimal _mealPrice;
        private decimal _totalAmount;

        private readonly Dictionary<string, decimal> DormsPriceDict = new Dictionary<string, decimal>()
        {
            { "Allen Hall", 1500m },
            { "Pike Hall" , 1600m},
            { "Farthing Hall", 1800m },
            { "University Suites", 2500m}
        };

        private readonly Dictionary<string, decimal> MealPlansPriceDict = new Dictionary<string, decimal>()
        {
            { "7 Meals per week", 600m },
            { "14 Meals per week" , 1200m},
            { "Unlimited Meals", 1700m}
        };

        public List<string> Dorms
        {
            get { return _dorms; }
            set { _dorms = value; NotifyPropertyChanged(); }
        }

        public string SelectedDorm
        {
            get { return _selectedDorm; }
            set { _selectedDorm = value; NotifyPropertyChanged(); }
        }

        public decimal DormPrice
        {
            get { return _dormPrice; }
            set { _dormPrice = value; NotifyPropertyChanged(); }
        }

        public decimal MealPrice
        {
            get { return _mealPrice; }
            set { _mealPrice = value; NotifyPropertyChanged(); }
        }

        public decimal TotalAmount
        {
            get { return _totalAmount; }
            set { _totalAmount = value; NotifyPropertyChanged(); }
        }

        public List<string> MealPlans
        {
            get { return _mealPlans; }
            set { _mealPlans = value; NotifyPropertyChanged(); }
        }

        public string SelectedMealPlan
        {
            get { return _selectedMealPlan; }
            set { _selectedMealPlan = value; NotifyPropertyChanged(); }
        }

        // Function to return list of keys from a dictionary
        public List<string> GetKeyListFromDict(Dictionary<string, decimal> Dict)
        {
            List<string> tempList = new List<string>();
            foreach (var key in Dict.Keys)
            {
                tempList.Add(key);
            }
            return tempList;
        }

        // Constructor to initialize combobox contents
        public PlanCalculatorVM()
        {
            Dorms = GetKeyListFromDict(DormsPriceDict);
            MealPlans = GetKeyListFromDict(MealPlansPriceDict);
        }

        // Function to calculate total amount based on selection
        public void Calculate()
        {
            DormPrice = DormsPriceDict[SelectedDorm];
            MealPrice = MealPlansPriceDict[SelectedMealPlan];
            TotalAmount = DormPrice + MealPrice;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Property Change event handler
        private void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
