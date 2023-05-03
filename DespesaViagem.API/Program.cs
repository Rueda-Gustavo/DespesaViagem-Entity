using DespesaViagem.Infra;
using DespesaViagem.Service;
using Microsoft.Net.Http.Headers;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.WriteIndented = true;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
    });
builder.Services.AddRouting(options => options.LowercaseUrls = true);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddDespesaViagemInfra(builder.Configuration)
    .AddDespesaViagemService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(policy => policy
    .AllowAnyOrigin()
    //.WithOrigins("https://localhost:7175/", "http://localhost:7175/")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithHeaders(HeaderNames.ContentType)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
