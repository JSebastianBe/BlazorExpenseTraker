using BlazorExpenseTraker.Data;
using BlazorExpenseTraker.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
var SqlConnectionConfiguration = new SqlConfiguration(config.GetConnectionString("SqlConnection"));
builder.Services.AddSingleton(SqlConnectionConfiguration);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.Run();
