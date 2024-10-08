using BuberDinner.Api.Common;
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Filters;
using BuberDinner.Api.Middleware;
using BuberDinner.Application.Services;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
