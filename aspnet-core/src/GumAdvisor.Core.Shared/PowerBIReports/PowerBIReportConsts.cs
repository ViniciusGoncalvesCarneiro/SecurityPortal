namespace GumAdvisor.PowerBIReports
{
    public class PowerBIReportConsts
    {
        public const int MinGroupIdLength = 1;
        public const int MaxGroupIdLength = 40;

        public const int MinReportIdLength = 1;
        public const int MaxReportIdLength = 40;

        public const int MinUrlLength = 1;
        public const int MaxUrlength = 500;

        public const int MinDescriptionLength = 1;
        public const int MaxDescriptionLength = 100;

        #region [ - Parâmetros PowerBI - ]
        public static string tenantId = "915fe7db-2988-4ee1-b20b-fd2e18641985";
        public static string clientId = "30d5ab4d-3887-415d-9ab4-d2a00e9cff0a";
        public static string authority = $"https://login.microsoftonline.com/{tenantId}";
        public static string scope = "https://analysis.windows.net/powerbi/api/.default";
        public static string username = "embeddedpbi@activebi.com.br";
        public static string password = "Nof03560";
        #endregion

    }
}
