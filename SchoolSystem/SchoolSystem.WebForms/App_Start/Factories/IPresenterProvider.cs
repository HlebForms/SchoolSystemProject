using System;

using WebFormsMvp;

namespace SchoolSystem.WebForms.App_Start.Factories
{
    public  interface IPresenterProvider
    {
        IPresenter GetPresenter(Type presenterType, Type viewType, IView viewInstance);
    }
}
