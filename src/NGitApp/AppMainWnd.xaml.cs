using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.Drawing;
using NGitApp.Properties;
using NGitApp.SelfControl;

namespace NGitApp
{
    /// <summary>
    /// Interaction logic for AppMainWnd.xaml
    /// </summary>
    public partial class AppMainWnd : Window
    {
        #region Initialize 
        public AppMainWnd()
        {
            InitializeComponent();
            //
            this.DataContext = new AppMainWndViewModel();

            //location
            this.WindowStartupLocation = WindowStartupLocation.Manual;       
            this.Left = Screen.PrimaryScreen.WorkingArea.Right-341;
            this.Top =  Screen.PrimaryScreen.WorkingArea.Height - 120;

            //
            InitialTray();

        }
        private void TopCanva_Loaded(object sender, RoutedEventArgs e)
        {
            
            //add resouce image
            ImgIgnore.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Ignore_n.png", "/NGitApp;component/App_Res/FunctionImg2/Ignore_o.png");
            ImgStash.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Stash_n.png", "/NGitApp;component/App_Res/FunctionImg2/Stash_o.png");
            ImgStage.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Add_n.png", "/NGitApp;component/App_Res/FunctionImg2/Add_o.png");
            ImgUnStage.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Minus_n.png", "/NGitApp;component/App_Res/FunctionImg2/Minus_o.png");
            ImgCommit.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Commit_n.png", "/NGitApp;component/App_Res/FunctionImg2/Commit_o.png");
            ImgRevert.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Revert_n.png", "/NGitApp;component/App_Res/FunctionImg2/Revert_o.png");
            ImgPush.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Push_n.png", "/NGitApp;component/App_Res/FunctionImg2/Push_o.png");
            ImgFetch.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Pull_n.png", "/NGitApp;component/App_Res/FunctionImg2/Pull_o.png");
            ImgSync.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Async_n.png", "/NGitApp;component/App_Res/FunctionImg2/Async_o.png");
            ImgConflict.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Conflict_n.png", "/NGitApp;component/App_Res/FunctionImg2/Conflict_o.png");
            ImgGraph.InitializeSwitchImg("/NGitApp;component/App_Res/FunctionImg2/Graph_n.png", "/NGitApp;component/App_Res/FunctionImg2/Graph_o.png");
        }
        #endregion

