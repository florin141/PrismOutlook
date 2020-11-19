using System.Windows;
using Infragistics.Themes;
using Infragistics.Windows.OutlookBar;
using Infragistics.Windows.Ribbon;
using PrismOutlook.Core;

namespace PrismOutlook.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : XamRibbonWindow
    {
        private readonly IApplicationCommands _applicationCommands;

        public MainWindow(IApplicationCommands applicationCommands)
        {
            InitializeComponent();

            ThemeManager.ApplicationTheme = new Office2013Theme();

            _applicationCommands = applicationCommands;
        }

        private void XamOutlookBar_OnSelectedGroupChanged(object sender, RoutedEventArgs e)
        {
            if (!(sender is XamOutlookBar xamOutlookBar))
            {
                return;
            }

            if (xamOutlookBar.SelectedGroup is IOutlookBarGroup group)
            {
                _applicationCommands.NavigateCommand.Execute(group.DefaultNavigationPath);
            }
        }
    }
}
