namespace Jdmveira.aTareado.Test.Entities.EntityBase
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;

    [TestClass]
    public class When_Creating_An_EntityBase
    {
        [TestMethod]
        public void It_Must_Have_A_Unique_ID()
        {
            var eb = new EntityBase();

            Assert.IsNotNull(eb.UniqueId, "It must have a Unique Id");
        }

        [TestMethod]
        public void It_Must_Have_An_Empty_Title()
        {
            var eb = new EntityBase();

            Assert.IsTrue(string.IsNullOrEmpty(eb.Title), "Title must be empty by default");
        }

        [TestMethod]
        public void It_Must_Have_An_Empty_Description()
        {
            var eb = new EntityBase();

            Assert.IsTrue(string.IsNullOrEmpty(eb.Description), "Description must be empty by default");
        }

        [TestMethod]
        public void It_Must_Have_The_UniqueId_Passed_As_Parameter()
        {
            Guid uid = Guid.NewGuid();
            string title = string.Empty;
            string description = string.Empty;

            var eb = new EntityBase(uid, title, description);

            Guid actual = eb.UniqueId;

            Assert.AreEqual<Guid>(uid, actual, "Unique ID must be the same");
        }

        [TestMethod]
        public void It_Must_Have_The_Title_Passed_As_Parameter()
        {
            Guid uid = Guid.NewGuid();
            string title = DateTime.Now.ToString();
            string description = string.Empty;

            var eb = new EntityBase(uid, title, description);

            string actual = eb.Title;

            Assert.AreEqual<string>(title, actual, "Title must be the same");
        }

        [TestMethod]
        public void It_Must_Have_The_Description_Passed_As_Parameter()
        {
            Guid uid = Guid.NewGuid();
            string title = string.Empty;
            string description = DateTime.Now.ToString(); ;

            var eb = new EntityBase(uid, title, description);

            string actual = eb.Description;

            Assert.AreEqual<string>(description, actual, "Description must be the same");
        }
    }
}
