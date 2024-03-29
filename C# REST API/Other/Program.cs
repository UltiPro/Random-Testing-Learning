using Microsoft.EntityFrameworkCore;
using APIContext;
using Microsoft.Extensions.Options;
using entityf.Configurations;
using entityf.Contracts;
using entityf.Repository;
using Microsoft.AspNetCore.Identity;
using entityf.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using entityf.Middleware;
using Microsoft.AspNetCore.OData;
using Microsoft.OpenApi.Models;
using System.ComponentModel.Design;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("API");

builder.Services.AddDbContext<API>(options =>
{
    options.UseSqlServer(connectionString);
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Title",
        Version = "v1",
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Description",
        Name = "Name",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "0auth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
});

builder.Services.AddAutoMapper(typeof(MapperConfiguration));

builder.Services.AddIdentityCore<APIUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<APIUser>>("APIListingHotel")
    .AddEntityFrameworkStores<API>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<ICountriesRepository, CountriesRepository>();

builder.Services.AddScoped<IAuthMenager, AuthMenager>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ClockSkew = TimeSpan.Zero,
        ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
        ValidAudience = builder.Configuration["JwtSettings:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]))
    };
});

builder.Services.AddResponseCaching(options =>
{
    options.MaximumBodySize = 8192;
    options.UseCaseSensitivePaths = true;
});

builder.Services.AddHealthChecks().AddCheck<CustomHealthCheck>("Custom hc", failureStatus: HealthStatus.Degraded,
    tags: new[] {"custom"});

// mo�na jeszcze sprawdzi� baz� danych ASP.healthcheck.Sqlserver

// .AddSqlServer(constring)

//extensions.diagnostic.healthcheck.entityframeworkcore

//.AddDBContextCheck<DBcontextjaki�>();

builder.Services.AddControllers().AddOData(options =>
{
    options.Select().Filter().OrderBy();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthcheck", new HealthCheckOptions
{
    Predicate = hc => hc.Tags.Contains("custom"),
    ResultStatusCodes =
    {
        [HealthStatus.Healthy] = StatusCodes.Status200OK,
        [HealthStatus.Unhealthy] = StatusCodes.Status503ServiceUnavailable,
        [HealthStatus.Degraded] = StatusCodes.Status200OK
    },
    ResponseWriter = WriteResponse
});

static Task WriteResponse(HttpContext context, HealthReport report)
{
    /* jaka� logika */
    throw new NotImplementedException();
}

app.MapHealthChecks("/hc2");

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseResponseCaching();

app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new Microsoft.Net.Http.Headers.CacheControlHeaderValue()
        {
            Public = true,
            MaxAge = TimeSpan.FromSeconds(10)
        };
    context.Response.Headers[Microsoft.Net.Http.Headers.HeaderNames.Vary] =
        new string[] { "Accept-Encoding" };
    await next();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

class CustomHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        var isHealth = true;

        /* some code */

        if (isHealth) return Task.FromResult(HealthCheckResult.Healthy("Works good."));
        else return Task.FromResult(new HealthCheckResult(context.Registration.FailureStatus, "bad :<"));
    }
}