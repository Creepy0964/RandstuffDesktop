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
    /// Логика взаимодействия для PasswordPage.xaml
    /// </summary>
    public partial class PasswordPage : Page
    {
        private Randstuff _randstuff = new Randstuff();

        public PasswordPage()
        {
            InitializeComponent();
        }

        async private void GeneratePassword_Click(object sender, RoutedEventArgs e)
        {
            int length = (int)LengthSlider.Value;
            int numbers = NumbersCheckBox.IsChecked == true ? 1 : 0;
            int symbols = SymbolsCheckBox.IsChecked == true ? 1 : 0;

            try
            {
                // Метод возвращает строку с паролем
                string password = await _randstuff.GetRandomPassword(length, numbers, symbols);

                PasswordTextBox.Text = password;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
