namespace Jdmveira.aTareado.Test.Entities.EntityBase
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using GalaSoft.MvvmLight.Ioc;
    using Jdmveira.aTareado.Entities;

    [TestClass]
    public class When_Comparing_Two_EntityBase_Instances
    {
        [TestMethod]
        public void It_Results_Unequal_If_Both_UniqueIds_Are_Different()
        {
            Guid g1 = Guid.NewGuid();
            Guid g2 = Guid.NewGuid();

            string title = "Title";
            string description = "Description";

            var eb1 = new EntityBase(g1, title, description);
            var eb2 = new EntityBase(g2, title, description);

            Assert.AreNotEqual<EntityBase>(eb1, eb2, "Two different instances must not be equal if both Unique IDs are not equal");
        }

        [TestMethod]
        public void It_Results_Equal_If_Both_UniqueIds_Are_The_Same()
        {
            Guid g1 = Guid.NewGuid();

            string title = "Title";
            string description = "Description";

            var eb1 = new EntityBase(g1, title, description);
            var eb2 = new EntityBase(g1, title, description);

            Assert.AreEqual<EntityBase>(eb1, eb2, "Two instances must be equal if both Unique IDs are equal");
        }
    }
}
