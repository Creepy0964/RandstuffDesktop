using System.Windows;
using System.Windows.Controls;

namespace RandstuffDesktop.Pages
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class JokePage : Page
    {
        Randstuff rnd = new Randstuff();
        public JokePage()
        {
            InitializeComponent();
            Update();
        }

        async void Update()
        {
            var text = await rnd.GetRandomJoke();

            jText.Text = text;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }
    }
}
