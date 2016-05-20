using System;
using ReactiveUI;
using Restofit.Core.ViewModels;
using Xamarin.Forms;

namespace Restofit.UI.Pages.Welcome
{
    public partial class SignUpPage : SignUpPageXaml
    {
        public SignUpPage()
        {
            InitializeComponent();
            Initialize();
            
            // Example: Using WhenAny instead of Value Converters 
            ViewModel.WhenAnyValue(x => x.IsLoading).Subscribe(isLoading => 
            {
                if (isLoading)
                {
                    loadingLayout.IsVisible = true;
                    regesterStack.IsVisible = false;
                }
                else
                {
                    loadingLayout.IsVisible = false;
                    regesterStack.IsVisible = true;
                }
            });
        }

        protected sealed override void Initialize()
        {
            var color = App.Current.GetThemeFromColor("indigo");
            StatusBarColor = color.Dark;
            ActionBarBackgroundColor = color.Primary;
            NavigationBarColor = Color.Black;
            base.Initialize();
        }
    }
    public class SignUpPageXaml : BaseContentPage<SignUpViewModel>
    {

    }
}
