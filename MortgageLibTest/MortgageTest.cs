using MortagageLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageLibTest
{
    [TestClass]
    public class MortgageTest
    {
        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Construct_Mortgage_With_OriginationDate_In_The_Past_Should_ThrowException()
        {
            //arrange
            Mortgage m;
            //act
            m = new Mortgage(
                DateTime.Now.AddDays(-3),
                MortgageDuration.ThirtyYears
                );
            //assert
        }

        [TestMethod()]
        public void New_15Years_Mortgage_Should_Have_180_Payments() {
            //arrange - instantiate a new Mortgage with 15 Year
            //act - no need to act for this one
            //assert
            Mortgage m;
          
            m = new Mortgage(
                DateTime.Now.AddDays(5),
                MortgageDuration.FifteenYears
                );
            Assert.AreEqual(180, m.Payments.Count);
        }

        [TestMethod()]
        public void New_30Years_Mortgage_Should_Have_360_Payments() {
            Mortgage m;
            //act
            m = new Mortgage(
                DateTime.Now.AddDays(5),
                MortgageDuration.ThirtyYears
                );
            Assert.AreEqual(360, m.Payments.Count);
        }

    }
}
