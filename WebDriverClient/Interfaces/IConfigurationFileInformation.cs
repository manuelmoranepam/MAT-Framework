namespace WebDriverClient.Interfaces
{
    public interface IConfigurationFileInformation
    {
        string FileName { get; }
        string FilePath { get; }
        bool IsOptional { get; }
        bool ReloadOnChange { get; }
    }
}