        #region TrayIcon
        private System.Windows.Forms.NotifyIcon notifyIcon = null;
        private void InitialTray()
        {

            //设置托盘的各个属性
            notifyIcon = new System.Windows.Forms.NotifyIcon();
            notifyIcon.BalloonTipText = @"NGit Start Running...\";
            notifyIcon.Text = @"NGit";
            //notifyIcon.Icon = new System.Drawing.Icon(@"Ngit_Icon32.ico");
            notifyIcon.Icon = new System.Drawing.Icon(@"Ngit.ico");
            notifyIcon.Visible = true;
            //notifyIcon.ShowBalloonTip(1000);   //it's TBD
            notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(notifyIcon_MouseClick);

            //设置菜单项
            System.Windows.Forms.MenuItem menuShow = new System.Windows.Forms.MenuItem("Show");
            menuShow.Click += new EventHandler(show_Click);
            System.Windows.Forms.MenuItem menuHide= new System.Windows.Forms.MenuItem("Hide");
            menuHide.Click += new EventHandler(hide_Click);
            System.Windows.Forms.MenuItem menuAbout = new System.Windows.Forms.MenuItem("About");

            //退出菜单项
            System.Windows.Forms.MenuItem menuExit = new System.Windows.Forms.MenuItem("Exit");
            menuExit.Click += new EventHandler(exit_Click);

            //关联托盘控件
            System.Windows.Forms.MenuItem[] childen = new System.Windows.Forms.MenuItem[] {menuShow,menuHide, menuAbout, menuExit };
            notifyIcon.ContextMenu = new System.Windows.Forms.ContextMenu(childen);

            //窗体状态改变时候触发
            this.StateChanged += new EventHandler(SysTray_StateChanged);
        }
        /// windows status changed
        private void SysTray_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.Visibility = Visibility.Hidden;
            }
        }
        /// show
        private void show_Click(object sender, EventArgs e)
        {
            Show();
            this.Activate();
        }
        /// hide
        private void hide_Click(object sender, EventArgs e)
        {
            Hide();
        }
        private void ImgGitIcon_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Hide();
        }
        /// exit
        private void exit_Click(object sender, EventArgs e)
        {
            if (System.Windows.MessageBox.Show("Are you sure to close the NGit now?",
                                               "Exit", MessageBoxButton.YesNo,
                                                MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                notifyIcon.Dispose();
                System.Windows.Application.Current.Shutdown();
            }
        }
        /// tray icon mouse click
        private void notifyIcon_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (this.Visibility == Visibility.Visible)
                {
                    //this.Visibility = Visibility.Hidden;
                    Hide();
                }
                else
                {
                    //this.Visibility = Visibility.Visible;
                    Show();
                    this.Activate();
                }
            }
        }
        #endregion

        #region file drag/drop
        //Drag and Drop
        //http://www.cnblogs.com/mgen/archive/2011/07/11/2102993.html
        
        private void TopCanva_DragEnter(object sender, System.Windows.DragEventArgs e)
        {
            if ( e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))

                e.Effects = System.Windows.DragDropEffects.Copy;
        }
        private void TopCanva_Drop(object sender, System.Windows.DragEventArgs e)
        {
            string[] files = e.Data.GetData(System.Windows.DataFormats.FileDrop) as string[];

            foreach (var s in files)
            {
                DirectoryTX.Text = s;
            }

            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void DirectoryTX_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var browseDialog = new FolderBrowserDialog();
            if (browseDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                DirectoryTX.Text = browseDialog.SelectedPath;
            }
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        #endregion

        #region Main Frame Button UI functions
        private void m_btnConfigure_Click(object sender, RoutedEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.Setting_Click(DirectoryTX.Text);
            vmObj.Initialize();
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);

        }
        private void m_btnLocal_Click(object sender, RoutedEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.Local_Click(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void m_btnStorage_Click(object sender, RoutedEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.Index_Click(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void m_btnGerrit_Click(object sender, RoutedEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.Gerrit_Click(DirectoryTX.Text);
        }
        private void m_btnMsg_Click(object sender, RoutedEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.Msg_Click(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void m_btnRemote_Click(object sender, RoutedEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.Remote_Click(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        #endregion

        #region Git function Button
        public void SwitchPath(string szPath)
        {
            DirectoryTX.Text = szPath;

            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void textBlock1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.SwitchBranch(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgIgnore_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgIgnore(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgStash_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgStash(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgStage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgStage(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgUnStage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgUnStage(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgCommit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgCommit(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgRevert_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgRevert(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgPush_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgPush(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);

        }
        private void ImgFetch_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgFetch(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgSync_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgSync(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgConflict_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgConflict(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        private void ImgBranchGraph_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.ImgGraph(DirectoryTX.Text);
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }
        #endregion

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    DragMove();
                }
            }

        }

        private void DirectoryTX_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            List<string>  AllRecords=vmObj.GetLocalOperRecored();
            if (AllRecords == null || AllRecords.Count < 1)
                return;

            System.Windows.Controls.ContextMenu cMenu = new  System.Windows.Controls.ContextMenu();
            foreach (string item in AllRecords)
            {
                System.Windows.Controls.MenuItem  menuItem = new System.Windows.Controls.MenuItem();
                menuItem.Header = item;
                cMenu.Items.Add(menuItem);
                menuItem.Click += new RoutedEventHandler(HistoryRecoredClicked);
            }
            DirectoryTX.ContextMenu = cMenu;
        }

        public void HistoryRecoredClicked(object sender, RoutedEventArgs e)
        {
           // ServiceLocator.Current.GetInstance<OpenWindow>().OpenSettingDlg();
            System.Windows.Controls.MenuItem menuItem = e.Source as System.Windows.Controls.MenuItem;
            if(menuItem==null)
                return;
           
            string szName = menuItem.Header.ToString();
            if(string.IsNullOrEmpty(szName))
                return;

            DirectoryTX.Text = szName;
            AppMainWndViewModel vmObj = DataContext as AppMainWndViewModel;
            vmObj.UpdateUIFromRepo(DirectoryTX.Text);
        }

    }
}
