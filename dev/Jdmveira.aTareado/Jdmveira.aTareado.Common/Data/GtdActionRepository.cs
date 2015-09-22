namespace Jdmveira.aTareado.Data
{
	using Jdmveira.aTareado.Entities;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;

	public class GtdActionRepository : IRepository<GtdAction>
	{
		#region Constructor
		public GtdActionRepository()
		{
			_actions = new ObservableCollection<GtdAction>();
		}
		#endregion

		#region Miembros Públicos

		public bool Delete(GtdAction entity)
		{
			return _actions.Remove(entity);
		}

		public IQueryable<GtdAction> GetAll()
		{
			return _actions.AsQueryable<GtdAction>();
		}

		public GtdAction GetById(Guid id)
		{
			return _actions.FirstOrDefault(g => g.UniqueId == id);
		}

		public IEnumerator<GtdAction> GetEnumerator()
		{
			return _actions.GetEnumerator();
		}

		public void Insert(GtdAction entity)
		{
			_actions.Add(entity);
		}

		public IQueryable<GtdAction> SearchFor(Func<GtdAction, bool> predicate)
		{
			return _actions.Where(predicate).AsQueryable<GtdAction>();
		}

		public bool Update(GtdAction entity)
		{
			var i = _actions.IndexOf(entity);
			if (i == -1)
				return false;

			_actions[i] = entity;

			return true;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _actions.GetEnumerator();
		}

		public virtual void Save()
		{
			throw new NotImplementedException();
		}

		public virtual void Load()
		{
			throw new NotImplementedException();
		}

        public IQueryable<GtdAction> GetPassed()
        {
            DateTime beginOfDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            return SearchFor(a => a.Schedule.DueDate != null && a.Schedule.DueDate < beginOfDay);
        }

        public IQueryable<GtdAction> GetToday()
        {
            DateTime beginOfDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            DateTime endOfDay = beginOfDay.AddDays(1);

            return SearchFor(a => a.Schedule.DueDate != null && beginOfDay <= a.Schedule.DueDate && endOfDay > a.Schedule.DueDate);
        }

        public IQueryable<GtdAction> GetTodo()
        {
            DateTime endOfTheDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

            return SearchFor(a => a.Schedule.DueDate != null && a.Schedule.DueDate > endOfTheDay);
        }

        public KindOfGtdAction KindOf(GtdAction entity)
        {
            return entity.KindOf();
        }
        #endregion

        #region Miembros Privados

        protected ObservableCollection<GtdAction> _actions;
		#endregion
	}
}