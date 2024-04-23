using CarFactory.Models.BodyTypes;
using CarFactory.Models.Brands;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.SteeringPositions;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.CarFactories
{
    public interface ICar
    {
        public IBrand Brand { get; }
        public IEngine Engine { get; }
        public IBodyType BodyType { get; }
        public IColor Color { get; }
        public ISteeringPosition SteeringPosition { get; }
        public ITransmission Transmission { get; }
    }
}
