using DALReverse;
using System.Linq;
namespace BALReverse
{
    public class ReverseList
    {
        public List<String> ReverseName()
        {
            Students s=new Students();
            List<string> names=s.GetData();
            List<string> reversed=new List<string>();
            foreach(string name in names)
            {
                
                string revName = new string(name.Reverse().ToArray());
                reversed.Add(revName);
            }
            return reversed;
        }

    }
}
