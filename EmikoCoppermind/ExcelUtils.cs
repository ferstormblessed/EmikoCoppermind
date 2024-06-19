using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

namespace EmikoCoppermind
{
    internal class ExcelUtils
    {
        static private string getCSVFile(string fileToSearch)
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

        static private string getFileFromPath(string path, int length)
        {
            string f = path.Substring(length);
            int dot = f.IndexOf('.');
            f = f.Substring(0, dot);
            return f;
        }

        static public void OpenExcel(object sender, RoutedEventArgs e)
        {
            string nameFile = ((Button)sender).Name;
            string filepath = getCSVFile(nameFile);
            Debug.WriteLine("----------------------------------");
            Debug.WriteLine(filepath);
            Debug.WriteLine("----------------------------------");
            if (filepath == "")
            {
                throw new Exception("No file related to this room");
            }

            DataTable excelData = ReadExcelFile(filepath);
            ExcelPopupWindow popup = new ExcelPopupWindow(excelData, filepath);
            popup.ShowDialog();
        }

        static private DataTable ReadExcelFile(string filePath)
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
