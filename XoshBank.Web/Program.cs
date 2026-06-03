using XoshBank.Web.Services.Interfaces;
using XoshBank.Web.Services.Implementations;
using XoshBank.Core.Repositories;
using XoshBank.Persistent.SQLServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IBranchService, BranchService>();
builder.Services.AddTransient<IEmployeeService, EmployeeService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUnitOfWork>(x =>
    new MsSQLUnitOfWork(
        builder.Configuration.GetConnectionString("MsSql")
    )
);

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
