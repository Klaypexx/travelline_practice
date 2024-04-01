using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Models.Engine
{
    public class V6 : IEngine
    {
        public string Name { get; } = "V6";
        public int MaxSpeed { get; } = 196;
        public int MaxGears { get; } = 6;
    }
}
