using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMapper
{
    public class Key
    {
        public string name;
        public int virtualKeyCode;

        public override bool Equals(object obj)
        {
            //obj must be of the same type
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                Key kg = (Key)obj;
                return this.name.Equals(kg.name) && this.virtualKeyCode == kg.virtualKeyCode;
            }
        }

        public override int GetHashCode()
        {
            return virtualKeyCode;
        }

        public Key(string name)
        {
            this.name = name.ToUpper();
            virtualKeyCode = VirtualKeyCodes.getVirtualCodeFromKeyName(name);

        }

        public Key(int vCode)
        {
            name = VirtualKeyCodes.getKeyNameFromVirtualCode(vCode);
            virtualKeyCode = vCode;
        }
    }
}
