using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Manager
{
    public class CGitManagerUI
    {        
        // The git manager for UI/Repo/Core
        private CGitManager _gitManagerObj = null;


        public CGitManagerUI(CGitManager GitManagerObj) 
        {
            this._gitManagerObj = GitManagerObj;
        }

        public bool Initizlize()
        {
            return true;
        }

    }
}
