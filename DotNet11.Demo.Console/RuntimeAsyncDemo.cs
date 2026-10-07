using System.Diagnostics;

namespace DotNet11.Demo.ConsoleApp
{
    // Enable runtime async by adding in the .csproj file:
    // <Features>runtime-async=on</Features>

    internal class RuntimeAsyncDemo
    {
        internal async Task Run()
        {
            Console.WriteLine("RuntimeAsync Stacktrace Demo");
            Console.WriteLine("----------------");
            await OuterAsync();
            Console.WriteLine("----------------");
        }

        private async Task OuterAsync()
        {
            await Task.CompletedTask;
            await MiddleAsync();
        }

        private async Task MiddleAsync()
        {
            await Task.CompletedTask;
            await InnerAsync();
        }

        private async Task InnerAsync()
        {
            await Task.CompletedTask;
            Console.WriteLine(new StackTrace(fNeedFileInfo: true)); //or just Environment.StackTrace;
        }
    }
}
