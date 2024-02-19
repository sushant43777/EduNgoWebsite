using EduNgoWebsite.LogHelper;
using EduNgoWebsite.Models;
using EduNgoWebsite.Repository.Interface;
using EduNgoWebsite.Repository.Service;
using Microsoft.EntityFrameworkCore;
using NLog.Extensions.Logging;
using NLog.Web;
using System.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add NLog
builder.Logging.ClearProviders();
builder.Logging.AddNLog(builder.Configuration.GetSection("Logging"));

// Configure NLog
builder.Host.UseNLog();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<EduNgoWebsiteContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("connString")
    ));



builder.Services.AddTransient<IVolunteerRepository, VolunteerRepository>();
builder.Services.AddTransient<IVolunteerService, VolunteerService>();
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
//}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
