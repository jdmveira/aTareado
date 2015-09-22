namespace Jdmveira.aTareado.Data
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Threading.Tasks;

	public interface IRepository<T> : IEnumerable<T>, IGtdAbleCollection<T> where T : class
    {
        void Insert(T entity);

        bool Delete(T entity);

        bool Update(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> SearchFor(Func<T, bool> predicate);

        T GetById(Guid id);

		void Save();

		void Load();
    }
}