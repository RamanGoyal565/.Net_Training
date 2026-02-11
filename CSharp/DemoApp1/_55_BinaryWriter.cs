using System;
using System.IO;

class _55_User
{
    public int Id;
    public string Name;
}

class _55_Program
{
    public void Main()
    {
        _55_User user = new _55_User
        {
            Id = 123,
            Name = "Sandeep"
        };

        using (BinaryWriter writer = new BinaryWriter(File.Open("Day14/_55_user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
        }

        Console.WriteLine("Binary user data saved");

        _55_User readUser = new _55_User();

        using (BinaryReader reader = new BinaryReader(File.Open("Day14/_55_user.bin", FileMode.Open)))
        {
            readUser.Id = reader.ReadInt32();
            readUser.Name = reader.ReadString();
        }

        Console.WriteLine(readUser.Id);
        Console.WriteLine(readUser.Name);
    }
}
