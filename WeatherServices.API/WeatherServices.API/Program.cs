using System.Configuration;
using WeatherServices.API.Models;
using WeatherServices.ApiHelper;
using WeatherServices.Service.WeatherDetail;

var builder = WebApplication.CreateBuilder(args);
var weatherApiBaseUrl = builder.Configuration.GetValue<string>("weatherApiBaseUrl");


// Add services to the container.

builder.Services.AddControllers();
//builder.Services.Configure<Settings>(builder.Configuration.GetSection("weatherApiKey"));
builder.Services.AddScoped<IWeatherDetailService, WeatherDetailService>();
builder.Services.AddHttpClient<IWeatherApiCaller, WeatherApiCaller>(client =>
{
    client.BaseAddress = new Uri(weatherApiBaseUrl);
    client.DefaultRequestHeaders.Add("apiKey", builder.Configuration.GetValue<string>("weatherApiKey"));
    
});
//Enable cors
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Enable cors
app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
