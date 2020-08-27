using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.AutoCAD.DatabaseServices;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using X16 = DocumentFormat.OpenXml.Office2016.Excel;

namespace AutoCAD_1.windows
{
    class util
    {
        string filepath = @"C:\Users\L\source\repos\AutoCAD_1\windows\test2.xlsx";

        public static SharedStringItem GetSharedStringItemById(WorkbookPart workbookPart, int id)
        {
            return workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
        }

        string cellValue = null;

        //open excel file
        public string openExcel(int row,int col)
        {
            DataTable dtTable = new DataTable();

            //open excel file
            SpreadsheetDocument doc = SpreadsheetDocument.Open(filepath, false);

            //create the object for workbook part  
            WorkbookPart workbookPart = doc.WorkbookPart;
            Sheets thesheetcollection = workbookPart.Workbook.GetFirstChild<Sheets>();

            foreach (Sheet thesheet in thesheetcollection.OfType<Sheet>())
            {
                // statement to get the worksheet object by using the sheet id
                Worksheet theWorksheet = ((WorksheetPart)workbookPart.GetPartById(thesheet.Id)).Worksheet;

                SheetData thesheetdata = theWorksheet.GetFirstChild<SheetData>();

               DocumentFormat.OpenXml.Spreadsheet.Cell thecurrentcell = (DocumentFormat.OpenXml.Spreadsheet.Cell)thesheetdata.ElementAt(row).ChildElements.ElementAt(col);

                if (thecurrentcell.DataType != null && thecurrentcell.DataType == CellValues.SharedString)
                {
                    int id;
                    Int32.TryParse(thecurrentcell.InnerText, out id);
                    SharedStringItem item = workbookPart.SharedStringTablePart.SharedStringTable.Elements<SharedStringItem>().ElementAt(id);
                    cellValue = item.InnerText;
                }
                else
                {
                    cellValue = thecurrentcell.InnerText;
                }

                

            }



                return cellValue;
        }

    }
}
