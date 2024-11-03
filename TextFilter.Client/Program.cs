using Microsoft.Extensions.DependencyInjection;
using TextFilter.Services.Derived;
using TextFilter.Services.Helpers;
using TextFilter.Shared;

namespace TextFilter.Client;

public static class Program
{
    public static string FilteredContent { get; set; } = string.Empty;

    public static void Main(string[] args)
    {
        var host = Dependencies.CreateHostBuilder(args).Build();
        var filterService = host.Services.GetRequiredService<FilterService>();
        try
        {
            Console.WriteLine("****** Reading text file in ******\n");
            var fileContent = FileHelper.GetFileContent(Directory.GetCurrentDirectory(), AppConstants.TextInputFileName);
            Console.WriteLine("****** Text file processed ******\n");
            FilteredContent = filterService.ApplyFilters(fileContent);
            Console.WriteLine("****** Content filtered ******\n");
            Console.WriteLine(FilteredContent);
            Console.WriteLine("\n");
            Console.WriteLine("****** End of filtered output ******");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}
