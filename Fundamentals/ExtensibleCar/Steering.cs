using System;
using System.ComponentModel.Composition;

namespace ExtensibleCar
{
    [Export]
    internal class Steering
    {
        public void Left()
        {
            Console.WriteLine("Steering turned to left.");
        }

        public void Right()
        {
            Console.WriteLine("Steering turned to right.");
        }
    }
}