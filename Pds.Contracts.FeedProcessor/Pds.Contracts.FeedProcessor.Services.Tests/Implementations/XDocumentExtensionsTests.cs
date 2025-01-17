﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pds.Contracts.FeedProcessor.Services.Implementations;
using System;
using System.Xml.Linq;

namespace Pds.Contracts.FeedProcessor.Services.Tests.Implementations
{
    [TestClass]
    public class XDocumentExtensionsTests
    {
        [TestMethod]
        public void LowerCaseAllElementNames_XDocument_NullArgument_ThrowsException()
        {
            // Arrange
            XDocument document = null;

            // Act
            Action act = () => document.LowerCaseAllElementNames();

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void LowerCaseAllElementNames_XDocument_ConvertsCurrentElement()
        {
            // Arrange
            string expectedString = @"<root>
  <childofroot>Some Mixed Case Value</childofroot>
</root>";
            XDocument document = XDocument.Parse("<Root><childOfRoot>Some Mixed Case Value</childOfRoot></Root>");

            // Act
            document.LowerCaseAllElementNames();

            // Assert
            document.ToString().Should().BeEquivalentTo(expectedString);
        }

        [TestMethod]
        public void LowerCaseAllElementNames_XElement_NullArgument_ThrowsException()
        {
            // Arrange
            XElement element = null;

            // Act
            Action act = () => element.LowerCaseAllElementNames();

            // Assert
            act.Should().Throw<ArgumentNullException>();
        }

        [TestMethod]
        public void LowerCaseAllElementNames_XElement_ConvertsCurrentElement()
        {
            // Arrange
            string expectedString = @"<root>
  <childofroot>Some Mixed Case Value</childofroot>
</root>";
            XDocument document = XDocument.Parse("<Root><childOfRoot>Some Mixed Case Value</childOfRoot></Root>");

            // Act
            document.Element("Root").LowerCaseAllElementNames();

            // Assert
            document.Element("root").ToString().Should().BeEquivalentTo(expectedString);
        }
    }
}
