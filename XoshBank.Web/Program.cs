using XoshBank.Core.Repositories;
using XoshBank.Web.Services.Interfaces;
using XoshBank.Web.Services.Implementations;
using XoshBank.Persistent.SQLServer.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IEmployeeService, EmployeeService>();


builder.Services.AddTransient<IUnitOfWork>(provider =>
    new MsSQLUnitOfWork(
        builder.Configuration.GetConnectionString("DefaultConnection")
    ));

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
    pattern: "{controller=Employees}/{action=Index}/{id?}");

app.Run();
