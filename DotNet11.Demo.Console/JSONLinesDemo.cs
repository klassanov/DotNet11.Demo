using System.Text.Json;

namespace DotNet11.Demo.ConsoleApp
{
    internal class JSONLinesDemo
    {
        internal async Task Run()
        {
            await using var fileStream = File.Create("people.jsonl");
            await JsonSerializer.SerializeAsyncEnumerable(
                fileStream,
                GetPeopleAsync(),
                topLevelValues: true);

            await using var outputStream = Console.OpenStandardOutput();
            await JsonSerializer.SerializeAsyncEnumerable(
                outputStream, GetPeopleAsync(),
                topLevelValues: true);
        }

        async IAsyncEnumerable<Person> GetPeopleAsync()
        {
            yield return new(1, "Alice");
            yield return new(2, "Bob");
            yield return new(3, "Charlie");
            await Task.CompletedTask;
        }
    }

    record Person(int Id, string Name);
}
