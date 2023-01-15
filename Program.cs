using KbstAPI.Core.DTO.Mapping;
using KbstAPI.Core.IRepositories;
using KbstAPI.Core.Repositories;
using KbstAPI.Core.UnitOfWork;
using KbstAPI.Data;
using KbstAPI.Documentation;
using KbstAPI.Services;
using KbstAPI.Services.ConcreteServices;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Converters;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Kbst") ?? "Data Source=Kbst.db";

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Mappings));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IAssetService, AssetService>();
builder.Services.AddScoped<IAssetTypeService, AssetTypeService>();
builder.Services.AddScoped<IReportService, ReportService>();
builder.Services.AddScoped<IReportRepository, ReportRepository>();
builder.Services.AddScoped<IAssetTypeRepository, AssetTypeRepository>();
builder.Services.AddScoped<IAssetRepository, AssetRepository>();


builder.Services.AddControllers().AddJsonOptions(opt =>
    opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())
    );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSqlite<KbstContext>(connectionString);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SupportNonNullableReferenceTypes();
    options.SchemaFilter<ExampleSchemaFilter>();
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Version = "v1",
        Title = "KBST API",
        Description = "An ASP.NET Core Web API"
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
