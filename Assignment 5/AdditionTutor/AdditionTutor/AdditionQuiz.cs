/** AdditionTutor - A5 - Group4
 * Vishal V.    8205031
 * Gevindu M.
 * Rahul M.     8258980
 * Ramandeep K.
 * Gurjinder S.
 */
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdditionTutor
{
    class AdditionQuiz : INotifyPropertyChanged
    {
        private const string EXPRESSION_FORMAT = "{0} + {1} = {2}";
        private int _firstNumber;
        public int _secondNumber;
        public int Output;

        private readonly int RANDOM_NUMBER_LOWER_LIMIT = 100;
        private readonly int RANDOM_NUMBER_UPPER_LIMIT = 500;

        public int FirstNumber
        {
            get { return _firstNumber; }
            set { _firstNumber = value; NotifyPropertyChanged(); }
        }

        public int SecondNumber
        {
            get { return _secondNumber; }
            set { _secondNumber = value; NotifyPropertyChanged(); }
        }

        // Constructor to generate addition quiz
        public AdditionQuiz()
        {
            Random r = new Random();
            FirstNumber = r.Next(RANDOM_NUMBER_LOWER_LIMIT, RANDOM_NUMBER_UPPER_LIMIT);
            SecondNumber = r.Next(RANDOM_NUMBER_LOWER_LIMIT, RANDOM_NUMBER_UPPER_LIMIT);
            Output = FirstNumber + SecondNumber;
        }

        // Function to return addition expression (in string) for the quiz
        public string Expression()
        {
            return String.Format(EXPRESSION_FORMAT, FirstNumber.ToString(), 
                SecondNumber.ToString(), Output.ToString());
        }

        // Function to check if userInput is correct
        public bool CheckAnswer(int userInput)
        {
            return Output == userInput;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
