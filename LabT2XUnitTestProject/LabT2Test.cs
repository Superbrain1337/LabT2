using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using LabT2.Controllers;
using LabT2.Models;
using Moq;

namespace LabT2XUnitTestProject
{
    public class LabT2Test
    {
        [Fact]
        public void GetAllData_EmptyList()
        {
            //Arrange
            var Mockservice = new Mock<IApiRequestSend<BankAcount>>();

            BankAccountController BAC = new BankAccountController(Mockservice.Object);

            //Act
            var theReturn = BAC.GetAllData();
            
            Assert.Empty(theReturn);
            Mockservice.Verify(m => m.GetAllData(), Times.Once);
        }

        [Fact]
        public void GetAllData_NotEmptyList()
        {
            //Arrange
            var Mockservice = new Mock<IApiRequestSend<BankAcount>>();

            BankAccountController BAC = new BankAccountController(Mockservice.Object);
            BankAcount B = new BankAcount { Personnummer = 940806 };

            //Act
            BAC.IApiRequestSend.AddEntity(B);
            BAC.TheAcount.Add(B);
            var theReturn = BAC.GetAllData();

            Assert.Single(theReturn);
            Mockservice.Verify(m => m.GetAllData(), Times.Once);
        }

        [Fact]
        public void AddValue_AddAccountToEmptyList()
        {
            //Arrange
            var Mockservice = new Mock<IApiRequestSend<BankAcount>>();

            BankAccountController BAC = new BankAccountController(Mockservice.Object);
            BankAcount B = new BankAcount { Personnummer = 940806 };

            //Act
            BAC.AddAcount(B);

            Assert.Single(BAC.TheAcount);
            Mockservice.Verify(m => m.AddEntity(It.IsAny<BankAcount>()), Times.Once);

        }

        [Fact]
        public void AddValue_AddAccountToNotEmptyList()
        {
            //Arrange
            var Mockservice = new Mock<IApiRequestSend<BankAcount>>();

            BankAccountController BAC = new BankAccountController(Mockservice.Object);
            BankAcount A = new BankAcount { Personnummer = 940806 };
            BankAcount B = new BankAcount { Personnummer = 910531 };
            
            //Act
            BAC.TheAcount.Add(A);
            BAC.AddAcount(B);

            Assert.Equal(2, BAC.TheAcount.Count);
            Mockservice.Verify(m => m.AddEntity(It.IsAny<BankAcount>()), Times.Once());
        }
    }
}
