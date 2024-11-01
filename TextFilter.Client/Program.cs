using Microsoft.Extensions.DependencyInjection;
using TextFilter.Services.Derived;
using TextFilter.Services.Helpers;
using TextFilter.Shared;

namespace TextFilter.Client;

internal class Program
{
    private static void Main(string[] args)
    {
        var host = Dependencies.CreateHostBuilder(args).Build();
        var filterService = host.Services.GetRequiredService<FilterService>();
        try
        {
            Console.WriteLine("****** Reading text file in ******\n");
            var fileContent = FileHelper.GetFileContent(Directory.GetCurrentDirectory(), AppConstants.TextInputFileName);
            Console.WriteLine("****** Text file processed ******\n");
            var filteredContent = filterService.ApplyFilters(fileContent);
            Console.WriteLine("****** Content filtered ******\n");
            Console.WriteLine(filteredContent);
            Console.WriteLine("\n");
            Console.WriteLine("****** End of filtered output ******");
            Console.ReadLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            Console.ReadLine();
        }
    }
}
