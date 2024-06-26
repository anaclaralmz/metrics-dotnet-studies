using IDMetric;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<HatCoMetrics>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("/complete-sale", ([FromBody] SaleModel model, HatCoMetrics metrics) =>
    {
        metrics.HatsSold(model.QuantitySold);
    })
    .WithName("CreateCompleteSale")
    .WithOpenApi();

app.Run();

public class SaleModel
{
    public int QuantitySold { get; set; }
}