using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Models.Engine
{
    public class V12 : IEngine
    {
        public string Name { get; } = "V12";
        public int MaxSpeed { get; } = 217;
        public int MaxGears { get; } = 7;
    }
}
