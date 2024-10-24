using System;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        string url = "https://gutenberg.org/ebooks/11074"; // URL книги
        char letterToCount;

        Console.Write("Введите букву для подсчета: ");
        letterToCount = Console.ReadKey().KeyChar;
        Console.WriteLine();

        string bookContent = await DownloadBookAsync(url);
        int count = CountLetterOccurrences(bookContent, letterToCount);

        Console.WriteLine($"Количество '{letterToCount}' в книге: {count}");
    }

    static async Task<string> DownloadBookAsync(string url)
    {
        using (HttpClient client = new HttpClient())
        {
            return await client.GetStringAsync(url);
        }
    }

    static int CountLetterOccurrences(string content, char letter)
    {
        int count = 0;
        foreach (char c in content)
        {
            if (char.ToLower(c) == char.ToLower(letter)) 
            {
                count++;
            }
        }
        return count;
    }
}
