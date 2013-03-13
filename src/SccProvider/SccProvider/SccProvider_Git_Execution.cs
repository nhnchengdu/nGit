using System;
using System.IO;
using System.Resources;

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;
using Microsoft.Win32;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio;

using Git.Core.Commands;  //file status enum;
using Git.UI;


namespace Nhn.Git.SourceControl.Provider
{
    partial class SccProvider
    {
        //NGit Command Implementation Function          --by fengzheng
        #region NGit Command Execution

        //
        private void Exec_icmdNhnGitInitRepo(object sender, EventArgs e)
        {
            if (IsThereASolution())
            {
                String szDir = this.GetSolutionDirectory();
                sccService.InitializeRepo(szDir);

                //refresh all node glyphs later
                //RefreshNodesGlyphs(selectedNodes);
            }
            else
            {
                sccService.InitializeRepo(null);
            }
            return;
        }
        
        // The function can be used to bring back the provider's toolwindow if it was previously closed
        private void Exec_icmdGitPropertylWindow(object sender, EventArgs e)
        {
            ShowToolWindow();   
        }
        //
        private void Exec_icmdNhnGitCloneRepo(object sender, EventArgs e)
        {
            sccService.CloneRepository();
        }

        //
        private void Exec_icmdStage(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            List<string> listSelectedItem = new List<string>();
            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            foreach (string file in files)
            {
                listSelectedItem.Add(file);
            }

            bool bRes=sccService.AddFiles(this.GetSolutionDirectory(), listSelectedItem);
            if (bRes)
            {
                RefreshNodesGlyphs(selectedNodes);
            }
        }

        //
        private void Exec_icmdUnStage(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            List<string> listSelectedItem = new List<string>();
            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            foreach (string file in files)
            {
                listSelectedItem.Add(file);
            }

            bool bRes = sccService.UnStageFiles(this.GetSolutionDirectory(), listSelectedItem);
            if (bRes)
            {
                RefreshNodesGlyphs(selectedNodes);
            }

            //IList<VSITEMSELECTION> selectedNodes = null;
            //IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            //foreach (string file in files)
            //{
            //    FileSccStatus status = sccService.GetFileStatus(file);
            //    if (status == FileSccStatus.ST_NEW_STAGED || status == FileSccStatus.ST_MODIFY_STAGED )
            //    {   
            //        string szResult = sccService.UnStageFile(file);
            //    }
            //}
            ////Update the selected nodes' glyphs
            //RefreshNodesGlyphs(selectedNodes);
        }

        //
        private void Exec_icmdNhnGitCommit(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            List<string> listSelectedItem=new List<string>();
            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            foreach (string file in files)
            {
                FileSccStatus status = sccService.GetFileStatus(file);
                if (status == FileSccStatus.ST_NEW_STAGED || status == FileSccStatus.ST_MODIFY_STAGED ||status == FileSccStatus.ST_MODIFY_STAGED_MODIFY)
                {
                    listSelectedItem.Add(file);
                }
            }
            
            sccService.Commit(this.GetSolutionDirectory(), listSelectedItem);
            RefreshNodesGlyphs(selectedNodes);
        }

        private void Exec_icmdNhnGitDiscard(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            if (files.Count == 0)
                return;

            sccService.Discard(this.GetSolutionDirectory(), files as List<string>);
            RefreshNodesGlyphs(selectedNodes);
        }

        private void Exec_icmdNhnGitDelete(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            if (files.Count == 0)
                return;

            sccService.Delete(this.GetSolutionDirectory(), files as List<string>);
            RefreshNodesGlyphs(selectedNodes);

        }

