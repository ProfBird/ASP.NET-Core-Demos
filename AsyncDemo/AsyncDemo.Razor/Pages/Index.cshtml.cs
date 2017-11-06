using System.Threading;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AsyncDemo.Razor.Pages
{
    public class IndexModel : PageModel
    {
        public string Message1 { get; set; }
        public string Message2 { get; set; }
        public string Message3 { get; set; }

        public void OnGet()
        {
            Message1 = "";
            Message2 = "";
            Message3 = "";

        }public void OnGetNormal()
        {
            Message1 = SlowOperation("first");
            Message2 = SlowOperation("second");
            Message3 = SlowOperation("third");
        }

        public async Task OnGetImprovedAsync()
        {
            Task<string> message1 = SlowOperationAsync("first");
            Task<string> message2 = SlowOperationAsync("second");
            Task<string> message3 = SlowOperationAsync("third");
            await Task.WhenAll(message1, message2, message3);
            Message1 = message1.Result;
            Message2 = message2.Result;
            Message3 = message3.Result;
        }

        private string SlowOperation(string title)
        {
            Thread.Sleep(1000);
            return title + " operation done";
        }

        private async Task<string> SlowOperationAsync(string title)
        {
            await Task.Delay(1000);
            return title + " operation done";
        }
    }
}
