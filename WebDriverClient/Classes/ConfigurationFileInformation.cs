using WebDriverClient.Interfaces;

namespace WebDriverClient.Classes
{
    public class ConfigurationFileInformation : IConfigurationFileInformation
    {
        private readonly string _filePath;
        private readonly string _fileName;
        private readonly bool _isOptional;
        private readonly bool _reloadOnChange;

        public ConfigurationFileInformation(string filePath, string fileName, bool isOptional, bool reloadOnChange)
        {
            _filePath = filePath;
            _fileName = fileName;
            _isOptional = isOptional;
            _reloadOnChange = reloadOnChange;
        }

        public string FilePath => _filePath;
        public string FileName => _fileName;
        public bool IsOptional => _isOptional;
        public bool ReloadOnChange => _reloadOnChange;
    }
}