using System;
using System.Collections.Generic;
using System.Text;
using Git.Core.SourceApp;
using System.Diagnostics;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Threading;

namespace Git.Core.Helper
{
    public delegate void GitEventHandler(object sender, DataReceivedEventArgs e);

    public static class CGitSourceHelpler
    {

        public static void StreamCopy(Stream input, Stream output)
        {
            int read;
            var buffer = new byte[2048];
            do
            {
                read = input.Read(buffer, 0, buffer.Length);
                output.Write(buffer, 0, read);
            } while (read > 0);
        }
       
        public static void SetEnvironmentVariable()
        {
            SetEnvironmentVariable(false);
        }

        public static void SetEnvironmentVariable(bool reload)
        {
            string path = Environment.GetEnvironmentVariable("PATH", EnvironmentVariableTarget.Process);
            if (!string.IsNullOrEmpty(CGitSourceConfig.m_szGitBinDir) && !path.Contains(CGitSourceConfig.m_szGitBinDir))
                Environment.SetEnvironmentVariable("PATH", string.Concat(path, ";", CGitSourceConfig.m_szGitBinDir), EnvironmentVariableTarget.Process);

            if (!string.IsNullOrEmpty(CGitSourceConfig.m_szCustomHomeDir))
            {
                Environment.SetEnvironmentVariable(
                    "HOME",
                    CGitSourceConfig.m_szCustomHomeDir);
                return;
            }

            if (CGitSourceConfig.m_szUserHomeDir)
            {
                Environment.SetEnvironmentVariable(
                    "HOME",
                    Environment.GetEnvironmentVariable("USERPROFILE"));
                return;
            }


            string szUserHomeDir = Environment.GetEnvironmentVariable("HOME", EnvironmentVariableTarget.User);
            if (reload)
            {               
                Environment.SetEnvironmentVariable(
                    "HOME",
                    szUserHomeDir);
            }

            //Default!
            if (string.IsNullOrEmpty(szUserHomeDir))
            {
                string szDefaultHomeDir = CHelpFuntions.GetDefaultHomeDir();
                Environment.SetEnvironmentVariable("HOME", szDefaultHomeDir);
            }            
        }

        public static void StartExternalCommand(string cmd, string arguments,string szWorkingiDir)
        {
            try
            {
                SetEnvironmentVariable();

                var processInfo = new ProcessStartInfo
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = false,
                    FileName = cmd,
                    WorkingDirectory = szWorkingiDir,
                    Arguments = arguments,
                    CreateNoWindow = true
                };

                using (var process = new Process { StartInfo = processInfo })
                {
                    process.Start();
                }
            }
            catch 
            {
                
            }
        }


        internal static Stream GetFile(string arguments, string cmd)
        {
            if (string.IsNullOrEmpty(cmd))
            {
                return null;
            }

            try
            {
                var newStream = new MemoryStream();

                //
                CGitSourceConfig.m_objGitLog.Log(cmd + " " + arguments);

                //process used to execute external commands
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = false;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = false;
                startInfo.RedirectStandardError = false;

                startInfo.CreateNoWindow = true;
                startInfo.FileName = cmd;
                startInfo.Arguments = arguments;
                startInfo.WorkingDirectory = CGitSourceConfig.m_szWorkingDir;
                startInfo.LoadUserProfile = true;

                //
                using (var process = Process.Start(startInfo))
                {
                    StreamCopy(process.StandardOutput.BaseStream, newStream);
                    newStream.Position = 0;

                    process.WaitForExit();
                    return newStream;
                }
            }
            catch (System.Exception ex)
            {

                throw new ApplicationException("Error running command: '" + cmd + " " + arguments, ex);
            }
        }
        internal static int BeginProcess(string arguments, string cmd, out byte[] stdOutput, out byte[] stdError, string stdInput)
        {
            if (string.IsNullOrEmpty(cmd))
            {
                stdOutput = stdError = null;
                return -1;
            }

            try
            { 
                //
                CGitSourceConfig.m_objGitLog.Log(cmd + " " + arguments);

                //process used to execute external commands
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.UseShellExecute = false;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.StandardOutputEncoding = CGitSourceConfig.m_LogOutputEncoding;
                startInfo.StandardErrorEncoding = CGitSourceConfig.m_LogOutputEncoding;

                startInfo.CreateNoWindow = true;
                startInfo.FileName = cmd;
                startInfo.Arguments = arguments;
                startInfo.WorkingDirectory = CGitSourceConfig.m_szWorkingDir;
                startInfo.LoadUserProfile = true;

                //
                using (var process = Process.Start(startInfo))
                {
                    if (!string.IsNullOrEmpty(stdInput))
                    {
                        process.StandardInput.Write(stdInput);
                        process.StandardInput.Close();
                    }

                    stdOutput = CHelpFuntions.ReadByteFromStream(process.StandardOutput.BaseStream);
                    stdError = CHelpFuntions.ReadByteFromStream(process.StandardError.BaseStream);
                    process.WaitForExit();
                    return process.ExitCode;
                }
            }
            catch (System.Exception ex)
            {
                
                stdOutput = null;
                stdError = null;
                throw new ApplicationException("Error running command: '" + cmd + " " + arguments, ex);
                
            	
            }
           

        }

