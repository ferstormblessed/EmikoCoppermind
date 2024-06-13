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

namespace EmikoCoppermind
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }

        private void Office_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Rectangle clickedRectangle = sender as Rectangle;
            string officeName = clickedRectangle.Name;

            // Show pop-up with general data
            MessageBoxResult result = MessageBox.Show($"{officeName} - General Data\n\nDo you want to open the document?", "Office Information", MessageBoxButton.YesNo);

            /*// Open document if Yes is clicked
            if (result == MessageBoxResult.Yes)
            {
                // Assuming the document is a PDF or similar, open it using default viewer
                string documentPath = $"{officeName}_document.pdf";
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(documentPath) { UseShellExecute = true });
            }*/
        }
    }
}
