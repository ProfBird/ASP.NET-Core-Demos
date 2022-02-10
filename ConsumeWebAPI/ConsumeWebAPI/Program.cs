using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;


namespace ConsumeWebAPI
{
    class Program
    {
        static HttpClient client = new HttpClient();

        public class Document
        {
            public int cover_i { get; set; }
            public bool has_fulltext { get; set; }
            public int edition_count { get; set; }
            public string title { get; set; }
            public List<string> author_name { get; set; }
            public int first_publish_year { get; set; }
            public string key { get; set; }
            public List<string> ia { get; set; }
            public List<string> author_key { get; set; }
            public bool public_scan_b { get; set; }
        }


        static async Task Main(string[] args)
        {
            Console.WriteLine("Open Library!");
            Task<string> getBooks = GetBooksAsync("http://openlibrary.org/search.json?author=tolkien");

            var books = await getBooks;
        }

        static async Task<string> GetBooksAsync(string path)
        {
            string books = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                books = await response.Content.ReadAsStringAsync();
                //books = await response.Content.ReadAsAsync<Document>();
            }
            return books;
        }
    }
}

/*
 * References
 * 
 * HttpClient tutorial:
 * https://docs.microsoft.com/en-us/aspnet/web-api/overview/advanced/calling-a-web-api-from-a-net-client
 * Open Library Web API documentation:
 * https://openlibrary.org/developers/api
 * https://openlibrary.org/dev/docs/api/search
 * Convert JSON objects to C# classes online:
 * https://json2csharp.com/json-to-csharp
 */