        internal static int BeginProcess(string arguments, string cmd, string workDir, out string stdOutput, out string stdError, string stdInput)
        {
            if (string.IsNullOrEmpty(cmd))
            {
                stdOutput = stdError = "";
                return -1;
            }

            try
            {
                CGitSourceConfig.m_objGitLog.Log(cmd + " " + arguments);
                
                //process used to execute external commands
                ProcessStartInfo startInfo =new ProcessStartInfo();            

                startInfo.UseShellExecute = false;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.StandardOutputEncoding = CGitSourceConfig.m_LogOutputEncoding;
                startInfo.StandardErrorEncoding = CGitSourceConfig.m_LogOutputEncoding;

                startInfo.CreateNoWindow = true;
                startInfo.FileName = cmd;
                startInfo.Arguments = arguments;
                startInfo.WorkingDirectory = workDir;
                startInfo.LoadUserProfile = true;

                using (var process = Process.Start(startInfo))
                {
                    if (!string.IsNullOrEmpty(stdInput))
                    {
                        process.StandardInput.Write(stdInput);
                        process.StandardInput.Close();
                    }

                    stdOutput = process.StandardOutput.ReadToEnd();
                    stdError = process.StandardError.ReadToEnd();
                    process.WaitForExit();
                    return process.ExitCode;
                }
            }
            catch (System.Exception ex)
            {
                
                stdOutput = null;
                stdError = null;
                throw new ApplicationException("Error running command: '" + cmd + " " + arguments, ex);
            }
            
        }

        internal static Process BeginProcessAsynch(bool IsOutPut,string arguments, string cmd, string workDir, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(cmd))
                return null;

            try
            {
                CGitSourceConfig.m_objGitLog.Log(cmd + " " + arguments);

                //process used to execute external commands
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.UseShellExecute = false;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.StandardOutputEncoding = CGitSourceConfig.m_LogOutputEncoding;
                startInfo.StandardErrorEncoding = CGitSourceConfig.m_LogOutputEncoding;

                startInfo.CreateNoWindow = true;
                startInfo.FileName = cmd;
                startInfo.Arguments = arguments;
                startInfo.WorkingDirectory = workDir;
                startInfo.LoadUserProfile = true;

                Process process = new Process();
                process.StartInfo = startInfo;
                //var process = Process.Start(startInfo);               
                process.EnableRaisingEvents = true;
                process.OutputDataReceived += AppHandleOutput;
                process.ErrorDataReceived += AppHandleError;
                process.Exited += AppHandleAbort;

                process.Start();
                if (IsOutPut == true)
                {
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();                    
                }
                return process;
               
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("Error running command: '" + cmd + " " + arguments, ex);
            }


        }

        internal static Process BeginProcessAsynch(bool IsOutPut, string arguments, string cmd, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            if (string.IsNullOrEmpty(cmd))
                return null; 

            try
            {
                CGitSourceConfig.m_objGitLog.Log(cmd + " " + arguments);

                //process used to execute external commands
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.UseShellExecute = false;
                startInfo.ErrorDialog = false;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardInput = true;
                startInfo.RedirectStandardError = true;
                startInfo.StandardOutputEncoding = CGitSourceConfig.m_LogOutputEncoding;
                startInfo.StandardErrorEncoding = CGitSourceConfig.m_LogOutputEncoding;

                startInfo.CreateNoWindow = true;
                startInfo.FileName = cmd;
                startInfo.Arguments = arguments;
                startInfo.WorkingDirectory = CGitSourceConfig.m_szWorkingDir;
                startInfo.LoadUserProfile = true;

                Process process = new Process();
                process.StartInfo = startInfo;
                //var process = Process.Start(startInfo);
                process.EnableRaisingEvents = true;
                process.OutputDataReceived += AppHandleOutput;
                process.ErrorDataReceived += AppHandleError;
                process.Exited += AppHandleAbort;
                process.Start();
                if (IsOutPut == true)
                {
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    
                }
                return process;

            }
            catch (System.Exception ex)
            {
                throw new ApplicationException("Error running command: '" + cmd + " " + arguments, ex);
            }           


        }
    
        internal static Thread BeginProcessByThread(bool IsOutPut, string arguments, string cmd, DataReceivedEventHandler AppHandleOutput, DataReceivedEventHandler AppHandleError, EventHandler AppHandleAbort)
        {
            Thread backgroundThread = new Thread(xxxxx);
            backgroundThread.IsBackground = true;
            backgroundThread.Start(arguments);
            return backgroundThread;
        }

        internal static void xxxxx(object data)
        {
            /*

            string line;
            do
            {
                line = Process.StandardOutput.ReadLine();

                if (line != null)
                {

                }
            } 
            while (line != null);*/
        
        }
    }
}
