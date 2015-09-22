namespace Jdmveira.aTareado.Test.Entities.ActionScheduleInfo
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;
    using System.Threading;

    [TestClass]
    public class When_Creating_Action_Schedule_Info
    {
        [TestMethod]
        public void It_Must_Have_Default_StartDate_By_Default()
        {
            ActionScheduleInfo asi = new ActionScheduleInfo();

            Assert.IsFalse(asi.StartDate.HasValue, "StartDate must not be initialized by default");
        }

        [TestMethod]
        public void It_Must_Have_Default_DueDate_By_Default()
        {
            ActionScheduleInfo asi = new ActionScheduleInfo();

            Assert.IsFalse(asi.DueDate.HasValue, "DueDate must not be initialized by default");
        }

        [TestMethod]
        public void It_Must_Have_CreationDate_By_Default ()
        {
            var dt1 = DateTime.UtcNow;

            Thread.Sleep(1);

            var asi = new ActionScheduleInfo();

            Thread.Sleep(2);

            var dt2 = DateTime.UtcNow;

            Assert.IsTrue(dt1 <= dt2, "Control dates must be different");
            Assert.IsTrue(dt1 <= asi.CreationDate, "CreationDate must be smaller than starting test date");
            Assert.IsTrue(dt2 >= asi.CreationDate, "CreationDate must be greatet than ending test date");
        }

        [TestMethod]
        public void It_Must_Have_StartingDate_Initialized_When_Passed_As_Parameter ()
        {
            var expected = DateTime.Now;

            var asi = new ActionScheduleInfo(expected, default(DateTime?));

            Assert.IsTrue(asi.StartDate.HasValue, "StartDate must be initialized");
        }

        [TestMethod]
        public void It_Must_Have_The_Passed_StartDate_In_Utc ()
        {
            var startDate = DateTime.Now;
            var expected = startDate.ToUniversalTime();

            var asi = new ActionScheduleInfo(startDate, default(DateTime?));

            Assert.AreEqual<DateTime>(expected, asi.StartDate.Value, "StartDate must be the passed value converted to UTC");
        }

        [TestMethod]
        public void It_Must_Have_DueDate_Initialized_When_Passed_As_Parameter()
        {
            var expected = DateTime.Now;

            var asi = new ActionScheduleInfo(default(DateTime?), expected);

            Assert.IsTrue(asi.DueDate.HasValue, "DueDate must be initialized");
        }

        [TestMethod]
        public void It_Must_Have_The_Passed_DueDate_In_Utc()
        {
            var dueDate = DateTime.Now;
            var expected = dueDate.ToUniversalTime();

            var asi = new ActionScheduleInfo(default(DateTime?), dueDate);

            Assert.AreEqual<DateTime>(expected, asi.DueDate.Value, "DueDate must be the passed value converted to UTC");
        }

        [TestMethod]
        public void It_Must_Have_The_Passed_CreatinDate_In_Utc ()
        {
            var creationDate = DateTime.Now;
            var expected = creationDate.ToUniversalTime();

            var asi = new ActionScheduleInfo(default(DateTime?), default(DateTime?), creationDate);

            Assert.AreEqual<DateTime>(expected, asi.CreationDate, "CreationDate must be the passed value converted to UTC");
        }
    }
}
