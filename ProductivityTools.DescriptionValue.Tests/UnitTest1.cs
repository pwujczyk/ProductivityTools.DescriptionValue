using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductivityTools.DescriptionValue.Tests
{
    enum EnumExample
    {
        [System.ComponentModel.Description("OneValue")]
        One,
        Two
    }

    class TestClass
    {
        [System.ComponentModel.Description("Property description")]
        public EnumExample Enum { get; set; }

        [System.ComponentModel.Description("Method description")]
        public void Method1() { }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnumDescription()
        {
            var testClass = new TestClass();
            var rEnum=testClass.Enum.GetDescription();
            Assert.AreEqual("OneValue", rEnum);
        }

        [TestMethod]
        public void PropertyDescription()
        {
            var testClass = new TestClass();

            var rProperty = testClass.GetType().GetPropertyDescription("Enum");
            Assert.AreEqual("Property description", rProperty);
        }


        [TestMethod]
        public void MethodDescription()
        {
            var testClass = new TestClass();
            var rProperty = testClass.GetType().GetMethodDescription("Method1");
            Assert.AreEqual("Method description", rProperty);
        }
    }
}
