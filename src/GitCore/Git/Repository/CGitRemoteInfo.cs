using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Git.Repository
{
    public class CGitRemoteInfo
    {
        public bool m_bIsValid = false;
        public string m_szWorkingDir = null;
        private readonly object _processInfo = new object();
        
        //branch
        public string m_CurentBranch=null;


        public Dictionary<string, string> m_mapLocalBranch;       
        public Dictionary<string, string> m_mapRemoteBranch; 
        public Dictionary<string, string> m_mapTag;
        public Dictionary<string, string> m_mapAllRemotes; //<remote, fetch/push>
        public Dictionary<string, string> m_mapAllTracking; //<LocalBranch, Remote>

        public CGitRemoteInfo() 
        {
            m_mapLocalBranch = new Dictionary<string, string>();
            m_mapRemoteBranch = new Dictionary<string, string>();
            m_mapTag = new Dictionary<string, string>();
            m_mapAllRemotes = new Dictionary<string, string>();
            m_mapAllTracking = new Dictionary<string, string>();
        }

    }
}

