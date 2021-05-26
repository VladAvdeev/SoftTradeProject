using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradePlusAdmin.Services
{
    public class DiConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWindowService>().To<WindowService>();
        }
    }
}
