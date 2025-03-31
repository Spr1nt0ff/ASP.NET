using Microsoft.AspNetCore.Mvc;
using ServicesInMiddleware.Services;

namespace ServicesInMiddleware.Controllers
{
    public class HomeController : Controller
    {
        private static int i = 0; // статический счетчик запросов
        ICounter Counter { get; }
        CounterService CounterService { get; }
        public HomeController(CounterService counterService, ICounter counter)
        {
            CounterService = counterService;
            Counter = counter;
            i++;
        }

        public IActionResult Index()
        {
            return Content($"Запрос {i}; Counter: {Counter.Value}; Service: {CounterService.Counter.Value}");
        }
    }
}
