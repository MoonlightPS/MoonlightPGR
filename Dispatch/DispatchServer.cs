using Microsoft.AspNetCore.Builder;
using MoonlightPGR.Util;


namespace MoonlightPGR.Dispatch
{
    public static class DispatchServer
    {
        public static void Start()
        {
            Thread.CurrentThread.IsBackground = true;
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                EnvironmentName = "Development",
            });
            var app = builder.Build();

            DispatchController.AddHandlers(app);

            app.UsePathBase("/");
            app.Urls.Add("http://*:80");
            //app.Urls.Add("https://*:443");

            Logger.c.Log("Starting dispatch on http://localhost/");
            app.Run();
        }
    }
}
