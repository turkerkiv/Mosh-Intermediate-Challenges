using System;

namespace ConsoleApp2
{
    public class Post
    {
        public int VoteCount { get; private set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; private set; }

        public Post()
        {
            DateCreated = DateTime.Now;
        }

        public void UpVote()
        {
            VoteCount++;
        }
        public void DownVote()
        {
            VoteCount--;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Post NewPost1 = new Post();

            Console.Write("Enter a title: ");
            NewPost1.Title = Console.ReadLine();

            Console.Write("Enter Description: ");
            NewPost1.Description = Console.ReadLine();

            //Votes can depend on a button or something
            NewPost1.UpVote();
            NewPost1.UpVote();
            NewPost1.DownVote();
            NewPost1.DownVote();
            NewPost1.DownVote();

            Console.WriteLine("Votes: " + NewPost1.VoteCount + "\nTitle: " + NewPost1.Title + "\nDescription: " + NewPost1.Description + "\nCreated at: " + NewPost1.DateCreated);

        }
    }
}
