global using BlazorApp2.Data;
global using BlazorApp2.Interfaces;
global using BlazorApp2.Services;
using BlazorApp2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var app = Startup.InitializeApp(builder);
await app.Build().RunAsync();
