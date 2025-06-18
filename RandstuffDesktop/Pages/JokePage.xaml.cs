using System.Windows;
using System.Windows.Controls;

namespace RandstuffDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class JokePage : Page
    {
        private Randstuff _randstuff = new Randstuff();

        public JokePage()
        {
            InitializeComponent();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "Загрузка...";
            try
            {
                string joke = await _randstuff.GetRandomJoke();
                ResultTextBox.Text = joke;
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}
