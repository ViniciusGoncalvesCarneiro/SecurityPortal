using GumAdvisor.DataExporting.Excel.NPOI;
using GumAdvisor.SystemSurvey.Importing.Dto;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GumAdvisor.SystemSurvey.Importing
{
    public class NistQuestionExcelDataReader : NpoiExcelImporterBase<ImportNistDto>, INistQuestionExcelDataReader
    {
        public List<ImportNistDto> GetNistFromExcel(byte[] fileBytes)
        {
            return ProcessExcelFile(fileBytes, ProcessExcelRow);
        }

        private ImportNistDto ProcessExcelRow(ISheet worksheet, int row)
        {
            //if (IsRowEmpty(worksheet, row)) { return null; }

            var exceptionMessage = new StringBuilder();
            var nist = new ImportNistDto();
            try
            {
                nist.Function = GetOptionalValueFromRowOrNull(worksheet, row, 0, exceptionMessage, CellType.String);
                nist.Category = GetOptionalValueFromRowOrNull(worksheet, row, 1, exceptionMessage, CellType.String);
                nist.Subcategory = GetOptionalValueFromRowOrNull(worksheet, row, 2, exceptionMessage, CellType.String);
            }
            catch (System.Exception exception)
            {
                nist.Exception = exception.Message;
            }

            return nist;
        }

        private string GetOptionalValueFromRowOrNull(ISheet worksheet, int row, int column, StringBuilder exceptionMessage, CellType? cellType = null)
        {
            var cell = worksheet.GetRow(row).GetCell(column);
            if (cell == null)
            {
                return string.Empty;
            }

            if (cellType != null)
            {
                cell.SetCellType(cellType.Value);
            }

            var cellValue = worksheet.GetRow(row).GetCell(column).StringCellValue;
            if (cellValue != null && !string.IsNullOrWhiteSpace(cellValue))
            {
                return cellValue;
            }

            return String.Empty;
        }
    }
}
