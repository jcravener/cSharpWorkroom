using System;
using System.Collections.Generic;
using System.Linq;

namespace SetOfTuples
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] foo = { 4, 5, 6, 7, 8, 1, 2, 3, 22, 18, 33, 14, 9 };
            OrderedUnits orderedUnits = new OrderedUnits(foo, 18);

            foreach(var u in orderedUnits.Get())
            {
                Console.WriteLine($"value: {u.value} index: {u.index}");
            }
        }
    }

    public class Unit 
    {
        public Unit(int value, int index)
        {
            this.value = value;
            this.index = index;
        }

        public int value { get; set; }
        public int index { get; set; }
    }

    public class OrderedUnits
    {
        public OrderedUnits(int[] u, int boundry)
        {
            BindUnits(u, boundry);
        }

        private List<Unit> Units = new();

        private void BindUnits(int[] u, int boundry)
        {
            var i = 0;

            foreach(int val in u)
            {
                Units.Add(new Unit(val, i));
                i++;
            }

            //var results = from unit in Units
            //              where unit.value < 6
            //              select unit;
            //Units = results.OrderBy(x => x.value).ToList<Unit>();
            
            Units = Units.Where(x => x.value < boundry)
                    .OrderBy(x => x.value)
                    .ToList<Unit>();
        }

        public List<Unit> Get()
        {
            return Units;
        }
    }
}
