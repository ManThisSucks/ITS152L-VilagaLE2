using BlogDataLibrary.Database;
using BlogDataLibrary.Data;
using Microsoft.Extensions.Configuration;
using BlogDataLibrary.Models;

namespace BlogTestUI
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            SqlData db = GetConnection();

            DoCustomOption(db);

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }

        private static void DoCustomOption(SqlData db)
        {
            char? option;

            do
            {
                Console.Write("Would you like to [R]egister, [A]dd post, [V]iew post, or [E]xit?\n>>>");
                option = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                switch (option)
                {
                    case 'R':
                        Register(db);
                        break;
                    case 'A':
                        AddPost(db);
                        break;
                    case 'V':
                        ShowPostDetails(db);
                        break;
                    case 'E':
                        break;
                    default:
                        option = null;
                        break;
                }
                Console.WriteLine("\n---\n");
            } while (option != 'E');
        }

        public static void Authenticate(SqlData db)
        {
            UserModel user = GetCurrentUser(db);

            if (user == null)
            {
                Console.WriteLine("Invalid credentials");
            }
            else
            {
                 Console.WriteLine($"Welcome, {user.UserName}");
            }
        }

        private static UserModel GetCurrentUser(SqlData db)
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();

            Console.Write("Password: ");
            string password = Console.ReadLine();

            UserModel user = db.Authenticate(username, password);

            return user;
        }

        static SqlData GetConnection()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            IConfiguration config = builder.Build();
            ISqlDataAccess dbAccess = new SqlDataAccess(config);
            SqlData db = new SqlData(dbAccess);

            return db;
        }

        public static void Register(SqlData db)
        {
            Console.Write("Enter new username: ");
            var username = Console.ReadLine();

            Console.Write("Enter new password: ");
            var password = Console.ReadLine();

            Console.Write("Enter first name: ");
            var firstname = Console.ReadLine();

            Console.Write("Enter last name: ");
            var lastName = Console.ReadLine();

            db.Register(username, firstname, lastName, password);
        }

        public static void AddPost(SqlData db)
        {
            UserModel user = GetCurrentUser(db);

            Console.Write("Title: ");
            string title = Console.ReadLine();

            Console.WriteLine("Write Body: ");
            string body = Console.ReadLine();

            PostModel post = new PostModel
            {
                Title = title,
                Body = body,
                DateCreated = DateTime.Now,
                UserId = user.Id
            };

            db.AddPost(post);
        }

        public static void ShowPostDetails(SqlData db)
        {
            Console.Write("Enter a post ID: ");
            int id = Int32.Parse(Console.ReadLine());

            ListPostModel post = db.ShowPostDetails(id);
            Console.WriteLine(post.Title);
            Console.WriteLine($"by {post.FirstName} {post.LastName} [{post.UserName}]");

            Console.WriteLine();

            Console.WriteLine(post.Body); 

            Console.WriteLine(post.DateCreated.ToString("MMM d yyyy"));
        }
    }
}
