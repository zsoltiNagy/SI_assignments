using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlayWithRegex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayWithRegex.Tests
{
    [TestClass()]
    public class ValidatorTests
    {
        [TestMethod()]
        public void ValidName_NameStartinWithSpecialLetterIsValid()
        {
            var sample = "Ézsau";
            var result = Validator.ValidName(sample);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidName_NameContainingOnlyEnglishLettersIsValid()
        {
            var sample = "pop";
            var result = Validator.ValidName(sample);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ValidName_NameValidationIsCaseInsensitive()
        {
            var sample = "oPPo";
            var result = Validator.ValidName(sample);
            Assert.IsTrue(result);
        }


        [TestMethod()]
        public void ValidEmailTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ValidPhoneNumberTest()
        {
            Assert.Fail();
        }
    }
}