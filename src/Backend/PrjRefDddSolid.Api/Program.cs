using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using PrjRefDddSolid.Api.Converters;
using PrjRefDddSolid.Api.Filters;
using PrjRefDddSolid.Application;
using PrjRefDddSolid.Infrastructure;
using PrjRefDddSolid.Infrastructure.Migrations;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new StringConverter()));
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

//Substituído pelo builder.Services.AddInfrastructure(), usando o método de extensão
// PrjRefDddSolid.Infrastructure.DependencyInjectionExtension.AddInfrastructure(builder.Services);

//Substituído pelo builder.Services.AddApplication(), usando o método de extensão
// PrjRefDddSolid.Application.DependencyInjectionExtension.AddApplication(builder.Services);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new List<CultureInfo> { new("en"), new("pt-BR"), new("es") };

    options.DefaultRequestCulture = new RequestCulture("en");

    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;

    options.RequestCultureProviders = [new AcceptLanguageHeaderRequestCultureProvider()];
});

builder.Services.AddMvc(options => options.Filters.Add<ExceptionFilter>());

// Configure routing to use lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

var localizationOptions = app.Services.GetService<IOptions<RequestLocalizationOptions>>();

app.UseRequestLocalization(localizationOptions.Value);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await ExecuteMigrations();

app.Run();

async Task ExecuteMigrations()
{
    await using var scope = app.Services.CreateAsyncScope();

    DataBaseMigrations.ExecuteMigrations(scope.ServiceProvider);

    //await DataBaseMigrations.ExecuteMigrations(scope.ServiceProvider);
}

public partial class Program { }
