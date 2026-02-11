namespace LibrarySystem.Items{
    class Book : LibraryItem,IReservable,INotifiable
    {
        public void Reserve()
        {
            Console.WriteLine($"Book reserved successfully");
        }
        public void Notify(string msg)
        {
            Console.WriteLine("Notification: "+msg);
        }
        void IReservable.Reserve()
        {
            Console.WriteLine($"Book reserved successfully");
        }
        void INotifiable.Notify(string msg)
        {
            Console.WriteLine("Notification: "+msg);
        }
        public override void Display()
        {
            Console.WriteLine("Tittle of book is: "+Title);
            Console.WriteLine("Author of Book is: "+Author);
            Console.WriteLine("ItemID of book is: "+ItemID);
        }
        public override double LateFee(int days)
        {
            double charge=days*1;
            return charge;
        }
    }
    class Magazine : LibraryItem
    {
        public override void Display()
        {
            Console.WriteLine("Tittle of Magazine is: "+Title);
            Console.WriteLine("Author of Magazine is: "+Author);
            Console.WriteLine("ItemID of Magazine is: "+ItemID);
        }
        public override double LateFee(int days)
        {
            double charge=days*0.5;
            return charge;
        }
    }
}
