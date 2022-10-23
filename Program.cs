namespace CompositePatternExampleNamespace
{
    // link to this tutorial :
    // https://www.youtube.com/watch?v=UsynwPeipb8
    /// <summary>
    /// Composite pattern is like 'matreshka' russian doll.
    /// It is like tree with many brunches. 
    /// Or is is like recursion.
    /// Author of this tutorial is using LINQpad 6 app
    /// for creating this example, and he is using 'Dump()'
    /// method which shows all components of this programm
    /// to be visualized, I can't make it.
    /// What is LINQPad used for?
    /// LINQPad is a software utility targeted at.NET 
    /// Framework and.NET Core development.It is used to 
    /// interactively query SQL databases(among other 
    /// data sources such as OData or WCF Data Services) 
    /// using LINQ, as well as interactively writing 
    /// C# code without the need for an IDE.
    /// ============================================
    /// Composite pattern is used where we need to treat a group 
    /// of objects in similar way as a single object. 
    /// Composite pattern composes objects in term of a tree
    /// structure to represent part as well as whole hierarchy.
    /// This type of design pattern comes under structural
    /// pattern as this pattern creates a tree structure of
    /// group of objects.
    /// This pattern creates a class that contains group of
    /// its own objects.This class provides ways to modify
    /// its group of same objects.
    /// ======================================================
    /// The Composite Pattern has four participants:
    /// ======================================================
    /// Component – Component declares the interface for 
    /// objects in the composition and for accessing and
    /// managing its child components. It also implements 
    /// default behavior for the interface common to all 
    /// classes as appropriate.
    /// ======================================================
    /// Leaf – Leaf defines behavior for primitive objects 
    /// in the composition. It represents leaf objects in 
    /// the composition.
    /// ======================================================
    /// Composite – Composite stores child components and 
    /// implements child related operations in the component 
    /// interface.
    /// ======================================================
    /// Client – Client manipulates the objects in the 
    /// composition through the component interface.
    /// ======================================================
    /// In an organization, It have general managers and under 
    /// general managers, there can be managers and under 
    /// managers there can be developers. Now you can set 
    /// a tree structure and ask each node to perform common 
    /// operation like getSalary().
    /// Composite design pattern treats each node in two ways:
    /// 1) Composite – Composite means it can have 
    /// other objects below it.
    /// 2) leaf – leaf means it has no objects below it.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //I don't have 'Dump()' here as shown in a tutorial
            //new Table().Dump();
            Table table = new Table();
            foreach (var component in table.Components)
            {
                Console.WriteLine("Table parts : ");
                Console.WriteLine(component.ToString());
            }
        }
    }
    /// <summary>
    /// It is 'public abstract class Product. 
    /// Sometimes instead of abstract we can use interfaces.
    /// It gives ability when we can inherit from multiple interfaces.
    /// I think this is the key part of this pattern :
    /// 'Product' class has 'List<Product>'
    /// </summary>
    public abstract class Product
    {
        public List<Product> Components { get; set; } = 
            new List<Product>();
    }
    public class Table : Product
    {
        public Table()
        {
            Components.Add(new Legs());
            Components.Add(new Top());
            Components.Add(new Screws());
        }
    }
    public class Top : Product { }
    public class Legs : Product
    {
        public Legs()
        {
            Components.Add(new Feet());
            Components.Add(new Padding());
            Components.Add(new Screws());
            foreach (var item in Components)
            {
                Console.WriteLine("Legs parts : ");
                Console.WriteLine(item.ToString());
            }
        }
    }
    public class Screws : Product { }
    public class Feet : Product { }
    /// <summary>
    /// Author said that he wants soft paddings 
    /// on the feet of the table, that he wants
    /// to protect the surface of floor from feet
    /// of table. Very interesting desicion.
    /// </summary>
    public class Padding : Product { }
}
/* output :
Legs parts :
CompositePatternExampleNamespace.Feet
Legs parts :
CompositePatternExampleNamespace.Padding
Legs parts :
CompositePatternExampleNamespace.Screws
Table parts :
CompositePatternExampleNamespace.Legs
Table parts :
CompositePatternExampleNamespace.Top
Table parts :
CompositePatternExampleNamespace.Screws
 */

/*
Composite pattern is used where we need to treat a group 
of objects in similar way as a single object. 
Composite pattern composes objects in term of a tree 
structure to represent part as well as whole hierarchy. 
This type of design pattern comes under structural 
pattern as this pattern creates a tree structure of 
group of objects.
This pattern creates a class that contains group of 
its own objects. This class provides ways to modify 
its group of same objects.
link here : https://www.geeksforgeeks.org/composite-design-pattern/
 */