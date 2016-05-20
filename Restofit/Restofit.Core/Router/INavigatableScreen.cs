namespace Restofit.Core.Router
{
    public interface INavigatableScreen
    {
        /// <summary>
        /// The Navigation associated with Screen
        /// </summary>
        NavigationState Navigation { get; }
    }
}
