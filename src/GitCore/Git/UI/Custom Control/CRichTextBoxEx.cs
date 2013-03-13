using System;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;

using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using System.Collections;

using System.Data;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
namespace Git.UI
{
    public class CRichTextBoxEx:RichTextBox
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        public CRichTextBoxEx()
        {
        }
        public const int WM_HSCROLL = 276;
        public const int WM_VSCROLL = 277;
        public const int WM_SETCURSOR = 32;
        public const int WM_MOUSEWHEEL = 522;
        public const int WM_MOUSEMOVE = 512;
        public const int WM_MOUSELEAVE = 675;
        public const int WM_MOUSELAST = 521;
        public const int WM_MOUSEHOVER = 673;
        public const int WM_MOUSEFIRST = 512;
        public const int WM_MOUSEACTIVATE = 33;
        public const int WM_MOUSEHWHEEL = 526;

        private RichTextBox _OtherRichTextBox;
        public RichTextBox m_mOtherRichTextBox
        {
            get { return _OtherRichTextBox; }
            set { _OtherRichTextBox = value; }
        }
        protected override void WndProc(ref Message m)
        {
            if ((_OtherRichTextBox != null) &&
                (m.Msg == WM_HSCROLL ||
                m.Msg == WM_VSCROLL ||
                // m.Msg == WM_SETCURSOR ||
                m.Msg == WM_MOUSEWHEEL
                // m.Msg == WM_MOUSEMOVE ||
                //m.Msg == WM_MOUSELEAVE ||
                // m.Msg == WM_MOUSELAST ||
                // m.Msg == WM_MOUSEHOVER ||
                //m.Msg == WM_MOUSEFIRST ||
                //m.Msg == WM_MOUSEHWHEEL ||
                // m.Msg == WM_MOUSEACTIVATE))
               ))
            {
                //_OtherRichTextBox.Focus();
                SendMessage(_OtherRichTextBox.Handle, m.Msg, m.WParam, m.LParam);


                
            }
            base.WndProc(ref m);
        }

        public void AppendText(string szText)
        { 
            for(int i=0; i<Lines.Length;i++)
            {
                Lines[i]=Lines[i].Substring(Lines[i].IndexOf(")")+1,Lines[i].Length-Lines[i].IndexOf(")")-1);
            }

            //{0,x}， 0 will cause error,avoiding it.
            //string szRegex = "\\s{1,}\\d{1,5}\\)\\s+.{0,}\n";
            string szRegex = "\\s{1,}\\d{1,5}\\)\\s{1}.*\n";
            //string szRegex = "\\s{1,}\\d{1,5}){1,}*\\n";
            Regex r = new Regex(szRegex); // 定义一个Regex对象实例
            MatchCollection mc = r.Matches(szText); // 在字符串中匹配

            for (int i = 0; i < mc.Count; i++) //在输入字符串中找到所有匹配
            {
                string szpp = mc[i].Value; //将匹配的字符串添在字符串数组中
                base.AppendText(szpp);// Environment.NewLine
            }  
        
        }
    }
   

}
