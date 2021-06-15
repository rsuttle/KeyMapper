using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace KeyMapper
{
    public class OpenProgramAction : KeyAction
    {

        private string programToOpen;
        public OpenProgramAction(string program)
        {
            programToOpen = program;
        }

        public override void Execute()
        {
            Process.Start("https://www.google.com/");
        }

        public override string GetReturnMessage()
        {
            return "Ok";
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                OpenProgramAction openProgAction = (OpenProgramAction)obj;
                return String.Equals(programToOpen, openProgAction.programToOpen, StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}
