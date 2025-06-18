using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RandstuffDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для QuestionPage.xaml
    /// </summary>
    public partial class QuestionPage : Page
    {
        private Randstuff randstuff = new();
        private int currentQuestionId;

        public QuestionPage()
        {
            InitializeComponent();
            LoadNewQuestion();
        }

        private async void LoadNewQuestion()
        {
            var question = await randstuff.GetRandomQuestion();

            currentQuestionId = int.Parse(question.id);
            QuestionTextBlock.Text = question.text;
            AnswerButton1.Content = question.answer1;
            AnswerButton2.Content = question.answer2;
            AnswerButton3.Content = question.answer3;
            AnswerButton4.Content = question.answer4;
        }

        private async void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && int.TryParse(btn.Tag.ToString(), out int answerNumber))
            {
                var result = await randstuff.GetRandomAnswer(currentQuestionId, answerNumber);
                if (int.Parse(result.correct) == answerNumber)
                    MessageBox.Show("Правильно!", "Результат", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                    MessageBox.Show("Неправильно!", "Результат", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GenerateNewQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            LoadNewQuestion();
        }
    }
}
