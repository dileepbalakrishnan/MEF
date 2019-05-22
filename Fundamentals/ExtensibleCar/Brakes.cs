using System;
using System.ComponentModel.Composition;

namespace ExtensibleCar
{
    [Export]
    class Brakes {
        public void Stop()
        {
            Console.WriteLine("Car stopped.");
        }
    }
}