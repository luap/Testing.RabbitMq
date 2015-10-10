using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Testing.RabbitMq
{
    class RabbitMqInstance
    {
        private Process _process;
        private string _rabbitMqTempPath;

        public void Start()
        {
            CreateTempDirectory();

            var rabbitMqInstallationPath = Directory.GetDirectories(@"C:\Program Files (x86)\RabbitMQ Server\", "rabbitmq_server-*").OrderByDescending(x => x).First();

            var processStartInfo = new ProcessStartInfo()
            {
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Normal,
                FileName = Path.Combine(rabbitMqInstallationPath, "sbin", "rabbitmq-server.bat")
            };

            processStartInfo.EnvironmentVariables["RABBITMQ_NODENAME"] = "rabbitfunctionaltests";
            processStartInfo.EnvironmentVariables["RABBITMQ_NODE_PORT"] = "5675";
            processStartInfo.EnvironmentVariables["RABBITMQ_BASE"] = _rabbitMqTempPath;
            processStartInfo.EnvironmentVariables["HOMEDRIVE"] = Path.GetPathRoot(Path.GetTempPath());
            processStartInfo.EnvironmentVariables["HOMEPATH"] = Path.GetTempPath().Replace(Path.GetPathRoot(Path.GetTempPath()), "");

            _process = Process.Start(processStartInfo);
        }

        public void Stop()
        {
            _process.CloseMainWindow();
        }

        private void CreateTempDirectory()
        {
            _rabbitMqTempPath = Path.Combine(Path.GetTempPath(), "rabbitMQ");

            if (Directory.Exists(_rabbitMqTempPath))
            {
                Directory.Delete(_rabbitMqTempPath, true);
            }

            Directory.CreateDirectory(_rabbitMqTempPath);
        }
    }
}
