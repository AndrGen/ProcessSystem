using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProcessSystem.UI.Blazor.Server.Client
{
    public interface IProcessSystem
    {
        void RegisterAsync();
        void UnregisterAsync();
    }
}
