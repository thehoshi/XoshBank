using XoshBank.Web.Services.Interfaces;
using XoshBank.Web.Services.Implementations;
using XoshBank.Core.Repositories;
using XoshBank.Persistent.SQLServer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Register services before building the app
builder.Services.AddTransient<IBranchService, BranchService>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IUnitOfWork>(x =>
    new MsSQLUnitOfWork(
        builder.Configuration.GetConnectionString("MsSql")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
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
