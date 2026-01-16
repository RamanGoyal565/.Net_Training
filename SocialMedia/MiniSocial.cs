using System.Text.RegularExpressions;
namespace MiniSocialMedia
{
    class SocialException:Exception
    {
        public SocialException(string message):base(message)
        { }
        public SocialException(string message,Exception inner):base(message, inner)
        { }
    }
    interface IPostable
    {
        public void AddPost(string content);
        public IReadOnlyList<Post> GetPosts();
    }
    public partial class User : IPostable, IComparable<User>
    {
        public string Username{get;init;}
        public string Email{get;init;}
        private List<Post> _posts;
        private HashSet<string> _following;
        public event Action<Post> OnNewPost;
        public User(string username,string email)
        {
            string pattern=@"^[\w.-]+@[\w-]+(\.[\w]{2,})+$";
            if(string.IsNullOrWhiteSpace(username))
                throw new ArgumentException("Username cannot be null, empty, or whitespace."+username);
            if(!Regex.IsMatch(email,pattern))
                throw new SocialException("Invalid email format");
            Username=username.Trim();
            Email=email.Trim().ToLower();
            _following=new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            _posts=new List<Post>();
        }
        public void Follow(string username)
        {
            if (string.Equals(username, Username, StringComparison.OrdinalIgnoreCase))
                throw new SocialException("Cannot follow yourself");
            _following.Add(username);
        }
        public bool IsFollowing(string username)=>_following.Contains(username);
        public void AddPost(string content)
        {
            if(string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("Post content cannot be empty");
            if(content.Length>280)
                throw new SocialException("Post too long (max 280 characters)");
            content=content.Trim();
            Post obj=new Post(this,content);
            _posts.Add(obj);
            OnNewPost?.Invoke(obj);
        }
        public IReadOnlyList<Post> GetPosts()
        {
            return _posts;
        }
        public int CompareTo(User? other)
        {
            if(other==null)
            return 1;
            return string.Compare(Username,other.Username, StringComparison.OrdinalIgnoreCase);
        }
        public override string ToString()
        {
            return $"@{Username}";
        }
    }
    public partial class User
    {
        public string GetDisplayName()
        {
            return $"User: {Username} <{Email}>";
        }
    }
    public class Post
    {
        public User Author{get;init;}
        public string Content{get;init;}
        public DateTime CreatedAt{get;}=DateTime.UtcNow;
        public Post(User author,string content)
        {
            if(author==null)
                throw new ArgumentException("Author cannot be null.");
            Author=author;
            Content=content;
        }
        public override string ToString()
        {
            string message=$"@{Author.Username}•{CreatedAt}\n{Content}";
            var hashtags = Regex.Matches(Content, @"#[A-Za-z]+");
            if (hashtags.Count == 0)
            return message;
            return message+"\nTags: "+string.Join(", ", hashtags.Cast<Match>().Select(m => m.Value));
        }
    }
    class Repository<T>where T:class
    {
        private readonly List<T> _items=new();
        public void Add(T item)=>_items.Add(item);
        public IReadOnlyList<T> GetAll()=>_items;
        public T? Find(Predicate<T> match) =>_items.Find(match);
    }
    static class SocialUtils
    {
        public static string FormatTimeAgo(this DateTime dateTime)
        {
            TimeSpan diff=DateTime.UtcNow-dateTime;
            if (diff.TotalMinutes < 1)
                return "just now";
            if (diff.TotalMinutes < 60)
            {
                int minutes = (int)diff.TotalMinutes;
                return $"{minutes} min ago";
            }
            if (diff.TotalHours < 24)
            {
                int hours = (int)diff.TotalHours;
                return $"{hours} h ago";
            }
            return dateTime.ToString("MMM dd");
        }
    }
}
namespace MiniSocialMedia
{
    public static class UserExtensions
    {
        public static IEnumerable<string> GetFollowingNames(this User user)
        {
            return user.GetType()
                       .GetField("_following",
                           System.Reflection.BindingFlags.NonPublic |
                           System.Reflection.BindingFlags.Instance)!
                       .GetValue(user) as IEnumerable<string>;
        }
    }
}
