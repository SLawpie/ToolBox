using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Models;
using System.Runtime.CompilerServices;
using ToolBox.Converters;

namespace ToolBox.ViewModels
{
    class FiltrationAreaViewModel: INotifyPropertyChanged
    {
        public FiltrationAreaViewModel()
        {
           
            string[,] initialValues = new string[,]
                {
                    {"FilterDiameter", "180" },
                    {"FilterFactor", "125" },
                    {"NumberOfFilters", "18" },
                    {"TotalEfficiency","5500" }
                 };

            filterDiameter = initialValues[0,1];
            filterFactor = initialValues[1, 1];
            numberOfFilters = initialValues[2, 1];
            totalEfficiency = initialValues[3, 1];

            aqq = filterDiameter;

            filters = new List<Filter>();

            Filters.Clear();
            MakeFiltersList();
        }

        private string aqq;
        public string Aqq
        {
            get { return aqq; }
            set
            {
                aqq = value;
                NotifyPropertyChanged();
            }
        }

        private List<Filter> filters;
        public List<Filter> Filters
        {
            get { return filters; }
            set { filters = value; }
        }

        private string filterDiameter;
        public string FilterDiameter
        {
            get { return filterDiameter; }
            set
            { 
                filterDiameter = value;
                Aqq = filterDiameter;
                NotifyPropertyChanged();
            }
        }

        private string filterFactor;
        public string FilterFactor
        {
            get { return filterFactor; }
            set
            {
                filterFactor = value;
                NotifyPropertyChanged();
            }
        }

        private string numberOfFilters;
        public string NumberOfFilters
        {
            get { return numberOfFilters; }
            set
            {
                numberOfFilters = value;
                NotifyPropertyChanged();
            }
        }

        private string totalEfficiency;
        public string TotalEfficiency
        {
            get { return totalEfficiency; }
            set
            {
                totalEfficiency = value;
                NotifyPropertyChanged();
            }
        }

        private void MakeFiltersList()
        {
            for (int i = 1000; i <= 3000; i += 100)
            {
                Filters.Add(new Filter(
                    i, 
                    Convert.ToInt32(filterDiameter), 
                    Convert.ToInt32(filterFactor),
                    Convert.ToInt32(totalEfficiency),
                    Convert.ToInt32(numberOfFilters)
                    ));
            }

            //if (orderDesc)
            //{
            //    Filters = Filters.OrderByDescending(o => o.Length).ToList();
            //    // orderDesc = true;
            //}
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            //if (PropertyChanged != null)
            //{
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            //}
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
