namespace Jdmveira.aTareado.Common.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Common;
    using System.ComponentModel;
    using aTareado.Test;

    [TestClass]
    public class BindableBaseRelatedTests
    {
        #region Clase auxiliar

        protected class BindableClass : BindableBase
        {
            public string MyProp
            {
                get { return _myProp; }
                set
                {
                    SetProperty<string>(ref _myProp, value);
                }
            }

            private string _myProp;
        }
        #endregion

        #region Testing Related Methods

        [TestInitialize]
        public virtual void InitializeTest ()
        {
            IocWrapper.Register<BindableBase, BindableClass>();
        }

        [TestCleanup]
        public virtual void CleanupTest ()
        {
            IocWrapper.Reset();
        }
        #endregion

        //[TestMethod]
        //public void CheckThatEventIsRaisedAndCorrectValueIsRetrieved()
        //{
        //    BindableClass bc = new BindableClass();

        //    const string propName = "MyProp";
        //    const string propValue = "testing";

        //    string receivedPropName = string.Empty;

        //    bc.PropertyChanged += delegate (object sender, System.ComponentModel.PropertyChangedEventArgs e)
        //    {
        //        receivedPropName = e.PropertyName;
        //    };

        //    bc.MyProp = propValue;

        //    Assert.AreEqual<string>(propName, receivedPropName);
        //    Assert.AreEqual<string>(propValue, bc.MyProp);
        //}
    }
}
