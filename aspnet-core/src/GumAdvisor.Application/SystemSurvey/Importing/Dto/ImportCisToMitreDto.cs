namespace GumAdvisor.SystemSurvey.Importing.Dto
{
    public class ImportCisToMitreDto
    {
        public string CIS_Control { get; set; }
        public string CIS_Safeguard { get; set; }
        public string Asset_Type { get; set; }
        public string Security_Function { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Enterprise_Mitigation_ID { get; set; }

        public string Exception { get; set; }
        public bool CanBeImported()
        {
            return string.IsNullOrEmpty(Exception);
        }
    }
}
