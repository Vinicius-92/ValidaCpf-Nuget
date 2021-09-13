using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidaCpf;

namespace ValidaCpf.Test
{
    [TestClass]
    public class ValidaCpfTests
    {
        [TestMethod("Should validate CPF")]
        public void ShouldValidateCpf()
        {
            Assert.IsFalse(ValidaCpf.ValidaCpfExtension.Validate("11111111111"));
            Assert.IsFalse(ValidaCpf.ValidaCpfExtension.Validate("99999999999"));
            Assert.IsTrue(ValidaCpf.ValidaCpfExtension.Validate("41496861817"));
            Assert.IsTrue(ValidaCpf.ValidaCpfExtension.Validate("32586106814"));
        }
    }
}
