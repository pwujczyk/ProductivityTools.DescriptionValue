using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProductivityTools.DescriptionValue.Tests
{
    enum E
    {
        [System.ComponentModel.Description("OneValue")]
        one,
        two
    }

    class TestClass
    {
        [System.ComponentModel.Description("Property description")]
        public E Enum { get; set; }
    }

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void EnumDescription()
        {
            var testClass = new TestClass();
            var r=testClass.Enum.GetDescription();
            Assert.AreEqual("OneValue", r);
        }
    }
}
