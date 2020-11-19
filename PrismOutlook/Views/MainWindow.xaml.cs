using System.Windows;
using Infragistics.Themes;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using Prism.Regions;
using PrismOutlook.Core;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : XamRibbonWindow
    {
        private readonly IRegionManager _regionManager;

        public MainWindow(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitializeComponent();
            ThemeManager.ApplicationTheme = new Office2013Theme();
        }

        private void XamOutlookBar_OnSelectedGroupChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is XamOutlookBar xamOutlookBar))
            {
                return;
            }

            if (xamOutlookBar.SelectedGroup is IOutlookBarGroup group)
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, @group.DefaultNavigationPath);
            }
        }
    }
}
