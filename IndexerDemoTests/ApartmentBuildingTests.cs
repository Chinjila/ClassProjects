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

        public void Bob_1A_lives_in_1A(){
            //arrange
            ApartmentBuilding b = new ApartmentBuilding();

            //act
            Apartment a = b.GetApartment("1A");
            //assert
            Assert.AreEqual("Bob-1A", a.Owner);
        }
    }
}