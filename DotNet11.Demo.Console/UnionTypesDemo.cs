namespace DotNet11.Demo.ConsoleApp
{
    internal class UnionTypesDemo
    {
        internal void Run()
        {
            Console.WriteLine("UnionTypes Demo");
            Console.WriteLine("----------------");
            Console.WriteLine("Creating a new post");

            var post = CreatePost("Lorem Ipsum");
            var result = post switch
            {
                PostCreationSuccess success => $"Created with Id:{success.PostCreated.Id}",
                PostCreationPending pending => $"Pending: {pending.Message}",
                PostCreationError error => $"Error: {error.Message}"
            };

            Console.WriteLine(result);
            Console.WriteLine("----------------");
        }

        private PostCreationResult CreatePost(string content)
        {
            var random = Random.Shared.NextSingle();
            if (random < 0.33) return new PostCreationSuccess(new Post(Id: Random.Shared.NextInteger<int>(), Content: content));
            else if (random < 0.66) return new PostCreationPending(Message: "Pending for some reason");
            else return new PostCreationError(Message: "Error creating the post");
        }
    }

    internal record Post(int Id, string Content);
    
    internal record PostCreationSuccess(Post PostCreated);

    internal record PostCreationPending(string Message);
    
    internal record PostCreationError(string Message);


    internal union PostCreationResult(PostCreationSuccess, PostCreationPending, PostCreationError);
}
