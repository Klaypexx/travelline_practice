namespace CarFactory.Models.Engines
{
    public class V12 : IEngine
    {
        public string Name { get; } = "V12";
        public int MaxSpeed { get; } = 217;
        public int MaxGears { get; } = 7;
    }
}
