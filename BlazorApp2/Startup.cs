using BlazorApp2.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorApp2
{
    public static class Startup
    {
        public static WebAssemblyHostBuilder InitializeApp(WebAssemblyHostBuilder builder)
        {
            //var builder = WebAssemblyHostBuilder.CreateDefault(args);
            ConfigureRootComponetns(builder);
            ConfigureServices(builder);
            //var app = builder.Build();
            //Configure(app);
            return builder;
        }
        private static void ConfigureRootComponetns(WebAssemblyHostBuilder builder)
        {
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
        }
        private static void ConfigureServices(WebAssemblyHostBuilder builder)
        {
            //builder.Services.AddRazorPages();
            //builder.Services.AddServerSideBlazor();
            //builder.Services.AddSingleton<WeatherForecastService>();
            //builder.Services.AddHttpClient<IPersonService, PersonService>();
            //builder.Services.AddTransient<PersonService>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<IPersonService, PersonService>();
            //builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
        }

        private static void Configure(WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            //app.UseMvcWithDefaultRoute();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
        }
    }
}
