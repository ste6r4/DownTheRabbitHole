using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextFilter.Services.Derived;
using TextFilter.Services.Interfaces;

namespace TextFilter.Client
{
    public static class Dependencies
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddSingleton<FilterService>()
                        .AddSingleton<IWordFilter, VowelNearMiddleFilter>()
                        .AddSingleton<IWordFilter, LengthFilter>()
                        .AddSingleton<IWordFilter, ContainsLetterFilter>());
    }
}
