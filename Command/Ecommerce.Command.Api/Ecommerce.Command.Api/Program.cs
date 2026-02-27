using Ecommerce.Entities.Infrastructure.Extensions;
using FluentValidation.AspNetCore;
using Ecommerce.Command.Services.Endpoints;
using Ecommerce.Command.Services.Services.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEntitiesInfrastructure(builder.Configuration);
builder.Services.AddCommandServices();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("UAT"))
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseWhen(ctx => ctx.Request.Path.StartsWithSegments("/api/v1"), branch =>
{
    branch.UseSerilogRequestLogging();
});
app.MapControllers();
app.MapEntityEndpoints();

app.Run();
