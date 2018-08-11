using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.Models;
using System.Runtime.CompilerServices;
using ToolBox.Converters;
using System.Collections.ObjectModel;

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

            filters = new ObservableCollection<Filter>();

            filters.Clear();
            MakeFiltersList();

        }

        private ObservableCollection<Filter> filters;
        public ObservableCollection<Filter> Filters
        {
            get
            {
                filters.Clear();
                MakeFiltersList();
                return filters;
            }
            set
            {
                filters = value;
                NotifyPropertyChanged();
            }
        }

        private string filterDiameter;
        public string FilterDiameter
        {
            get { return filterDiameter; }
            set
            { 
                filterDiameter = value;
                NotifyPropertyChanged("Filters");
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
                NotifyPropertyChanged("Filters");
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
                NotifyPropertyChanged("Filters");
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
                NotifyPropertyChanged("Filters");
                NotifyPropertyChanged();
            }
        }

        private void MakeFiltersList()
        {
            for (int i = 3000; i >= 1000; i -= 100)
            {
                filters.Add(new Filter(
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
