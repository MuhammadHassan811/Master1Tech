using Master1Tech.Client.Services.Mapping;
using Master1Tech.Client.Shared;
using Master1Tech.Server.Authorization;
using Master1Tech.Server.Helpers;
using Master1Tech.Server.Models;
using Master1Tech.Server.Services;
using Master1Tech.Server.Services.Industry;
using Master1Tech.Server.Services.Mapping.IndustryMapping;
using Master1Tech.Server.Services.Mapping.ServiceMapping;
using Master1Tech.Server.Services.Mapping.TechnologyMapping;
using Master1Tech.Server.Services.Person;
using Master1Tech.Server.Services.Service;
using Master1Tech.Server.Services.Technology;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Quartz;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnection_DebugMode")));
builder.Services.AddScoped<IHttpService, HttpService>();

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonMappingService, PersonMappingService>();


builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IServiceMappingService, ServiceMappingService>();


builder.Services.AddScoped<ITechnologyService, TechnologyService>();
builder.Services.AddScoped<ITechnologyMappingService, TechnologyMappingService>();

builder.Services.AddScoped<IIndustryService, IndustryService>();
builder.Services.AddScoped<IIndustryMappingService, IndustryMappingService>();
//builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("BlazorServerCRUD"));
builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();

builder.Services.AddScoped<IUploadRepository, UploadRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IIndustryRepository, IndustryRepository>();
builder.Services.AddScoped<IJwtUtils, JwtUtils>();

builder.Services.AddScoped<ITechnologyRepository, TechnologyRepository>();
builder.Services.AddScoped<ITechnologyService, TechnologyService>();
builder.Services.AddScoped<ITechnologyMappingService, TechnologyMappingService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Master1Tech API",
        Version = "v1",
        Description = "CRUD API Services that act as the backend to the Master1Tech website."
    });

    // Set the comments path for the Swagger JSON and UI.
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);
    c.CustomSchemaIds(r => r.FullName);
});

builder.Services.AddQuartz(q =>
{
    q.AddJobAndTrigger<UploadProcessorJob>(builder.Configuration);
});
builder.Services.AddQuartzHostedService(
    q => q.WaitForJobsToComplete = true);

builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var appDbContext = services.GetRequiredService<AppDbContext>();
        //DataGenerator.Initialize(appDbContext);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Master1Tech.api v1");
    c.DefaultModelsExpandDepth(-1);
});

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseMiddleware<ErrorHandlerMiddleware>();
app.UseMiddleware<JwtMiddleware>();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();