namespace Jdmveira.aTareado.Common.Test
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Common;
    using System.ComponentModel;
    using aTareado.Test;
    using aTareado.Test.Entities;

    [TestClass]
    public class BindableBaseRelatedTests : INotifyPropertyChangedRelatedTests
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
    }
}
