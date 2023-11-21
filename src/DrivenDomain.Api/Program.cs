using DrivenDomain.Crosscutting.Extensions;
using Microsoft.OpenApi.Models;
using DrivenDomain.Infrastructure.Context;
using DrivenDomain.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDD API", Version = "v1" });
});

//dependency injection
builder.Services.Inject();

//fluent validation
builder.Services.AddValidators();

//auto mapper
builder.Services.AddProfile();

//database configuration
builder.Services.AddDbContextPool<DrivenDomainContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DDD API V1");
    c.RoutePrefix = "swagger";
});

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();