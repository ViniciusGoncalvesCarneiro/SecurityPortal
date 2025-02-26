namespace GumAdvisor.SystemSurvey.Importing.Dto
{
    public class ImportNistDto
    {
        public string Function { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }

        public string Exception { get; set; }
        public bool CanBeImported()
        {
            return string.IsNullOrEmpty(Exception);
        }
    }
}
