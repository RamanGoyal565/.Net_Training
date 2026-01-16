using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
namespace MiniSocialMedia
{
    class Program
    {
        private static Repository<User> _users = new();
        private static User? _currentUser;
        private static readonly string _dataFile = "social-data.json";
        static void Main()
        {
            Console.Title = "MiniSocial - Console Edition";
            Console.WriteLine("=== MiniSocial ===");

            LoadData();

            while (true)
            {
                try
                {
                    if (_currentUser == null)
                        ShowLoginMenu();
                    else
                        ShowMainMenu();
                }
                catch (SocialException ex)
                {
                    ConsoleColorWrite(ConsoleColor.Red, $"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unexpected Error!!");
                    Console.WriteLine(ex.Message);
                    LogError(ex);
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
        static void ShowLoginMenu()
        {
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("0. Exit");
            Console.Write("Choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": Register(); break;
                case "2": Login(); break;
                case "0":
                    SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        static void Register()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            if(_users.Find(u =>string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase))
            !=null)
            {
                Console.WriteLine("User already exist");
                return;
            }
            User user = new User(username, email);
            _users.Add(user);
            Console.WriteLine($"Welcome, {user.ToString()}!");
        }
        static void Login()
        {
            Console.Write("Username: ");
            string username = Console.ReadLine();
            User? user = _users.Find(u =>
                string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
                throw new SocialException("User not found");
            _currentUser = user;
            _currentUser.OnNewPost += PostNotification;
            Console.WriteLine($"Logged in as {_currentUser.ToString()}!");
        }
        static void ShowMainMenu()
        {
            Console.WriteLine($"Logged in as {_currentUser}");
            Console.WriteLine("1. Post message");
            Console.WriteLine("2. View my posts");
            Console.WriteLine("3. View timeline");
            Console.WriteLine("4. Follow user");
            Console.WriteLine("5. List users");
            Console.WriteLine("6. Logout");
            Console.WriteLine("0. Exit and save");

            Console.Write("Choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": PostMessage(); break;
                case "2": ShowPosts(_currentUser!.GetPosts()); break;
                case "3": ShowTimeline(); break;
                case "4": FollowUser(); break;
                case "5": ListUsers(); break;
                case "6":
                    _currentUser = null;
                    Console.WriteLine("Logged out.");
                    break;
                case "0":
                    SaveData();
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
        static void PostMessage()
        {
            if (_currentUser == null)
                return;
            Console.WriteLine("Write your post (max 280 characters):");
            var content = Console.ReadLine();
            _currentUser.AddPost(content); 
            Console.WriteLine("Post added successfully.");
        }
        static void ShowTimeline()
        {
            if (_currentUser == null)
                return;
            List<Post> timeline = new List<Post>();
            timeline.AddRange(_currentUser.GetPosts());
            foreach (var name in _currentUser.GetFollowingNames())
            {
                User user = _users.Find(u =>
                    string.Equals(u.Username, name, StringComparison.OrdinalIgnoreCase));
                if (user != null)
                    timeline.AddRange(user.GetPosts());
            }
            var ordered = timeline.OrderByDescending(p => p.CreatedAt).Take(20);
            Console.WriteLine("=== Your Timeline ===");
            ShowPosts(ordered);
        }
        private static void ShowPosts(IEnumerable<Post> posts)
        {
            int count = 0;
            foreach (var post in posts)
            {
                Console.WriteLine(post.ToString());
                Console.WriteLine(post.CreatedAt.FormatTimeAgo());
                Console.WriteLine(new string('-', 40));
                count++;
            }
            if (count == 0)
                Console.WriteLine("No posts yet.");
        }
        static void FollowUser()
        {
            if (_currentUser == null)
                return;
            Console.Write("Enter username to follow: ");
            string name = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(name))
            Console.WriteLine("Cancelled");
            User user = _users.Find(u =>
                string.Equals(u.Username, name, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {    
                Console.WriteLine("User not found");
                return;
            }
            _currentUser.Follow(name);
            Console.WriteLine($"Now following @{name}");
        }
        static void ListUsers()
        {
            foreach (var user in _users.GetAll().OrderBy(u => u))
                Console.WriteLine(user.GetDisplayName());
        }
        static void SaveData()
        {
            try
            {
                var dataToSave = _users.GetAll().Select(u => new
                {
                    Username = u.Username,
                    Email = u.Email,
                    Following = u.GetFollowingNames().ToList(),
                    Posts = u.GetPosts().Select(p => new
                    {
                        Content = p.Content,
                        CreatedAt = p.CreatedAt
                    }).ToList()
                }).ToList();
                var options = new JsonSerializerOptions{WriteIndented = true};
                string json = JsonSerializer.Serialize(dataToSave, options);
                File.WriteAllText(_dataFile, json);
                Console.WriteLine("Data saved.");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to save data.");
            }
        }
        static void LoadData()
        {
            try
            {
                if (!File.Exists(_dataFile))
                    return;
                string json = File.ReadAllText(_dataFile);
                using JsonDocument document = JsonDocument.Parse(json);
                foreach (var userElement in document.RootElement.EnumerateArray())
                {
                    string username = userElement.GetProperty("Username").GetString()!;
                    string email = userElement.GetProperty("Email").GetString();
                    var user = new User(username, email);
                    if (userElement.TryGetProperty("Following", out var following))
                    {
                        foreach (var f in following.EnumerateArray())
                        {
                            user.Follow(f.GetString()!);
                        }
                    }
                    if (userElement.TryGetProperty("Posts", out var posts))
                    {
                        foreach (var p in posts.EnumerateArray())
                        {
                            string content = p.GetProperty("Content").GetString();
                            DateTime createdAt = p.GetProperty("CreatedAt").GetDateTime();
                            var post = new Post(user, content, createdAt);
                            user.AddLoadedPost(post);
                        }
                    }
                    _users.Add(user);
                }
                Console.WriteLine("Data loaded");
            }
            catch (Exception ex)
            {
                LogError(ex);
                Console.WriteLine("Failed to load data.");
            }
        }
        static void LogError(Exception ex)
        {
            try
            {
                File.AppendAllText("error.log",
                    $"{DateTime.Now}\n{ex.Message}\n{ex.StackTrace}\n\n");
            }
            catch { }
        }
        static void ConsoleColorWrite(ConsoleColor color, string message)
        {
            var old = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ForegroundColor = old;
        }
        static void PostNotification(Post post)
        {
            ConsoleColorWrite(ConsoleColor.Cyan,
                $"New post by {post.Author}: " +
                $"{(post.Content.Length > 40 ? post.Content[..40] + "..." : post.Content)}");
        }
    }
}