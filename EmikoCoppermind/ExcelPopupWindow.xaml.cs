using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace EmikoCoppermind
{
    /// <summary>
    /// Interaction logic for ExcelPopupWindow.xaml
    /// </summary>
    public partial class ExcelPopupWindow : Window
    {
        private string filePath;

        public ExcelPopupWindow(DataTable excelData, string filePath)
        {
            InitializeComponent();
            ExcelDataGrid.ItemsSource = excelData.DefaultView;
            this.filePath = filePath;
        }

        private void OpenInExcelButton_Click(object sender, RoutedEventArgs e)
        {
            Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
