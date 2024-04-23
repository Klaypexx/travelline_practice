using CarFactory.Models.BodyTypes;
using CarFactory.Models.CarFactories;
using CarFactory.Models.Brands;
using CarFactory.Models.Colors;
using CarFactory.Models.Engines;
using CarFactory.Models.SteeringPositions;
using CarFactory.Models.Transmissions;

namespace CarFactory
{
    public partial class CarFactoryForm : Form
    {
        public CarFactoryForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
        }

        private void CarForm(object sender, EventArgs e)
        {
            carBrand.SelectedIndex = 0;
            carBodyType.SelectedIndex = 0;
            carColor.SelectedIndex = 0;
            carEngine.SelectedIndex = 0;
            carTransmission.SelectedIndex = 0;
            carSteeringPosition.SelectedIndex = 0;
        }

        private void buttonConfirm(object sender, EventArgs e)
        {
            ICar car = PickConfigurations();
            string carCharacteristicsText = CarCharacteristicsMessage(car);
            MessageBox.Show(carCharacteristicsText);
        }

        private string CarCharacteristicsMessage(ICar car)
        {
            string carCharacteristicsText = $"Your configuration:\n";
            carCharacteristicsText += $"Brand - {car.Brand.Name}\n";
            carCharacteristicsText += $"Engine - {car.Engine.Name}\n";
            carCharacteristicsText += $"Maximum speed - {car.Engine.MaxSpeed} km\\h\n";
            carCharacteristicsText += $"Gears - {car.Engine.MaxGears}\n";
            carCharacteristicsText += $"Body type - {car.BodyType.Name}\n";
            carCharacteristicsText += $"Body color - {car.Color.Name}\n";
            carCharacteristicsText += $"The steering wheel position - {car.SteeringPosition.Name}\n";
            carCharacteristicsText += $"Transmission - {car.Transmission.Name}";
            return carCharacteristicsText;
        }

        private ICar PickConfigurations()
        {
            CarPartsDictionaryProvider newDictionary = new CarPartsDictionaryProvider();
            IBodyType bodyType = newDictionary.BodyTypeDictionary[carBodyType.SelectedItem.ToString()];
            IBrand brand = newDictionary.BrandDictionary[carBrand.SelectedItem.ToString()];
            IColor color = newDictionary.ColorDictionary[carColor.SelectedItem.ToString()];
            IEngine engine = newDictionary.EngineDictionary[carEngine.SelectedItem.ToString()];
            ISteeringPosition steeringPosition = newDictionary.SteeringPositionDictionary[carSteeringPosition.SelectedItem.ToString()];
            ITransmission transmission = newDictionary.TransmissionDictionary[carTransmission.SelectedItem.ToString()];

            return new Car(brand, engine, bodyType, color, steeringPosition, transmission);
        }
    }
}