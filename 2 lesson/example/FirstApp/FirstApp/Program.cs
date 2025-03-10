using FirstApp;
var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.UseSecond();

app.UseNextComponent();

app.Run();
