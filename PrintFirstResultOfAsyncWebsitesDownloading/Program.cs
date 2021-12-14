using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PrintFirstResultOfAsyncWebsitesDownloading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter list of URL for downloading and separate them by space:");
            string[] urls = (Console.ReadLine()).Split(' ');
            List<Task> tasks = new List<Task> { };
            foreach (string url in urls)
            {
                tasks.Add(Task.Run(async () =>
                {
                    return await client.GetAsync(url);
                }));
            }
            var firstFinishedTask = await Task.WhenAny(tasks);
            Console.WriteLine($"Size of first downloaded website is: {firstFinishedTask}");

            Console.ReadKey();
        }
    }
}
