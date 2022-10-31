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
        public void ConstructMortgageWithOriginationDateInThePastShouldThrowException() //next time use underscore to separate
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
    }
}
