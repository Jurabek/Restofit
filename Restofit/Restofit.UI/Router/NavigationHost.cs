using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using ReactiveUI;
using Restofit.Core.Router;
using Splat;
using Xamarin.Forms;

namespace Restofit.UI.Router
{
    public class NavigationHost : NavigationPage, IActivatable
    {
        public static readonly BindableProperty RouterProperty =
            BindableProperty.Create(nameof(Router), typeof(NavigationState), typeof(NavigationHost), default(NavigationHost), BindingMode.OneWay);

        public NavigationState Router
        {
            get { return (NavigationState)GetValue(RouterProperty); }
            set { SetValue(RouterProperty, value); }
        }

        public NavigationHost()
        {
            SubscribeNavigationHosts();
        }

        public NavigationHost(ContentPage root) : base(root)
        {
            SubscribeNavigationHosts();
        }

        private void SubscribeNavigationHosts()
        {
            bool currentlyPopping = false;
            this.WhenAnyObservable(x => x.Router.NavigationStack.Changed)
                .Where(_ => Router.NavigationStack.IsEmpty)
                .SelectMany(_ => pageForViewModel(Router.GetCurrentViewModel()))
                .SelectMany(async x =>
                {
                    currentlyPopping = true;
                    await this.PopToRootAsync();
                    currentlyPopping = false;
                    return x;
                })
                .Subscribe();

            this.WhenAnyObservable(x => x.Router.NavigateToMainPage)
                .SelectMany(pageForViewModel)
                .Subscribe(p =>
                {
                    Application.Current.MainPage = null;
                    Application.Current.MainPage = p;
                    while (Navigation.NavigationStack.Count > 1)
                        Navigation.RemovePage(Navigation.NavigationStack[0]); //WelcomeStartPage
                });


            this.WhenAnyObservable(x => x.Router.Navigate)
                .SelectMany(_ => pageForViewModel(Router.GetCurrentViewModel()))
                .SelectMany(x =>
                        this.PushAsync(x).ToObservable())
                .Subscribe();

            this.WhenAnyObservable(x => x.Router.NavigateBack)
                .SelectMany(async x =>
                {
                    currentlyPopping = true;
                    await this.PopAsync();
                    currentlyPopping = false;

                    return x;
                })
                // ReSharper disable once SuspiciousTypeConversion.Context
                .Do(_ => ((IViewFor)CurrentPage).ViewModel = Router.GetCurrentViewModel())
                .Subscribe();

            var poppingEvent = Observable.FromEventPattern<NavigationEventArgs>(x => this.Popped += x, x => this.Popped -= x);
            poppingEvent
                 .Where(_ => !currentlyPopping && Router != null)
                 .Subscribe(_ =>
                 {
                     Router.NavigationStack.RemoveAt(Router.NavigationStack.Count - 1);
                     // ReSharper disable once SuspiciousTypeConversion.Context
                     ((IViewFor)this.CurrentPage).ViewModel = Router.GetCurrentViewModel();
                 });


            Router = Locator.Current.GetService<INavigatableScreen>().Navigation;
            if (Router == null) throw new Exception("You *must* register an IScreen class representing your App's main Screen");
        }

        IObservable<Page> pageForViewModel(INavigatableViewModel vm)
        {
            if (vm == null) return Observable.Empty<Page>();

            var ret = ViewLocator.Current.ResolveView(vm);
            if (ret == null)
            {
                var msg = $"Couldn't find a View for ViewModel. You probably need to register an IViewFor<{vm.GetType().Name}>";
                return Observable.Throw<Page>(new Exception(msg));
            }

            ret.ViewModel = vm;

            // ReSharper disable once SuspiciousTypeConversion.Context
            var pg = (Page)ret;
            pg.Title = vm.Title;
            return Observable.Return(pg);
        }
    }
}
