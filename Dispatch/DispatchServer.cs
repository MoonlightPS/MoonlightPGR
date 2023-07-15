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
            app.Run();

            Logger.c.Log("Started dispatch on http://localhost/");
        }
    }
}
