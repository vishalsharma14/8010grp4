using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Sentence_Builder
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        string[] words = { "code", "What", "I", "the", "am", "Who", "writing",
            "great", "are", "Where", "Hurray!", "is", "you", "playing",
            "driving", "That's", "weather", "doing", "cricket", "pleasant"};

        List<String> wordsList = new List<String>();

        // Function to render buttons in WrapPanel for all the strings in array words
        void RenderButtons()
        {
            foreach (string word in words)
            {
                Button BtnWord = new Button
                {
                    Content = word,
                    Tag = word,
                    Width = 100,
                    Height = 30,
                    Margin = new Thickness(10, 10, 10, 10)
                };
                BtnWord.Click += BtnWord_Click; // Adding Click EventHandler for Button
                ButtonsPanel.Children.Add(BtnWord);
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            RenderButtons();
        }

        // Function to build sentence
        private void SentenceBuilder()
        {
            LblSentence.Text = String.Empty;
            foreach (string word in wordsList)
            {
                LblSentence.Text += (" " + word); // Button Content is appended to exisiting Text
            }
        }

        // Function to handle redo button click event
        private void BtnUndo_Click(Object sender, EventArgs e)
        {
            int wordsCount = wordsList.Count;
            if (wordsCount > 0)
            {
                wordsList.RemoveAt(wordsCount - 1);
                SentenceBuilder();
            }
        }

        // Function to handle word button click event
        private void BtnWord_Click(Object sender, EventArgs e)
        {
            string text = (string)((Button)sender).Tag;
            wordsList.Add(text);
            SentenceBuilder();
        }

        // Function to handle clear button click event
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            LblSentence.Text = string.Empty;
            wordsList.Clear();
        }
    }
}
