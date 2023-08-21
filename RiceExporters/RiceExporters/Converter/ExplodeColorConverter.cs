using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RiceExporters
{
    public class ExplodeColorConverter : IValueConverter
    {
        private int previousIndex = -1; 

        private Color[] colors = new Color[]
        {
        Color.FromArgb(255, 16, 96, 220),
        Color.FromArgb(255, 0, 181, 83),
        Color.FromArgb(255, 218, 105, 2),
        Color.FromArgb(255, 199, 25, 105),
        Color.FromArgb(255, 138, 193, 20),
        Color.FromArgb(255, 132, 25, 199)
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int explodeIndex)
            {
                if (explodeIndex >= 0)
                {
                    previousIndex = explodeIndex;
                    return new SolidColorBrush(colors[explodeIndex]);
                }
                else if (explodeIndex == -1)
                {
                    return new SolidColorBrush(colors[previousIndex]); 
                }
            }

            return new SolidColorBrush(Colors.Transparent);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
