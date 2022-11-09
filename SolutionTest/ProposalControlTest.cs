using DAL;
using BLL;
using NUnit.Framework;
using System.Collections.Generic;

namespace DLL
{
    public class ProposalControlTest
    {
        private ProposalControl PC;
        private Client client;
        private List<Estate> _list;
        [SetUp]
        public void Setup()
        {
             PC = new ProposalControl();
             client = new Client("Adam", "Green", "AD12345678", 12345, "1-room flat");
             _list = new List<Estate>();
        }

        [Test]
        public void Test_SelectDefaultProp()
        {
            // ARRANGE
            List<Estate> one = new List<Estate>();
            //ACT
            one = PC.SelectDefaultProp(_list, client);
            //ASSERT
            Assert.AreEqual(new List<Estate>(), one);
        }
        [Test]
        public void Test_SelectBoundProp()
        {
            // ARRANGE
            List<Estate> one = new List<Estate>();
            double high = 9000.99;
            double low = 100.10;
            string type = "1-room flat";
            //ACT
            one = PC.SelectBoundProp(_list, client, type, high, low);
            //ASSERT
            Assert.AreEqual(new List<Estate>(), one);
        }
    }
}