using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyMapper;
using System.Collections.Generic;

namespace KeyMapperTests
{
    [TestClass]
    public class TestKeyGroupEquality
    {
        [TestMethod]
        public void KeyGroupsWithSameKeys_ShouldBeEqual()
        {
            Key k1 = new Key("A");
            Key k2 = new Key("B");

            KeyGroup kg1 = new KeyGroup(k1, k2);
            KeyGroup kg2 = new KeyGroup(k1, k2);

            Assert.AreEqual(kg1, kg2);
        }

        [TestMethod]
        public void KeyGroupsWithDifferentKeys_ShouldNotBeEqual()
        {
            Key k1 = new Key("A");
            Key k2 = new Key("B");

            KeyGroup kg1 = new KeyGroup(k1);
            KeyGroup kg2 = new KeyGroup(k2);

            Assert.AreNotEqual(kg1, kg2);
        }
    }
}
