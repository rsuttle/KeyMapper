using System.Collections.Generic;
using System.Linq;

namespace KeyMapper
{
    public class VirtualKeyCodes
    {
        private static Dictionary<string, int> keyNameToVirtualCode = new Dictionary<string, int>
            {
                { "LMOUSE", 1 },
                { "RMOUSE", 2 },
                { "MMOUSE", 4 },
                { "MOUSEB1", 5 },
                { "MOUSEB2", 6 },
                { "BACK", 8 },
                { "TAB", 9 },
                { "CLEAR", 12 },
                { "ENTER", 13 },
                { "SHIFT", 16 },
                { "CTRL", 17 },
                { "ALT", 18 },
                { "PAUSE", 19 },
                { "CAPS", 20 },
                { "ESC", 27 },
                { "SPACE", 32 },
                { "PGUP", 33 },
                { "PGDOWN", 34 },
                { "END", 35 },
                { "HOME", 36 },
                { "LEFTARROW", 37 },
                { "UPARROW", 38 },
                { "RIGHTARROW", 39 },
                { "DOWNARROW", 40 },
                { "SELECT", 41 },
                { "PRINT", 42 },
                { "EXECUTE", 43 },
                { "PRNTSCRN", 44 },
                { "INS", 45 },
                { "DEL", 46 },
                { "HELP", 47 },
                { "0", 48 },
                { "1", 49 },
                { "2", 50 },
                { "3", 51 },
                { "4", 52 },
                { "5", 53 },
                { "6", 54 },
                { "7", 55 },
                { "8", 56 },
                { "9", 57 },
                { "A", 65 },
                { "B", 66 },
                { "C", 67 },
                { "D", 68 },
                { "E", 69 },
                { "F", 70 },
                { "G", 71 },
                { "H", 72 },
                { "I", 73 },
                { "J", 74 },
                { "K", 75 },
                { "L", 76 },
                { "M", 77 },
                { "N", 78 },
                { "O", 79 },
                { "P", 80 },
                { "Q", 81 },
                { "R", 82 },
                { "S", 83 },
                { "T", 84 },
                { "U", 85 },
                { "V", 86 },
                { "W", 87 },
                { "X", 88 },
                { "Y", 89 },
                { "Z", 90 },
                { "NUMPAD0", 96 },
                { "NUMPAD1", 97 },
                { "NUMPAD2", 98 },
                { "NUMPAD3", 99 },
                { "NUMPAD4", 100 },
                { "NUMPAD5", 101 },
                { "NUMPAD6", 102 },
                { "NUMPAD7", 103 },
                { "NUMPAD8", 104 },
                { "NUMPAD9", 105 },
                { "MULT", 106 },
                { "ADD", 107 },
                { "SEP", 108 },
                { "SUB", 109 },
                { "DECIMAL", 110 },
                { "DIV", 111 },
                { "F1", 112 },
                { "F2", 113 },
                { "F3", 114 },
                { "F4", 115 },
                { "F5", 116 },
                { "F6", 117 },
                { "F7", 118 },
                { "F8", 119 },
                { "F9", 120 },
                { "F10", 121 },
                { "F11", 122 },
                { "F12", 123 },
                { "NUMLOCK", 144 },
                { "SCROLLLOCK", 145 },
                { "LSHIFT", 160 },
                { "RSHIFT", 161 },
                { "LCTRL", 162 },
                { "RCTRL", 163 },
                {"SEMICOLON",186 },
                {"EQUALS",187 },
                {"COMMA", 188 },
                {"MINUS",189 },
                {"PERIOD",190 },
                {"FWDSLASH",191 },
                {"BACKTICK",192 },
                {"OPENBRACKET",219 },
                {"BACKSLASH",220 },
                {"CLOSEBRACKET",221 },
                {"QUOTE",222 }
            

        };

        //Reverse
        private static Dictionary<int, string> virtualCodeToKeyName = keyNameToVirtualCode.ToDictionary((i) => i.Value, (i) => i.Key);

        private VirtualKeyCodes() { }

        public static int getVirtualCodeFromKeyName(string keyName)
        {
            if (!keyNameToVirtualCode.ContainsKey(keyName.ToUpper()))
            {
                throw new KeyNotFoundException("Key name is spelled incorrectly, or not yet supported.");
            }

            return keyNameToVirtualCode[keyName.ToUpper()];

        }

        public static string getKeyNameFromVirtualCode(int vCode)
        {
            if (!virtualCodeToKeyName.ContainsKey(vCode))
            {
                throw new KeyNotFoundException("Virtual key code not found.");
            }

            return virtualCodeToKeyName[vCode];
        }



    }
}
