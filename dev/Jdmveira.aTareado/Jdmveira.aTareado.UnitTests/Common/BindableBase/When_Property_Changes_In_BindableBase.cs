namespace Jdmveira.aTareado.Common.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using aTareado.Test;
    using System.Threading;
    using System;

    [TestClass]
    public class When_Property_Changes_In_Bindable_Base : BindableBaseRelatedTests
    {
        [TestMethod]
        public void It_Raises_Property_Change_Evento_On_The_Correct_Property()
        {
            BindableClass bc = new BindableClass();

            string expected = "MyProp";
            string actual = string.Empty;

            InitializeINotifyPropertyChangeInstance(bc);

            bc.MyProp = "Value";

            actual = GetInfoRegardingPropertyName();

            Assert.AreEqual<string>(expected, actual, "Property invoqued must have different name");
        }

        [TestMethod]
        public void It_Must_Not_Raise_If_Value_Does_Not_Change()
        {
            BindableClass bc = new BindableClass();
            string value = "My Property Test";
            
            bc.MyProp = value;

            // [Jdmv] Esto es innecesario pero lo hice por practicar
            Func<string, bool> expected = delegate (string s)
            {
                return string.IsNullOrEmpty(s);
            };

            InitializeINotifyPropertyChangeInstance(bc);

            bc.MyProp = value;

            string actual = GetInfoRegardingPropertyName();

            Assert.IsTrue(expected(actual), "INotifyPropertyChanged must not be called if value has not change");
        }
    }
}
