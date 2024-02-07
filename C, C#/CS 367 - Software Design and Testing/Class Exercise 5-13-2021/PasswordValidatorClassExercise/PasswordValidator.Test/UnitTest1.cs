using NUnit.Framework;

namespace PasswordValidator.Test
{
    public class Tests
    {
        private PasswordValidatorV1 _Validate;
        [SetUp]
        public void Setup()
        {
            _Validate = new PasswordValidatorV1();
        }

        [Test]
        public void ValidatorTest_MeetsAllRequirementsWithASymbol()
        {
            bool v = _Validate.Validate("_This*Pass%Works");

            Assert.IsTrue(v);
        }

        [Test]
        public void ValidatorTest_FailsCapitalRule()
        {
            bool v = _Validate.Validate("_thispasswordfails");

            Assert.IsFalse(v);
        }

        [Test]
        public void ValidatorTest_FailsLowerCaseRule()
        {
            bool v = _Validate.Validate("_THISPASSWORDFAILS");

            Assert.IsFalse(v);
        }

        [Test]
        public void ValidatorTest_FailsNonalphaCaseRule()
        {
            bool v = _Validate.Validate("ThisPasswordFails");

            Assert.IsFalse(v);
        }

        [Test]
        public void ValidatorTest_FailsNonAlphaWithNumberCaseRule()
        {
            bool v = _Validate.Validate("0ThisPassWorks");

            Assert.IsFalse(v);
        }

        [Test]
        public void ValidatorTest_FailsMinLengthCaseRule()
        {
            bool v = _Validate.Validate("Fails");

            Assert.IsFalse(v);
        }
    }
}