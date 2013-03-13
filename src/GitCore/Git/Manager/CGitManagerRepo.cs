using System;
using System.Collections.Generic;
using System.Text;

namespace Git.Manager
{
    public class CGitManagerRepo
    {
        // The git manager for UI/Repo/Core
        private CGitManager _gitManagerObj = null;


        public CGitManagerRepo(CGitManager GitManagerObj) 
        {
            this._gitManagerObj = GitManagerObj;
        }
        public bool Initizlize()
        {
            return true;
        }

    }
}
