using System;

namespace GumAdvisor.SystemSurvey.Importing.Dto
{
    public class ImportMitreDto
    {
        public string Mitre_ID { get; set; }
        public string STIX_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }
        public DateTime Last_Modified { get; set; }
        public string Domain { get; set; }
        public string Version { get; set; }
        public string Relationship_Citations { get; set; }


        public string Exception { get; set; }
        public bool CanBeImported()
        {
            return string.IsNullOrEmpty(Exception);
        }
    }
}
