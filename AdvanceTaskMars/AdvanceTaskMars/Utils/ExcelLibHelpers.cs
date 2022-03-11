using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace AdvanceTaskMars.Utils
{
    class ExcelLibHelpers
    {
        private static DataTable ExcelToDataTable(string filename, string SheetName)
        {
            using FileStream stream = File.Open(filename, FileMode.Open, FileAccess.Read);
            {
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                using IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                {
                    //ExcelReaderFactory.CreateBinaryReader(stream);

                    DataSet resultset = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    DataTableCollection table = resultset.Tables;
                    DataTable resultTable = table[SheetName];
                    //excelReader.Dispose();
                    excelReader.Close();

                    return resultTable;
                }
            }
        }

        public class Datacollection
        {
            public int rowNumber { get; set; }
            public string colName { get; set; }
            public string colValue { get; set; }
        }

        static List<Datacollection> dataCol = new List<Datacollection>();
        public static void PopulateInDataCollection(string filename, string SheetName)
        {
            DataTable table = ExcelToDataTable(filename, SheetName);
            for (int row = 1; row <= table.Rows.Count; row++)
            {
                for (int col = 0; col < table.Columns.Count; col++)
                {
                    Datacollection dtTable = new Datacollection()
                    {
                        rowNumber = row,
                        colName = table.Columns[col].ColumnName,
                        colValue = table.Rows[row - 1][col].ToString()

                    };
                    dataCol.Add(dtTable);
                }
            }
        }

        public static string ReadData(int rowNumber, string columnName)
        {
            try
            {
                rowNumber = rowNumber - 1;
                var data = (from colData in dataCol
                            where (colData.colName == columnName) && (colData.rowNumber == rowNumber)
                            select colData.colValue).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                //Assert.Fail("The Read Data did not load", ex.Message);
                return null;
            }
        }
    }
}
