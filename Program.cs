using mvc_project.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;
using mvc_project.Controllers.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(o =>{
    o.LoginPath="/Home/Login";
});
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new  DemoAction());
});
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new  ExecptionFilter());
});
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(new  ResultFilter());
});



    

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

app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
