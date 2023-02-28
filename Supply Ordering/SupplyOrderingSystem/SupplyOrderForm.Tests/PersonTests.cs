using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplyOrderForm;
using System.Data;

namespace SupplyOrderForm.Tests
{
    [TestClass]
    public class MyTestClass
    {

        [TestMethod]
        [DataRow("John", "Smith", "jsmith@aol.com", "614-123-1234", 1, "John","Smith","jsmith@aol.com","614-123-1234")]
        
        public void ValidatePersonConstructorWorksWithPhoneNumberAndNullPhoneNumber(string firstName, string lastName, string email, string phone, int personId, string result)
        {
            // Arrange
            Person testPerson = new Person(firstName, lastName, email, phone, personId);

            // Act
            string actualResult = testPerson.ToString();
            // Assert
            Assert.AreEqual(result, actualResult, $"Expected {result}, but method returned {actualResult}");
        }
    }

    [TestMethod]
        [DataRow("John", "Smith", "jsmith@aol.com", "614-123-1234", 1, "John Smith                 jsmith@aol.com                     614-123-1234   ")]
        [DataRow("John","Smith","jsmith@aol.com", null,1,"John Smith                 jsmith@aol.com                                    ")]
        public void ValidatePersonToStringMethod(string firstName, string lastName, string email, string phone, int personId, string result)
        {
            // Arrange
            Person testPerson = new Person(firstName, lastName, email, phone, personId);

            // Act
            string actualResult = testPerson.ToString();
            // Assert
            Assert.AreEqual(result, actualResult, $"Expected {result}, but method returned {actualResult}");
        }
    }
}
