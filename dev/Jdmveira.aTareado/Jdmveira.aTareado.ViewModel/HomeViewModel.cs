namespace Jdmveira.aTareado.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using GalaSoft.MvvmLight;
	using System.Collections.ObjectModel;
	using Jdmveira.aTareado.Entities;
	using Jdmveira.aTareado.Data;

	public sealed class HomeViewModel : ViewModelBase
	{
		#region Constructor

		public HomeViewModel(IRepository<GtdAction> actionRepository)
		{

			_actionsRep = actionRepository;

			_actions = new ObservableCollection<GtdAction>(actionRepository.GetAll());
		}
		#endregion

		#region Miembros Públicos

		public ObservableCollection<GtdAction> AllActions
		{
			get { return _actions; }
		}
		#endregion

		#region Miembros Privados

		private IRepository<GtdAction> _actionsRep;
		private ObservableCollection<GtdAction> _actions;
		#endregion
	}
}
