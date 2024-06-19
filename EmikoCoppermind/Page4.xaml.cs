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
using System.Diagnostics;
using Microsoft.Win32;
using System.Data;
using ExcelDataReader;
using System.IO;

namespace EmikoCoppermind
{

    public partial class Page4 : Page
    {
        public Page4()
        {
            InitializeComponent();
        }

        private string getCSVFile(string fileToSearch)
        {
            //string fileToSearch = "email-list";
            string directoryPath = "C:\\Users\\f.camacho\\source\\repos\\EmikoCoppermind\\EmikoCoppermind\\ExcelFiles\\";
            int lenDirectory = directoryPath.Length;
            DirectoryInfo directory = new DirectoryInfo(directoryPath);

            string[] files = Directory.GetFiles(directoryPath);

            foreach (var file in files)
            {
                if (getFileFromPath(file, lenDirectory) == fileToSearch)
                {
                    return file;
                } 
            }
            return "";
        }

        private string getFileFromPath(string path, int length)
        {
            string f = path.Substring(length);
            int dot = f.IndexOf('.');
            f = f.Substring(0, dot);
            return f;
        }

        private void OpenExcelButton_Click(object sender, RoutedEventArgs e)
        {
            string nameFile = ((Button)sender).Name;
            string filepath = getCSVFile(nameFile);
            DataTable excelData = ReadExcelFile(filepath);
            ExcelDataGrid.ItemsSource = excelData.DefaultView;
        }

        private DataTable ReadExcelFile(string filePath)
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                    });

                    // Assuming the first table in the workbook
                    return result.Tables[0];
                }
            }
        }
    }
}
