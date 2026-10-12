namespace DotNet11.Demo.ConsoleApp
{
    internal class TupleReturningJoinsDemo
    {
        record Project(int Id, string Description);

        record Developer(int Id, string Name, int? ProjectId);

        private Project[] projects = [
                    new Project(1, "CPQ"),
                    new Project (2, "Azure Middleware")
             ];


        private Developer[] developers = [
              new Developer (Id: 1, Name:"Dev1", ProjectId: 1),
              new Developer (Id: 2, Name:"Dev2", ProjectId: 1),
              new Developer (Id: 3, Name:"Dev3", ProjectId: 2),
              new Developer (Id: 4, Name:"Dev4", ProjectId: null)
            ];

        internal void Run()
        {
            InnerJoinTuples();
            Console.WriteLine();
            LeftJoinTuples();
        }


        private void InnerJoinTuples()
        {
            var result = developers.Join(
                projects,
                dev => dev.ProjectId,
                proj => proj.Id);

            foreach (var (dev, proj) in result)
            {
                Console.WriteLine($"{dev.Name} works on {proj.Description}");
            }
        }

        private void LeftJoinTuples()
        {
            var result = developers.LeftJoin(
                projects,
                dev => dev.ProjectId,
                proj => proj.Id);

            foreach (var (dev, proj) in result)
            {
                Console.WriteLine($"{dev.Name} works on {proj?.Description ?? "NO PROJECT"}");
            }
        }

    }


}
