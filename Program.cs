var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
builder.Configuration.AddEnvironmentVariables();	

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
