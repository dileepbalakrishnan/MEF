using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ExportsDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            AssemblyCatalog assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            CompositionContainer container = new CompositionContainer(assemblyCatalog);

            foreach (var part in container.Catalog)
            {
                Console.WriteLine(part.ToString());
            }
        }
    }

    [InheritedExport]
    internal interface IInterface1
    {
    }

    internal class ClassA : IInterface1
    {
    }

    internal class ClassB : ClassA
    {
    }

    internal class ClassC : ClassB
    {
    }
    [Export]
    internal class ClassA1
    {
    }

    internal class ClassB1 : ClassA1
    {
    }

    internal class ClassC1 : ClassB1
    {
    }
}