using System;
using System.Reflection;

public class Source
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    // Add more properties as needed...
}

public class Destination
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    // Add more properties as needed...
}

public class PropertyMapper
{
    public static void MapProperties(Source source, Destination destination)
    {
        PropertyInfo[] sourceProperties = typeof(Source).GetProperties();
        PropertyInfo[] destinationProperties = typeof(Destination).GetProperties();

        foreach (var sourceProperty in sourceProperties)
        {
            foreach (var destinationProperty in destinationProperties)
            {
                if (sourceProperty.Name == destinationProperty.Name && sourceProperty.PropertyType == destinationProperty.PropertyType)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                    break;
                }
            }
        }
    }
}

class Program
{
    static void Main()
    {
        // Step 3: Test Dynamic Property Mapping

        // Create instances of Source and Destination classes
        Source source = new Source { Id = 1, Name = "SourceObject", Age = 25 };
        Destination destination = new Destination { Id = 6, Name = "DestinationObject", Description = "Destination Description" };

        // Call MapProperties method to map properties from Source to Destination
        PropertyMapper.MapProperties(source, destination);

        // Display mapped properties in Destination
        Console.WriteLine("Mapped Properties in Destination:");
        Console.WriteLine($"Id: {destination.Id}");
        Console.WriteLine($"Name: {destination.Name}");
        Console.WriteLine($"Description: {destination.Description}");
        // Add more properties of Destination as needed...

        Console.ReadKey();
    }
}
