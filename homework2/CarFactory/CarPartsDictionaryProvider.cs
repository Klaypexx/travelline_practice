using CarFactory.Models.BodyType;
using CarFactory.Models.Brand;
using CarFactory.Models.CarModel;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.SteeringPosition;
using CarFactory.Models.Transmission;

namespace CarFactory
{
    public class CarPartsDictionaryProvider
    {
        public Dictionary<string, IBodyType> BodyTypeDictionary = new Dictionary<string, IBodyType>
        {
            {"Convertible", new Convertible()},
            {"HatchBack", new HatchBack()},
            {"Sedan", new Sedan()}
        };

        public Dictionary<string, IBrand> BrandDictionary = new Dictionary<string, IBrand>
        {
            {"Honda", new Honda()},
            {"Mercedez", new Mercedez()},
            {"Mitsubishi", new Mitsubishi()},
            {"Toyota", new Toyota()},
            {"Volkswagen", new Volkswagen()}
        };

        public Dictionary<string, IColor> ColorDictionary = new Dictionary<string, IColor>
        {
            {"Black", new Black()},
            {"Blue", new Blue()},
            {"Red", new Red()},
            {"White", new White()}
        };

        public Dictionary<string, IEngine> EngineDictionary = new Dictionary<string, IEngine>
        {
            {"V12", new V12()},
            {"V6", new V6()},
            {"V8", new V8()}
        };

        public Dictionary<string, ISteeringPosition> SteeringPositionDictionary = new Dictionary<string, ISteeringPosition>
        {
            {"LeftPosition", new LeftPosition()},
            {"RightPosition", new RightPosition()}
        };

        public Dictionary<string, ITransmission> TransmissionDictionary = new Dictionary<string, ITransmission>
        {
            {"Automatical", new Automatical()},
            {"Mechanical", new Mechanical()}
        };
    }
}
