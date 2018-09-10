/** NameSearch - A8 - Group4
 * Vishal V.    8205031
 * Gevindu M.   8060295
 * Rahul M.     8258980
 * Ramandeep K. 8261570
 * Gurjinder S. 8261661
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;

namespace NameSearch
{
    class NameSearchVM : INotifyPropertyChanged
    {
        private string _inputBoyName = String.Empty;
        private string _inputGirlName = String.Empty;
        private string _output = String.Empty;

        private const string BOY_NAMES_FILE = "BoyNames.txt";
        private const string GIRL_NAMES_FILE = "GirlNames.txt";
        private const string MOST_POPULAR_MESSAGE = "{0} is among the most popular\n";
        private const string NOT_FOUND_MESSAGE = "Not found among most popular!";

        private List<string> BoyNamesList = new List<string>();
        private List<string> GirlNamesList = new List<string>();

        public string InputBoyName
        {
            get { return _inputBoyName; }
            set { _inputBoyName = value; SearchNames(); NotifyPropertyChanged(); }
        }

        public string InputGirlName
        {
            get { return _inputGirlName; }
            set { _inputGirlName = value; SearchNames(); NotifyPropertyChanged(); }
        }

        public string Output
        {
            get { return _output; }
            set { _output = value; NotifyPropertyChanged(); }
        }

        // Constructor to load data from files
        public NameSearchVM()
        {
            LoadNamesFromFiles();
        }

        // Function to return List of strings containing file lines
        private List<string> GetListFromFile(string fileName)
        {
            List<string> tempList = new List<string>();
            string[] lines = File.ReadAllLines(fileName);

            foreach (string line in lines)
            {
                tempList.Add(line.Trim().ToLower());
            }
            return tempList;
        }

        // Function to load names from files
        private void LoadNamesFromFiles()
        {
            BoyNamesList = GetListFromFile(BOY_NAMES_FILE);
            GirlNamesList = GetListFromFile(GIRL_NAMES_FILE);
        }

        // Function to search Input Names and update Output message
        public void SearchNames()
        {
            Output = String.Empty;

            if (InputBoyName != String.Empty && BoyNamesList.Contains(InputBoyName.ToLower()))
                Output += String.Format(MOST_POPULAR_MESSAGE, InputBoyName);

            if (InputGirlName != String.Empty && GirlNamesList.Contains(InputGirlName.ToLower()))
                Output += String.Format(MOST_POPULAR_MESSAGE, InputGirlName);

            if ((InputBoyName != String.Empty || InputGirlName != String.Empty) && Output == String.Empty)
                Output = NOT_FOUND_MESSAGE;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
