class RealEstateListing
{
    public int ID{get;set;}
    public string Title{get;set;}
    public string Description{get;set;}
    public int Price{get;set;}
    public string Location{get;set;}
}
class RealEstateApp
{
    private List<RealEstateListing> _listings=new List<RealEstateListing>();
    public void AddListing(RealEstateListing listing)
    {
        _listings.Add(listing);
    }
    public void RemoveListing(int listingID)
    {
        _listings.Remove(_listings.Find(f=>f.ID==listingID));
    }
    public void UpdateListing(RealEstateListing listing)
    {
        if(listing==null)
        return;
        var update=_listings.Find(f=>f.ID==listing.ID);
        if(update==null)
        return;
        update.Title=listing.Title;
        update.Description=listing.Description;
        update.Price=listing.Price;
        update.Location=listing.Location;
    }
    public List<RealEstateListing> GetListings()
    {
        return _listings;
    }
    public List<RealEstateListing> GetListingByLocation(string location)
    {
        List<RealEstateListing> list=new List<RealEstateListing>();
        foreach(var listing in _listings)
        {
            if(string.Equals(film.Location,location))
                list.Add(listing);
        }
        return list;
    }
    
}