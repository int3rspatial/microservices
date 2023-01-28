using Microsoft.EntityFrameworkCore;
using BusinessLogicLevel;
using BusinessLogicLevel.Interfaces;
using BusinessLogicLevel.Services;
using TaskPlannerWeb.Utilities;
using DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.InjectDependencies(builder.Configuration);

builder.Services.AddAutoMapper(typeof(ViewAutoMapperProfile));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//using (var scope =
//  app.ApplicationServices.CreateScope())
//using (var context = scope.ServiceProvider.GetService<ApplicationDbContext>())
//    context.Database.Migrate();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
    db.Database.EnsureCreated();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
