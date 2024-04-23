using CarFactory.Models.BodyTypes;
using CarFactory.Models.Brands;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.SteeringPositions;
using CarFactory.Models.Transmissions;

namespace CarFactory.Models.CarFactories
{
    public class Car : ICar
    {
        public IBrand Brand { get; }
        public IEngine Engine { get; }
        public IBodyType BodyType { get; }
        public IColor Color { get; }
        public ISteeringPosition SteeringPosition { get; }
        public ITransmission Transmission { get; }
        
        public Car(IBrand brand, IEngine engine, IBodyType bodyType, IColor color, ISteeringPosition steeringPosition, ITransmission transmission)
        {
            Brand = brand;
            Engine = engine;
            BodyType = bodyType;
            Color = color;
            SteeringPosition = steeringPosition;
            Transmission = transmission;
        }
    }
}
