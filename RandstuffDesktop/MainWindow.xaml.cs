using RandstuffDesktop.Pages;
using System.Diagnostics;
using System.IO;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RandstuffDesktop.Pages;

namespace RandstuffDesktop;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    Randstuff rnd = new Randstuff();
    public MainWindow()
    {
        InitializeComponent();
        MainFrame.Navigate(new JokePage());
    }

    private void Navigate_Joke(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new JokePage());
    }

    private void Navigate_Fact(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new FactPage());
    }

    private void Navigate_Wisdom(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new WisdomPage());
    }

    private void Navigate_Ask(object sender, RoutedEventArgs e)
    {
        MainFrame.Navigate(new AskPage());
    }

    async private void Navigate_Question(object sender, RoutedEventArgs e)
    {
        var text = await rnd.GetRandomNumber(count: 5);

        MessageBox.Show(text);
    }
}