namespace Jdmveira.aTareado.ViewModel
{
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Ioc;
    using Data = Jdmveira.aTareado.Data;
    using Entities = Jdmveira.aTareado.Entities;
    using Microsoft.Practices.ServiceLocation;
    using Jdmveira.aTareado.ViewModel;
    using Jdmveira.aTareado.Entities;
    using System;
    using Jdmveira.aTareado.Data;

    public sealed class ViewModelLocator
    {
        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<Data.IRepository<Entities.GtdAction>, Data.Design.GtdActionRepository>();
            }
            else
            {
#if TESTING
                SimpleIoc.Default.Register<Data.IRepository<Entities.GtdAction>, Data.Design.GtdActionRepository>();
#else
                SimpleIoc.Default.Register<Data.IRepository<Entities.GtdAction>, Data.GtdActionRepository>();
#endif
            }

            // Registrando los modelos de las vistas
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<ActionsSelectorViewModel>();
        }

        public HomeViewModel Home
        {
            get { return SimpleIoc.Default.GetInstance<HomeViewModel>(); }
        }

        public ActionsSelectorViewModel ActionsSelector
        {
            get { return SimpleIoc.Default.GetInstance<ActionsSelectorViewModel>(); }
        }

        public IRepository<GtdAction> DesignTimeActions
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return SimpleIoc.Default.GetInstance<IRepository<GtdAction>>();
                else
                    throw new NotImplementedException();
            }
        }

        public GtdAction DesignTimeAction
        {
            get
            {
                if (ViewModelBase.IsInDesignModeStatic)
                    return SimpleIoc.Default.GetInstance<IRepository<GtdAction>>().GetEnumerator ().Current;
                else
                    throw new NotImplementedException();
            }
        }
    }
}
