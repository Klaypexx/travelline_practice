using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Models.Engine
{
    public interface IEngine
    {
        public string Name { get; }
        public int MaxSpeed { get; }
        public int MaxGears { get; }
        
    }
}
