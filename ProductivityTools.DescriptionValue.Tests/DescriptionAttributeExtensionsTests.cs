using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel;
using ProductivityTools.DescriptionValue;
using FluentAssertions;

namespace ProductivityTools.DescriptionValue.Tests
{

    [TestClass]
    public class DescriptionAttributeExtensionsTests
    {

        public class TestClass
        {
            [System.ComponentModel.Description("Property1 Description")]
            public string Property1 { get; set; }

            public int Property2 { get; set; }
        }

        [TestMethod]
        public void GetPropertyDescription_ShouldReturnDescription_WhenDescriptionAttributeExists()
        {
            // Arrange
            var myClass = new TestClass();

            // Act
            string description = myClass.GetPropertyDescription(x => x.Property1);

            // Assert
            description.Should().Be("Property1 Description");
        }

        [TestMethod]
        public void GetPropertyDescription_ShouldReturnEmptyString_WhenDescriptionAttributeDoesNotExist()
        {
            // Arrange
            var myClass = new TestClass();

            // Act
            string description = myClass.GetPropertyDescription(x => x.Property2);

            // Assert
            description.Should().BeEmpty();
        }

        [TestMethod]
        public void DescriptionExists_ShouldReturnTrue_WhenDescriptionAttributeExists()
        {
            // Arrange
            var myClass = new TestClass();

            // Act
            bool exists = myClass.PropertyDescriptionExists(x => x.Property1);

            // Assert
            exists.Should().BeTrue();
        }

        [TestMethod]
        public void DescriptionExists_ShouldReturnFalse_WhenDescriptionAttributeDoesNotExist()
        {
            // Arrange
            var myClass = new TestClass();

            // Act
            bool exists = myClass.PropertyDescriptionExists(x => x.Property2);

            // Assert
            exists.Should().BeFalse();
        }
    }
}
