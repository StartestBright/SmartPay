using SmartPay.Server.Data;
using Microsoft.EntityFrameworkCore;
using SmartPay.Server.Models;
using SmartPay.Server.Services.Interfaces;
using SmartPay.Server.Services;
using SmartPay.Server.Helper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Bind tax brackets configuration
var taxBrackets = new List<TaxBracket>();
builder.Configuration.GetSection("TaxBrackets").Bind(taxBrackets);
builder.Services.AddSingleton(taxBrackets); // Make available for DI
builder.Services.AddScoped<IPayslipService, PayslipService>();
builder.Services.AddScoped<IGrossIncomeCalculator,GrossIncomeCalculator>();
builder.Services.AddScoped<IIncomeTaxCalculator,IncomeTaxCalculator>();
builder.Services.AddScoped<ISuperCalculator,SuperCalculator>();
builder.Services.AddScoped<IPayPeriodFormatter,PayPeriodFormatter>();
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);


var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();



