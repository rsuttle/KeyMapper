using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMapper
{
    public class KeyGroup
    {
        private HashSet<Key> keys = new HashSet<Key>();

        public KeyGroup(params Key[] initialKeys)
        {
            foreach (Key k in initialKeys)
            {
                keys.Add(k);
            }
        }

        public KeyGroup(string[] keyNames)
        {
            foreach (string k in keyNames)
            {
                keys.Add(new Key(k));
            }
        }

        public override bool Equals(object obj)
        {
            //obj must be of the same type
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                KeyGroup kg = (KeyGroup)obj;
                return this.keys.SetEquals(kg.keys);
            }
            
        }

        public override int GetHashCode()
        {
            int hash = 0;
            foreach(Key k in keys)
            {
                hash ^= k.virtualKeyCode;
            }
            return hash;
        }

        public void AddKey(Key k)
        {
            keys.Add(k);
        }

        public void RemoveKey(Key k)
        {
            keys.Remove(k);
        }
    }
}
