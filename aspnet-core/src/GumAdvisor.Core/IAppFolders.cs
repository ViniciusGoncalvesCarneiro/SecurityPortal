namespace GumAdvisor
{
    public interface IAppFolders
    {
        string SampleProfileImagesFolder { get; }

        string WebLogsFolder { get; set; }
    }
}