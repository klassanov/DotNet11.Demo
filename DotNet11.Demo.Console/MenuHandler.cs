using DotNet11.Demo.ConsoleApp.Demos;

namespace DotNet11.Demo.ConsoleApp
{
    internal static class MenuHandler
    {
        private static char exitKey = 'q';

        private static readonly List<MenuChoice> menuChoices =
        [
            new MenuChoice('1', "Union Types Demo", () => {
                new UnionTypesDemo().Run();
                return Task.CompletedTask;
            }),

            new MenuChoice('2', "Async Runtime Demo", async () => {
                await new RuntimeAsyncDemo().Run();
            }),           

            new MenuChoice('3', "JSON Lines Demo", async () => {
                await new JSONLinesDemo().Run();
            }),

            new MenuChoice('4', "Joins Returning Tuples Demo", () => {
                new TupleReturningJoinsDemo().Run();
                return Task.CompletedTask;
            }),

            new MenuChoice('5', "CLI Environment Variables Demo", () => {
                new CLIEnvVarsDemo().Run();
                return Task.CompletedTask;
            }),

             new MenuChoice('6', "Partial Parsing Demo", () => {
                new PartialParsingDemo().Run();
                return Task.CompletedTask;
            }),

            new MenuChoice(exitKey, "Exit", () => {
                FunConsoleWriter.WriteLine("Bye bye");
                return Task.CompletedTask; 
            })
        ];

        internal static async Task HandleMenu()
        {
            char selectedKey = ' ';
            while (selectedKey != exitKey)
            {
                PrintMenu();
                Console.WriteLine();

                selectedKey = Console.ReadKey().KeyChar;
                Console.WriteLine();


                await ExecuteChoice(selectedKey);
                Console.WriteLine();
            }
        }
        

        private static void PrintMenu()
        {
            Console.WriteLine($"Welcome to the .NET 11 Demo. Press a number key to choose a demo. {exitKey} to exit");
            menuChoices.ForEach(x => Console.WriteLine($"{x.SelectionKey}: {x.Description}"));
        }

        private static async Task ExecuteChoice(char selectedKey)
        {
            var menuChoice = menuChoices.SingleOrDefault(x => x.SelectionKey.Equals(selectedKey));
            if (menuChoice == null)
            {
                FunConsoleWriter.WriteLine("Please make a valid choice");
            }
            else
            {
                FunConsoleWriter.WriteLine(menuChoice.Description);
                FunConsoleWriter.WriteLine("---------------------");
                await menuChoice.DemoAction();
                FunConsoleWriter.WriteLine("---------------------");
            }
        }
    }

    internal record MenuChoice(char SelectionKey, string Description, Func<Task> DemoAction);
}
