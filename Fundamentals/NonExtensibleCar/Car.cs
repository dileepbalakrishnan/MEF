namespace NonExtensibleCar
{
    class Car
    {
        private readonly Engine _engine;
        private readonly Steering _steering;
        private readonly Transmission _transmission;
        private readonly Brakes _brakes;

        public Car()
        {
            _engine = new Engine();
            _steering = new Steering();
            _transmission = new Transmission();
            _brakes = new Brakes();
        }

        public void Drive()
        {
            _engine.Start();
            _transmission.ShiftUp();
            _steering.Left();
            _brakes.Stop();
        }
    }
}