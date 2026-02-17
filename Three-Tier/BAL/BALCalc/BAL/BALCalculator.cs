using DALCalc;
namespace BALCalc
{
    public class BALCalculator { 
        public int BALAdd(int a, int b)
        {
            DALCalculator d = new DALCalculator();
            return d.DalAdd(a, b)-1;
        }
    }
}
