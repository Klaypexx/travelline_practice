using CarFactory.Models.CarModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarFactory.Models.Brand
{
    public class Toyota : IBrand
    {
        public string Name { get; } = "Toyota";
    }
}
