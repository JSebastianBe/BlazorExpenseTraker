using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using BlazorExpenseTraker.UI.Interfaces;
using BlazorExpenseTraker.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();


builder.Services.AddServerSideBlazor().AddCircuitOptions(options => {options.DetailedErrors = true;});

builder.Services.AddHttpClient<ICategoryService, CategoryService>(
    client => {client.BaseAddress = new Uri("http://localhost:5041");}
);

builder.Services.AddHttpClient<IExpenseService, ExpenseService>(
    client => {client.BaseAddress = new Uri("http://localhost:5041");}
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
