namespace Jdmveira.aTareado.Test.Entities.GtdAction
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;

    [TestClass]
    public class When_Setting_ScheduleInfo_To_A_GtdAction
    {
        [TestMethod]
        public void It_Must_Be_A_Passed_Action_If_DueDate_Is_Previous_To_Today()
        {
            GtdAction a = new GtdAction();

            DateTime dd = DateTime.Now.AddDays(-1);            
            ActionScheduleInfo asi = new ActionScheduleInfo(default(DateTime?), dd);

            a.Schedule = asi;

            var expected = KindOfGtdAction.Passed;
            var actual = GtdAction.KindOf(a);

            Assert.AreEqual<KindOfGtdAction>(expected, actual, "Action must be Passed because DueDate was yesterday");
        }

        [TestMethod]
        public void It_Must_Be_A_Today_Action_If_DueDate_Is_Whithin_Today()
        {
            GtdAction a = new GtdAction();

            DateTime dd = ScheduleInfoTestHelper.CreateForEndOfDay(DateTime.Now);
            ActionScheduleInfo asi = new ActionScheduleInfo(default(DateTime?), dd);

            a.Schedule = asi;

            var expected = KindOfGtdAction.Today;
            var actual = GtdAction.KindOf(a);

            Assert.AreEqual<KindOfGtdAction>(expected, actual, "Action must be Today because DueDate is whithin today");
        }
    }
}
