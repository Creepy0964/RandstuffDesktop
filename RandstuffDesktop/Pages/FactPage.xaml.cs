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
    /// Логика взаимодействия для Page2.xaml
    /// </summary>
    public partial class FactPage : Page
    {
        private Randstuff _randstuff = new Randstuff();

        public FactPage()
        {
            InitializeComponent();
        }

        private async void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "Загрузка...";
            try
            {
                string joke = await _randstuff.GetRandomFact();
                ResultTextBox.Text = joke;
            }
            catch (Exception ex)
            {
                ResultTextBox.Text = "Ошибка: " + ex.Message;
            }
        }
    }
}
