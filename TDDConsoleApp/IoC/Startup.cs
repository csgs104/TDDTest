namespace TDDConsoleApp.IoC;

using Microsoft.Extensions.Hosting;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using ...;

public static class Startup
{
    public static IHostBuilder CreateHostBuilder()
    {
        // build the basepath of appsettings.json 
        // not system dependent maybe... try on windows and tell me!
        // var path = Directory.GetCurrentDirectory();
        // var root = Path.GetPathRoot(path) ?? string.Empty;
        // var b = Path.Combine(path.Split(Path.DirectorySeparatorChar).TakeWhile(s => !s.Equals("bin")).ToArray());
        // var basepath = Path.Combine(root, b);

        // add the filepath of appsettings.json to host
        // var host = Host.CreateDefaultBuilder().UseContentRoot(basepath);

        // add the filepath of appsettings.json to host
        var host = Host.CreateDefaultBuilder();

        // configure host
        return host.ConfigureServices((context, service)
            => {
                // adding services
                // service.AddSingleton<>();
            });
    }
}

