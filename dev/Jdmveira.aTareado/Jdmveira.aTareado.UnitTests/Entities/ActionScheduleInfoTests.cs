namespace Jdmveira.aTareado.Entities.UnitTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;

    [TestClass]
    public class ActionScheduleInfoTests
    {
        [TestMethod]
        public void TestDefaultConstructor()
        {
            DateTime dt1 = DateTime.Now;

            ActionScheduleInfo asi = new ActionScheduleInfo();

            DateTime dt2 = DateTime.Now;

            Assert.IsFalse(asi.StartDate.HasValue);
            Assert.IsFalse(asi.DueDate.HasValue);
            Assert.IsTrue(dt1 <= asi.CreationDate);
            Assert.IsTrue(dt2 >= asi.CreationDate);
        }

        [TestMethod]
        public void TestConstructorWithStartAndDueDateBothNull ()
        {
            DateTime dt1 = DateTime.Now;

            DateTime? sd = default(DateTime?);
            DateTime? dd = default(DateTime?);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);

            DateTime dt2 = DateTime.Now;

            Assert.IsFalse(asi.StartDate.HasValue);
            Assert.IsFalse(asi.DueDate.HasValue);
            Assert.IsTrue(dt1 <= asi.CreationDate);
            Assert.IsTrue(dt2 >= asi.CreationDate);

        }

        [TestMethod]
        public void TestConstructorWithStartDateNotNullAndDueDateNull()
        {
            DateTime dt1 = DateTime.Now;

            DateTime? sd = DateTime.Now;
            DateTime? dd = default(DateTime?);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);

            DateTime dt2 = DateTime.Now;

            Assert.IsTrue(asi.StartDate.HasValue);
            Assert.AreEqual<DateTime?>(sd.Value, asi.StartDate.Value);

            Assert.IsFalse(asi.DueDate.HasValue);
            Assert.IsTrue(dt1 <= asi.CreationDate);
            Assert.IsTrue(dt2 >= asi.CreationDate);
        }

        [TestMethod]
        public void TestConstructorWithStartDateNullAndDueDateNotNull()
        {
            DateTime dt1 = DateTime.Now;

            DateTime? dd = DateTime.Now;
            DateTime? sd = default(DateTime?);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);

            DateTime dt2 = DateTime.Now;

            Assert.IsTrue(asi.DueDate.HasValue);
            Assert.AreEqual<DateTime?>(dd.Value, asi.DueDate.Value);

            Assert.IsFalse(asi.StartDate.HasValue);
            Assert.IsTrue(dt1 <= asi.CreationDate);
            Assert.IsTrue(dt2 >= asi.CreationDate);
        }

        [TestMethod]
        public void TestConstructorWithStartAndDueDateNotNull()
        {
            DateTime dt1 = DateTime.Now;

            DateTime? sd = DateTime.Now;
            DateTime? dd = sd.Value.AddHours(10) ;

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);

            DateTime dt2 = DateTime.Now;

            Assert.IsTrue(asi.StartDate.HasValue);
            Assert.IsTrue(asi.DueDate.HasValue);

            Assert.AreEqual<DateTime?>(sd.Value, asi.StartDate);
            Assert.AreEqual<DateTime?>(dd.Value, asi.DueDate);

            Assert.IsTrue(dt1 <= asi.CreationDate);
            Assert.IsTrue(dt2 >= asi.CreationDate);
        }

        [TestMethod]
        public void TestConstructorWithStartAndDueDateNotNullAndCreationTimeDefined()
        {
            DateTime? sd = DateTime.Now;
            DateTime? dd = sd.Value.AddHours(10);
            DateTime ct = DateTime.Now.AddHours(-1);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd, ct);

            Assert.IsTrue(asi.StartDate.HasValue);
            Assert.IsTrue(asi.DueDate.HasValue);

            Assert.AreEqual<DateTime?>(sd.Value, asi.StartDate);
            Assert.AreEqual<DateTime?>(dd.Value, asi.DueDate);

            Assert.AreEqual<DateTime>(ct, asi.CreationDate);
        }

        [TestMethod]
        public void TestSetPropertyOnStartDate ()
        {
            ActionScheduleInfo asi = new ActionScheduleInfo();

            DateTime? sd = DateTime.Now;

            string propName = "StartDate";
            string changeOnProp = string.Empty;

            asi.PropertyChanged += delegate (object o, System.ComponentModel.PropertyChangedEventArgs e)
            {
                changeOnProp = e.PropertyName;
            };

            asi.StartDate = sd;

            Assert.IsFalse(string.IsNullOrEmpty(changeOnProp));
            Assert.AreEqual<string>(propName, changeOnProp);
            Assert.IsTrue(asi.StartDate.HasValue);
            Assert.AreEqual<DateTime?>(sd.Value, asi.StartDate);
        }

        [TestMethod]
        public void TestSetPropertyOnDueDate()
        {
            ActionScheduleInfo asi = new ActionScheduleInfo();

            DateTime? dd = DateTime.Now;

            string propName = "DueDate";
            string changeOnProp = string.Empty;

            asi.PropertyChanged += delegate (object o, System.ComponentModel.PropertyChangedEventArgs e)
            {
                changeOnProp = e.PropertyName;
            };

            asi.DueDate = dd;

            Assert.IsFalse(string.IsNullOrEmpty(changeOnProp));
            Assert.AreEqual<string>(propName, changeOnProp);
            Assert.IsTrue(asi.DueDate.HasValue);
            Assert.AreEqual<DateTime?>(dd.Value, asi.DueDate);
        }

        [TestMethod]
        public void TestSetPropertyOnCreationDate()
        {
            ActionScheduleInfo asi = new ActionScheduleInfo();

            DateTime cd = DateTime.Now;

            string propName = "CreationDate";
            string changeOnProp = string.Empty;

            asi.PropertyChanged += delegate (object o, System.ComponentModel.PropertyChangedEventArgs e)
            {
                changeOnProp = e.PropertyName;
            };

            asi.CreationDate = cd;

            Assert.IsFalse(string.IsNullOrEmpty(changeOnProp));
            Assert.AreEqual<string>(propName, changeOnProp);
            Assert.AreEqual<DateTime?>(cd, asi.CreationDate);
        }

        [TestMethod]
        public void TestTwoDefaultSchedulesEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            Assert.AreNotEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithDifferentInitializedDatesEquality ()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime sd1 = DateTime.Now;
            DateTime sd2 = sd1.AddTicks(1);

            DateTime dd1 = DateTime.Now;
            DateTime dd2 = dd1.AddTicks(1);

            asi1.StartDate = sd1;
            asi1.DueDate = dd1;
            asi2.StartDate = sd2;
            asi2.DueDate = dd2;

            Assert.AreNotEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithNotInitializedDueDatesAndIdenticalStartDatesEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime sd1 = DateTime.Now;
            DateTime sd2 = sd1;

            asi1.StartDate = sd1;
            asi2.StartDate = sd2;

            Assert.AreNotEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithNotInitializedStartDatesAndIdenticalDueDatesEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime dd1 = DateTime.Now;
            DateTime dd2 = dd1;

            asi1.DueDate = dd1;
            asi2.DueDate = dd2;

            Assert.AreNotEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithSameStartDatesButDifferentDueDatesEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime sd1 = DateTime.Now;
            DateTime sd2 = sd1; ;

            DateTime dd1 = DateTime.Now;
            DateTime dd2 = dd1.AddTicks(1);

            asi1.StartDate = sd1;
            asi1.DueDate = dd1;
            asi2.StartDate = sd2;
            asi2.DueDate = dd2;

            Assert.AreNotEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithSameDueDatesButDifferentStartDatesEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime sd1 = DateTime.Now;
            DateTime sd2 = sd1; 

            DateTime dd1 = DateTime.Now;
            DateTime dd2 = dd1;

            asi1.StartDate = sd1;
            asi1.DueDate = dd1;
            asi2.StartDate = sd2;
            asi2.DueDate = dd2;

            Assert.AreNotEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithSameDueAndStartDatesButDifferentCreationDateEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime sd1 = DateTime.Now;
            DateTime sd2 = sd1; 

            DateTime dd1 = DateTime.Now;
            DateTime dd2 = dd1;

            DateTime cd1 = DateTime.Now;
            DateTime cd2 = cd1.AddTicks(1);

            asi1.StartDate = sd1;
            asi1.DueDate = dd1;
            asi2.StartDate = sd2;
            asi2.DueDate = dd2;
            asi1.CreationDate = cd1;
            asi2.CreationDate = cd2;

            Assert.AreEqual<ActionScheduleInfo>(asi1, asi2);
        }

        [TestMethod]
        public void TestTwoSchedulesWithSameDueAndStartDatesAndEqualCreationDateEquality()
        {
            ActionScheduleInfo asi1 = new ActionScheduleInfo();
            ActionScheduleInfo asi2 = new ActionScheduleInfo();

            DateTime sd1 = DateTime.Now;
            DateTime sd2 = sd1;

            DateTime dd1 = DateTime.Now;
            DateTime dd2 = dd1;

            DateTime cd1 = DateTime.Now;
            DateTime cd2 = cd1;

            asi1.StartDate = sd1;
            asi1.DueDate = dd1;
            asi2.StartDate = sd2;
            asi2.DueDate = dd2;
            asi1.CreationDate = cd1;
            asi2.CreationDate = cd2;

            Assert.AreEqual<ActionScheduleInfo>(asi1, asi2);
        }
    }
}
