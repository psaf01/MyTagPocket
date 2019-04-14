using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyTagPocket.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageMaster : ContentPage
    {
        public ListView ListView;

        public HomePageMaster()
        {
            InitializeComponent();

            BindingContext = new HomePageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class HomePageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<HomePageMenuItem> MenuItems { get; set; }
            
            public HomePageMasterViewModel()
            {
                MenuItems = new ObservableCollection<HomePageMenuItem>(new[]
                {
                    new HomePageMenuItem { Id = 0, Title = "Page 1", TargetType = typeof(FatalError)},
                    new HomePageMenuItem { Id = 1, Title = "Page 2", TargetType= typeof(Settings.UpgradePage) },
                    new HomePageMenuItem { Id = 2, Title = "Page 3" },
                    new HomePageMenuItem { Id = 3, Title = "Page 4" },
                    new HomePageMenuItem { Id = 4, Title = "Page 5" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}