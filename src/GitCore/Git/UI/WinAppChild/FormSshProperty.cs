using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


using Git.Manager;
using System.Diagnostics;
using System.Threading;
using Git.Core.Helper;
using Git.Core.SourceApp;

namespace Git.UI
{
    public partial class FormSshProperty : CGitAsynchFomr
    {
        CGitManager _objGitMgr = null;
        string _szGitFetchURL = null;
        string _szTargetDir= null;

        private bool _bIsUpLoaded;
        public FormSshProperty()
        {
            InitializeComponent();
        }
        #region Asynchron information from updating remote repository
        override protected void CallBackGitProcessExit(object sender, int code)
        {
            m_txOperRes.ForeColor = Color.Green;
            _objGitMgr._objGitMgrCore.Async_DataReceived_Event -= ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event -= ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event -= ProcessErrorData;
            _bIsRegGitEvent = false;

            m_btnCheck.Enabled = true;
            m_btnCancel.Enabled = true;
            m_btnStop.Enabled = false;
        }
        override protected void CallBackGitProcessReceiveData(object sender, DataReceivedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Data))
                return;
            m_txOperRes.AppendText(e.Data + Environment.NewLine);

        }
        override protected void CallBackGitProcessErrorData(object sender, DataReceivedEventArgs e)
        {
            //some useful information is gotten by errror input stream,so strange. example:progress
            CallBackGitProcessReceiveData(sender, e);
        }
        #endregion




        #region help inner function
        public FormSshProperty(CGitManager objGitMgr, string szGitFetchURl, string szTargetDir)
        {
            InitializeComponent();
            _objGitMgr = objGitMgr;
            _szGitFetchURL = szGitFetchURl;
            _szTargetDir = szTargetDir;
            _bIsUpLoaded = false;
 
        }
        private void CheckSshKey()
        {
            m_txOperRes.AppendText("Start Check SSH Key.....");
            m_txOperRes.AppendText(Environment.NewLine);

            string szSSHDir = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.ssh";
            if (Directory.Exists(szSSHDir) == false)
            {
                Directory.CreateDirectory(szSSHDir);
            }

            _objGitMgr._objGitMgrCore.Async_DataReceived_Event += ProcessReceiveData;
            _objGitMgr._objGitMgrCore.Async_Exited_Event += ProcessAbort;
            _objGitMgr._objGitMgrCore.Async_ErrorReceived_Event += ProcessErrorData;
            _bIsRegGitEvent = true;
            if (false == _objGitMgr._objGitMgrCore.CheckSshKey(szSSHDir,m_txRemoteRepo.Text))
            {
                m_btnCheck.Enabled = true;
                m_btnCancel.Enabled = true;
                m_btnStop.Enabled = false;
            }
        }
        #endregion


        private void m_btnCheck_Click(object sender, EventArgs e)
        {
            m_txOperRes.Clear();
            if (string.IsNullOrEmpty(m_txRemoteRepo.Text))
                return;

            m_btnCheck.Enabled = false;
            m_btnCancel.Enabled = false;
            m_btnStop.Enabled = true;
            CheckSshKey();
        }
        private void m_btnCreateKey_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(m_txUsrName.Text))
                return;
            string szSSHDir = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.ssh";
            if (Directory.Exists(szSSHDir) == false)
            {
                Directory.CreateDirectory(szSSHDir);
            }

            string szTargetDir = szSSHDir + @"\" + m_txUsrName.Text;
            string szTargetFile1 = szSSHDir + @"\" + m_txUsrName.Text + @"\" + @"id_rsa";
            string szTargetFile2 = szSSHDir + @"\" + m_txUsrName.Text + @"\" + @"id_rsa.pub";
            if(File.Exists(szTargetFile1)||File.Exists(szTargetFile2))
            {
                MessageBox.Show(this, "The required SSH key has existed", "Warning");
                return;            
            }
            if(Directory.Exists(szTargetDir)==false)
            {
                Directory.CreateDirectory(szTargetDir);
            }

            

            string szRes = _objGitMgr._objGitMgrCore.CreateSshKey(szSSHDir,m_txUsrName.Text);
            if (string.IsNullOrEmpty(szRes)==false)
            {
                MessageBox.Show(this, "Successful: Create SSH Key", "Success");
            }
            else
            {
                MessageBox.Show(this, "Failed: Create SSH Key", "Error");
                return;
            }

        }
        private void m_btnOpenKey_Click(object sender, EventArgs e)
        {
            //string szSshDir = Environment.UserName;
            //string s1 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            //string s2=Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //string s3=Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            //string s4 = Environment.GetEnvironmentVariable("windir");

            string szSSHDir = Environment.GetEnvironmentVariable("USERPROFILE") + @"\.ssh";
            if (Directory.Exists(szSSHDir)==false)
            {
                Directory.CreateDirectory(szSSHDir);          
            }
            System.Diagnostics.Process.Start("explorer.exe", szSSHDir);



            /*
            %SystemDrive% 操作系统所在的分区号。如 C:
            %SystemRoot% 操作系统根目录。如 C:\WINDOWS
            %windir% 操作系统根目录。如 C:\WINDOWS
            %ALLUSERSPROFILE% 相当于 C:\Documents and Settings\All Users
            %APPDATA% 相当于 C:\Documents and Settings\用户目录\Application Data
            %ProgramFiles% 相当于 C:\Program Files
            %CommonProgramFiles% 相当于 C:\Program Files\Common Files
            %HOMEDRIVE% 操作系统所在的分区号。如：C:
            %HOMEPATH% 相当于 \Documents and Settings\用户目录
            %USERPROFILE% 相当于 C:\Documents and Settings\用户目录
            %HOMEDRIVE% = C:\ 当前启动的系统的所在分区 
            %SystemRoot% = C:\WINDOWS 当前启动的系统的所在目录 
            %windir% = %SystemRoot% = C:\WINDOWS 当前启动的系统的所在目录 
            %USERPROFILE% = C:\Documents and Settings\minamiko 当前用户数据变量 
            %HOMEPATH% = C:\Documents and Settings\minamiko 当前用户环境变量 
            %system% = C:\WINDOWS\SYSTEM32 
            %ALLUSERSPROFILE% ： 列出所有用户Profile文件位置。
            %APPDATA% : 列出应用程序数据的默认存放位置。
            %CD% : 列出当前目录。
            %CLIENTNAME% : 列出联接到终端服务会话时客户端的NETBIOS名。
            %CMDCMDLINE% : 列出启动当前cmd.exe所使用的命令行。
            %CMDEXTVERSION% : 命令出当前命令处理程序扩展版本号。
            %CommonProgramFiles% : 列出了常用文件的文件夹路径。
            %COMPUTERNAME% : 列出了计算机名。 
            %COMSPEC% : 列出了可执行命令外壳（命令处理程序）的路径。
            %DATE% : 列出当前日期。
            %ERRORLEVEL% : 列出了最近使用的命令的错误代码。
            %HOMEDRIVE% : 列出与用户主目录所在的驱动器盘符。
            %HOMEPATH% : 列出用户主目录的完整路径。
            %HOMESHARE% : 列出用户共享主目录的网络路径。
            %LOGONSEVER% : 列出有效的当前登录会话的域名控制器名。
            %NUMBER_OF_PROCESSORS% : 列出了计算机安装的处理器数。
            %OS% : 列出操作系统的名字。(Windows XP 和 Windows 2000 列为 Windows_NT.)
            %Path% : 列出了可执行文件的搜索路径。
            %PATHEXT% : 列出操作系统认为可被执行的文件扩展名。 
            %PROCESSOR_ARCHITECTURE% : 列出了处理器的芯片架构。
            %PROCESSOR_IDENTFIER% : 列出了处理器的描述。
            %PROCESSOR_LEVEL% : 列出了计算机的处理器的型号。 
            %PROCESSOR_REVISION% : 列出了处理器的修订号。
            %ProgramFiles% : 列出了Program Files文件夹的路径。
            %PROMPT% : 列出了当前命令解释器的命令提示设置。
            %RANDOM% : 列出界于0 和 32767之间的随机十进制数。
            %SESSIONNAME% : 列出连接到终端服务会话时的连接和会话名。
            %SYSTEMDRIVE% : 列出了Windows启动目录所在驱动器。
            %SYSTEMROOT% : 列出了Windows启动目录的位置。
            %TEMP% and %TMP% : 列出了当前登录的用户可用应用程序的默认临时目录。
            %TIME% : 列出当前时间。
            %USERDOMAIN% : 列出了包含用户帐号的域的名字。
            %USERNAME% : 列出当前登录的用户的名字。
            %USERPROFILE% : 列出当前用户Profile文件位置。
            %WINDIR% : 列出操作系统目录的位置。 
            变量 类型 描述 
            %ALLUSERSPROFILE% 本地 返回“所有用户”配置文件的位置。 
            %APPDATA% 本地 返回默认情况下应用程序存储数据的位置。 
            %CD% 本地 返回当前目录字符串。 
            %CMDCMDLINE% 本地 返回用来启动当前的 Cmd.exe 的准确命令行。 
            %CMDEXTVERSION% 系统 返回当前的“命令处理程序扩展”的版本号。 
            %COMPUTERNAME% 系统 返回计算机的名称。 
            %COMSPEC% 系统 返回命令行解释器可执行程序的准确路径。 
            %DATE% 系统 返回当前日期。使用与 date /t 命令相同的格式。由 Cmd.exe 生成。有关 date 命令的详细信息，请参阅 Date。 
            %ERRORLEVEL% 系统 返回上一条命令的错误代码。通常用非零值表示错误。 
            %HOMEDRIVE% 系统 返回连接到用户主目录的本地工作站驱动器号。基于主目录值而设置。用户主目录是在“本地用户和组”中指定的。 
            %HOMEPATH% 系统 返回用户主目录的完整路径。基于主目录值而设置。用户主目录是在“本地用户和组”中指定的。 
            %HOMESHARE% 系统 返回用户的共享主目录的网络路径。基于主目录值而设置。用户主目录是在“本地用户和组”中指定的。 
            %LOGONSERVER% 本地 返回验证当前登录会话的域控制器的名称。 
            %NUMBER_OF_PROCESSORS% 系统 指定安装在计算机上的处理器的数目。 
            %OS% 系统 返回操作系统名称。Windows 2000 显示其操作系统为 Windows_NT。 
            %PATH% 系统 指定可执行文件的搜索路径。 
            %PATHEXT% 系统 返回操作系统认为可执行的文件扩展名的列表。 
            %PROCESSOR_ARCHITECTURE% 系统 返回处理器的芯片体系结构。值：x86 或 IA64（基于 Itanium）。 
            %PROCESSOR_IDENTFIER% 系统 返回处理器说明。 
            %PROCESSOR_LEVEL% 系统 返回计算机上安装的处理器的型号。 
            %PROCESSOR_REVISION% 系统 返回处理器的版本号。 
            %PROMPT% 本地 返回当前解释程序的命令提示符设置。由 Cmd.exe 生成。 
            %RANDOM% 系统 返回 0 到 32767 之间的任意十进制数字。由 Cmd.exe 生成。 
            %SYSTEMDRIVE% 系统 返回包含 Windows server operating system 根目录（即系统根目录）的驱动器。 
            %SYSTEMROOT% 系统 返回 Windows server operating system 根目录的位置。 
            %TEMP% 和 %TMP% 系统和用户 返回对当前登录用户可用的应用程序所使用的默认临时目录。有些应用程序需要 TEMP，而其他应用程序则需要 TMP。 
            %TIME% 系统 返回当前时间。使用与 time /t 命令相同的格式。由 Cmd.exe 生成。有关 time 命令的详细信息，请参阅 Time。 
            %USERDOMAIN% 本地 返回包含用户帐户的域的名称。 
            %USERNAME% 本地 返回当前登录的用户的名称。 
            %USERPROFILE% 本地 返回当前用户的配置文件的位置。 
            %WINDIR% 系统 返回操作系统目录的位置。
            %temp% = %USERPROFILE%\Local Settings\Temp = C:\Documents and Settings\minamiko\Local Settings\Temp  当前用户TEMP缓存变量 
            */
        }
        private void m_btnStop_Click(object sender, EventArgs e)
        {
            _objGitMgr._objGitMgrCore.KillProcess();
            m_txOperRes.AppendText("The SSH test operation is being canceling.......... ");
            m_txOperRes.AppendText(Environment.NewLine);
            m_btnStop.Enabled = false;
        }
        private void m_btnCancel_Click(object sender, EventArgs e)
        {
            if (_bIsUpLoaded)
                this.DialogResult = DialogResult.OK;

             _objGitMgr = null;
             _szGitFetchURL = null;
             _szTargetDir = null;
            this.Close();
        }

    }
}
