using MED_Tool.Properties;
using System.Windows;
using System.Windows.Media;

namespace MED_Tool.Views
{
    /// <summary>
    /// Interaction logic for Overlay.xaml
    /// </summary>
    public partial class OverlayView : Window
    {
        public OverlayView()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Color.FromRgb(Settings.Default.OverlayBackgroundColor.R, Settings.Default.OverlayBackgroundColor.G, Settings.Default.OverlayBackgroundColor.B));
        }
    }
}
