using ServicesInMiddleware.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Transient: объект сервиса создается каждый раз, когда требуется экземпляр класса сервиса. 
// Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, которые не хранят данных о состоянии.
//builder.Services.AddCounterService();

// Scoped: для каждого запроса создается один объект сервиса.
builder.Services.AddScoped<ICounter, RandomCounter>();
builder.Services.AddScoped<CounterService>();

// Singleton: объект сервиса создается при первом обращении к нему, 
// все последующие запросы используют один и тот же ранее созданный объект сервиса
//builder.Services.AddSingleton<ICounter, RandomCounter>();
//builder.Services.AddSingleton<CounterService>();

var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
