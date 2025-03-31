namespace ServicesInMiddleware.Services
{
    public static class ServiceProviderExtensions
    {
        public static void AddCounterService(this IServiceCollection services)
        {
            // Transient: объект сервиса создается каждый раз, когда к нему обращается запрос. 
            // Подобная модель жизненного цикла наиболее подходит для легковесных сервисов, которые не хранят данных о состоянии
            services.AddTransient<ICounter, RandomCounter>();
            services.AddTransient<CounterService>();
        }
    }
}
