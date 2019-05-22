using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;

namespace ExtensibleCar
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var assemblyCatalog = new AssemblyCatalog(Assembly.GetExecutingAssembly());
            var container = new CompositionContainer(assemblyCatalog);
            var car = new Car();
            container.ComposeParts(car);
            car.Drive();
        }
    }
}