using MasterDetailsPracticeNew.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(option => option.UseOracle(builder.Configuration.GetConnectionString("connection")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();
//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllerRoute(
//        name: "default",
//        pattern: "{controller=Projects}/{action=List}/{ Projectid ?}/{ memberid ?}");
//});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Projects}/{action=List}/{Projectid?}/{ProjectTaskId?}");

app.Run();
