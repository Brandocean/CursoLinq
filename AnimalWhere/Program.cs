using System;
using System.Collections.Generic;
using System.Linq;

class Program {
  public static void Main (string[] args) {

    List<Animal> animales = new List<Animal>();
    animales.Add(new Animal() { Nombre = "Hormiga", Color = "Rojo" });
    animales.Add(new Animal() { Nombre = "Lobo", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Elefante", Color = "Gris" });
    animales.Add(new Animal() { Nombre = "Pantegra", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Gato", Color = "Negro" });
    animales.Add(new Animal() { Nombre = "Iguana", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Sapo", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Camaleon", Color = "Verde" });
    animales.Add(new Animal() { Nombre = "Gallina", Color = "Blanco" });

    // Escribe tu código aquí

    // filtra todos los animales que sean de color verde que su nombre inicie con una vocal
    // List<char> vocales = new List<char>() {'a', 'e', 'i', 'o', 'u'};
    // List<Animal> animalesVerdes = animales.Where(p => p.Color == "Verde" && vocales.Contains(p.Nombre.ToLower()[0])).ToList();
    // animalesVerdes.ForEach(p => Console.WriteLine($"Nombre: {p.Nombre}, Color: {p.Color}"));

    // Retorna los elementos de la colleción animal ordenados por nombre
    // List<Animal> animalesOrdenados = animales.OrderBy(p => p.Nombre).ToList();
    // animalesOrdenados.ForEach(p => Console.WriteLine($"Nombre: {p.Nombre}, Color: {p.Color}"));

    // Retorna los datos de la colleción Animales agrupada por color 
    IEnumerable<IGrouping<string, Animal>> animalesAgrupadosColor = animales.GroupBy(p => p.Color);
    foreach(var grupo in animalesAgrupadosColor){

      Console.WriteLine($"\nGrupo: {grupo.Key}");

      foreach(var animal in grupo)
      {
        Console.WriteLine($"Nombre: {animal.Nombre}, Color: {animal.Color}");
      }
      
    }

  }

  public class Animal
  {
    public string Nombre {get;set;}
    public string Color {get;set;}
  }
}