namespace Jdmveira.aTareado.Test.Entities.ActionScheduleInfo
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;
    using System.Threading;
    using System.ComponentModel;

    [TestClass]
    public class When_Property_Changes_In_ActionScheduleInfo: INotifyPropertyChangedRelatedTests
    {
        [TestMethod]
        public void It_Must_Raise_PropertyChanged_On_StartDate()
        {
            DateTime? sd = DateTime.Now;

            string propertyName = "StartDate";
            string actual = String.Empty;

            var asi = new ActionScheduleInfo();

            InitializeINotifyPropertyChangeInstance(asi);

            asi.StartDate = sd;

            actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(propertyName, actual, "Property called must be StartDate" );
        }

        [TestMethod]
        public void It_Must_Raise_PropertyChanged_On_DueDate()
        {
            DateTime? dd = DateTime.Now;

            string propertyName = "DueDate";
            string actual = String.Empty;

            var asi = new ActionScheduleInfo();

            InitializeINotifyPropertyChangeInstance(asi);

            asi.DueDate = dd;

            actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(propertyName, actual, "Property called must be DueDate");
        }

        [TestMethod]
        public void It_Must_Raise_PropertyChanged_On_CreationDate()
        {
            DateTime cd = DateTime.Now.AddDays (-1);

            string propertyName = "CreationDate";
            string actual = String.Empty;

            var asi = new ActionScheduleInfo();

            InitializeINotifyPropertyChangeInstance(asi);

            asi.CreationDate = cd;

            actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(propertyName, actual, "Property called must be CreationDate");
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentOutOfRangeException), "StartDate must be previous or equal to DueDate")]
        public void It_Must_Raise_ArgumentOurOfRangeException_If_DueDate_Is_Constructed_Previous_To_StartDate ()
        {
            DateTime sd = DateTime.Now;
            DateTime dd = sd.AddMilliseconds(-1);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "StartDate must be previous or equal to DueDate")]
        public void It_Must_Raise_ArgumentOurOfRangeException_If_StartDate_Is_Set_Back_To_DueDate ()
        {
            DateTime sd = DateTime.Now;
            DateTime dd = sd.AddDays(1);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);

            asi.StartDate = asi.DueDate.Value.AddMilliseconds(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException), "StartDate must be previous or equal to DueDate")]
        public void It_Must_Raise_ArgumentOurOfRangeException_If_DueDate_Is_Set_Previous_To_StartDate()
        {
            DateTime sd = DateTime.Now;
            DateTime dd = sd.AddDays(1);

            ActionScheduleInfo asi = new ActionScheduleInfo(sd, dd);

            asi.DueDate = asi.StartDate.Value.AddMilliseconds(-1);
        }
    }
}
