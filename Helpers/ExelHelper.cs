using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CartrigeAltstar.Helpers
{
    public class ExelHelper
    {

        public ResourceManager resourceManager;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridView"></param>
        /// <param name="pOpenExportedDoc"> True, если нужно после экспорта открыть окно с экспортированным документом</param>
        /// <param name="from"> с какого места пришло</param>
        public static void MyExportExel(DataGridView dataGridView,  bool pOpenExportedDoc, string from)
        {
            DateTime now = DateTime.Now;
            var datenow = now.ToShortDateString().ToString();

            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                FileName = String.Format("{0}{1}{2}{3}{4}{5}-{6}", now.Year.ToString(),
                  now.Month.ToString().PadLeft(2, '0'), now.Day.ToString().PadLeft(2, '0'), now.Hour.ToString().PadLeft(2, '0'),
                  now.Minute.ToString().PadLeft(2, '0'), now.Second.ToString().PadLeft(2, '0'), from),

                Title = "Export to Exel",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                Filter = "Excel Files (*.xlsx)|*.xlsx",
                FilterIndex = 0,
                AddExtension = true,
                DefaultExt = "xlsx"
            };


            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataGridView,saveFileDialog.FileName,from);
                if (pOpenExportedDoc)
                    Process.Start(saveFileDialog.FileName);
            }

        }





      /// <summary>
      /// 
      /// </summary>
      /// <param name="dataGridView"></param>
      /// <param name="filepath"></param>
      /// <param name="from">с какого места пришло</param>

        public static void ExportToExcel(DataGridView dataGridView, string filepath, string from)
        {

            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkBook;
            Excel.Worksheet ExcelWorkSheet;
            Excel.Range ExcelRange;

            ExcelApp.SheetsInNewWorkbook = 2;

            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);

            ExcelApp.DisplayAlerts = false;

            ExcelWorkSheet = (Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);


            ExcelWorkSheet.Name = from;

            int columnIndex = 1;
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i].Visible) // Проверка видимости столбца
                {
                    ExcelWorkSheet.Cells[1, columnIndex] = dataGridView.Columns[i].HeaderText;
                    //рамки заголовков
                    //ExcelWorkSheet.Cells[1, columnIndex].Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = 2;
                    //ExcelWorkSheet.Cells[1, columnIndex].Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = 2;
                    //ExcelWorkSheet.Cells[1, columnIndex].Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = 2;
                    //ExcelWorkSheet.Cells[1, columnIndex].Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = 4;

                    ExcelRange = (Excel.Range)ExcelWorkSheet.Cells[1, columnIndex];
                    ExcelRange.Cells.Font.Size = 14;
                    ExcelRange.Cells.Font.Bold = 500;
                    ExcelRange.Cells.Font.Color = Color.Brown;
                    ExcelRange.Cells.HorizontalAlignment = HorizontalAlignment.Center;
                    columnIndex++;
                }
            }

            object[,] data = new object[dataGridView.RowCount, columnIndex - 1];

            for (int i = 0; i < dataGridView.RowCount; i++)
            {
                columnIndex = 1;
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    if (dataGridView.Columns[j].Visible)
                    {
                        if (dataGridView[j, i].Value != null)
                        {
                            if (dataGridView[j, i].Value is DateTime dateValue)
                            {
                                data[i, columnIndex - 1] = dateValue.ToString("yyyy-MM-dd");
                            }
                            else
                            {
                                data[i, columnIndex - 1] = dataGridView[j, i].Value.ToString();
                            }
                        }
                        columnIndex++;
                    }
                }
            }

            Fill(2, 1, data);

            void Fill(int topRow, int leftCol, object[,] data1)
            {
                //отслеживания прорисовки для отладки
           //     ExcelApp.Visible = true;
                int rows = data1.GetUpperBound(0) + 1;
                int cols = data1.GetUpperBound(1) + 1;

                Excel.Worksheet sheet = (Excel.Worksheet)ExcelApp.ActiveSheet;

                object leftTop = ExcelWorkSheet.Cells[topRow, leftCol];
                object rightBottom = ExcelWorkSheet.Cells[topRow + dataGridView.RowCount - 1, leftCol + columnIndex - 2];

                Excel.Range range = ExcelWorkSheet.get_Range(leftTop, rightBottom);
                range.Value2 = data1;
                SetStyle(range);
                // Сохранение рабочей книги
                ExcelWorkBook.SaveAs(filepath);

                //// Закрытие рабочей книги
                ExcelWorkBook.Close();

                //// Завершение работы с Excel
                ExcelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(ExcelApp);

                MessageBox.Show("Данные успешно экспортированы и сохранены в Excel.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            //прорисовка
            void SetStyle(Excel.Range range)
            {
                range.EntireColumn.AutoFit();
                range.EntireRow.AutoFit();

                object[] border = new object[]
                {
                    Excel.XlBordersIndex.xlEdgeLeft,
                    Excel.XlBordersIndex.xlEdgeTop,
                    Excel.XlBordersIndex.xlEdgeBottom,
                    Excel.XlBordersIndex.xlEdgeRight,
                    Excel.XlBordersIndex.xlInsideVertical,
                    Excel.XlBordersIndex.xlInsideHorizontal
                };

                for (int i = 0; i < border.Length; i++)
                {
                    //рамки данних
                    //range.Borders[(Excel.XlBordersIndex)border[i]].LineStyle = Excel.XlLineStyle.xlContinuous;
                    //range.Borders[(Excel.XlBordersIndex)border[i]].Weight = Excel.XlBorderWeight.xlThin;
                    //range.Borders[(Excel.XlBordersIndex)border[i]].ColorIndex = Excel.XlColorIndex.xlColorIndexAutomatic;
                    range.HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;
                }
            }

        }





    }
}
