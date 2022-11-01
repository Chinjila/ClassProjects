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
        public void Bob_1A_lives_in_1A()
        {
            //arrange
            ApartmentBuilding b = new ApartmentBuilding();
            //act
            Apartment a = b.GetApartment("1A");
            //assert
            Assert.AreEqual("Bob-1A", a.Owner);
           
        }
        [TestMethod()]
        public void When_Lookup_NonExisting_Apartment_Should_Throw_ANF_Exception()
        {
            //arrange
            ApartmentBuilding b = new ApartmentBuilding();
            //act

            //assert
            Assert.ThrowsException<ApartmentNotFoundException>(() => b.GetApartment("5A"));

        }

        [TestMethod()]
        public void ApartmentBuilding_Should_Support_Indexer()
        {
            //arrange
            ApartmentBuilding b = new ApartmentBuilding();
            //act
            Apartment a = b["1A"];
            //assert
            Assert.AreEqual("Bob-1A", a.Owner);
        }

        public void Indexer_And_GetApartment_Should_Return_The_Same_Object()
        {
            //arrange
            ApartmentBuilding b = new ApartmentBuilding();
            //act
            ;
            //assert
            Assert.AreSame(b.GetApartment("1A"), b["1A"]);
        }
    }
}