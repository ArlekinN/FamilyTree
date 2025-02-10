using Serilog;

namespace FamilyTree.Common
{
    public static class Logger
    {
        public static void Initialize()
        {
            var rootDirectory = RootDirectory.GetPath();
            var logDirectory = Path.Combine(rootDirectory, "Log");
            var logPath = Path.Combine(rootDirectory, "Log/log.log");
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(logPath, rollingInterval: RollingInterval.Infinite)
                .CreateLogger();
            Log.Information("Run app");
        }
    }
}