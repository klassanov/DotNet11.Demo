
using System.Text;
using System.Text.Json;

namespace DotNet11.Demo.ConsoleApp.Demos
{
    //NOT RELATED TO .NET 11, JUST TESTING A LINQ QUERY

    internal class AdobeOpenAcquisitionsDemo
    {
        private static readonly OpenAcquisition acquisition = new OpenAcquisition("RessellerId", "CustomerId",
            [
                //Ref-1 items
                new OpenAcquisitionItem("Ref-1", "Prod-1", 5),
                new OpenAcquisitionItem("Ref-1", "Prod-2", 10),
                new OpenAcquisitionItem("ref-1", "Prod-2", 10),

                //Ref-2 items
                new OpenAcquisitionItem("Ref-2", "Prod-3", 15),
                new OpenAcquisitionItem("Ref-2", "Prod-4", 25),
                
                //Ref-3 items
                new OpenAcquisitionItem("Ref-3", "Prod-5", 35),
                new OpenAcquisitionItem("Ref-3", "Prod-1", 45),
                new OpenAcquisitionItem("Ref-3", "Prod-7", 50),
            ]);

        internal static void Run()
        {
            //Console.WriteLine("Aggregate Groups");
            //Console.WriteLine();
            //SliceByReferenceId();
            //Console.WriteLine();
            //Console.WriteLine("------------------------------------");
            //CreateMessages();

            Console.WriteLine("Before");
            PrintJson(acquisition);

            Console.WriteLine("-------------------------------------------------------------");

            var after = PartitionAcquisitionByReferenceId();
            Console.WriteLine("After");
            foreach (var a in after)
            {
                PrintJson(a);
                Console.WriteLine();
            }
        }

        private static void SliceByReferenceId()
        {
            IEnumerable<KeyValuePair<string, OpenAcquisitionItem[]>> referenceIdGroups = acquisition.Items.AggregateBy<OpenAcquisitionItem, string, OpenAcquisitionItem[]>(
                keySelector: item => item.ReferenceId,
                seed: [],
                func: (group, item) => [.. group, item]
             );


            foreach (KeyValuePair<string, OpenAcquisitionItem[]> referenceIdGroup in referenceIdGroups)
            {
                Console.WriteLine($"Items with referenceId {referenceIdGroup.Key}");
                foreach (OpenAcquisitionItem openAcquisitionItem in referenceIdGroup.Value)
                {
                    Console.WriteLine(openAcquisitionItem);
                }

                Console.WriteLine();
            }
        }

        private static void CreateMessages()
        {
            IEnumerable<KeyValuePair<string, OpenAcquisitionItem[]>> referenceIdGroups = acquisition.Items.AggregateBy<OpenAcquisitionItem, string, OpenAcquisitionItem[]>(
                keySelector: item => item.ReferenceId,
                seed: [],
                func: (group, item) => [.. group, item],
                keyComparer: StringComparer.OrdinalIgnoreCase
             );

           var messages = referenceIdGroups.Select(refIdGroup => new OpenAcquisition(acquisition.ResellerId, acquisition.CustomerId, refIdGroup.Value));

            foreach (var msg in messages)
            {
                Console.WriteLine(msg);
                Console.WriteLine("Items");
                foreach(var item in msg.Items)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();
            }
        }


        private static IEnumerable<OpenAcquisition> PartitionAcquisitionByReferenceId()
        {
            return acquisition.Items
                .AggregateBy<OpenAcquisitionItem, string, OpenAcquisitionItem[]>(
                    keySelector: item => item.ReferenceId,
                    seed: [],
                    func: (group, item) => [.. group, item],
                    keyComparer: StringComparer.OrdinalIgnoreCase
                )
                .Select(group => new OpenAcquisition(
                    acquisition.ResellerId,
                    acquisition.CustomerId,
                    group.Value
                ));
        }

        private static void PrintPartitionedAcquisitions(IEnumerable<OpenAcquisition> openAcquisitions)
        {
            foreach (var message in openAcquisitions)
            {
                Console.WriteLine($"Partitioned Message - ReferenceId: {message.Items.First().ReferenceId}");
                Console.WriteLine($"  ResellerId: {message.ResellerId}, CustomerId: {message.CustomerId}");
                Console.WriteLine($"  Items Count: {message.Items.Length}");
                foreach (var item in message.Items)
                {
                    Console.WriteLine($"    {item}");
                }
                Console.WriteLine();
            }
        }

        private static void PrintJson<T>(T obj)
        {
            Console.WriteLine(JsonSerializer.Serialize<T>(obj, new JsonSerializerOptions { WriteIndented = true }));
        }
    }

    public record OpenAcquisition(string ResellerId, string CustomerId, OpenAcquisitionItem[] Items);

    public record OpenAcquisitionItem(string ReferenceId, string ProductName, int Quantity);
}
