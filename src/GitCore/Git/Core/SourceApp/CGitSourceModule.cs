using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Permissions;
using System.ComponentModel;
using Git.Core.Helper;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace Git.Core.SourceApp
{
    public sealed class CGitSourceModule
    {

        public CGitSourceModule(string workingdir, string GitSrcCmd)
        {
            m_szWorkingDir = workingdir;
            _szGitSrcCmd = GitSrcCmd;
        }

        private string _szGitSrcCmd;
        private string _workingdir;
        private CGitSourceModule _superprojectModule;
        private string _submoduleName;
        public string m_szWorkingDir
        {
            get
            {
                return _workingdir;
            }
            set
            {
                if (value != null)
                    _workingdir = value.Trim();
                else
                    _workingdir = null;
                // _workingdir = FindGitWorkingDir(value.Trim());
                //string superprojectDir = FindGitSuperprojectPath(out _submoduleName);
                //_superprojectModule = superprojectDir == null ? null : new CGitSourceModule(superprojectDir, _szGitSrcCmd);
            }
        }
        public string SubmoduleName
        {
            get
            {
                return _submoduleName;
            }
        }
        public CGitSourceModule SuperprojectModule
        {
            get
            {
                return _superprojectModule;
            }
        }


        private static string FindGitWorkingDir(string startDir)
        {
            if (string.IsNullOrEmpty(startDir))
                return "";

            if (!startDir.EndsWith("\\") && !startDir.EndsWith("/"))
                startDir += "\\";

            var dir = startDir;

            while (dir.LastIndexOfAny(new[] { '\\', '/' }) > 0)
            {
                dir = dir.Substring(0, dir.LastIndexOfAny(new[] { '\\', '/' }));

                if (ValidWorkingDir(dir))
                    return dir + "\\";
            }
            return startDir;
        }

        private static bool ValidWorkingDir(string dir)
        {
            if (string.IsNullOrEmpty(dir))
                return false;

            if (Directory.Exists(dir + "\\" + ".git") || File.Exists(dir + "\\" + ".git"))
                return true;

            return !dir.Contains(".git") &&
                   Directory.Exists(dir + "\\" + "info") &&
                   Directory.Exists(dir + "\\" + "objects") &&
                   Directory.Exists(dir + "\\" + "refs");
        }

        public string RunCommonCmd(string szCommand,string arguments, out int exitCode)
        {
            byte[] output, error;
            exitCode = RunCmdByte(szCommand, arguments, null, out output, out error);
            return EncodingHelper.GetString(output, error, CGitSourceConfig.m_LogOutputEncoding);
        }

        public string RunGitCmd(string arguments, out int exitCode)
        {
            byte[] output, error;
            exitCode = RunCmdByte(_szGitSrcCmd, arguments, null, out output, out error);
            return EncodingHelper.GetString(output, error, CGitSourceConfig.m_LogOutputEncoding);
        }

        public string RunGitCmd(string arguments, out int exitCode, string stdInput, Encoding encoding)
        {
            return RunCmd(_szGitSrcCmd, arguments, out exitCode, stdInput, encoding);
        }

        [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
        public string RunCmd(string cmd, string arguments, out int exitCode, string stdInput, Encoding encoding)
        {
            byte[] output, error;
            exitCode = RunCmdByte(cmd, arguments, stdInput, out output, out error);
            return EncodingHelper.GetString(output, error, encoding);
        }

        private int RunCmdByte(string cmd, string arguments, string stdInput, out byte[] output, out byte[] error)
        {
            CGitSourceHelpler.SetEnvironmentVariable();
            arguments = arguments.Replace("$QUOTE$", "\\\"");
            int exitCode = CGitSourceHelpler.BeginProcess(arguments, cmd, out output, out error, stdInput);
            return exitCode;
        }

        public Stream RunCmdGetFile(string arguments)
        {
            CGitSourceHelpler.SetEnvironmentVariable();
            arguments = arguments.Replace("$QUOTE$", "\\\"");
            return CGitSourceHelpler.GetFile(arguments, _szGitSrcCmd);
        }

        //asynch
        public Process RunCommonCmdAsynch(string szCommand, string arguments, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            return RunCmdByteAsynch(szCommand, arguments, AppHandleOutput, AppHandleError, AppHandleAbort);
        } 
        public Process RunGitCmdAsynch(string arguments, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            return RunCmdByteAsynch(_szGitSrcCmd, arguments, AppHandleOutput, AppHandleError, AppHandleAbort);
        } 

        private Process RunCmdByteAsynch(string cmd, string arguments, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            CGitSourceHelpler.SetEnvironmentVariable();
            arguments = arguments.Replace("$QUOTE$", "\\\"");
            return CGitSourceHelpler.BeginProcessAsynch(true, arguments, cmd, AppHandleOutput, AppHandleError, AppHandleAbort);
        }


        //asynch thread
        public Thread RunGitCmdByThread(string arguments, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            return RunCmdByteByThread(_szGitSrcCmd, arguments, AppHandleOutput, AppHandleError, AppHandleAbort);
        }

        private Thread RunCmdByteByThread(string cmd, string arguments, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            CGitSourceHelpler.SetEnvironmentVariable();
            arguments = arguments.Replace("$QUOTE$", "\\\"");
            return CGitSourceHelpler.BeginProcessByThread(true, arguments, cmd, AppHandleOutput, AppHandleError, AppHandleAbort);

        }
    }

}
