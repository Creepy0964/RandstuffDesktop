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
    /// Логика взаимодействия для TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Page
    {
        private Randstuff randstuff = new();

        public TicketPage()
        {
            InitializeComponent();
            LoadNewTicket();
        }

        private async void LoadNewTicket()
        {
            var ticket = await randstuff.GetRandomTicket();
            TicketTextBlock.Text = $"Номер билета: {ticket.ticket}\nСчастливый ли: {(ticket.lucky ? "да" : "нет")}";
        }

        private void GenerateNewTicketButton_Click(object sender, RoutedEventArgs e)
        {
            LoadNewTicket();
        }
    }
}
