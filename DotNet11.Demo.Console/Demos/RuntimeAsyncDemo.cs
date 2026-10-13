using System.Diagnostics;

namespace DotNet11.Demo.ConsoleApp.Demos
{
    // Enable runtime async by adding in the .csproj file:
    // <Features>runtime-async=on</Features>

    internal class RuntimeAsyncDemo
    {
        internal async Task Run()
        {
            FunConsoleWriter.WriteLine("RuntimeAsync Stacktrace");
            await OuterAsync();
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
            FunConsoleWriter.WriteLine(new StackTrace(fNeedFileInfo: true).ToString()); //or just Environment.StackTrace;
        }
    }
}
