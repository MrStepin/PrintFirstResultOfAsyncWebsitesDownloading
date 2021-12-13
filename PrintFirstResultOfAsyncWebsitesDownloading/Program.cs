using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace PrintFirstResultOfAsyncWebsitesDownloading
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var client = new HttpClient();
            Console.WriteLine("Enter list of URL for downloading and separate them by space:");
            string[] urls = (Console.ReadLine()).Split(' ');
            Task[] tasks = new Task[urls.Length];
            int taskNumber = 0;
            foreach (string url in urls)
            {
                tasks[taskNumber] = Task.Run(async () =>
                {
                    return await client.GetAsync(url);
                });
                taskNumber++;
            }
            var firstFinishedTask = Task.WaitAny(tasks);
            Console.WriteLine($"Size of first downloaded website is: {tasks[firstFinishedTask]}");

            Console.ReadKey();
        }
    }
}
