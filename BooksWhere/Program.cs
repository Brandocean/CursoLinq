using System.Timers;

LinqQueries queries = new LinqQueries();

//Imprimir todos los libros
// PrintValues(queries.AllBooks());

//Imprimir los libros despues de cierto anio
// PrintValues(queries.BooksAfterYear(2000));

//Imprimir libros con mayor numero de paginas y en el titulo un string
// PrintValues(queries.FilterByPagesAndWords(250, "in Action"));

//Todos los libros tienen status?
// Console.WriteLine($"Todos los libros tienen status? = {queries.AllBooksHasStatus()}");

//Hay algun libro del 2005?
// Console.WriteLine($"Hay algun libro del 2005? = {queries.AnyBookIsFromYear(2005)}");

//Libros que tiene la categoria de python
// PrintValues(queries.ContainString("Python"));

//Libro que tiene la categoria de Java ordenados por titulo
// PrintValues(queries.ContainStringOrderByName("Java"));

//Libros con mas de un # de paginas ordenados por paginas de manera descendente
// PrintValues(queries.MoreThanPagesDescending(450));

// Los 3 libros de Java mas recientemente
// PrintValues(queries.TopThreeBooksOrderByDate("Java"));

//Tercer y cuarto libro con mas de 400 paginas
// PrintValues(queries.SkipBooks(400));

// Tres primeros libros filtrados con select
// PrintValues(queries.TresPrimerosLibrosDeLaCollecion());

// El numero de libros que tienen 200-500 paginas
// System.Console.WriteLine($"El numero de libros es: {queries.RetoCount()}");

// El minimo y el maximo en la fecha de publicacion
// System.Console.WriteLine($"La menor fecha de publicacion es: {queries.MinDateTime()}");
// System.Console.WriteLine($"La maxima fecha de publicacion es: {queries.MaxDateTime()}");

// Libro con menor numero de paginas
// var libroMenorPag = queries.LibroConMenorNumeroDePaginas();
// System.Console.WriteLine($"{libroMenorPag.Title} - {libroMenorPag.PageCount}");

// Libro con la fecha de publicacion mas reciente
// var libroFechaMax = queries.LibroConFechaMasReciente();
// System.Console.WriteLine($"{libroFechaMax.Title} - {libroFechaMax.PublishedDate}");

// Suma de paginas entre libros de 0 a 500 paginas
// System.Console.WriteLine($"La suma es: {queries.SumPagesBetweenRange(0,500)}");

//Libros publicados despues del 2015
// Console.WriteLine(queries.TitleOfBooksAfterYearConcatenate(2015));

// Promedio de caracteres de los titulos de los libros
// System.Console.WriteLine($"El promedio es: {queries.AverageTitleChars()}");

//Libros publicados despues del 2000 agrupados por año (groupby)
// ImprimirGrupo(queries.BooksAfterYearGroupByYear(2000));

//Diccionario de libros agrupado por la primera letra del titulo
// printDictionary(queries.GetDictionaryByLetter(), 'C');

// Libros con mas de 500 paginas publicados despues del 2005 usando join
PrintValues(queries.JoinBooks(500, 2005));

void PrintValues(IEnumerable<Book> books)
{
    Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", 
                        "Titulo", 
                        "N. Paginas", 
                        "Fecha publicacion");

    foreach(var item in books)
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}", 
                            item.Title, 
                            item.PageCount, 
                            item.PublishedDate.ToShortDateString());
    }
}

void ImprimirGrupo(IEnumerable<IGrouping<int,Book>> ListadeLibros)
{
    foreach(var grupo in ListadeLibros)
    {
        Console.WriteLine("");
        Console.WriteLine($"Grupo: { grupo.Key }");
        Console.WriteLine("{0,-60} {1, 15} {2, 15}\n", "Titulo", "N. Paginas", "Fecha publicacion");
        foreach(var item in grupo)
        {
            Console.WriteLine("{0,-60} {1, 15} {2, 15}",item.Title,item.PageCount,item.PublishedDate.Date.ToShortDateString()); 
        }
    }
}

void printDictionary(ILookup<char, Book> listBooks, char letter)
{
    char letterUpper = Char.ToUpper(letter);
    if (listBooks[letterUpper].Count() == 0)
    {
        Console.WriteLine($"No hay libros que inicien con la letra '{letterUpper}'");
    } 
    else 
    {
        Console.WriteLine("{0, -60} {1, 15} {2, 15}\n", "Título", "Nro. Páginas", "Fecha de Publicación");
        foreach (var book in listBooks[letterUpper])
        {
            Console.WriteLine("{0, -60} {1, 15} {2, 15}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }
}