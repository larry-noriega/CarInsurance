using CarInsurance.API.Middleware.AuthJWT;
using CarInsurance.Core.Interfaces;
using CarInsurance.Core.Models.Settings;
using CarInsurance.Core.Models.Settings.Auth;
using CarInsurance.Core.Services;
using CarInsurance.Infrastructure.Data;
using CarInsurance.Infrastructure.Data.Context;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<CarInsuranceDBSettings>(
    builder.Configuration.GetSection("InsurancePoliciesDatabase") );

builder.Services.AddSingleton<CarInsuranceService>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
      {
        new OpenApiSecurityScheme
        {
          Reference = new OpenApiReference
          {
            Type=ReferenceType.SecurityScheme,
            Id="Bearer"
          }
        },
        Array.Empty<string>()
      }
    });
});

builder.Services.AddCors();

// configure strongly typed settings object
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// configure DI for application services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICarInsuranceRepository, CarInsuranceRepository>();

// sigleton for settings
builder.Services.AddTransient<ICarInsuranceContext, CarInsuranceContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// configure HTTP request pipeline
{
    // global cors policy
    app.UseCors(x => x
      .AllowAnyOrigin()
      .AllowAnyMethod()
      .AllowAnyHeader());

    // custom JWT auth middleware
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();