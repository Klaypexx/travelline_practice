using CarFactory.Models.BodyType;
using CarFactory.Models.CarModel;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.SteeringPosition;
using CarFactory.Models.Transmission;

namespace CarFactory.Models.CarFactory
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
