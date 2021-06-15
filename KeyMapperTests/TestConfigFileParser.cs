using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using KeyMapper;
using System.Collections.Generic;
using System.IO;

namespace KeyMapperTests
{
    [TestClass]
    public class TestConfigFileParser
    {
        [TestMethod]
        public void ParsingSingleLine_ShouldReturnCorrectKeyGroupAndKeyAction()
        {

            KeyGroup expectedKeyGroup = new KeyGroup(new Key("a"), new Key("b"), new Key("c"));
            KeyAction expectedKeyAction = new PressSingleKeyAction(new Key("F5"));
            StreamReader configFile = File.OpenText("./testConfigFiles/testSingleLineConfigFile.txt");

            List<Tuple<KeyGroup, KeyAction>> mappings = ConfigFileParser.ParseConfigFile(configFile);

            Assert.AreEqual(expectedKeyGroup, mappings[0].Item1);
            Assert.AreEqual(expectedKeyAction, mappings[0].Item2);
        }

        [TestMethod]
        public void ParsingMultipleLines_ShouldReturnCorrectKeyGroupsAndKeyActions()
        {

            KeyGroup expectedKeyGroup1 = new KeyGroup(new Key("a"), new Key("b"), new Key("c"));
            KeyAction expectedKeyAction1 = new PressSingleKeyAction(new Key("F5"));
            KeyGroup expectedKeyGroup2 = new KeyGroup(new Key("alt"), new Key("del"), new Key("ins"));
            KeyAction expectedKeyAction2 = new PressSingleKeyAction(new Key("tab"));
            StreamReader configFile = File.OpenText("./testConfigFiles/testMultiLineConfigFile.txt");

            List<Tuple<KeyGroup, KeyAction>> mappings = ConfigFileParser.ParseConfigFile(configFile);

            Assert.AreEqual(expectedKeyGroup1, mappings[0].Item1);
            Assert.AreEqual(expectedKeyAction1, mappings[0].Item2);

            Assert.AreEqual(expectedKeyGroup2, mappings[1].Item1);
            Assert.AreEqual(expectedKeyAction2, mappings[1].Item2);
        }


        [TestMethod]
        public void ParsingSingleLineWithOpenAction_ShouldReturnCorrectKeyGroupAndAction()
        {

            KeyGroup expectedKeyGroup = new KeyGroup(new Key("a"), new Key("b"));
            KeyAction expectedKeyAction = new OpenProgramAction("Chrome");
            StreamReader configFile = File.OpenText("./testConfigFiles/testConfigFileWithOpenAction.txt");

            List<Tuple<KeyGroup, KeyAction>> mappings = ConfigFileParser.ParseConfigFile(configFile);

            Assert.AreEqual(expectedKeyGroup, mappings[0].Item1);
            Assert.AreEqual(expectedKeyAction, mappings[0].Item2);
        }
    }
}
