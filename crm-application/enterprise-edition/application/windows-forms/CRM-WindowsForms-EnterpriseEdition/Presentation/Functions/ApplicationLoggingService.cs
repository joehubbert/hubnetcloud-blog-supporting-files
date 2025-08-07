namespace CRM_WindowsForms_EnterpriseEdition.Presentation.Functions
{
    public class ApplicationLoggingService
    {
        private string _action;
        private string? _errorCode;
        private string? _errorException;
        private static readonly string ConfigFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CRM-WindowsForms.EnterpriseEdition");
        private static readonly string ApplicationLogFilePath = Path.Combine(ConfigFolderPath, "CRM-WindowsForms-EnterpriseEdition-Log.txt");

        public ApplicationLoggingService(string action, string? errorCode = null, string? errorException = null)
        {
            _action = action;
            if (errorCode != null)
            {
                _errorCode = errorCode;
            }
            if (errorException != null)
            {
                _errorException = errorException;
            }
            Orchestrator(_action);
        }

        private void Orchestrator(string action)
        {
            switch (action)
            {
                case "AppendToLogFile":
                    AppendToLogFile(_errorCode ?? string.Empty, _errorException ?? string.Empty);
                    break;
                case "CreateLogFileIfNotExists":
                    CreateLogFileIfNotExists();
                    break;
                case "ClearLogFile":
                    ClearLogFile();
                    break;
                case "OpenLogFile":
                    OpenLogFile();
                    break;
                default:
                    throw new ArgumentException("Invalid action specified.");
            }
        }

        private void AppendToLogFile(string errorCode, string errorException)
        {
            CreateLogFileIfNotExists();
            using (var streamWriter = new StreamWriter(ApplicationLogFilePath, true))
            {
                streamWriter.WriteLine($"{DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss} Error Code: {errorCode}, Exception: {errorException}");
            }
        }

        private void ClearLogFile()
        {
            if (File.Exists(ApplicationLogFilePath))
            {
                using (var stream = File.Open(ApplicationLogFilePath, FileMode.Truncate))
                {
                    // Truncate the file to zero length
                }
            }
        }

        private void CreateLogFileIfNotExists()
        {
            if (!Directory.Exists(ConfigFolderPath))
            {
                Directory.CreateDirectory(ConfigFolderPath);
            }
            if (!File.Exists(ApplicationLogFilePath))
            {
                using (var stream = File.Create(ApplicationLogFilePath))
                {
                    // Create the log file
                }
                using (var streamWriter = new StreamWriter(ApplicationLogFilePath, true))
                {
                    streamWriter.WriteLine($"CRM-Forms-EnterpriseEdition Log File Created At: {DateTime.UtcNow:yyyy-MM-dd-hh-mm-ss}");
                }
            }
        }

        private void OpenLogFile()
        {
            if (File.Exists(ApplicationLogFilePath))
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = ApplicationLogFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                throw new FileNotFoundException("Log file does not exist.");
            }
        }
    }
}