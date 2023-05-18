using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfDatabindingListToClass
{
    class Cars
    {
        public static List<Car> GetCars()
        {
            return new List<Car>()
            {
                new Car(){Owner="Mike", CarType=CarType.Hatchback},
                new Car(){Owner="Mike2", CarType=CarType.Sedan},
                new Car(){Owner="Mike3", CarType=CarType.SUV}
            }.ToList();
        }
    }
}
