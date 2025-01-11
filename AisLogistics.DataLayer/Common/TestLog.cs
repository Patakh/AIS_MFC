using Serilog;

namespace AisLogistics.DataLayer.Common;

public class TestLog 
{
    public TestLog()
    {
        Log.Logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.Information()
            .WriteTo.File("logs.txt")
            .CreateLogger();
    }
}