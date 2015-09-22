namespace Jdmveira.aTareado.Test.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.ComponentModel;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class INotifyPropertyChangedRelatedTests
    {
        #region Test Initialization & Cleanup

        [TestInitialize]
        public virtual void InitializeTest() {

            _mutex = new Mutex(true);
            _propertyName = string.Empty;                        
        }

        [TestCleanup]
        public virtual void CleanupTest() {

            _mutex.Dispose();
            if (_object != null)
                _object.PropertyChanged -= Delegate;
        }
        #endregion

        #region Required for Testing

        protected void InitializeINotifyPropertyChangeInstance(INotifyPropertyChanged obj)
        {
            _object = obj;
            _object.PropertyChanged += Delegate;
        }

        protected string GetInfoRegardingPropertyName ()
        {
            Thread.Sleep(1);
            _mutex.WaitOne(1);

            return _propertyName;
        }
        #endregion

        #region Private Members

        private void Delegate(Object sender, PropertyChangedEventArgs e)
        {
            _mutex.WaitOne();

            _propertyName = e.PropertyName;

            _mutex.ReleaseMutex();
        }

        private INotifyPropertyChanged _object;
        private Mutex _mutex = null;
        private string _propertyName = String.Empty;
        #endregion
    }
}
