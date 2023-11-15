using PetGuadian.API.Configuration;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfiguration(builder.Configuration);

//DependencyInjetions
builder.Services.RegisterServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())

app.UseApiConfiguration(app.Environment);
app.UseSwaggerConfiguration();


app.Run();
