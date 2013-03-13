using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Collections;


namespace Git.UI
{
    public class CSystemTreeView : TreeView
    {
        private Hashtable _extensionList;
        private ImageList _imageList; 
        public CSystemTreeView()
        {
            _extensionList=new Hashtable();
            _imageList = new ImageList();
            base.ImageList = _imageList;
           
        }
        public int Add(TreeNode ParentNode, object TagContent,string szFileName,bool bIsParent)
        {
            //Check that we haven't already got the extension, if we have, then
            //return back its index
            if(bIsParent==false)
            {   
                // Split it down so we can get the extension
                string[] splitPath = szFileName.Split(new Char[] { '.' });
                string szExtention = (string)splitPath.GetValue(splitPath.GetUpperBound(0));
                szExtention = "." + szExtention;

                if (_extensionList.ContainsKey(szExtention.ToUpper()))
                {
                    // it already exists
                    int nInex = (int)_extensionList[szExtention.ToUpper()]; //return existing index
                    //Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();                   
                                       
                    TreeNode tmpNdoe = new TreeNode(szFileName);
                    tmpNdoe.Tag = TagContent;
                    tmpNdoe.ImageIndex = nInex;
                    tmpNdoe.SelectedImageIndex = nInex;
                    return ParentNode.Nodes.Add(tmpNdoe);
                }
                else
                {
                    int pos = base.ImageList.Images.Count;
                    Shell32.SHFILEINFO shfi=new Shell32.SHFILEINFO();
                    base.ImageList.Images.Add(IconReader.GetFileIcon(szExtention,IconReader.IconSize.Small, false, ref shfi));
                    _extensionList.Add(szExtention.ToUpper(), pos);
                    
                    TreeNode tmpNdoe = new TreeNode(szFileName);
                    tmpNdoe.Tag = TagContent;
                    tmpNdoe.ImageIndex = pos;
                    tmpNdoe.SelectedImageIndex = pos;
                    return ParentNode.Nodes.Add(tmpNdoe);
                }
            }
            else
            {
                string szFolder = "FolderClose";
                if (_extensionList.ContainsKey(szFolder.ToUpper()))
                {
                    // it already exists
                    int nInex = (int)_extensionList[szFolder.ToUpper()]; //return existing index
                    //Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();


                    TreeNode tmpNdoe = new TreeNode(szFileName);
                    tmpNdoe.Tag = TagContent;
                    tmpNdoe.ImageIndex = nInex;
                    tmpNdoe.SelectedImageIndex = nInex;
                    return ParentNode.Nodes.Add(tmpNdoe);
                }
                else
                {
                    int pos = base.ImageList.Images.Count;
                    Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                    base.ImageList.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Closed, ref shfi));
                    _extensionList.Add(szFolder.ToUpper(), pos);

                    TreeNode tmpNdoe = new TreeNode(szFileName);
                    tmpNdoe.Tag = TagContent;
                    tmpNdoe.ImageIndex = pos;
                    tmpNdoe.SelectedImageIndex = pos;
                    return ParentNode.Nodes.Add(tmpNdoe);
                }
            }

        }

        public int AddRoot(string szSHA)
        {
            string szFolder = "FolderOpen";
            int nIndexOpen = 0, nIndexCloesed = 0;
            if (!_extensionList.ContainsKey(szFolder.ToUpper()))
            {
                nIndexOpen = base.ImageList.Images.Count;
                Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                base.ImageList.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Open, ref shfi));
                _extensionList.Add(szFolder.ToUpper(), nIndexOpen);
            }
            else 
            {
                 nIndexOpen = (int)_extensionList[szFolder.ToUpper()]; 
            }


            szFolder = "FolderClose";
            if (!_extensionList.ContainsKey(szFolder.ToUpper()))
            {
                nIndexCloesed = base.ImageList.Images.Count;
                Shell32.SHFILEINFO shfi = new Shell32.SHFILEINFO();
                base.ImageList.Images.Add(IconReader.GetFolderIcon(IconReader.IconSize.Small, IconReader.FolderType.Closed, ref shfi));
                _extensionList.Add(szFolder.ToUpper(), nIndexCloesed);
            }
            else
            {
                nIndexCloesed = (int)_extensionList[szFolder.ToUpper()];
            }

            TreeNode tmpNdoe = new TreeNode(szSHA);
            tmpNdoe.Tag = null;
            tmpNdoe.ImageIndex = nIndexOpen;
            tmpNdoe.SelectedImageIndex = nIndexOpen;
            return base.Nodes.Add(tmpNdoe);

        }

    }
}
