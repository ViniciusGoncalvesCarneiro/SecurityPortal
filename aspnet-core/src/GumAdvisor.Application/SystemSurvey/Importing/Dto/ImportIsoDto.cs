namespace GumAdvisor.SystemSurvey.Importing.Dto
{
    public class ImportIsoDto
    {
        public string Clause { get; set; }
        public string Domain { get; set; }
        public string Section { get; set; }
        public string InformationSecurityControl { get; set; }
        public string ISO_27001_Control_Description { get; set; }

        public string Exception { get; set; }
        public bool CanBeImported()
        {
            return string.IsNullOrEmpty(Exception);
        }
    }
}
