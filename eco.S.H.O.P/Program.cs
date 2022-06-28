using BLL.Infrastructure;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DLL.Context;
using eco.S.H.O.P.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using Serilog;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'ECOshopContextConnection' not found.");

builder.Services.AddDbContext<ECOshopContext>(options =>
    options.UseSqlServer(connectionString)); ;



//var keyVaultEndpoint = new Uri("https://ecoshopvault.vault.azure.net/");

//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());


builder.Host.UseSerilog((HostingContext, AsyncServiceScope, configuration) =>
{
    configuration.WriteTo.File(builder.Environment.WebRootPath + "/LooooG.txt");
});
//var connectionString = builder.Configuration.GetValue(typeof(string),"DefaultConnection").ToString() ?? throw new InvalidOperationException("Connection string 'ECOshopContextConnection' not found.");

//builder.Services.AddDbContext<ECOshopContext>(options => options.UseSqlServer(connectionString));


var identityBuilder = builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ECOshopContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


BLL.Infrastructure.Configuration.ConfigurationService(builder.Services, connectionString, identityBuilder); // Config Business

//builder.Services.AddTransient<IEmailSender, SendGridEmailSender>();

eco.S.H.O.P.Infrastructure.Configuration.ConfigurationService(identityBuilder);



builder.Services.AddControllersWithViews();
builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
