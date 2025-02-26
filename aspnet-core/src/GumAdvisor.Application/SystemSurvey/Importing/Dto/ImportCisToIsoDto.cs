namespace GumAdvisor.SystemSurvey.Importing.Dto
{
    public class ImportCisToIsoDto
    {
        public string CIS_Control { get; set; }
        public string CIS_Safeguard { get; set; }
        public string Asset_Type { get; set; }
        public string Security_Function { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Relationship { get; set; }
        public string ISO_IEC_27001_2022 { get; set; }

        public string Exception { get; set; }
        public bool CanBeImported()
        {
            return string.IsNullOrEmpty(Exception);
        }
    }
}
