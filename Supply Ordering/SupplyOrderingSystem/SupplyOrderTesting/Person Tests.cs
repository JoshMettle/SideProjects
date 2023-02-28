using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplyOrderForm;

namespace SupplyOrderForm
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [DataRow("John","Smith", "jsmith@test.com","413-123-1234", 1,"'John",1, "413-123-1234")]
        [DataRow("Jim","Wilson", "jwilson@test.com",null, 2,"'John",2, null)]
        public void ValidatePersonConstructor(string firstName, string lastName, string email, string phone, int id,string resultFirst, int resultId, string resultPhone)
        {
            // Arrange

            // Act
            Person testPerson = new Person(firstName, lastName, email, phone, id);
            // Assert
            Assert.AreEqual(resultFirst, testPerson.FirstName, $"Expected first name: {resultFirst}, Actual first name: {testPerson.FirstName}");
            Assert.AreEqual(resultId, testPerson.PersonId, $"Expected PersonId: {resultId}, Actual PersonId: {testPerson.PersonId}");
            Assert.AreEqual(resultPhone, testPerson.PhoneNumber, $"Expected PersonId: {resultPhone}, Actual PersonId: {testPerson.PhoneNumber}");
        }

        [TestMethod]
        [DataRow("John", "Smith", "jsmith@test.com", "413-123-1234", 1, "John Smith                 jsmith@test.com                    413-123-1234   ")]
        [DataRow("Jim", "Wilson", "jwilson@test.com", null, 2, "Jim Wilson                 jwilson@test.com                                  ")]
        public void ValidatePersonToStringMethod(string firstName, string lastName, string email, string phone, int id, string result)
        {
            // Act
            Person testPerson = new Person(firstName, lastName, email, phone, id);
            // Assert
            Assert.AreEqual(result, testPerson.ToString(), $"Expected first name: {result}, Actual: {testPerson}");
        }
    }
}
