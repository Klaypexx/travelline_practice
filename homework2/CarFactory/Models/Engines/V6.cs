namespace CarFactory.Models.Engines
{
    public class V6 : IEngine
    {
        public string Name { get; } = "V6";
        public int MaxSpeed { get; } = 196;
        public int MaxGears { get; } = 6;
    }
}
