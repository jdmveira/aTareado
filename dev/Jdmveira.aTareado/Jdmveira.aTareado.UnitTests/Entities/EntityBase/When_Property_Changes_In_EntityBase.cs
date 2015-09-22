namespace Jdmveira.aTareado.Test.Entities.EntityBase
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;
    using System.Threading;
    using System.ComponentModel;

    [TestClass]
    public class When_Property_Changes_In_EntityBase: INotifyPropertyChangedRelatedTests
    {
        [TestMethod]
        public void It_Must_Raise_PropertyChanged_On_Title()
        {
            var eb = new EntityBase();

            var actual = "Title";
            var expected = string.Empty;

            InitializeINotifyPropertyChangeInstance(eb);

            eb.Title = "New title";

            expected = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(expected, actual, "Property changed must be Title");
        }

        [TestMethod]
        public void It_Must_Raise_PropertyChanged_On_Description ()
        {
            var eb = new EntityBase();

            var actual = "Description";
            var expected = string.Empty;

            InitializeINotifyPropertyChangeInstance(eb);

            eb.Description = "New description";

            expected = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(expected, actual, "Property changed must be Description");
        }
    }
}
