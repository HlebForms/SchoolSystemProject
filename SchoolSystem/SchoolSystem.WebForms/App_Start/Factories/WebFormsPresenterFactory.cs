using System;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace SchoolSystem.WebForms.App_Start.Factories
{
    public class WebFormsPresenterFactory : IPresenterFactory
    {
        private readonly IPresenterProvider presenterProvider;

        public WebFormsPresenterFactory(IPresenterProvider presenterProvider)
        {
            this.presenterProvider = presenterProvider;
        }

        public IPresenter Create(Type presenterType, Type viewType, IView viewInstance)
        {
            var presenter = this.presenterProvider.GetPresenter(presenterType, viewType, viewInstance);
            return presenter;
        }

        public void Release(IPresenter presenter)
        {
        }
    }
}