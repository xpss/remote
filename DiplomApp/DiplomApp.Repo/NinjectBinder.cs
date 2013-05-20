using DiplomApp.Interfaces;
using Ninject.Modules;

namespace DiplomApp.Repo
{
    class NinjectBinder : NinjectModule
    {
        public override void Load()
        {
            Bind<IPoint>().To<PointRepo>();
            Bind<IUser>().To<UserRepo>();
            Bind<ICredentials>().To<CredentialsRepo>();
        }
    }
}
