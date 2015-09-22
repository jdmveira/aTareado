namespace Jdmveira.aTareado.Test.Entities.GtdAction
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;

    [TestClass]
    public class When_Property_Changes_In_GtdAction: INotifyPropertyChangedRelatedTests
    {
        [TestMethod]
        public void It_Must_Raise_NotifyProperty_Changed_On_ScheduleInfo()
        {
            GtdAction a = new GtdAction();
            ActionScheduleInfo asi = new ActionScheduleInfo();

            InitializeINotifyPropertyChangeInstance(a);

            a.Schedule = asi;

            string expected = "Schedule";
            var actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(expected, actual, "Property Schedule must change");
        }
                
        [TestMethod]
        public void It_Must_Raise_NotifyProperty_Changed_On_IsImportant()
        {
            GtdAction a = new GtdAction();
            bool important = !a.IsImportant;

            InitializeINotifyPropertyChangeInstance(a);

            a.IsImportant = important;

            string expected = "IsImportant";
            var actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(expected, actual, "Property IsImportant must change");
        }

        [TestMethod]
        public void It_Must_Raise_NotifyProperty_Changed_On_PercentageCompleted()
        {
            GtdAction a = new GtdAction();
            double pc = 100.0;

            InitializeINotifyPropertyChangeInstance(a);

            a.PercentageCompleted = pc;

            string expected = "PercentageCompleted";
            var actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(expected, actual, "Property PercentageCompleted must change");
        }
    }
}
