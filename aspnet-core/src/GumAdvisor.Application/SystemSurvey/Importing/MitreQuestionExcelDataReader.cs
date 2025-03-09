using GumAdvisor.DataExporting.Excel.NPOI;
using GumAdvisor.SystemSurvey.Importing.Dto;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace GumAdvisor.SystemSurvey.Importing
{
    public class MitreQuestionExcelDataReader : NpoiExcelImporterBase<ImportMitreDto>, IMitreQuestionExcelDataReader
    {
        public List<ImportMitreDto> GetMitreFromExcel(byte[] fileBytes)
        {
            return ProcessExcelFile(fileBytes, ProcessExcelRow);
        }

        private ImportMitreDto ProcessExcelRow(ISheet worksheet, int row)
        {
            //if (IsRowEmpty(worksheet, row)) { return null; }

            var exceptionMessage = new StringBuilder();
            var mitre = new ImportMitreDto();
            try
            {

                mitre.Mitre_ID = GetOptionalValueFromRowOrNull(worksheet, row, 0, exceptionMessage, CellType.String);
                mitre.STIX_ID = GetOptionalValueFromRowOrNull(worksheet, row, 1, exceptionMessage, CellType.String);
                mitre.Name = GetOptionalValueFromRowOrNull(worksheet, row, 2, exceptionMessage, CellType.String);
                mitre.Description = GetOptionalValueFromRowOrNull(worksheet, row, 3, exceptionMessage, CellType.String);
                mitre.Url = GetOptionalValueFromRowOrNull(worksheet, row, 4, exceptionMessage, CellType.String);
                mitre.Created = Convert.ToDateTime(GetOptionalValueFromRowOrNull(worksheet, row, 5, exceptionMessage, CellType.String));
                mitre.Last_Modified = Convert.ToDateTime(GetOptionalValueFromRowOrNull(worksheet, row, 6, exceptionMessage, CellType.String));
                mitre.Domain = GetOptionalValueFromRowOrNull(worksheet, row, 7, exceptionMessage, CellType.String);
                mitre.Version = GetOptionalValueFromRowOrNull(worksheet, row, 8, exceptionMessage, CellType.String);
                mitre.Relationship_Citations = GetOptionalValueFromRowOrNull(worksheet, row, 9, exceptionMessage, CellType.String);
            }
            catch (System.Exception exception)
            {
                mitre.Exception = exception.Message;
            }

            return mitre;
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
