class PolicyDirectory
{
    Dictionary<int,string> policyList=new Dictionary<int, string>();
    public string this[int id]
    {
        get
        {
            return policyList.ContainsKey(id)?policyList[id]:"Policy Not Found";
        }
        set
        {
            policyList[id]=value;
        }
    }
    public int this[string name]
    {
        get
        {
            return policyList.FirstOrDefault(p=>p.Value==name).Key;
        }
    }
}