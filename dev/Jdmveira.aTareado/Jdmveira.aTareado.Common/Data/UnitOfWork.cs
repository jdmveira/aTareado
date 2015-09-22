
namespace Jdmveira.aTareado.Data
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class UnitOfWork<T> where T : class
    {
        #region Constructor

        public UnitOfWork(IRepository<T> repository) {

            _dirty = new HashSet<T>();
            _new = new HashSet<T>();
            _deleted = new HashSet<T>();

            _rep = repository;
        }
        #endregion

        #region Miembros Públicos
        private void MarkDirty(T data)
        {
            _dirty.Add(data);
        }

        private void MarkNew(T data)
        {
            _new.Add(data);
        }

        private void MarkDelete(T data)
        {
            _deleted.Add(data);
        }

        private void Commit()
        {
            foreach (var data in _new)
            {
                _rep.Insert(data);
            }

            foreach (var data in _dirty)
            {
                _rep.Update(data);
            }

            foreach (var data in _deleted)
            {
                _rep.Delete(data);
            }

            _new.Clear();
            _dirty.Clear();
            _deleted.Clear();
        }

        private void Rollback()
        {
            _new.Clear();
            _dirty.Clear();
            _deleted.Clear();
        }
        #endregion

        #region Miembros Privados

        private ISet<T> _dirty;
        private ISet<T> _new;
        private ISet<T> _deleted;

        private IRepository<T> _rep;
        #endregion
    }
}