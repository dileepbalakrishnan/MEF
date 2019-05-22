using System.ComponentModel.Composition;
namespace ExtensibleCar
{
    internal class Car
    {
        [Import] private Brakes _brakes;

        [Import] private Engine _engine;

        [Import] private Steering _steering;

        [Import] private Transmission _transmission;

        public void Drive()
        {
            _engine.Start();
            _transmission.ShiftUp();
            _steering.Left();
            _brakes.Stop();
        }
    }
}