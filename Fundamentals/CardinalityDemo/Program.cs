using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace CardinalityDemo
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(assemblyCatalog);

            var ic = new ImporterClass();
            container.ComposeParts(ic);
        }
    }

    internal class ImporterClass
    {
        [Import(AllowDefault = true)] private SingleExport SingleExport;
        [ImportMany] private IEnumerable<ExportBase> MultiExports;
    }

    //[Export]
    internal class SingleExport
    {
    }

    [InheritedExport]
    class ExportBase { }

    class MultiExport1 : ExportBase { }
    class MultiExport2 : ExportBase { }

}