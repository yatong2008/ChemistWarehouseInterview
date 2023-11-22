using PizzeriaBL.ServiceInterfaces;
using PizzeriaBL.Services;
using PizzeriaDAL.Repositories;
using PizzeriaDAL.RepositoryInterfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IPizzeriaService, PizzeriaService>();
builder.Services.AddTransient<IMenuItemService, MenuItemService>();
builder.Services.AddTransient<IMenuItemRepository, MenuItemRepository>();
builder.Services.AddTransient<IPizzeriaRepository, PizzeriaRepository>();
builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
builder.Services.AddTransient<IToppingRepository, ToppingRepository>();

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
