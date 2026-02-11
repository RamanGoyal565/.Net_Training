// public class User
// {
//     public int Id{get;set;}
//     public int age{get;set;} 
//     public string Name{get;set;}
// }
class File_Program
{
    public static void main()
    {
        FileInfo file=new FileInfo("sample.txt");
        if (!file.Exists)
        {
            using (StreamWriter writer = file.CreateText())
            {
                writer.WriteLine("Hello FileInfo class");
            }
        }
        Console.WriteLine("File Name: "+file.Name);
        Console.WriteLine("File Size: "+file.Length);
        Console.WriteLine("Created on: "+file.CreationTime);
    }
 }