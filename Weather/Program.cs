using Hangfire;
using QuickNews.Services.Abstract;
using QuickNews.Services.Concrete;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHangfireServer();
builder.Services.AddSingleton<INewsService, NewsService>();
builder.Services.AddSingleton<IEmailService, EmailService>();
builder.Services.AddSingleton<IQuickNewsService, QuickNewsService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseHangfireServer();
app.UseHangfireDashboard();
RecurringJob.AddOrUpdate<IQuickNewsService>("QuickNewsJob",service => service.CurrencyReporter(), Cron.Daily);

app.Run();
