using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMapper
{
    public class ConfigFileParser
    {


        public static List<Tuple<KeyGroup,KeyAction>> ParseConfigFile(StreamReader file)
        {
            List<Tuple<KeyGroup, KeyAction>> mappings = new List<Tuple<KeyGroup, KeyAction>>();

           
            string line;
            while ((line = file.ReadLine()) != null)
            {
                string[] split = line.Split(new[] { "::" },StringSplitOptions.None);

                string[] keyNames = split[0].Split(',');

                KeyGroup keyGroup;
                try
                {
                    keyGroup = new KeyGroup(keyNames);
                }
                catch (KeyNotFoundException ex)
                {
                    throw new FormatException("One of the keys in the config file could not be found. Check for misspellings, and confirm that the key is supported.",ex);
                }

                string[] actionSettings = split[1].Split(',');

                string action = actionSettings[0];
                KeyAction keyAction;
                switch (action)
                {
                    case "Single":
                        keyAction = new PressSingleKeyAction(new Key(actionSettings[1]));
                        break;
                    case "Open":
                        keyAction = new OpenProgramAction(actionSettings[1]);
                        break;
                    default:
                        throw new FormatException("The specified action type is not available. Check for misspellings.");
                }

                mappings.Add(new Tuple<KeyGroup, KeyAction>(keyGroup,keyAction));
                
            }

            return mappings;
        }
    }
}
