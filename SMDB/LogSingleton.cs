
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;
using System.Diagnostics;
using System.Security.Claims;

namespace SMDP
{
    public class LogSingleton : DelegatingHandler
    {       
        private string filePath;
        private StreamWriter sw;
        private static LogSingleton instance;
        private IConfiguration _configuration;
        public static LogSingleton Instance
        {
            get

            {
                if (instance == null)
                {
                    instance = new LogSingleton();
                }

                return instance;
            }
        }

        private LogSingleton()
        {
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var filePath = _configuration.GetSection("AppSettings:Path").Value;
            string logFile = Combine(filePath, "log.txt");
            if (!File.Exists(logFile))
            {
                File.Create(logFile).Dispose();
            }

            sw = new StreamWriter(logFile);           

        }      
        public void WriteRequest(string data)
        {
            sw.WriteLine($"{DateTime.Now} -- {data}");

            sw.Flush();
        }

        public void GetUser(string userId)
        {
            sw.WriteLine($"You are logged in with: {userId}");

            sw.Flush();
        }
        public void WriteKind(string data)
        {
            sw.WriteLine($"Your request Type is:{data}");

            sw.Flush();
        }
        public void WriteResponse(object data)
        {
            sw.WriteLine($"Your response is: {data}");

            sw.Flush();
        }
    }
}
