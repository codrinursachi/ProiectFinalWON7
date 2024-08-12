using Microsoft.EntityFrameworkCore;
using ProiectFinalWON7.Data;
using ProiectFinalWON7.MiddlewareFilters;
using ProiectFinalWON7.Services;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<StudentRegistryDbContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("StudentsDb"))
    );
builder.Services.AddScoped<StudentService>();
builder.Services.AddScoped<SubjectService>();
builder.Services.AddScoped<MarkService>();
builder.Services.AddScoped<SeedService>();
builder.Services.AddControllers(options =>
{
    options.Filters.Add<IdNotFoundExceptionFilter>();
    options.Filters.Add<AddressNotFoundExceptionFilter>();
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(o=>AddSwaggerDocumentation(o));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void AddSwaggerDocumentation(SwaggerGenOptions o)
{
    var xmlFilename=$"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    o.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
}