using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using System.Configuration;
using Ninject;
using System.Net;

namespace DiplomApp.Helpers
{
    public class BinderHelper
    {
        public static IKernel iKernel { get; set; }

        static BinderHelper()
        {
            using (var wc = new WebClient())
            {
                Assembly asm;
                try
                {
                    asm = Assembly.Load(wc.DownloadData("ftp://xpss.somee.com/www.xpss.somee.com/bin/DiplomApp.Repo.dll"));
                }
                catch (Exception)
                {
                    asm = Assembly.LoadFrom(ConfigurationManager.AppSettings.Get("path"));
                }
                Type binderType = asm.GetType("DiplomApp.Repo.NinjectBinder");
                var binderModul = (INinjectModule)Activator.CreateInstance(binderType);
                iKernel = new StandardKernel(binderModul);
            }
        }

        public IKernel GetKernel()
        {
            using (var wc = new WebClient())
            {
                Assembly asm;
                try
                {
                    asm = Assembly.Load(wc.DownloadData("ftp://xpss.somee.com/www.xpss.somee.com/bin/DiplomApp.Repo.dll"));
                }
                catch (Exception)
                {
                    asm = Assembly.LoadFrom(ConfigurationManager.AppSettings.Get("path"));
                }
                Type binderType = asm.GetType("DiplomApp.Repo.NinjectBinder");
                var binderModul = (INinjectModule)Activator.CreateInstance(binderType);
                return new StandardKernel(binderModul);
            }
        }
    }
}
