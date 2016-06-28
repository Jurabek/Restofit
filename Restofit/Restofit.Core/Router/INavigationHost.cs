using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactiveUI;

namespace Restofit.Core.Router
{
    public interface INavigationHost : IActivatable
    {
        NavigationState Router { get; set; }
    }
}
