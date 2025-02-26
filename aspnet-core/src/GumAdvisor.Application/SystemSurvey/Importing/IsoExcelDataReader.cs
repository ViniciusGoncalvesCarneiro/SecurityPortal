using GumAdvisor.DataExporting.Excel.NPOI;
using GumAdvisor.SystemSurvey.Importing.Dto;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GumAdvisor.SystemSurvey.Importing
{
    public class IsoExcelDataReader : NpoiExcelImporterBase<ImportIsoDto>, IIsoExcelDataReader
    {
        public List<ImportIsoDto> GetIsoFromExcel(byte[] fileBytes)
        {
            return ProcessExcelFile(fileBytes, ProcessExcelRow);
        }

        private ImportIsoDto ProcessExcelRow(ISheet worksheet, int row)
        {
            //if (IsRowEmpty(worksheet, row)) { return null; }

            var exceptionMessage = new StringBuilder();
            var iso = new ImportIsoDto();
            try
            {
                iso.Clause = GetOptionalValueFromRowOrNull(worksheet, row, 0, exceptionMessage, CellType.String);
                iso.Domain = GetOptionalValueFromRowOrNull(worksheet, row, 1, exceptionMessage, CellType.String);
                iso.Section = GetOptionalValueFromRowOrNull(worksheet, row, 2, exceptionMessage, CellType.String);
                iso.InformationSecurityControl = GetOptionalValueFromRowOrNull(worksheet, row, 3, exceptionMessage, CellType.String);
                iso.ISO_27001_Control_Description = GetOptionalValueFromRowOrNull(worksheet, row, 4, exceptionMessage, CellType.String);
            }
            catch (System.Exception exception)
            {
                iso.Exception = exception.Message;
            }

            return iso;
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
