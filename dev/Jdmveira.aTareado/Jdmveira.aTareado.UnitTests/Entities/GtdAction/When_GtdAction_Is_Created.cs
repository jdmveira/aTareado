namespace Jdmveira.aTareado.Test.Entities.GtdAction
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Jdmveira.aTareado.Entities;

    [TestClass]
    public class When_GtdAction_Is_Created
    {
        [TestMethod]
        public void It_Is_Not_Important_By_Default()
        {
            GtdAction a = new GtdAction();

            Assert.IsFalse(a.IsImportant, "An Action is not important by default");
        }

        [TestMethod]
        public void It_Has_Not_ScheduleInfo_By_Default ()
        {
            GtdAction a = new GtdAction();

            Assert.IsNull(a.Schedule, "An Action has not schedule by default");
        }

        [TestMethod]
        public void It_Has_A_Zero_Percent_Completeness_By_Default()
        {
            GtdAction a = new GtdAction();

            Assert.AreEqual<double?>(default(double?), a.PercentageCompleted);
        }
    }
}
