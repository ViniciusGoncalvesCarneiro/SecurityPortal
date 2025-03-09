using GumAdvisor.DataExporting.Excel.NPOI;
using GumAdvisor.SystemSurvey.Importing.Dto;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GumAdvisor.SystemSurvey.Importing
{
    public class CisToIsoQuestionExcelDataReader : NpoiExcelImporterBase<ImportCisToIsoDto>, ICisToIsoQuestionExcelDataReader
    {
        public List<ImportCisToIsoDto> GetCisToIsoFromExcel(byte[] fileBytes)
        {
            return ProcessExcelFile(fileBytes, ProcessExcelRow);
        }

        private ImportCisToIsoDto ProcessExcelRow(ISheet worksheet, int row)
        {
            //if (IsRowEmpty(worksheet, row)) { return null; }

            var exceptionMessage = new StringBuilder();
            var cisToIso = new ImportCisToIsoDto();
            try
            {
                cisToIso.CIS_Control = GetOptionalValueFromRowOrNull(worksheet, row, 0, exceptionMessage, CellType.String);
                cisToIso.CIS_Safeguard = GetOptionalValueFromRowOrNull(worksheet, row, 1, exceptionMessage, CellType.String);
                cisToIso.Asset_Type = GetOptionalValueFromRowOrNull(worksheet, row, 2, exceptionMessage, CellType.String);
                cisToIso.Security_Function = GetOptionalValueFromRowOrNull(worksheet, row, 3, exceptionMessage, CellType.String);
                cisToIso.Title = GetOptionalValueFromRowOrNull(worksheet, row, 4, exceptionMessage, CellType.String);
                cisToIso.Description = GetOptionalValueFromRowOrNull(worksheet, row, 5, exceptionMessage, CellType.String);
                cisToIso.Relationship = GetOptionalValueFromRowOrNull(worksheet, row, 6, exceptionMessage, CellType.String);
                cisToIso.ISO_IEC_27001_2022 = GetOptionalValueFromRowOrNull(worksheet, row, 7, exceptionMessage, CellType.String);
            }
            catch (System.Exception exception)
            {
                cisToIso.Exception = exception.Message;
            }

            return cisToIso;
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
