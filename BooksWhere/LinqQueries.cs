using System.Text.Json; // Para usar el JsonSerializer

public class LinqQueries
{
    private List<Book> booksCollection = new List<Book>();
    public LinqQueries()
    {
        using(StreamReader reader = new StreamReader("books.json"))
        {
            // Guarda todo el archivo books.json en la variable
            string json = reader.ReadToEnd(); 

            //Deserializamos el JSON y le indicamos que esta en lower camelcase
            booksCollection = JsonSerializer.Deserialize<List<Book>>
                (json, new JsonSerializerOptions(){PropertyNameCaseInsensitive = true });
        }
    }

    public IEnumerable<Book> AllBooks()
    {
        return booksCollection;
    }

    public IEnumerable<Book> BooksAfterYear(int year)
    {
        //Extension method
        //return booksCollection.Where(p => p.PublishedDate.Year > year);

        //Query expresion
        return from l in booksCollection where l.PublishedDate.Year > year select l;
    }

    public IEnumerable<Book> FilterByPagesAndWords(int pages, string word)
    {
        //Extension method
        //return booksCollection.Where(p => p.PageCount > pages && p.Title.Contains(word));
        
        //Query expresion
        return from l in booksCollection where l.PageCount > pages && l.Title.Contains(word) select l;
    }

    public bool AllBooksHasStatus()
    {
        return booksCollection.All(p => p.Status != string.Empty);
    }

    public bool AnyBookIsFromYear(int year)
    {
        return booksCollection.Any(p => p.PublishedDate.Year == year);
    }

    public IEnumerable<Book> ContainString(string word)
    {
        return booksCollection.Where(p => p.Categories.Contains(word));
    }

    public IEnumerable<Book> ContainStringOrderByName(string word)
    {
        return booksCollection.Where(p => p.Categories.Contains(word)).OrderBy(p => p.Title);
    }

    public IEnumerable<Book> MoreThanPagesDescending(int pages)
    {
        return booksCollection.Where(p => p.PageCount > pages).OrderByDescending(p => p.PageCount);
    }

    public IEnumerable<Book> TopThreeBooksOrderByDate(string word)
    {
        // return booksCollection
        //     .Where(P => P.Categories.Contains(word))
        //     .OrderByDescending(p => p.PublishedDate)
        //     .Take(3);

        return booksCollection
            .Where(P => P.Categories.Contains(word))
            .OrderBy(p => p.PublishedDate)
            .TakeLast(3);
    }

    public IEnumerable<Book> SkipBooks(int pages)
    {
        return  booksCollection
            .Where(p => p.PageCount > pages)
            .Take(4)
            .Skip(2);
    }

    public IEnumerable<Book> TresPrimerosLibrosDeLaCollecion()
    {
        return booksCollection.Take(3).Select(p => new Book() { Title = p.Title, PageCount = p.PageCount});
    }

    public int RetoCount() // Con LongCount devuelve long
    {
        return booksCollection.Count(p => p.PageCount > 199 && p.PageCount < 501);
    }

    public DateTime MinDateTime()
    {
        return booksCollection.Min(p => p.PublishedDate);
    }

    public DateTime MaxDateTime()
    {
        return booksCollection.Max(p => p.PublishedDate);
    }

    public Book LibroConMenorNumeroDePaginas()
    {
        return booksCollection.Where(p => p.PageCount > 0).MinBy(p => p.PageCount);
    }

    //Max nos devolveria la fecha pero con MaxBy con devuelve el objeto (libro)
    public Book LibroConFechaMasReciente()
    {
        return booksCollection.MaxBy(p => p.PublishedDate);
    }

    public int SumPagesBetweenRange(int minRange, int maxRange)
    {
        return booksCollection.Where(p => p.PageCount >= minRange && p.PageCount <= maxRange).Sum(p => p.PageCount);
    }

    public string TitleOfBooksAfterYearConcatenate(int year)
    {
        return booksCollection
               .Where(p => p.PublishedDate.Year > year)
               .Aggregate("", (TitulosLibros, next) =>
               {
                    if(TitulosLibros != string.Empty)
                        TitulosLibros += " - " + next.Title;
                    else
                        TitulosLibros += next.Title;

                    return TitulosLibros;
               });
    }

    public double AverageTitleChars()
    {
        return booksCollection.Average(p => p.Title.Length);
    }

    public IEnumerable<IGrouping<int, Book>> BooksAfterYearGroupByYear(int year)
    {
        return booksCollection.Where(p => p.PublishedDate.Year >= year).GroupBy(p => p.PublishedDate.Year);
    }

    public ILookup<char, Book> GetDictionaryByLetter()
    {
        return booksCollection.ToLookup(p => p.Title[0], p => p);
    }

    public IEnumerable<Book> JoinBooks(int pages, int year)
    {
        var booksMoreThanPages = booksCollection.Where(p => p.PageCount > pages);
        var booksAfterYear = booksCollection.Where(p => p.PublishedDate.Year > year);

        return booksMoreThanPages.Join(booksAfterYear, p => p.Title, x => x.Title, (p,x) => p);
    }
}