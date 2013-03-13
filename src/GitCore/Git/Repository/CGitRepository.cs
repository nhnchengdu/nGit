using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Git.Repository
{
    public struct CommiteInfoItem
    {
        public string szSelfSHA;
        public string szParentSHA;
        public string szTreeSHA;
        public string szAutrhorName;
        public string szAutrhorEmail;
        public string szAutrhorDate;
        public string szCommitName;
        public string szCommitDate;
        public string szCommitEncoding;
        public string szCommitMessage;
        public string szChildSHA;
    }

    public struct CommiteInfoItemSimple
    {
        public string szSelfSHA;
        public string szTreeSHA;
        public string szAutrhorName;
        public string szCommitDate;
        public string szCommitMessage;
    }


    public class CGitRepository
    {
        public bool m_bIsValid = false;
        public string m_szWorkingDir = null;


        private readonly object _processInfo = new object();
        //branch
        public string m_CurentBranch=null;


        public Dictionary<string, string> m_mapLocalBranch;       
        public Dictionary<string, string> m_mapRemoteBranch; 
        public Dictionary<string, string> m_mapTag;

        public Dictionary<string, string> m_mapId2LocalBranch;
        public Dictionary<string, string> m_mapId2RemoteBranch;
        public Dictionary<string, string> m_mapId2Tag;
        //commits information
        public bool m_bIsValidCommite=false;
        public Dictionary<string, CommiteInfoItem> m_mapAllCommites
        {
            get
            {
                lock (_processInfo)
                {
                    return _mapAllCommites;
                }            
            }
        }
        public Dictionary<string, CommiteInfoItem> m_mapTempAllCommites
        {
            get
            {
                lock (_processInfo)
                {
                    return _mapTempAllCommites;
                }
            }
        }
        private Dictionary<string, CommiteInfoItem> _mapAllCommites;
        private Dictionary<string, CommiteInfoItem> _mapTempAllCommites; 
        public void UpdateAllCommites()
        {
            if (_mapTempAllCommites.Count <= 0)
            {
                m_bIsValidCommite = false;
                return;
            }

            try
            {
                Dictionary<string, CommiteInfoItem> temp;
                lock (_processInfo)
                {
                    temp = _mapAllCommites;
                    _mapAllCommites = _mapTempAllCommites;
                    _mapTempAllCommites = temp;
                    temp.Clear();
                    m_bIsValidCommite = true;

                    RenewChildInfoForCommits();
                    RenewId2Refer();
                }
                return;

            }
            catch (System.Exception ex)
            {
                Trace.WriteLine(ex.Data.ToString());
                Debug.Assert(false);
            }
        }

        public void RenewChildInfoForCommits()
        {
            char[] cSplit=new char[] {'\0', '\t', ' '};

            List<string> TempList = new List<string>();
            TempList.AddRange(_mapAllCommites.Keys);
            foreach (string szKey in TempList)
            {   
                //add child informaiton
                string[] ResArray;
                ResArray =  _mapAllCommites[szKey].szParentSHA.Split(cSplit, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < ResArray.Length; i++)
                {
                    CommiteInfoItem Item = new CommiteInfoItem();
                    if (_mapAllCommites.ContainsKey(ResArray[i]))
                    {
                        Item = _mapAllCommites[ResArray[i]];
                        Item.szChildSHA += " " + szKey;
                        _mapAllCommites[ResArray[i]] = Item;
                    }
                    else
                    {
                        Debug.Assert(false);
                    }
                }

            }        
        }
        public void RenewId2Refer()
        {
            m_mapId2LocalBranch.Clear();
            m_mapId2RemoteBranch.Clear();
            m_mapId2Tag.Clear();
            string szNewValue = string.Empty;
            foreach (KeyValuePair<string, string> Item in m_mapLocalBranch)
            {
               
                if(m_mapId2LocalBranch.ContainsKey(Item.Value))
                {
                    szNewValue = string.Format("{0} {1}", m_mapId2LocalBranch[Item.Value], Item.Key);
                    m_mapId2LocalBranch[Item.Value]=szNewValue;
                }
                else
                {
                    m_mapId2LocalBranch.Add(Item.Value,Item.Key);
                }
            }
            foreach (KeyValuePair<string, string> Item in m_mapRemoteBranch)
            {
                if (m_mapId2RemoteBranch.ContainsKey(Item.Value))
                {
                    szNewValue = string.Format("{0} {1}", m_mapId2RemoteBranch[Item.Value], Item.Key);
                    m_mapId2RemoteBranch[Item.Value] = szNewValue;
                }
                else
                {
                    m_mapId2RemoteBranch.Add(Item.Value, Item.Key);
                }
            }
            foreach (KeyValuePair<string, string> Item in m_mapTag)
            {
                if (m_mapId2Tag.ContainsKey(Item.Value))
                {
                    szNewValue = string.Format("{0} {1}", m_mapId2Tag[Item.Value], Item.Key);
                    m_mapId2Tag[Item.Value] = szNewValue;
                }
                else
                {
                    m_mapId2Tag.Add(Item.Value, Item.Key);
                }
            }
        }      
        
        
        public CGitRepository() 
        {
            m_mapLocalBranch = new Dictionary<string, string>();
            m_mapRemoteBranch = new Dictionary<string, string>();
            m_mapTag = new Dictionary<string, string>();            
             
            m_mapId2LocalBranch=new Dictionary<string, string>();       
            m_mapId2RemoteBranch=new Dictionary<string, string>();
            m_mapId2Tag = new Dictionary<string, string>();

            _mapAllCommites = new Dictionary<string, CommiteInfoItem>();
            _mapTempAllCommites = new Dictionary<string, CommiteInfoItem>();
        }

    }
}
