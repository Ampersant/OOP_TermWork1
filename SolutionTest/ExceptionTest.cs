using BLL;
using DAL;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exception = BLL.Exception;

namespace DLL
{
    internal class ExceptionTest
    {
        private Exception ex;
        [SetUp]
        public void Setup()
        {
            // ARRANGE
            string s = "12345678";
            ex = new Exception(s, @"\d");
        }
        [Test]
        public void Test_ExceptionMaking()
        {
            //ACT
            string res = ex.Check();
            //ASSERT
            Assert.AreEqual("12345678", res);
        }
        [Test]
        public void TestErrorID()
        {
            // ARRANGE
            string check = "Object with such ID doesn't exist";
            // ACT
            string res = Exception.ErrorID();
            // ASSERT
            Assert.AreEqual(check, res);
        }
        [Test]
        public void TestErrorNullFile()
        {
            // ARRANGE
            string check = "File is empty, please enter your data firstly.";
            // ACT
            string res = Exception.ErrorNullFile();
            // ASSERT
            Assert.AreEqual(check, res);
        }
        [Test]
        public void TestErrorWrongSer()
        {
            // ARRANGE
            string check = "Error: Wrong type of serialization, please select XML or JSON.";
            // ACT
            string res = Exception.ErrorWrongSer();
            // ASSERT
            Assert.AreEqual(check, res);
        }
        [Test]
        public void TestInputError()
        {
            // ARRANGE
            string check = "Incorrect data, please try again:";
            // ACT
            string res = Exception.InputError();
            // ASSERT
            Assert.AreEqual(check, res);
        }
        [Test]
        public void TestErrorAlreadyExist()
        {
            // ARRANGE
            string check = "Object with such ID is already exist, please enter unique one:";
            // ACT
            string res = Exception.ErrorAlreadyExist();
            // ASSERT
            Assert.AreEqual(check, res);
        }

    }
}

