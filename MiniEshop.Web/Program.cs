using MiniEshop.Application;
using MiniEshop.Infrastructure;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// automatically validate modelstate with FluentValidation validators
//builder.Services.AddFluentValidationAutoValidation();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();

// for decimal seperator model binding
var culture = new CultureInfo("az-AZ");
culture.NumberFormat.NumberDecimalSeparator = ".";
CultureInfo.DefaultThreadCurrentCulture = culture;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
