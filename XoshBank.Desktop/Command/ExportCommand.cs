using ClosedXML.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using XoshBank.Attributes;

namespace XoshBank.Command
{
    public class ExportCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IEnumerable<T> items = (IEnumerable<T>)parameter;

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";

            bool? dialogResult = saveFileDialog.ShowDialog();

            if (dialogResult != true)
                return;

            string fileName = saveFileDialog.FileName;

            var table = new DataTable("Items");

            Type type = typeof(T);

            PropertyInfo[] properties = type.GetProperties();
            List<PropertyInfo> necessaryProperties = new List<PropertyInfo>();

            foreach (PropertyInfo propertyInfo in properties)
            {
                ExcelColumnIgnoreAttribute columnIgnoreAttribute = propertyInfo.GetCustomAttribute<ExcelColumnIgnoreAttribute>();

                if (columnIgnoreAttribute != null)
                    continue;

                necessaryProperties.Add(propertyInfo);
            }

            foreach (PropertyInfo propertyInfo in necessaryProperties)
            {
                ExcelColumnStyleAttribute columnStyleAttribute = propertyInfo.GetCustomAttribute<ExcelColumnStyleAttribute>();

                if (columnStyleAttribute != null)
                {
                    table.Columns.Add(columnStyleAttribute.Name);
                }
                else
                {
                    table.Columns.Add(propertyInfo.Name);
                }
            }

            foreach (var item in items)
            {
                object[] values = new object[necessaryProperties.Count];

                for (int i = 0; i < necessaryProperties.Count; i++)
                {
                    PropertyInfo propertyInfo = necessaryProperties[i];

                    values[i] = propertyInfo.GetValue(item);
                }

                table.Rows.Add(values);
            }

            using (XLWorkbook workbook = new XLWorkbook())
            {
                IXLWorksheet worksheet = workbook.Worksheets.Add(table);

                worksheet.Columns().AdjustToContents();

                workbook.SaveAs(fileName);
            }

            MessageBoxResult messageBoxResult = MessageBox.Show("File is ready. Do you want to open it?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (messageBoxResult != MessageBoxResult.Yes)
                return;

            Process.Start(fileName);
        }
    }
}
