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
            //var items = new List<BankAcount> { new BankAcount { Personnummer = 940806 } };
            //Mockservice.Setup(m => m.GetAllData()).Returns(new List<BankAcount>());

            BankAccountTest BAT = new BankAccountTest(Mockservice.Object);

            //Act
            //var theReturn1 = Mockservice.Object.GetAllData();
            var theReturn2 = BAT.GetAllData();

            //Assert.Equal(theReturn1, theReturn2);
            Assert.Empty(theReturn2);
            Mockservice.Verify(m => m.GetAllData(), Times.Once);
        }

        [Fact]
        public void AddValue_AddAccountToEmptyList()
        {
            //Arrange
            var Mockservice = new Mock<IApiRequestSend<BankAcount>>();
            //Mockservice.Setup(m => m.AddAcount(It.IsAny<BankAcount>()));

            BankAccountTest BAT = new BankAccountTest(Mockservice.Object);
            BankAcount B = new BankAcount { Personnummer = 940806 };

            BAT.AddAcount(B);
            //Mockservice.Object.AddAcount(B);

            Assert.Single(BAT.TheAcount);
            Mockservice.Verify(m => m.AddEntity(It.IsAny<BankAcount>()), Times.Once);

        }

        [Fact]
        public void AddValue_AddAccountToNotEmptyList()
        {
            //Arrange
            var Mockservice = new Mock<IApiRequestSend<BankAcount>>();
            //Mockservice.Setup(m => m.AddAcount(It.IsAny<BankAcount>()));

            BankAccountTest BAT = new BankAccountTest(Mockservice.Object);
            BankAcount A = new BankAcount { Personnummer = 940806 };
            BankAcount B = new BankAcount { Personnummer = 910531 };
            
            BAT.TheAcount.Add(A);
            BAT.AddAcount(B);
            //Mockservice.Object.AddAcount(A);
            //Mockservice.Object.AddAcount(B);

            Assert.Equal(2, BAT.TheAcount.Count);
            Mockservice.Verify(m => m.AddEntity(It.IsAny<BankAcount>()), Times.Once());
        }
    }
}
