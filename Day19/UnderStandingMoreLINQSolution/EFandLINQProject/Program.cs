using EFandLINQProject.Model;
using System;
using System.Linq;

namespace EFandLINQProject
{
    class Program
    {
        PostRepo postRepo;
        CommentRepo commentRepo;
        TweetContext context;
        public Program()
        {
            context = new TweetContext();
            commentRepo = new CommentRepo(context);
            postRepo = new PostRepo(context);
        }
        void PrintPostWithComments()
        {
            //select postid,posttext,commentid,commenttext from post p join comment c on p.id=c.postid
            //group by postid
            var postWiseComment = context.Comments.ToList().GroupBy(c => c.PostId);
            foreach (var postcomment in postWiseComment)
            {
                int id = postcomment.Key;
                Posts posts = postRepo.Get(id);
                PrintPost(posts);
                Console.WriteLine("Comment for this post");
                foreach (var Comment in postcomment)
                {
                    PrintComment(Comment);
                }
                Console.WriteLine("------------------------------------");
            }
        }
        void PrintComment(Comments comment)
        {
            Console.WriteLine("Comment id "+comment.Id);
            Console.WriteLine(comment.CommentText);
        }
        void AddPost()
        {
            Console.WriteLine("Please Enter the Post Category:");
            string category = Console.ReadLine();
            Console.WriteLine("Please enter the Post Text:");
            string text = Console.ReadLine();
            Posts posts = new Posts();
            posts.Category = category;
            posts.PostText = text;
            if(postRepo.Add(posts))
                Console.WriteLine("The Post is Posted");
            else
                Console.WriteLine("Could not Post");
        }
        void AddPosts()
        {
            int choice = 0;
            do
            {
                AddPost();
                Console.WriteLine("Do You wise to add Another Post?? if yes enter any number other than 0.To Exit enter 0.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Not a Correct input");
                }
            } while (choice != 0);
        }
        void PrintPosts()
        {
            var Posts = postRepo.GetAll();
            if(Posts!=null)
                foreach (var item in Posts.ToList())
                {
                    PrintPost(item);
                }
        }
        void PrintPost(Posts posts)
        {
            Console.WriteLine("-------------------------");
            Console.WriteLine("Post_Id: "+posts.Id);
            Console.WriteLine("Post_Category: " + posts.Category);
            Console.WriteLine("Post: " + posts.PostText);
            Console.WriteLine("-------------------------");
        }
        void AddComment()
        {
            PrintPosts();
            int id = 0;
            Console.WriteLine("Please Enter the ID for Which You Want to Comment:");
            id = Convert.ToInt32(Console.ReadLine());
            Posts posts = postRepo.Get(id);
            if (posts != null)
            {
                PrintPost(posts);
                Comments comments = TakeComment(id);
                if (commentRepo.Add(comments))
                    Console.WriteLine("Comment Updated");
            }
        }
        void UpdatePost()
        {
            PrintPosts();
            int id = 0;
            Console.WriteLine("Please Enter the Post ID to Update:");
            id = Convert.ToInt32(Console.ReadLine());
            Posts posts = postRepo.Get(id);
            if (posts != null)
            {
                Console.WriteLine("Please Enter the New Post Text:");
                string text = Console.ReadLine();
                posts.PostText = posts.PostText+" "+text;
                if (postRepo.Update(posts))
                    Console.WriteLine("The Post is Posted");
                else
                    Console.WriteLine("Could not Post");
            }
            else
            {
                Console.WriteLine("No such posts");
            }
        }
        private Comments TakeComment(int pid)
        {
            Comments comments = new Comments();
            comments.PostId = pid;
            Console.WriteLine("Please Enter the Comment");
            comments.CommentText = Console.ReadLine();
            return comments;
        }
        void UserInterface()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Twitter Menu");
                Console.WriteLine("1. Add Post");
                Console.WriteLine("2. Add List of Posts");
                Console.WriteLine("3. Add Comment For Post");
                Console.WriteLine("4. View All Post");
                Console.WriteLine("5. View PostWithComment");
                Console.WriteLine("6. Update Posts");
                Console.WriteLine("7. Exit..");
                Console.WriteLine("Please Enter the Choice:");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddPost();
                        break;
                    case 2:
                        AddPosts();
                        break;
                    case 3:
                        AddComment();
                        break;
                    case 4:
                        PrintPosts();
                        break;
                    case 5:
                        PrintPostWithComments();
                        break;
                    case 6:
                        UpdatePost();
                        break;
                    case 7:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice!=7);
        }
        static void Main(string[] args)
        {
            new Program().UserInterface();
        }
    }
}
