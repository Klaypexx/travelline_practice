using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Models.Engine
{
    public class V8 : IEngine
    {
        public string Name { get; } = "V8";
        public int MaxSpeed { get; } = 211;
        public int MaxGears { get; } = 7;
    }
}
