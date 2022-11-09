using BLL;
using DAL;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DLL
{
    internal class EstateControlTest
    {
        // private List<Estate> EstateList
        private EstateControl EC;
        [SetUp]
        public void Setup()
        {
            EC = new EstateControl();
        }
        [Test]
        public void Test_CreateDeleteEstate()
        {
            // ARRANGE
            List<Estate> Estates = new List<Estate>();
           
            int id = 13372;
            var idReader = new StringReader(id.ToString());

            string type = "1-room flat";
            var typeReader = new StringReader(type);
            
            double cost = 123.33;
            var costReader = new StringReader(cost.ToString());

            double square = 222.22;
            var squareReader = new StringReader(id.ToString() + type + cost.ToString() + square.ToString());

            //ACT

           
        
 
            Console.SetIn(idReader);
            EC.CreateEstate();
            Console.SetIn(typeReader);

            Console.SetIn(costReader);


            Console.SetIn(squareReader);





            var stringReader = new StringReader(id.ToString());
            Console.SetIn(stringReader);
            string s = EC.DeleteEstate();
            //ASSERT
            Assert.AreEqual("Deleting is successfull", s);
        }
    }
}
