

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using backend;
var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контекста данных
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры
builder.Services.AddControllers();

/*
var app = builder.Build();
*/

// Добавляем CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorClient", policy =>
    {
        policy.WithOrigins("http://localhost:5052") // адрес Blazor-приложения
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Используем CORS
app.UseCors("AllowBlazorClient");

app.MapControllers();

app.Run();


/*var builder = WebApplication.CreateBuilder(args);

// Добавляем поддержку контекста данных
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Добавляем контроллеры
builder.Services.AddControllers();

var app = builder.Build();


// Настройка маршрутизации и использования контроллеров
app.UseRouting();
app.MapControllers();

app.Run();*/