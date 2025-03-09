using GumAdvisor.DataExporting.Excel.NPOI;
using GumAdvisor.SystemSurvey.Importing.Dto;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GumAdvisor.SystemSurvey.Importing
{
    public class CisToMitreQuestionExcelDataReader : NpoiExcelImporterBase<ImportCisToMitreDto>, ICisToMitreQuestionExcelDataReader
    {
        public List<ImportCisToMitreDto> GetCisToMitreFromExcel(byte[] fileBytes)
        {
            return ProcessExcelFile(fileBytes, ProcessExcelRow);
        }

        private ImportCisToMitreDto ProcessExcelRow(ISheet worksheet, int row)
        {
            //if (IsRowEmpty(worksheet, row)) { return null; }

            var exceptionMessage = new StringBuilder();
            var cisToMitre = new ImportCisToMitreDto();
            try
            {
                cisToMitre.CIS_Control = GetOptionalValueFromRowOrNull(worksheet, row, 0, exceptionMessage, CellType.String);
                cisToMitre.CIS_Safeguard = GetOptionalValueFromRowOrNull(worksheet, row, 1, exceptionMessage, CellType.String);
                cisToMitre.Asset_Type = GetOptionalValueFromRowOrNull(worksheet, row, 2, exceptionMessage, CellType.String);
                cisToMitre.Security_Function = GetOptionalValueFromRowOrNull(worksheet, row, 3, exceptionMessage, CellType.String);
                cisToMitre.Title = GetOptionalValueFromRowOrNull(worksheet, row, 4, exceptionMessage, CellType.String);
                cisToMitre.Description = GetOptionalValueFromRowOrNull(worksheet, row, 5, exceptionMessage, CellType.String);
                cisToMitre.Enterprise_Mitigation_ID = GetOptionalValueFromRowOrNull(worksheet, row, 6, exceptionMessage, CellType.String);
            }
            catch (System.Exception exception)
            {
                cisToMitre.Exception = exception.Message;
            }

            return cisToMitre;
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
