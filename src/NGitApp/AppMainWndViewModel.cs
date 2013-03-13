using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using Git.Core.SourceApp;

namespace NGitApp
{
    public class LegalRepoFunctionVisibleConvert : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool bIsLegalRepo= (bool)value;
            if (bIsLegalRepo)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Collapsed;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            //return null;
        }
    }

    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void fire(string x)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(x));
            }
        }
    }

    class AppMainWndViewModel : ViewModelBase
    {
        #region private property
        AppMainWndModel m_MainModel = null;
        private bool _bIsLegualRepo = false;
        public bool IsLegualRepo
        {
            get { return _bIsLegualRepo; }
            set
            {
                _bIsLegualRepo = value;
                fire("IsLegualRepo");
            }
        }
        private string _szCurrentBranch = string.Empty;
        public string m_szCurrentBranch 
        {
            get { return _szCurrentBranch; }
            set
            {
                _szCurrentBranch = value;
                fire("m_szCurrentBranch");
            }
        }

        private bool _bIsShowWarning = false;
        public bool IsShowWarning
        {
            get { return _bIsShowWarning; }
            set
            {
                _bIsShowWarning = value;
                fire("IsShowWarning");
            }
        }
        private string _szWarningInfo = string.Empty;
        public string m_szWarningInfo
        {
            get { return _szWarningInfo; }
            set
            {
                _szWarningInfo = value;
                fire("m_szWarningInfo");
            }
        }

        private bool bIsValidConfigure;

        #endregion

        public AppMainWndViewModel()
        {
            m_MainModel = AppMainWndModel.GetInstence();
            Initialize();
        }

        #region UI update function
        public void Initialize()
        {
            if(m_MainModel!=null)
            {
                if(false==m_MainModel.MgrInitialize(IntPtr.Zero))
                {                    
                    //ignore it now
                    //App.Current.Shutdown(-1);   
                    bIsValidConfigure = false;
                }            
                else
                {
                    bIsValidConfigure = true;
                }
            }
        }

        public void UpdateUIFromRepo(string szRepoPath)
        {
            if (bIsValidConfigure == false)
            {
                IsShowWarning = true;
                m_szWarningInfo = "Ngit的配置项无效，请重新配置它！";
                IsLegualRepo = false;
                m_szCurrentBranch = null;
                return;

            }


            if (m_MainModel.IsValidRepo(szRepoPath) == false)
            {
                IsShowWarning = true;
                m_szWarningInfo = "这是一个无效的Git版本库";
                IsLegualRepo = false;
                m_szCurrentBranch = null;
                return;
            }

            //write history record
            SetLocalOperRecored(szRepoPath);

            string szCurBranch = m_MainModel.GetCurrentBranch(szRepoPath);
            if (string.IsNullOrEmpty(szCurBranch))
            {
                IsLegualRepo = m_MainModel.IsRebaseUnMerge(szRepoPath);
            }
            else
            {
                IsLegualRepo = true;
            }

            //update branch show
            m_szCurrentBranch = szCurBranch;


            //update warning information
            if(m_MainModel.IsRebaseUnMerge(szRepoPath))
            {
                IsShowWarning = true;
                m_szWarningInfo = "Merge任务没有完成，请解决冲突并提交！";            
            }
            else 
            {
                if (string.IsNullOrEmpty(szCurBranch))
                {
                    IsShowWarning = true;
                    m_szWarningInfo = "头指针分离状态，请切换到有效工作分支";
                }
                else
                {
                    IsShowWarning = false;
                    m_szWarningInfo = "";
                }            
            }

        
        }

        #endregion

        #region Main Frame Function
        public void  Setting_Click(string szCurrentWorkDir)
        {
            //m_MainModel.CloneRepository();
            m_MainModel.ShowPropertyDlg(szCurrentWorkDir);
        }
        public void Local_Click(string szCurrentWorkDir)
        {
            if (bIsValidConfigure == false)
                return;

            m_MainModel.LocalOperate(szCurrentWorkDir);
        }
        public void Index_Click(string szCurrentWorkDir)
        {
            if (bIsValidConfigure == false)
                return;

            m_MainModel.OperateRepository(szCurrentWorkDir);
        }
        public void Gerrit_Click(string szCurrentWorkDir)
        {
            if (bIsValidConfigure == false)
                return;

        }
        public void Msg_Click(string szCurrentWorkDir)
        {
            if (bIsValidConfigure == false)
                return;

        }
        public void Remote_Click(string szCurrentWorkDir)
        {
            if (bIsValidConfigure == false)
                return;

            m_MainModel.RemoteOperate(szCurrentWorkDir);
        }
        #endregion

        #region Git Function
        public void SwitchBranch(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;

                m_MainModel.GitSwitchBranch(szCurOperationPath);
                m_szCurrentBranch = m_MainModel.GetCurrentBranch(szCurOperationPath);
                if(string.IsNullOrEmpty(m_szCurrentBranch))
                {
                    IsLegualRepo = false;                
                }
                else
                {
                    IsLegualRepo = true;   
                }
            }
        }
        public void ImgIgnore(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure ==true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;
                m_MainModel.GitIgnore(szCurOperationPath);
            }
        }
        public void ImgStash(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;

                m_MainModel.GitStash(szCurOperationPath);
            }
        }
        public void ImgStage(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                m_MainModel.GitStage(szCurOperationPath);
            }
        }
        public void ImgUnStage(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                m_MainModel.GitUnStage(szCurOperationPath);
            }
        }
        public void ImgCommit(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                m_MainModel.GitCommit(szCurOperationPath);
            }
        }
        public void ImgRevert(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;

                m_MainModel.GitRevert(szCurOperationPath);
            }
        }
        public void ImgPush(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;

                m_MainModel.GitPush(szCurOperationPath, m_szCurrentBranch);
            }
        }
        public void ImgFetch(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;

                m_MainModel.GitFetch(szCurOperationPath, m_szCurrentBranch);
            }
        }
        public void ImgSync(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                if (IsUnmerge(szCurOperationPath))
                    return;

                m_MainModel.GitSync(szCurOperationPath, m_szCurrentBranch);
            }
        }

        public void ImgConflict(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                m_MainModel.GitConflict(szCurOperationPath, m_szCurrentBranch);
            }
        }
        public void ImgGraph(string szCurOperationPath)
        {
            if (m_MainModel != null && bIsValidConfigure == true)
            {
                m_MainModel.GitGraph(szCurOperationPath, m_szCurrentBranch);
            }
        }
        private bool IsUnmerge(string szCurOperationPath)
        {
            if(m_MainModel.IsRebaseUnMerge(szCurOperationPath))
            {
                MessageBox.Show("There's merge conflicts now,please resolve and commit them first!","Warning");
                return true;            
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Helper Functions
        public List<string> GetLocalOperRecored()
        {
            if (bIsValidConfigure == false)
                return null;            
            List<string> RemoteList = CGitSourceConfig.GetTargetUrlRegValue(false);
            return RemoteList;
        }
        private void SetLocalOperRecored(string szValidRepoPath)
        {
            if (bIsValidConfigure == false)
                return ;
            CGitSourceConfig.SetTargetUrlRegValue(szValidRepoPath, false);
        }
        #endregion
    }
}
