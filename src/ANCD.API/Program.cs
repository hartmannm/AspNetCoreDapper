using ANCD.API.Extensions;
using ANCD.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddApiVersioning();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddInfraConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
    app.UseSwaggerConfig();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
