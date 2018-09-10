using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;

namespace Assignment5
{
    class VM : INotifyPropertyChanged
    {
        CheckRandomNumber chkRandom = new CheckRandomNumber();
        Random randomizer = new Random();

        List<string> lines = new List<string>();
        public List<string> Things
        {
            get { return lines; }
            set { lines = value; notifyChanged(); }
        }

        int timeLeft;
        int sum = 0;
        DispatcherTimer timer = new DispatcherTimer();
        


        public string countTimer;

        int addend1;
        int addend2;
        int corrAns;
        int userAns;
        string wrongAns;
       
        public string Validation
        {
            get
            {
                return wrongAns;
            }
            set
            {
                wrongAns = value;
                notifyChanged();
            }
        }
        bool btn_check=true;
        public bool btnCheck
        {
            get
            {
                return btn_check;
            }
            set
            {
                btn_check = value;
                notifyChanged();
            }
        }

        public int CorrectAnswer
        {
            get
            {
                return corrAns;
            }
            set
            {
                corrAns = value;
                notifyChanged();
            }
        }

        public int UserAnswer
        {
            get
            {
                return userAns;
            }
            set
            {
                userAns = value;
                notifyChanged();
            }
        }

        public int Addition1
        {
            get
            {
                return addend1;
            }
            set
            {
                addend1 = value;
                notifyChanged();
            }
        }
        public int Addition2
        {
            get
            {
                return addend2;
            }
            set
            {
                addend2 = value;
                notifyChanged();
            }
        }

        public string CountTime
        {
            get
            {
                return countTimer;
            }
            set
            {
                countTimer = value;
                notifyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void notifyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }



        public VM()
        {
            
            timer.Tick += new EventHandler(dispatcherTimer_Tick);
            timer.Interval = new TimeSpan(0, 0, 1);
            GenerateRandomNumber();
           
        }

        public void GenerateRandomNumber()
        {
            Addition1 = randomizer.Next(100, 500);
            Addition2 = randomizer.Next(100, 500);
           

            if (lines != null)
            {
                using (StreamReader r = new StreamReader("output1.txt"))
                {
                    string line;
                    while ((line = r.ReadLine()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }
            else {  }

            timeLeft = 30;
            CountTime = "30 seconds";
            timer.Start();
        }

        
        
        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {

            if (CheckTheAnswer())
            {
                // If CheckTheAnswer() returns true, then the user 
                // got the answer right. Stop the timer  
                // and show a MessageBox.
                timer.Stop();

                MessageBox.Show("You got your answers right!",
                            "Congratulations!");

            }
            else if (timeLeft > 0)
            {
                // If CheckTheAnswer() return false, keep counting
                // down. Decrease the time left by one second and 
                // display the new time left by updating the 
                // Time Left label.

                //Display the new Time Left
                timeLeft = timeLeft - 1;
                CountTime = timeLeft + " seconds";
            }
            else
            {
                // If the user ran out of time, stop the timer, show 
                // a MessageBox, and fill in the answers.

                timer.Stop();
                sum = Addition1 + Addition2;
                CorrectAnswer = sum;
                //UserAnswer = 0;
                CountTime = "Time's up!";
                MessageBox.Show("You didn't finish in time", "Sorry!");
                btnCheck = false;
            }
        }

        public void checkAnswer()
        {
           
            if (UserAnswer == (Addition1 + Addition2))
            {
                Validation = "";
                
                sum = Addition1 + Addition2;
                CorrectAnswer = sum;
                timer.Stop();
                
                MessageBox.Show("You got your answers right!",
                            "Congratulations!");
                UserAnswer = 0;
                GenerateRandomNumber();
            }
            else
            {
                timeLeft = timeLeft - 1;
                CountTime = timeLeft + " seconds";
                Validation = "*Incorrect Answer!";
            }
            generateFile();
            
        }

        public void generateFile()
        {
            File.AppendAllText("Output1.txt", "Question :" + Addition1 + " + " + Addition2 + "\r\n");
            File.AppendAllText("Output1.txt", "User Answered :" + UserAnswer + "\r\n");
            File.AppendAllText("Output1.txt", "Correct Answer :" + (Addition1 + Addition2).ToString() + "\r\n \r\n");

        }


        private bool CheckTheAnswer()
        {
            if (Addition1 + Addition2 == sum)
                return true;
            else
                return false;
        }
    }
}
