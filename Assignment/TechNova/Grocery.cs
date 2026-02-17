namespace Inventory_Management_System
{
    class Grocery : Product
    {
        public DateTime ExpiryDate { get; set; }
        public double Weight { get; set; }
        public bool IsOrganic { get; set; }
        public int StorageTemperature { get; set; }

        public override void Verify()
        {
            if(ExpiryDate<DateTime.Now)
            {
                throw new Exception("Invalid Expiry Date");
            }
            if(Weight<0)
            {
                throw new Exception("Weight Cannot be 0");
            }
        }
    }
}