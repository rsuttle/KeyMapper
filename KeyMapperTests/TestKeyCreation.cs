using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyMapper;
using System.Collections.Generic;

namespace KeyMapperTests
{
    [TestClass]
    public class TestKeyCreation
    {
        [TestMethod]
        public void KeyCreationUsingValidVirtualCode_ShouldWork()
        {
            //A key
            Key k = new Key(65);
            Assert.AreEqual(k.name, "A");
            
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void KeyCreationUsingInvalidVirtualCode_ShouldThrowKeyNotFound()
        {
            Key k = new Key(0x3A);
        }

        [TestMethod]
        public void KeyCreationUsingValidKeyName_ShouldWork()
        {
            
            Key k = new Key("A");
            Assert.AreEqual(k.name, "A");
            Assert.AreEqual(k.virtualKeyCode, 65);

        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void KeyCreationUsingInvalidKeyName_ShouldThrowKeyNotFound()
        {
            Key k = new Key("asdf");
        }





    }
}
