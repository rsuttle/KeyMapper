using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMapper
{
    public class PressSingleKeyAction : KeyAction
    {

        private Key keyToPress;
        public PressSingleKeyAction(Key key)
        {
            keyToPress = key;
        }

        public override void Execute()
        {
            
        }

        public override string GetReturnMessage()
        {
            return "Single "+keyToPress.virtualKeyCode.ToString();
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                PressSingleKeyAction singleKeyAction = (PressSingleKeyAction)obj;
                return keyToPress.Equals(singleKeyAction.keyToPress);
            }
        }

        


    }
}
