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
    /// Логика взаимодействия для NumberPage.xaml
    /// </summary>
    public partial class NumberPage : Page
    {
        public NumberPage()
        {
            InitializeComponent();
        }

        private Randstuff _randstuff = new Randstuff();

        private void NumberOnly_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        async private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(CountTextBox.Text, out int count) ||
                !int.TryParse(StartTextBox.Text, out int start) ||
                !int.TryParse(EndTextBox.Text, out int end))
            {
                MessageBox.Show("Count, Start и End должны быть целыми числами");
                return;
            }

            string list = ListTextBox.Text;
            int uniqueInt = UniqueCheckBox.IsChecked == true ? 1 : 0;

            try
            {
                var result = await _randstuff.GetRandomNumber(count, start, end, list, uniqueInt);

                MessageBox.Show($"Результат: {string.Join(", ", result)}");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

    }
}
