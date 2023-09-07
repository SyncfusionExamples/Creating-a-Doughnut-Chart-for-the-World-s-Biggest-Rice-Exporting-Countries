using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RiceExporters
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                SetFontSizes(16);
                SetPathProperties(1.5, 1.3, new Thickness(0, 0, 20, 0));
                SetTextSingleLine();
            }
            else if (this.WindowState == WindowState.Normal)
            {
                SetFontSizes(12);
                SetPathProperties(0.75, 0.6, new Thickness(15, 0, 0, 0));
                SetTextMultiline();
            }
        }

        private void SetFontSizes(double fontSize)
        {
            text.FontSize = fontSize;
            foreach (var child in valueText.Children.OfType<TextBlock>())
            {
                child.FontSize = fontSize;
            }
        }

        private void SetPathProperties(double scaleX, double scaleY, Thickness margin)
        {
            var pathToSetMargin = path.Children.OfType<Path>().FirstOrDefault();
            if (pathToSetMargin != null)
            {
                pathToSetMargin.Margin = margin;
            }

            foreach (var pathElement in path.Children.OfType<Path>())
            {
                var scaleTransform = pathElement.RenderTransform as ScaleTransform;
                if (scaleTransform != null)
                {
                    scaleTransform.ScaleX = scaleX;
                    scaleTransform.ScaleY = scaleY;
                }
            }
        }

        private void SetTextSingleLine()
        {
            text.Inlines.Clear();
            text.Text = "Percent contributed by";
            valueText.Margin = new Thickness(0, -5, 0, 0);
        }

        private void SetTextMultiline()
        {
            text.Inlines.Clear();
            var textBlock1 = new TextBlock()
            {
                Margin = new Thickness(65, 3, 0, 0),
                Text = "Percent",
            };

            var textBlock2 = new TextBlock()
            {
                Margin = new Thickness(45, 3, 0, 0),
                Text = "contributed by",
            };

            text.Inlines.Add(textBlock1);
            text.Inlines.Add(new LineBreak());
            text.Inlines.Add(textBlock2);
            valueText.Margin = new Thickness(0, 0, 0, 0);
        }
    }
}
