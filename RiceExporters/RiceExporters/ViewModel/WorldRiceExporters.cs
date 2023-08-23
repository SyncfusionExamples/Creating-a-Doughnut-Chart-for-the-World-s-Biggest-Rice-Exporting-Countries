using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace RiceExporters
{
    public class WorldRiceExporters
    {
        public List<RiceExporterModel> ExportData { get; set; }
        private double groupTo = 2; //For values of 2 million or less
        private string country;
        private double percentage;
        private int selectedIndex;

        public double GroupTo
        {
            get { return groupTo; }
            set { groupTo = value; }
        }

        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        public double Percentage
        {
            get { return percentage; }
            set { percentage = value; }
        }

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set
            {
                  selectedIndex = value;
                  UpdateIndex(value);
            }
        }

        public WorldRiceExporters()
        {
            ExportData = new List<RiceExporterModel>
            {
                 new RiceExporterModel("India", 22500),
                 new RiceExporterModel("Thailand", 8500),
                 new RiceExporterModel("Vietnam",7500 ),
                 new RiceExporterModel("Pakistan", 3600),
                 new RiceExporterModel("US", 2125),

                new RiceExporterModel("Argentina", 400),
                new RiceExporterModel("Australia",275 ),
                new RiceExporterModel("Brazil",1100 ),
                new RiceExporterModel("Burma", 1850),
                new RiceExporterModel("Cambodia", 1800),
                new RiceExporterModel("China",1800 ),
                new RiceExporterModel("European Union", 400),
                new RiceExporterModel("Guyana", 440),
                new RiceExporterModel("Paraguay", 820),
                new RiceExporterModel("Turkey",240 ),
                new RiceExporterModel("Uruguay", 900),
                new RiceExporterModel("Others", 1398),
            };

            SelectedIndex = 0;
        }

        private void UpdateIndex(int value)
        {
            if (value >= 0 && value < ExportData.Count)
            {
                var model = ExportData[value];
                double sum = ExportData.Sum(item => item.Value);
                if (model != null)
                {
                    if (model.Value < GroupTo)
                    {
                        double selectedItemsSum = ExportData.Where(item => item.Value < GroupTo).Sum(item => item.Value);
                        double selectedItemsPercentage = (selectedItemsSum / sum) * 100;
                        Percentage = selectedItemsPercentage;
                        Country = "Others";
                    }
                    else
                    {
                        double SelectedItemsPercentage = (model.Value / sum) * 100;
                        Percentage = SelectedItemsPercentage;
                        Country = model.Country;
                    }
                }
            }
        }
    }
}
