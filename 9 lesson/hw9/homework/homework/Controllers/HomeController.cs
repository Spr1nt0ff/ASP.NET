using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using homework.Models;
using Microsoft.EntityFrameworkCore;

namespace homework.Controllers;

public class HomeController : Controller
{

    private readonly GuestBookContext _context;

    public HomeController(GuestBookContext context)
    {
        _context = context;
    }



    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    public ActionResult Logout()
    {
        Response.Cookies.Delete("login");
        return RedirectToAction("Index", "Home");
    }

    public IActionResult AddMessage(string Message)
    {
        var login = Request.Cookies["login"];
        var userId = _context.User.FirstOrDefault(u => u.Login == login).Id;

        Console.WriteLine($"Date: {DateTime.Now}, Message: {Message}, Login: {Request.Cookies["login"]}, UserId: {userId}");

        Messages messages = new Messages
        {
            MessageDate = DateTime.Now,
            Message = Message,
            UserId = userId
        };
        _context.Message.Add(messages);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}