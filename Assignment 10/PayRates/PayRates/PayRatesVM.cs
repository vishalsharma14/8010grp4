/** PayRates - A10 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace PayRates
{
    public class PayRatesVM : INotifyPropertyChanged
    {
        DB db = DB.GetInstance();

        public string MAXIMUM = "Maximum";
        public string MINIMUM = "Minimum";

        private BindingList<Employee> _employees;
        private string _outputPayPerHourMsg;
        private decimal _outputPayPerHour;

        public BindingList<Employee> Employees
        {
            get { return _employees; }
            set { _employees = value; OnNotifyChanged(); }
        }

        public decimal OutputPayPerHour
        {
            get { return _outputPayPerHour; }
            set { _outputPayPerHour = value; OnNotifyChanged(); }
        }

        public string OutputPayPerHourMsg
        {
            get { return _outputPayPerHourMsg; }
            set { _outputPayPerHourMsg = value; OnNotifyChanged(); }
        }

        public void CreateNewEmployee(int id, string name, string position, decimal payPerHour)
        {
            Employee e = new Employee()
            {
                ID = id,
                Name = name,
                Position = position,
                PayPerHour = payPerHour
            };
            db.Add(e);
        }

        public PayRatesVM()
        {
            CreateNewEmployee(1, "John", "Developer", 25m);
            CreateNewEmployee(2, "Jacob", "Architect", 30m);
            CreateNewEmployee(3, "Alan", "Database Admin", 10m);
            CreateNewEmployee(4, "Andrew", "Admin", 15m);
            CreateNewEmployee(5, "Jane", "Manager", 20m);
            CreateNewEmployee(6, "Ashley", "Developer", 22m);

            _employees = new BindingList<Employee>(db.Get());
        }

        public void Output(string payQuantifier)
        {
            if( payQuantifier == MAXIMUM)
            {
                OutputPayPerHourMsg = MAXIMUM;
                OutputPayPerHour = db.GetMaxPay(); 
            }
            else
            {
                OutputPayPerHourMsg = MINIMUM;
                OutputPayPerHour = db.GetMinPay();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyChanged([CallerMemberName] string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
