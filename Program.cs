using FastEndpoints.Swagger;
using ToyShopAPI.Features.Auth.Signin;
using ToyShopAPI.Features.Auth.Signup;
using ToyShopAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["JwtSigningKey"]);
builder.Services.AddSwaggerDoc(maxEndpointVersion: 1, settings: s =>
{
  s.DocumentName = "Initial Release 1.0";
  s.Title = "Toy Shop API Documentation";
  s.Version = "v1.0";
});
var connectionString = builder.Configuration.GetConnectionString("ToyShopAPI");
var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
builder.Services.AddDbContext<toyshopapiContext>(
  options => options
                  .UseLazyLoadingProxies()
                  .UseMySql(connectionString, serverVersion)
                  .LogTo(Console.WriteLine, LogLevel.Information)
                  .EnableSensitiveDataLogging()
                  .EnableDetailedErrors());
builder.Services.AddScoped<ISignupData, SignupData>();
builder.Services.AddScoped<ISigninData, SigninData>();

var app = builder.Build();
app.UseAuthorization();
app.UseFastEndpoints(c =>
{
  c.Versioning.Prefix = "v";
  c.Endpoints.RoutePrefix = "api";
});
app.UseOpenApi();
app.UseSwaggerUi3(c => c.ConfigureDefaults());

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
var url = $"http://0.0.0.0:{port}";
app.Run(url);