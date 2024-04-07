namespace CarFactory.Models.Engines
{
    public class V8 : IEngine
    {
        public string Name { get; } = "V8";
        public int MaxSpeed { get; } = 211;
        public int MaxGears { get; } = 7;
    }
}
