using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMapper
{

    public enum KeyDirection
    {
        Up,
        Down
    }
    class KeyEvent
    {
        private Key key;
        private KeyDirection direction;

        public static KeyEvent FromClientMessage(string msg)
        {
            KeyEvent keyEvent = new KeyEvent();

            string[] splitMsg = msg.Split(' ');

            keyEvent.SetKey(new Key(Int32.Parse(splitMsg[0])));
            Console.WriteLine("KASDLFKLSDFK"+splitMsg[1]);

            if (String.Equals("UP", splitMsg[1].ToUpper(), StringComparison.OrdinalIgnoreCase))
            {
                keyEvent.SetKeyDirection(KeyDirection.Up);
            }
            else
            {
                keyEvent.SetKeyDirection(KeyDirection.Down);
            }

            return keyEvent;

        }

        public Key GetKey()
        {
            return key;
        }

        public void SetKey(Key k)
        {
            key = k;
        }

        public KeyDirection GetKeyDirection()
        {
            return direction;
        }

        public void SetKeyDirection(KeyDirection keyDir)
        {
            direction = keyDir;
        }
    }
}
