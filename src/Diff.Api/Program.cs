using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Diff.ApplicationCore.AutoMapper;
using Diff.ApplicationCore.Interfaces.Services;
using Diff.ApplicationCore.Services;
using Diff.Infrastructure.Interfaces.Repositories;
using Diff.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning(opt =>
{
    opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    opt.ReportApiVersions = true;
    opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                    new HeaderApiVersionReader("x-api-version"),
                                                    new MediaTypeApiVersionReader("x-api-version"));
});

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
    .AddJsonOptions(options => {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Diff API",
        Description = "Diff a .NET 6 C# Rest API for the Paybyrd Assignment (Base64 Encoded Binary Differences)",
        Contact = new OpenApiContact
        {
            Name = "Lorena Rocha",
            Url = new Uri("https://www.linkedin.com/in/lorenadaphene/")
        }
    });

    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddAutoMapper(typeof(RequestToEntityProfile), typeof(EntityToResponseProfile));
builder.Services.AddTransient<IDifferenceService, DifferenceService>();
builder.Services.AddTransient<ILeftBase64EncodedBinaryService, LeftBase64EncodedBinaryService>();
builder.Services.AddTransient<IRightBase64EncodedBinaryService, RightBase64EncodedBinaryService>();
builder.Services.AddTransient<ILeftBase64EncodedBinaryRepository, LeftBase64EncodedBinaryRepository>();
builder.Services.AddTransient<IRightBase64EncodedBinaryRepository, RightBase64EncodedBinaryRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseHttpLogging();

app.Run();

