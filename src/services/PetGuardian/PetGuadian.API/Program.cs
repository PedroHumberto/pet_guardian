using System.Reflection;
using MediatR;
using PetGuadian.API.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);
builder.Services.AddHealthChecks();

//DependencyInjetions
builder.Services.RegisterServices();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

app.UseApiConfiguration(app.Environment);
app.UseSwaggerConfiguration();
app.MapHealthChecks("/health");
app.UseStaticFiles();


app.Run();
