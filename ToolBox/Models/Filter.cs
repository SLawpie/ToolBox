using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolBox.Models
{
    class Filter
    {
        public int Length { get; }
        public double TotalArea { get; }
        public int Diameter { get; }
        public double Area { get; }
        public double TotalEfficiency { get; }
        public double FilterFactor { get; }
        public double RequiredNumberOfFilters { get; }

        public int Factor { get; }
        public int Efficiency { get; }
        public int NumberOfFilters { get; }

        public Filter(int length, int diameter, int factor, int efficiency, int numberOfFilters)
        {
            Length = length;
            Diameter = diameter;
            Factor = factor;
            Efficiency = efficiency;
            NumberOfFilters = numberOfFilters;

            Area = Math.PI * diameter / 1000 * length / 1000 + Math.PI * diameter / 1000 / 2 * diameter / 1000 / 2;
            TotalArea = Area * numberOfFilters;
            TotalEfficiency = TotalArea * factor;
            FilterFactor = efficiency / TotalArea;
            RequiredNumberOfFilters = efficiency / factor / Area;
        }


    }
}
