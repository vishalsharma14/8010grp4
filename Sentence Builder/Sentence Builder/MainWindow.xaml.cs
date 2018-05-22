using System;
using System.Windows;
using System.Windows.Controls;

namespace Sentence_Builder
{
    /// Interaction logic for MainWindow.xaml
    public partial class MainWindow : Window
    {
        string[] words = { "code", "What", "I", "the", "am", "Who", "writing", "great", "are", "Where", "Hurray!", "is", "you", "playing",
            "driving", "That's", "weather", "doing", "cricket", "pleasant"};

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

        // Word Button Click Event Handler
        void BtnWord_Click(Object sender, EventArgs e)
        {
            string text = (string)((Button)sender).Tag;
            LblSentence.Text += (" " + text); // Button Content is appended to exisiting Text
        }

        // Clear Button Click Event Handler
        private void BtnClear_Click(object sender, RoutedEventArgs e)
        {
            LblSentence.Text = string.Empty;
        }
    }
}

