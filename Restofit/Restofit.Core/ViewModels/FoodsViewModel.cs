using ReactiveUI;
using Restofit.Core.Models;
using Restofit.Core.Models.Entities;
using Restofit.Core.Router;
using Splat;

namespace Restofit.Core.ViewModels
{
    public class FoodsViewModel : ReactiveObject, INavigatableViewModel
    {
        public MainViewModel MainViewModel { get; set; }
        public ReactiveCommand<object> OpenOrder { get; set; }

        public FoodsViewModel(INavigatableScreen screen = null)
        {
            OrderableFoods = new ReactiveList<Order>();
            OpenOrder = ReactiveCommand.Create();
            NavigationScreen = (screen ?? Locator.Current.GetService<INavigatableScreen>());
            MainViewModel = Locator.Current.GetService<MainViewModel>();
            //var foods = Context.AuthenticationManager.AuthenticatedApi.GetFoods();
            //foods.ToObservable()
            //.Do(x =>
            //{
            //    var orders = x.Select(f => new Order {Food = f, Id = Guid.NewGuid()});
            //    OrderableFoods.AddRange(orders);
            //})
            //.Subscribe();

            //OpenOrder.Do(_ =>
            //    {
            //        NavigationScreen.Navigation.Navigate.Execute(Locator.Current.GetService<BasketViewModel>());
            //    }).Subscribe();

        }
        public INavigatableScreen NavigationScreen
        {
            get; set;
        }

        public string Title => "Foods";

        public ReactiveList<Order> OrderableFoods { get; set; }
    }
}
