using DotNet11.Demo.ConsoleApp.Demos;

namespace DotNet11.Demo.ConsoleApp
{
    internal static class MenuHandler
    {
        private static char exitKey = 'q';

        private static readonly List<MenuChoice> menuChoices =
        [
            new MenuChoice('1', "Union Types Demo", () => new UnionTypesDemo().Run()),
            new MenuChoice('2', "Async Runtime Demo", async () => await new RuntimeAsyncDemo().Run()),
            new MenuChoice('3', "Partial Parsing Demo", () => new PartialParsingDemo().Run()),
            new MenuChoice('4', "JSON Lines Demo", async () =>  await new JSONLinesDemo().Run()),
            new MenuChoice('5', "Joins Returning Tuples Demo", () => new TupleReturningJoinsDemo().Run()),
            new MenuChoice('6', "CLI Environment Variables Demo", () => new CLIEnvVarsDemo().Run()),
            new MenuChoice(exitKey, "Exit", () => Console.WriteLine("Bye bye"))
        ];

        internal static void HandleMenu()
        {
            char selectedKey = ' ';
            while (selectedKey != exitKey)
            {
                PrintMenu();
                Console.WriteLine();

                selectedKey = Console.ReadKey().KeyChar;
                Console.WriteLine();
                
                ExecuteChoice(selectedKey);
                Console.WriteLine();
            }
        }


        private static void PrintMenu()
        {
            Console.WriteLine($"Welcome to the .NET 11 Demo. Press a number key to choose a demo. {exitKey} to exit");
            menuChoices.ForEach(x => Console.WriteLine($"{x.SelectionKey}: {x.Description}"));
        }

        private static void ExecuteChoice(char selectedKey)
        {
            var menuChoice = menuChoices.SingleOrDefault(x => x.SelectionKey.Equals(selectedKey));
            if (menuChoice == null)
            {
                Console.WriteLine("Please make a valid choice");
            }
            else
            {
                Console.WriteLine(menuChoice.Description);
                Console.WriteLine("---------------------");
                menuChoice.DemoAction();
                Console.WriteLine("---------------------");
            }
        }
    }

    internal record MenuChoice(char SelectionKey, string Description, Action DemoAction);   
}
