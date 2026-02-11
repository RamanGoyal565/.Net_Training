public interface IFilm
{
    string Title { get; set; }
    string Director { get; set; }
    int Year { get; set; }
}
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}
class Film : IFilm
{
    public string Title{get;set;}
    public string Director{get;set;} 
    public int Year{get;set;}
    public override string ToString()
    {
        return $"{Title} ({Year}), Director: {Director}";
    }
}
class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films=new List<IFilm>();
    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }
    public void RemoveFilm(string title)
    {
        _films.Remove(_films.Find(f=>string.Equals(f.Title,title)));
    }
    public List<IFilm> GetFilms()
    {
        return _films;
    }
    public List<IFilm> SearchFilms(string querry)
    {
        List<IFilm> list=new List<IFilm>();
        foreach(var film in _films)
        {
            if(film.Title.Contains(querry)||film.Director.Contains(querry))
                list.Add(film);
        }
        return list;
    }
    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}
class MovieLibrary
{
    public static void main()
    {
        IFilmLibrary library = new FilmLibrary();
        library.AddFilm(new Film{Title="Inception", Director="Christopher Nolan", Year=2010});
        library.AddFilm(new Film{Title="Interstellar Nolan",Director= "Christopher", Year=2014});
        library.AddFilm(new Film{Title="Pulp Fiction",Director="Quentin Tarantino",Year=1994});
        Console.WriteLine("All Films:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine(film);
        }
        Console.WriteLine("\nSearch Results for 'Nolan':");
        foreach (var film in library.SearchFilms("Nolan"))
        {
            Console.WriteLine(film);
        }
        library.RemoveFilm("Pulp Fiction");
        Console.WriteLine("\nAfter Removing Pulp Fiction:");
        foreach (var film in library.GetFilms())
        {
            Console.WriteLine(film);
        }
        Console.WriteLine($"\nTotal Films: {library.GetTotalFilmCount()}");
    }
}