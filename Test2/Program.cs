using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence;
using Services;
using Services.Contracts;
using System;
using System.Linq;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            //args[0] = "1";
            // Create service collection and configure our services
            var services = ConfigureServices();
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();

            // Kick off our actual code
            serviceProvider.GetService<ConsoleApplication>().RunAsync();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddDbContext<TestContext>(options => options.UseSqlServer("Data Source=US0PROD1082VA;Initial Catalog=TdfCorePlatform_2.0;Integrated Security=True;"));
            services.AddRepositoryConfiguration(typeof(Repository<>));
            services.AddTransient<ITestService, TestService>();
            // IMPORTANT! Register our application entry point
            services.AddTransient<ConsoleApplication>();
            return services;
        }
    }

    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositoryConfiguration(this IServiceCollection services, Type entityType)
        {
            if (entityType.GetInterfaces().Any(x => x.IsGenericType
                                                    && x.GetGenericTypeDefinition() == typeof(IRepository<>)))
            {
                return services.AddScoped(typeof(IRepository<>), entityType);
            }

            throw new ArgumentOutOfRangeException();
        }
    }

    public class ConsoleApplication
    {
        private readonly ITestService _testService;
        public ConsoleApplication(ITestService testService)
        {
            _testService = testService;
        }
        public async System.Threading.Tasks.Task RunAsync()
        {
            var result = _testService.GetAll();

            if (result != null) {
                var item = result[0] as UploadFile;

                Console.WriteLine($"Before update; item: {item.Name}, status : {item.Status}");

                //item.Status = newValue;

                Console.WriteLine($"Before update; value: {item.Status}");

                await _testService.Update(item);

                Console.WriteLine($"After update; item: {item.Name}, status : {item.Status}");
            }
        }
    }
}