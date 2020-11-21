using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using PrismOutlook.Business;
using PrismOutlook.Core;

namespace PrismOutlook.Modules.Mail.ViewModels
{
    public class MailGroupViewModel : ViewModelBase
    {
        private readonly IApplicationCommands _applicationCommands;
        private ObservableCollection<NavigationItem> _items;
        public ObservableCollection<NavigationItem> Items
        {
            get { return _items; }
            set { SetProperty(ref _items, value); }
        }

        private DelegateCommand<NavigationItem> _selectedCommand;
        public DelegateCommand<NavigationItem> SelectedCommand =>
            _selectedCommand ?? (_selectedCommand = new DelegateCommand<NavigationItem>(ExecuteSelectedCommand));

        void ExecuteSelectedCommand(NavigationItem item)
        {
            if (item != null)
            {
                _applicationCommands.NavigateCommand.Execute(item.NavigationPath);
            }
        }

        public MailGroupViewModel(IApplicationCommands applicationCommands)
        {
            GenerateMenu();
            _applicationCommands = applicationCommands;
        }

        void GenerateMenu()
        {
            Items = new ObservableCollection<NavigationItem>();

            var root = new NavigationItem
            {
                Caption = "Personal Folder",
                NavigationPath = "MailList?id=Default"
            };
            root.Items.Add(new NavigationItem
            {
                Caption = "Inbox",
                NavigationPath = "MailList?id=Inbox"
            });
            root.Items.Add(new NavigationItem
            {
                Caption = "Deleted",
                NavigationPath = "MailList?id=Deleted"
            });
            root.Items.Add(new NavigationItem
            {
                Caption = "Sent",
                NavigationPath = "MailList?id=Sent"
            });

            Items.Add(root);
        }
    }
}
