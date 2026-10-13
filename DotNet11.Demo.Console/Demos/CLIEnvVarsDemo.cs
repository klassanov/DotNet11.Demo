namespace DotNet11.Demo.ConsoleApp.Demos
{
    internal class CLIEnvVarsDemo
    {
        const string VAR_1_KEY = "VAR_1";
        const string VAR_2_KEY = "VAR_2";

        internal void Run()
        {
            FunConsoleWriter.WriteLine($"{VAR_1_KEY} value: {Environment.GetEnvironmentVariable(VAR_1_KEY) ?? "NOT SET"}");
            FunConsoleWriter.WriteLine($"{VAR_2_KEY} value: {Environment.GetEnvironmentVariable(VAR_2_KEY) ?? "NOT SET"}");
        }
    }
}
