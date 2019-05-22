using System;
using System.ComponentModel.Composition;

namespace ExtensibleCar
{
    [Export]
    class Engine {
        public void Start()
        {
            Console.WriteLine("Engined started.");
        }
    }
}