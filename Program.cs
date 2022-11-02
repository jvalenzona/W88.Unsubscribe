using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("cn"),
    new CultureInfo("id"),
    new CultureInfo("th"),
    new CultureInfo("vn")
};
var requestLocalizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
    {
        new QueryStringRequestCultureProvider()
        {
            QueryStringKey = "lang",
            UIQueryStringKey = "lang"
        }
    },
    ApplyCurrentCultureToResponseHeaders = true
};
app.UseRequestLocalization(requestLocalizationOptions);
app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Unsubscribe}/{action=Index}/{id?}");


app.Run();
