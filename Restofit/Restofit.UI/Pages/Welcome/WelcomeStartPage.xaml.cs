using System.Threading.Tasks;
using Restofit.Core.ViewModels;
using Xamarin.Forms;

namespace Restofit.UI.Pages.Welcome
{
    public partial class WelcomeStartPage : WelcomeStartPageXaml
    {
        public WelcomeStartPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
            Initialize();
        }
        protected override async void OnLoaded()
        {
            base.OnLoaded();
            await Task.Delay(300);
            await label1.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
            await label2.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
            await buttonStack.ScaleTo(1, (uint)App.AnimationSpeed, Easing.SinIn);
        }
        protected sealed override void Initialize()
        {
            base.Initialize();
            var theme = App.Current.GetThemeFromColor("blue");
            StatusBarColor = theme.Dark;
            NavigationBarColor = theme.Primary;
            BackgroundColor = theme.Primary;
        }
    }

    public class WelcomeStartPageXaml : BaseContentPage<AuthenticationViewModel>
    {

    }
}