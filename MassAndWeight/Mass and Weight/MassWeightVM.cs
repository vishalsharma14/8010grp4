/** MassAndWeight - A3 - Group4
 * Vishal V.    8205031
 * Gevindu M.
 * Rahul M.     8258980
 * Ramandeep K.
 * Gurjinder S.
 */
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Mass_and_Weight
{
    class MassWeightVM : INotifyPropertyChanged
    {
        const float CONVERSION_FACTOR = 9.8F;

        // Weight Threshold constants
        const int HEAVY_OBJECT_WEIGHT_THRESHOLD = 1000;
        const string HEAVY_OBJECT_MSG = "The object is too heavy!";
        const int LIGHT_OBJECT_WEIGHT_THRESHOLD = 10;
        const string LIGHT_OBJECT_MSG = "The object is too light!";

        const string WEIGHT_STRING_PATTERN = "0.## N";  // String pattern to display calculated weight in Newtons

        string weight;
        string mass;
        string weightDescription;

        public string Weight
        {
            get
            {
                return weight;
            }
            set
            {
                weight = value;
                OnPropertyChanged();
            }
        }

        public string Mass
        {
            get
            {
                return mass;
            }
            set
            {
                mass = value;
                OnPropertyChanged();
            }
        }

        public string WeightDescription
        {
            get
            {
                return weightDescription;
            }
            set
            {
                weightDescription = value;
                OnPropertyChanged();
            }
        }

        // Function to set weight description
        private void SetWeightDescription(float calculatedWeight)
        {
            WeightDescription = string.Empty;

            if (calculatedWeight > HEAVY_OBJECT_WEIGHT_THRESHOLD)
            {
                WeightDescription = HEAVY_OBJECT_MSG;
            }
            else if (calculatedWeight < LIGHT_OBJECT_WEIGHT_THRESHOLD)
            {
                WeightDescription = LIGHT_OBJECT_MSG;
            }
        }

        // Function to calculate weight for input mass
        public void ConvertMassToWeight()
        {
            float calculatedWeight = float.Parse(Mass) * CONVERSION_FACTOR;
            SetWeightDescription(calculatedWeight);
            Weight = calculatedWeight.ToString(WEIGHT_STRING_PATTERN);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        // Property Change event handler
        private void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
