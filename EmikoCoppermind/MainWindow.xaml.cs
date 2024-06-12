using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EmikoCoppermind
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void NavigatePage1(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page1());
            Debug.WriteLine("button 1");
        }

        private void NavigatePage2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page2());
            Debug.WriteLine("button 2");
        }

        private void NavigatePage3(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Page3());
            Debug.WriteLine("button 3");
        }

    }
}