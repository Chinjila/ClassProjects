using Microsoft.VisualStudio.TestTools.UnitTesting;
using IndexerDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndexerDemo.Tests
{
    [TestClass()]
    public class ApartmentBuildingTests
    {
        [TestMethod()]
        public void ApartmentBuildingTest()
        {
            //arrange
            ApartmentBuilding b = new ApartmentBuilding();
            //act
            Assert.AreEqual(9, b.ApartmentCount);
            //assert
        }
        [TestMethod()]
        public void Bob_1A_lives_in_1a()
        {
            ApartmentBuilding b = new ApartmentBuilding();
            Apartment a = b.GetApartment("1A");
            Assert.AreEqual("Bob-1A", a.Owner);
        }
        [TestMethod()]
        public void ApartmentBuild_Should_Support_Indexer()
        {
            ApartmentBuilding b = new ApartmentBuilding();
            Apartment a = b["1A"];
            Assert.AreEqual("Bob-1A", a.Owner);
        }
        [TestMethod()]
        public void Indexer_And_GetApartment_Should_Return_The_Same_Object()
        {
            ApartmentBuilding b = new ApartmentBuilding();

        }
    }
}