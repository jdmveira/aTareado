namespace Jdmveira.aTareado.Entities.UnitTests
{
	using System;
	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using Jdmveira.aTareado.Entities;

	[TestClass]
	public class GtdActionTests
	{
		[TestMethod]
		public void TestDefaultConstructor()
		{
			Guid id = Guid.NewGuid();
			string title = "Title";
			string description = "Description";

			var ac = new GtdAction(id, title, description);

			Assert.AreEqual<Guid>(id, ac.UniqueId);
			Assert.AreEqual<string>(title, ac.Title);
			Assert.AreEqual<string>(description, ac.Description);
			Assert.IsFalse(ac.IsImportant);
			Assert.IsFalse(ac.PercentageCompleted.HasValue);
		}

		[TestMethod]
		public void TestChangeActionTitle ()
		{
			Guid id = Guid.NewGuid();
			string title = "Title";
			string description = "Description";

			var ac = new GtdAction(id, title, description);

			title = "New title";

			ac.Title = title;

			Assert.AreEqual<string>(title, ac.Title);
		}

		[TestMethod]
		public void TestChangeActionDescription()
		{
			Guid id = Guid.NewGuid();
			string title = "Title";
			string description = "Description";

			var ac = new GtdAction(id, title, description);

			description = "New description";

			ac.Description= description;

			Assert.AreEqual<string>(description, ac.Description);
		}

        [TestMethod]
        public void TestChangeActionImportant()
        {
            Guid id = Guid.NewGuid();
            string title = "Title";
            string description = "Description";
            bool important = true;

            var ac = new GtdAction(id, title, description);

            ac.IsImportant = important;

            Assert.AreEqual<bool>(important, ac.IsImportant);
        }

        [TestMethod]
        public void TestChangeActionScheduleInfo()
        {
            Guid id = Guid.NewGuid();
            string title = "Title";
            string description = "Description";
            DateTime startDate = DateTime.Now;
            DateTime dueDate = startDate.AddDays(1);

            ActionScheduleInfo asi = new ActionScheduleInfo(startDate, dueDate);

            var ac = new GtdAction(id, title, description);

            ac.Schedule = asi;

            Assert.IsNotNull(ac.Schedule);
            Assert.AreEqual<ActionScheduleInfo>(asi, ac.Schedule);
        }

        [TestMethod]
		public void TestGuidEquatable()
		{
			Guid id = Guid.NewGuid();
			GtdAction action = new GtdAction(id, "Title", "Description");

			Assert.IsTrue(action.Equals (id));
		}

        [TestMethod]
        public void TestActionWithNoScheduleByDefault ()
        {
            Guid id = Guid.NewGuid();
            GtdAction action = new GtdAction(id, "Title", "Description");

            Assert.IsNull(action.Schedule);
        }

        [TestMethod]
        public void TestKindOfGtdEntityActionWithNoScheduleByDefaul()
        {
            Guid id = Guid.NewGuid();
            GtdAction action = new GtdAction(id, "Title", "Description");

            Assert.IsNull(action.Schedule);
            Assert.AreEqual<KindOfGtdEntity>(KindOfGtdEntity.Todo, action.KindOf());
        }

        [TestMethod]
        public void TestKindOfGtdEntityActionWithNotDefinedDueDate ()
        {
            Guid id = Guid.NewGuid();
            GtdAction action = new GtdAction(id, "Title", "Description");
            ActionScheduleInfo asi = new ActionScheduleInfo();

            asi.StartDate = DateTime.Now;


        }
    }
}
