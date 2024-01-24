using DrivenDomain.Crosscutting.Extensions;
using DrivenDomain.Infrastructure.Context;
using DrivenDomain.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Data;
using DrivenDomain.Api;
using DrivenDomain.Api.Config;
using DrivenDomain.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { 
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDD API", Version = "v1" }); 
            // Define security scheme (e.g., JWT Bearer Token)
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Enter your JWT Token",
            Name = "Authorization",
            Type = SecuritySchemeType.ApiKey
        });

        // Add security requirements
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] { }
            }
        });
    
    });

//dependency injection
builder.Services.Inject();

//fluent validation
builder.Services.AddValidators();

var jwtConfig = builder.Configuration.GetSection("Jwt").Get<JwtConfig>() ?? new JwtConfig();
builder.Services.AddSingleton(jwtConfig);

//Authorization Service
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "localhost",
            ValidAudience = "localhost",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.Secret ?? throw new DataException("SecretKey not found."))),
        };
    });

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

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

// app.Use(async (context, next) =>
// {
//     var myMiddleware = new AuthMiddleware(next, builder.Configuration);
//     await myMiddleware.InvokeAsync(context);
// });
app.UseMiddleware<ErrorHandlingMiddleware>();

//app.UseAuthentication(); // Use authentication middleware.
// app.UseAuthorization();

app.MapControllers();

app.Run();