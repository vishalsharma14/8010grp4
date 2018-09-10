/** AdditionTutor - A5 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace AdditionTutor
{
    class AdditionTutorVM : INotifyPropertyChanged
    {
        private AdditionQuiz _additionTutor;
        private int _inputValue;
        private string _ouptut;
        private string _displayQuizResult;
        private string _displayNewQuiz;
        private string _outputExpression;

        private const string VISIBILITY_VISIBLE = "Visible";
        private const string VISIBILTIY_HIDDEN = "Hidden";
        private const string CORRECT_ANSWER_RESPONSE = "Correct Answer!";
        private const string INCORRECT_ANSWER_RESPONSE = "Incorrect Answer ( {0} )";
        private const string FILE_NAME = "output.txt";
        private const string QUIZ_TEXT_FORMAT_FOR_FILE = "{0} User's Input: {1} \r\n";

        public int InputValue
        {
            get { return _inputValue; }
            set { _inputValue = value; NotifyPropertyChanged(); }
        }

        public string Output
        {
            get { return _ouptut; }
            set { _ouptut = value; NotifyPropertyChanged(); }
        }

        public AdditionQuiz AdditionTutor
        {
            get { return _additionTutor; }
            set { _additionTutor = value; NotifyPropertyChanged(); }
        }

        public string DisplayNewQuiz
        {
            get { return _displayNewQuiz; }
            set { _displayNewQuiz = value; NotifyPropertyChanged(); }
        }

        public string DisplayQuizResult
        {
            get { return _displayQuizResult; }
            set { _displayQuizResult = value; NotifyPropertyChanged(); }
        }

        public string OutputExpression
        {
            get { return _outputExpression; }
            set { _outputExpression = value; NotifyPropertyChanged(); }
        }

        public AdditionTutorVM()
        {
            NewQuiz();
        }

        // Function to generate new quiz and switch display grid
        public void NewQuiz()
        {
            AdditionTutor = new AdditionQuiz();
            InputValue = 0;
            DisplayNewQuiz = VISIBILITY_VISIBLE;
            DisplayQuizResult = VISIBILTIY_HIDDEN;
        }

        // Function to write quiz content to file
        public void WriteQuizResultToFile()
        {
            File.AppendAllText(FILE_NAME, 
                String.Format(QUIZ_TEXT_FORMAT_FOR_FILE, AdditionTutor.Expression(), InputValue));
        }

        // Function to evaluate quiz for the user input
        public void EvaluateQuiz()
        {
            bool isCorrectResponse = AdditionTutor.CheckAnswer(InputValue);

            // Write quiz result to file
            WriteQuizResultToFile();

            // Display quiz result
            Output = isCorrectResponse ? CORRECT_ANSWER_RESPONSE : String.Format(INCORRECT_ANSWER_RESPONSE, InputValue);
            OutputExpression = AdditionTutor.Expression();
            DisplayNewQuiz = VISIBILTIY_HIDDEN;
            DisplayQuizResult = VISIBILITY_VISIBLE;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName]string name="")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
