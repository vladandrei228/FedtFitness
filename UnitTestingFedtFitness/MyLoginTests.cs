using System;
using System.Linq;
using FedtFitness.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestingFedtFitness
{
    [TestClass]
    public class MyLoginTests
    {
        [TestMethod]
        public void TestLogin_WithNullUserName_Fails()
        {
            //Arrange
            RALVM lvm = new RALVM();

            //Act
            bool Result = lvm.Username.Contains(null);

            //Assert
            Assert.AreSame(null, Result);

        }

        [TestMethod]
        public void TestLogin_WithNullPassWord_Fails()
        {
            //Arrange
            RALVM lvm = new RALVM();

            //Act
            bool Result = lvm.Password.Contains(null);

            //Assert
            Assert.AreSame(null, Result);

        }



        //[TestMethod]
        //public void TestLogin_WithPopulatedPassWord_Passes()
        //{
        //    //Arrange
        //    RALVM lvm = new RALVM();

        //    //Act
        //    bool Result = lvm.Password.Contains(char.MaxValue);

        //    //Assert
        //    Assert.AreSame(expected:lvm.Password.Length <= 32, Result);

        //}

    }
}
