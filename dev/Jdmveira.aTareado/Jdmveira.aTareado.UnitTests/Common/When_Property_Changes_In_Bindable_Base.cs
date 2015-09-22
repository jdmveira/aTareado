namespace Jdmveira.aTareado.Common.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using aTareado.Test;
    using System.Threading;

    [TestClass]
    public class When_Property_Changes_In_Bindable_Base: BindableBaseRelatedTests
    {
        [TestMethod]
        public void It_Raises_Property_Changed_Event()
        {
            BindableBase bb = IocWrapper.GetInstance<BindableBase>();

            bool eRaised = false;
            Mutex mx = new Mutex(false);

            bb.PropertyChanged += delegate { };

            mx.WaitOne();
            Assert.IsTrue(eRaised, "Notify Property Changed");
        }

        private void Bb_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        [TestMethod]
        public void It_Must_Call_The_Correct_Property()
        {
            BindableBase bb = IocWrapper.GetInstance<BindableBase>();

            bool eRaised = false;
            Mutex mx = new Mutex(false);



            mx.WaitOne();
            Assert.IsTrue(eRaised, "Notify Property Changed");
        }
    }
}
