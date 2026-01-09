class _54_User{
    public int Id;
    public string Name;
}


class _54_Program
{
    public void Main(){
        _54_User user = new _54_User{
            Id = 123,
            Name = "Sandeep"
        };

         using(StreamWriter writer = new StreamWriter("Day14/_54_User.txt"))
        {
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);

            user.Id = 456;
            user.Name = "Manish";

            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);
        }


        
        using(StreamReader reader = new StreamReader("Day14/_54_User.txt"))
        {
            user.Id = int.Parse(reader.ReadLine());
            user.Name = reader.ReadLine();
        }
        Console.WriteLine($"User loaded ::>>  {user.Id},  {user.Name}");
        
    }    
}