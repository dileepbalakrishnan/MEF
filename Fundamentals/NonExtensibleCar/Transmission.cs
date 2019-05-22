using System;

namespace NonExtensibleCar
{
    class Transmission
    {
        private int _currentGear = 0;
        private const int MaxGears = 5;
        public void ShiftUp()
        {
            if(_currentGear < MaxGears)
                _currentGear++;
            Console.WriteLine($"Gear moved to {_currentGear}.");
        }

        public void ShiftDown()
        {
            if (_currentGear > 0)
                _currentGear--;
            Console.WriteLine($"Gear moved to {_currentGear}.");
        }
    }
}