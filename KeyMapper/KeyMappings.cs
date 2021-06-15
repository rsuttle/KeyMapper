using System;
using System.Collections.Generic;

namespace KeyMapper
{
    class KeyMappings
    {
        private Dictionary<KeyGroup, KeyAction> mappings = new Dictionary<KeyGroup, KeyAction>();

        public KeyMappings(List<Tuple<KeyGroup, KeyAction>> initialMappings)
        {
            foreach(Tuple<KeyGroup,KeyAction> t in initialMappings)
            {
                if(!mappings.ContainsKey(t.Item1)) mappings.Add(t.Item1, t.Item2);
            }
        }

        public bool Contains(KeyGroup keyGroup)
        {
            if (mappings.ContainsKey(keyGroup)) return true;
            return false;
            
        }

        public void AddKeyMapping(KeyGroup keyGroup, KeyAction keyAction)
        {
            if (!mappings.ContainsKey(keyGroup)) mappings.Add(keyGroup, keyAction);
        }

        public void RemoveKeyMapping(KeyGroup keyGroup)
        {
            mappings.Remove(keyGroup);
        }

        public KeyAction GetKeyAction(KeyGroup keyGroup)
        {
            if (!mappings.ContainsKey(keyGroup))
            {
                throw new ArgumentException("This KeyGroup has not been mapped.");
            }
            else
            {
                return mappings[keyGroup];
            }
        }

    }
}