        private void Exec_icmdNhnGitIgnore(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            if (files.Count == 0)                
            {

            }

            sccService.Ignore(this.GetSolutionDirectory());
            //RefreshNodesGlyphs(selectedNodes);


            // Refresh all files in solutions
            selectedNodes.Clear();
            Hashtable hashControllable = GetLoadedControllableProjectsEnum();
            foreach (IVsHierarchy pHier in hashControllable.Keys)
            {
                    VSITEMSELECTION vsItemSelection;
                    vsItemSelection.pHier = pHier;
                    vsItemSelection.itemid = VSConstants.VSITEMID_ROOT;
                    selectedNodes.Add(vsItemSelection);
            }
            RefreshNodesGlyphs(selectedNodes);



        }

        private void Exec_icmdNhnGitLocal(object sender, EventArgs e)
        {            
            if (!IsThereASolution())
            {
                sccService.LocalOperate(null);
            }
            else
            {
                sccService.LocalOperate(this.GetSolutionDirectory());

                // Refresh all files in solutions
                IList<VSITEMSELECTION> AllNodes = new List<VSITEMSELECTION>();
                AllNodes.Clear();
                Hashtable hashControllable = GetLoadedControllableProjectsEnum();
                foreach (IVsHierarchy pHier in hashControllable.Keys)
                {
                    VSITEMSELECTION vsItem;
                    vsItem.pHier = pHier;
                    vsItem.itemid = VSConstants.VSITEMID_ROOT;
                    AllNodes.Add(vsItem);
                }
                RefreshNodesGlyphs(AllNodes);
            }
        }

        private void Exec_icmdNhnGitRemote(object sender, EventArgs e)
        {

            if (!IsThereASolution())
            {
                sccService.RemoteOperate(null);
            }
            else
            {
                sccService.RemoteOperate(this.GetSolutionDirectory());

                // Refresh all files in solutions
                IList<VSITEMSELECTION> AllNodes = new List<VSITEMSELECTION>();
                AllNodes.Clear();
                Hashtable hashControllable = GetLoadedControllableProjectsEnum();
                foreach (IVsHierarchy pHier in hashControllable.Keys)
                {
                    VSITEMSELECTION vsItem;
                    vsItem.pHier = pHier;
                    vsItem.itemid = VSConstants.VSITEMID_ROOT;
                    AllNodes.Add(vsItem);
                }
                RefreshNodesGlyphs(AllNodes);
            }
            
        }

        private void Exec_icmdNhnGitRepo(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                sccService.OperateRepository(null);
            }
            else
            {
                sccService.OperateRepository(this.GetSolutionDirectory());

                // Refresh all files in solutions
                IList<VSITEMSELECTION> AllNodes =new List<VSITEMSELECTION>();
                AllNodes.Clear();
                Hashtable hashControllable = GetLoadedControllableProjectsEnum();
                foreach (IVsHierarchy pHier in hashControllable.Keys)
                {
                    VSITEMSELECTION vsItem;
                    vsItem.pHier = pHier;
                    vsItem.itemid = VSConstants.VSITEMID_ROOT;
                    AllNodes.Add(vsItem);
                }
                RefreshNodesGlyphs(AllNodes);
            }

        }


        private void Exec_icmdNhnGitBlame(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            IList<VSITEMSELECTION> selectedNodes = null;
            IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            if (files.Count == 0)
                return;

            sccService.blame(this.GetSolutionDirectory(), files[0],"HEAD");
        }

        private void Exec_icmdNhnGitAdvanced(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }
            sccService.Gitk(this.GetSolutionDirectory());
        }

        private void Exec_icmdNhnGitStash(object sender, EventArgs e)
        {
            if (!IsThereASolution())
            {
                return;
            }

            //IList<VSITEMSELECTION> selectedNodes = null;
            //IList<string> files = GetSelectedFilesInControlledProjects(out selectedNodes);
            //if (files.Count == 0)
                //return;

            sccService.Stash(this.GetSolutionDirectory());
            //RefreshNodesGlyphs(selectedNodes);

        }



        private void Exec_icmdNhnGitFunction(object sender, EventArgs e)
        {



        }

        #endregion
    
    
    
    
    
    
    }
}