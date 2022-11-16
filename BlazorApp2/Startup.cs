namespace BlazorApp2
{
    public static class Startup
    {
        public static WebApplication InitializeApp(String[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            ConfigureServices(builder);
            var app = builder.Build();
            Configure(app);
            return app;
        }
        private static void ConfigureServices(WebApplicationBuilder builder)
        {
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();
            builder.Services.AddSingleton<PersonService>();
            builder.Services.AddHttpClient<IPersonService, PersonService>();
            builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
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
            app.UseMvcWithDefaultRoute();
            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");
        }
    }
}
