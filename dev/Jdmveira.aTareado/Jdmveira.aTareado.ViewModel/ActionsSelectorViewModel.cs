namespace Jdmveira.aTareado.ViewModel
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Jdmveira.aTareado.Data;
    using Jdmveira.aTareado.Entities;

    public sealed class ActionsSelectorViewModel
    {
        #region Constructor

        public ActionsSelectorViewModel(IRepository<GtdAction> rep)
        {
            _rep = rep;

            _passedActions = null;
            _todayActions = null;
            _todoActions = null;            
        }
        #endregion

        #region Miembros Públicos

        public ObservableCollection<GtdAction> PassedActions
        {
            get { return _passedActions; }
        }

        public ObservableCollection<GtdAction> TodayActions
        {
            get { return _todayActions; }
        }

        public ObservableCollection<GtdAction> TodoActions
        {
            get { return _todoActions; }
        }
        #endregion

        #region Miembros Privados

        private IRepository<GtdAction> _rep;

        private ObservableCollection<GtdAction> _passedActions;
        private ObservableCollection<GtdAction> _todayActions;
        private ObservableCollection<GtdAction> _todoActions;
        #endregion
    }
}
