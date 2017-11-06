using System;
using System.Threading.Tasks;

/* Written by Brian Bird
 * 11/6/17
 * Console app demonstrating the use of async, await, and Task
 * Asynchronous methods allow execution of the calling method to continue 
 * without waiting for the async method to return
 */

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> answer = DemoAsync();                         // Non-void async methods must return a task object
            Console.WriteLine("After call to asyc method");         // ** Main point -> This line is executed imediately
            Console.WriteLine("The answer is " + answer.Result);    // answer.Result waits until the async mentod returns

        }

        // Simulate a method that takes a long time to return
        public static async Task<int> DemoAsync()   // async keyword is used to make an asynchronous method
        {
            Console.WriteLine("In async method");
            await Task.Delay(2000);                 // await releases execution back to the calling method
            Console.WriteLine("Delay finished");    // Task.Delay simulates a long running operation. Task wasn't requried here
            return 42;
        }

    }

}


/* For more information on async, await, and Task see:
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/async 
 * https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/await
 * https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.task-1?view=netcore-2.0
 */