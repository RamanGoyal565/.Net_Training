interface IGear
{
    void FirstGear();
    void SecondGear();
    void ThirdGear();
    void FourthGear();
    void FifthGear();
    void SixthGear();
}
abstract class Features
{
    public abstract void FirstGear();
    public abstract void SecondGear();
    public abstract void ThirdGear();
    public virtual void AudioSystem(){}
    public virtual void ReverseCamera(){}
}
class Car2 : Features
{
    public override void FirstGear()
    {
        Console.WriteLine("First Gear");
    }
    public override void SecondGear()
    {
        Console.WriteLine("Second Gear");
    }    
    public override void ThirdGear()
    {
        Console.WriteLine("Third Gear");
    }
    public override void ReverseCamera()
    {
        Console.WriteLine("Reverse Camera");
    }
    public static void main(){
        Car2 obj=new Car2();
        obj.FirstGear();
        obj.SecondGear();
        obj.ThirdGear();
        obj.ReverseCamera();
    }
}
class Car : IGear
{
    public void FirstGear()
    {
        Console.WriteLine("First Gear");
    }
    public void SecondGear()
    {
        Console.WriteLine("Second Gear");
    }    
    public void ThirdGear()
    {
        Console.WriteLine("Third Gear");
    }
    public void FourthGear()
    {
        Console.WriteLine("Fourth Gear");
    }
    public void FifthGear()
    {
        Console.WriteLine("Fifth Gear");
    }
    public void SixthGear()
    {
        Console.WriteLine("Sixth Gear");
    }
    public static void main()
    {
        Car obj=new Car();
        obj.FirstGear();
        obj.SecondGear();
        obj.ThirdGear();
        obj.FourthGear();
        obj.FifthGear();
        obj.SixthGear();
    }
}