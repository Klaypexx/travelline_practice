using CarFactory.Models.BodyType;
using CarFactory.Models.Brand;
using CarFactory.Models.CarFactory;
using CarFactory.Models.CarModel;
using CarFactory.Models.Color;
using CarFactory.Models.Engine;
using CarFactory.Models.SteeringPosition;
using CarFactory.Models.Transmission;

namespace CarFactory
{
    public partial class Form1 : Form
    {
        public Form1()
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
            DictionaryProvider newDictionary = new DictionaryProvider();
            IBodyType bodyType = newDictionary.BodyTypeDictionary[carBodyType.SelectedItem.ToString()];
            IBrand brand = newDictionary.BrandDictionary[carBrand.SelectedItem.ToString()];
            IColor color = newDictionary.ColorDictionary[carColor.SelectedItem.ToString()];
            IEngine engine = newDictionary.EngineDictionary[carEngine.SelectedItem.ToString()];
            ISteeringPosition steeringPosition = newDictionary.SteeringPositionDictionary[carSteeringPosition.SelectedItem.ToString()];
            ITransmission transmission = newDictionary.TransmissionDictionary[carTransmission.SelectedItem.ToString()];
            
            ICar car = new Car(brand, engine, bodyType, color, steeringPosition, transmission);

            MessageBox.Show($"���� ������������:\n����� - {car.Brand.Name}\n��������� - {car.Engine.Name}\n������������ �������� - {car.Engine.MaxSpeed} ��\\�\n���������� ������� - {car.Engine.MaxGears}\n��� ������ - {car.BodyType.Name}\n���� ������ - {car.Color.Name}\n������� ���� - {car.SteeringPosition.Name}\n����������� - {car.Transmission.Name}");
        }
    }
}