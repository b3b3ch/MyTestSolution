using Microsoft.VisualStudio.TestTools.UnitTesting;
using MySolution.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySolution.Common.Extensions.Tests
{
    [TestClass()]
    public class ArrayExtensionsTests
    {
        [TestMethod()]
        [DataRow(new int[] { 0, 0 }, 0)]
        [DataRow(new int[] { 1, 2 }, 3)]
        [DataRow(new int[] { 1, 1 }, 2)]
        [DataRow(new int[] { 3, 2 }, 5)]
        public void CountProperSum(int[] args, int expectedResult)
        {
            //arrange 
            var array = new int[] { args[0], args[1] };

            //act
            var actual = array.SumArguments();

            //assert
            Assert.AreEqual(expectedResult, actual);
        }

        [TestMethod()]
        [DataRow(new int[] { })]
        [DataRow(null)]
        [ExpectedException(typeof(ArgumentException), "Array can't be null or empty!")]
        public void ThrowsExceptionWhenArrayIsEmpty(int[] array)
        {
            //act
            array.SumArguments();
        }
    }
}