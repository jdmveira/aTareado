namespace Jdmveira.aTareado.Data
{
    using System.Linq;
    using Jdmveira.aTareado.Entities;

    public interface IGtdAbleCollection<T> where T : class
    {
        IQueryable<T> GetPassed();

        IQueryable<T> GetToday();

        IQueryable<T> GetTodo();

        KindOfGtdAction KindOf(T entity);
    }
}