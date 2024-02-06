
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();


var app = builder.Build();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapFallbackToFile("index.html");
app.Run();

// Make the implicit Program class public so test projects can access it
public abstract partial class Program;