using DotNet11.Demo.ConsoleApp;



char selectedKey = ' ';

while (!selectedKey.Equals('q'))
{
    Console.WriteLine("Welcome to the .NET 11 Demo. Press a number key to choose a demo. q to exit");    
    Console.WriteLine("1: Union Types Demo");
    Console.WriteLine("2: Async Runtime Demo");
    Console.WriteLine("3: Partial Parsing Demo");
    Console.WriteLine("4: JSON Lines Demo");
    Console.WriteLine("5: Joins Returning Tuples Demo");
    Console.WriteLine("6: CLI Environment Variables Demo");

    selectedKey = Console.ReadKey().KeyChar;
    Console.WriteLine();

    switch (selectedKey)
    {
        case '1': new UnionTypesDemo().Run();
                  break;

        case '2': await new RuntimeAsyncDemo().Run();
                  break;

        case '3': new PartialParsingDemo().Run();
                  break;

        case '4': await new JSONLinesDemo().Run();
                  break;

        case '5': new TupleReturningJoinsDemo().Run();
                  break;

        case '6': new CLIEnvVarsDemo().Run();
                  break;

        case 'q': Console.WriteLine("Bye bye"); 
                  break;                 

        default: Console.WriteLine("Please Make a valid choice");
                 break;
    }
    Console.WriteLine();
}


// Union Types
//new UnionTypesDemo().Run();

// Async Runtime
//await new RuntimeAsyncDemo().Run();

//Partial Parsing
//new PartialParsingDemo().Run();

//JSONLinesDemo
//await new JSONLinesDemo().Run();

//Tuple Returning Joins Demo
//new TupleReturningJoinsDemo().Run();

//CLIEnvVarsDemo
//new CLIEnvVarsDemo().Run();