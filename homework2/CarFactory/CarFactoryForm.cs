using CarFactory.Models.BodyType;
using CarFactory.Models.CarFactory;
using CarFactory.Models.CarModel;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.SteeringPosition;
using CarFactory.Models.Transmission;

namespace CarFactory
{
    public partial class CarFactoryForm : Form
    {
        public CarFactoryForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carBrand.SelectedIndex = 0;
            carBodyType.SelectedIndex = 0;
            carColor.SelectedIndex = 0;
            carEngine.SelectedIndex = 0;
            carTransmission.SelectedIndex = 0;
            carSteeringPosition.SelectedIndex = 0;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ICar car = PickConfigurations();
            string carCharacteristicsText = CarCharacteristicsMessage(car);
            MessageBox.Show(carCharacteristicsText);
        }

        private string CarCharacteristicsMessage(ICar car)
        {
            string carCharacteristicsText = $"Your configuration:\nBrand - {car.Brand.Name}\nEngine - {car.Engine.Name}\nMaximum speed - {car.Engine.MaxSpeed} km\\h\nGears - {car.Engine.MaxGears}\nBody type - {car.BodyType.Name}\nBody color - {car.Color.Name}\nThe steering wheel position - {car.SteeringPosition.Name}\nTransmission - {car.Transmission.Name}";
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