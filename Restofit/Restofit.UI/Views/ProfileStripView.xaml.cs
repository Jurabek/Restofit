using Restofit.Core.ViewModels;
using Splat;
using Xamarin.Forms;

namespace Restofit.UI.Views
{
    public partial class ProfileStripView : ContentView
    {
        public ProfileStripView()
        {
            InitializeComponent();
            root.BindingContext = Locator.Current.GetService<MainViewModel>();
        }
    }
}
