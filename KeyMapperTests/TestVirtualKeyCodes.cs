using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyMapper;
using System.Collections.Generic;

namespace KeyMapperTests
{
    [TestClass]
    public class TestVirtualKeyCodes
    {

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void InvalidVirtualCode_ShouldThrowKeyNotFound()
        {
            int virtualCode = 0xC1;
            VirtualKeyCodes.getKeyNameFromVirtualCode(virtualCode);
        }

        [TestMethod]
        public void ValidVirtualCode_ShouldReturnCorrectKeyname()
        {
            int virtualCode = 0xA0;
            string keyName = VirtualKeyCodes.getKeyNameFromVirtualCode(virtualCode);
            Assert.AreEqual(keyName, "LSHIFT");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void InvalidKeyname_ShouldThrowKeyNotFound()
        {
            string keyName = "AA";
            VirtualKeyCodes.getVirtualCodeFromKeyName(keyName);

        }

        [TestMethod]
        public void ValidKeyname_ShouldReturnCorrectVirtualCode()
        {
            string keyName = "A";
            int vCode = VirtualKeyCodes.getVirtualCodeFromKeyName(keyName);
            Assert.AreEqual(vCode, 0x41);
        }


    }
}
