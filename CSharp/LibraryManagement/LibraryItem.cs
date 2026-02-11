namespace LibrarySystem
{
    enum UserRole
    {
        Admin,
        Librarian,
        Member
    };
    enum ItemStatus
    {
        Available,
        Borrowed,
        Reserved,
        Lost
    };
    abstract class LibraryItem
    {
        public string Title
        {
            get;
            set;
        }
        public string Author
        {
            get;
            set;
        }
        public int ItemID
        {
            get;
            set;
        }
        public abstract void Display();
        public abstract double LateFee(int days); 
    }
    interface IReservable
    {
        void Reserve();
    }
    interface INotifiable
    {
        void Notify(string msg);
    }
}