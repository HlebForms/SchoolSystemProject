using WebFormsMvp.Binder;
using Ninject;

namespace SchoolSystem.WebForms.App_Start
{
    public class BindingsConfig
    {
        public static void BindPresenterFactory()
        {
            var presenterFactory = NinjectWebCommon.Kernel.Get<IPresenterFactory>();
            PresenterBinder.Factory = presenterFactory;
        }
    }
}