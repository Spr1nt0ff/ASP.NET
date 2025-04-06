using Microsoft.EntityFrameworkCore;
using Soccer.BLL.Interfaces;
using Soccer.BLL.Services;
using Soccer.BLL.Infrastructure;


var builder = WebApplication.CreateBuilder(args);

// �������� ������ ����������� �� ����� ������������
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSoccerContext(connection);
builder.Services.AddUnitOfWorkService();
builder.Services.AddTransient<ITeamService, TeamService>();
builder.Services.AddTransient<IPlayerService, PlayerService>();

// ��������� ������� MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles(); // ������������ ������� � ������ � ����� wwwroot

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Teams}/{action=Index}/{id?}");

app.Run();
