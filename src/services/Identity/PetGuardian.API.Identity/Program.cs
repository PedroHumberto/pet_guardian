using PetGuardian.API.Identity.Configuration;

var builder = WebApplication.CreateBuilder(args);

//Environment configuration 
IWebHostEnvironment environment = builder.Environment;
builder.Configuration.SetBasePath(environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsetings.{environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();

if (environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

builder.Services.AddApiConfiguration();

builder.Services.AddIdentityConfiguration(builder.Configuration);

var app = builder.Build();

app.UseApiConfiguration(app.Environment);
app.UseSwaggerConfiguration();

app.Run();
