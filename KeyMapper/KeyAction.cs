using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyMapper
{

    public abstract class KeyAction
    {
        public abstract void Execute();

        public abstract string GetReturnMessage();
        

        
    }
    
}
