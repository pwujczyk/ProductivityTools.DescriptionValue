using Microsoft.VisualStudio.TestPlatform.CrossPlatEngine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace ProductivityTools.DescriptionValue.Tests
{
    enum EnumExample
    {
        [System.ComponentModel.Description("OneValue")]
        One,
        Two
    }

    [System.ComponentModel.Description("Class description")]
    class TestClass
    {
        [System.ComponentModel.Description("Field description")]
        public string Field;

        [System.ComponentModel.Description("Property description")]
        public EnumExample Enum { get; set; }

        public string PropertyWithoutDescription { get; set; }

        [System.ComponentModel.Description("Method description")]
        public void Method1() { }
    }

    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void EnumDescription()
        {
            var testClass = new TestClass();
            var rEnum=testClass.Enum.GetDescription();
            Assert.AreEqual("OneValue", rEnum);
        }

        [TestMethod]
        public void EnumDescriptionExist()
        {
            var testClass = new TestClass();
            var rEnum = testClass.Enum.DescriptionExists();
            Assert.AreEqual(true, rEnum);
        }

        [TestMethod]
        public void EnumDescriptionDoesNotExist()
        {
            var testClass = new TestClass();
            testClass.Enum = EnumExample.Two;
            var rEnum = testClass.Enum.DescriptionExists();
            Assert.AreEqual(false, rEnum);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void EnumWithoutDescription()
        {
            var testClass = new TestClass();
            testClass.Enum = EnumExample.Two;
            var rEnum = testClass.Enum.GetDescription();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void PropertyWithoutDescription()
        {
            var testClass = new TestClass();
            var rEnum = testClass.GetType().GetPropertyDescription("PropertyWithoutDescription");
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
            var rProperty = typeof(TestClass).GetMethodDescription("Method1");
            Assert.AreEqual("Method description", rProperty);
        }

        [TestMethod]
        public void FieldDescription()
        {
            var field = typeof(TestClass).GetFieldDescription("Field");
            Assert.AreEqual("Field description", field);
        }

        [TestMethod]
        public void ClassDescription()
        {
            var field = typeof(TestClass).GetDescription();
            Assert.AreEqual("Class description", field);
        }
    }
}
