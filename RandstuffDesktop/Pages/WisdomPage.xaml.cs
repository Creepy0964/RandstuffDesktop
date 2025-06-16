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
    /// Логика взаимодействия для WisdomPage.xaml
    /// </summary>
    public partial class WisdomPage : Page
    {
        Randstuff rnd = new Randstuff();
        public WisdomPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var text = await rnd.GetRandomWisdom();

            wText.Text = text;
        }

        private void Navigate_Joke(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new JokePage());
        }

        private void Navigate_Fact(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FactPage());
        }

        private void Navigate_Wisdom(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new WisdomPage());
        }

        private void Navigate_Ask(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AskPage());
        }

        private void Navigate_Question(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new QuestionPage());
        }
    }
}
