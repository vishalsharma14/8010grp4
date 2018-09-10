/** DistanceConverter - A4 - Group4
 * Vishal V.    8205031
 * Gevindu M.
 * Rahul M.     8258980
 * Ramandeep K.
 * Gurjinder S.
 */
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DistanceConverter
{
    class DistanceConverterVM : INotifyPropertyChanged
    {
        string _tbInput;
        object _selectedFromUnit;
        object _selectedToUnit;
        string _lblDistance;

        const string YARD_UNIT = "Yards";
        const string FEET_UNIT = "Feet";
        const string INCHES_UNIT = "Inches";
        const float FEET_IN_YARD = 3;
        const float INCHES_IN_FEET = 12;
        const float INCHES_IN_YARD = FEET_IN_YARD * INCHES_IN_FEET;
        const string OUTPUT_DISTANCE_FORMAT = "{0} {1} = {2} {3}";
        const string DISTANCE_STRING_PATTERN = "0.##";  // String pattern to display calculated distance

        public string YARD_UNIT_LABEL = YARD_UNIT;
        public string FEET_UNIT_LABEL = FEET_UNIT;
        public string INCHES_UNIT_LABEL = INCHES_UNIT;

        public string TbInput
        {
            get { return _tbInput; }
            set { _tbInput = value; NotifyPropertyChanged(); }
        }

        public string LblDistance
        {
            get { return _lblDistance; }
            set { _lblDistance = value; NotifyPropertyChanged(); }
        }

        public object SelectedFromUnit
        {
            get { return _selectedFromUnit; }
            set { _selectedFromUnit = value; ClearLblDistance(); NotifyPropertyChanged(); }
        }

        public object SelectedToUnit
        {
            get { return _selectedToUnit; }
            set { _selectedToUnit = value; ClearLblDistance(); NotifyPropertyChanged(); }
        }

        // Function to convert distance from Yard
        private float ConvertFromYard(float inputValue, string toUnit)
        {
            switch (toUnit)
            {
                case FEET_UNIT:
                    return inputValue * FEET_IN_YARD;
                case INCHES_UNIT:
                    return inputValue * INCHES_IN_YARD;
                default:
                    return inputValue;
            }
        }

        // Function to convert distance from Feet
        private float ConvertFromFeet(float inputValue, string toUnit)
        {
            switch (toUnit)
            {
                case YARD_UNIT:
                    return inputValue / FEET_IN_YARD;
                case INCHES_UNIT:
                    return inputValue * INCHES_IN_FEET;
                default:
                    return inputValue;
            }
        }

        // Function to convert distance from Inches
        private float ConvertFromInches(float inputValue, string toUnit)
        {
            switch (toUnit)
            {
                case FEET_UNIT:
                    return inputValue / INCHES_IN_FEET;
                case YARD_UNIT:
                    return inputValue / INCHES_IN_YARD;
                default:
                    return inputValue;
            }
        }

        // Function to convert distance (fromUnit to toUnit)
        public void ConvertDistance()
        {
            if (SelectedFromUnit is object && SelectedToUnit is object)
            {
                string fromUnit = SelectedFromUnit.ToString();
                string toUnit = SelectedToUnit.ToString();
                float inputValue = float.Parse(TbInput);
                float convertedValue = inputValue;

                switch (fromUnit)
                {
                    case YARD_UNIT:
                        convertedValue = ConvertFromYard(inputValue, toUnit);
                        break;
                    case FEET_UNIT:
                        convertedValue = ConvertFromFeet(inputValue, toUnit);
                        break;
                    case INCHES_UNIT:
                        convertedValue = ConvertFromInches(inputValue, toUnit);
                        break;
                }
                LblDistance = string.Format(OUTPUT_DISTANCE_FORMAT, TbInput, fromUnit,
                    convertedValue.ToString(DISTANCE_STRING_PATTERN), toUnit);
            }
        }

        // Function to clear calculated distance output on Listbox selection change
        private void ClearLblDistance()
        {
            LblDistance = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // Property Change event handler
        private void NotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
