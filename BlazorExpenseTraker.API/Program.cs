using BlazorExpenseTraker.Data;
using BlazorExpenseTraker.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);


IConfigurationRoot config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IExpenseRepository, ExpenseRepository>();
var SqlConnectionConfiguration = new SqlConfiguration(config.GetConnectionString("SqlConnection"));
builder.Services.AddSingleton(SqlConnectionConfiguration);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddCors(opciones => opciones.AddPolicy("nuevaPolitica", app=>{
    app.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod();
}));



var app = builder.Build();

app.UseCors("nuevaPolitica");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseAuthorization();
app.UseEndpoints(endpoints => endpoints.MapControllers());


app.Run();
