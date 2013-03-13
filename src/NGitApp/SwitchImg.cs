using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace NGitApp.SelfControl
{
    class SwitchImg : Image
    {
        private string _szNormalPic=null;
        private string _szOverPic=null;

        public void InitializeSwitchImg(string szNormalPic, string szOverPic)
        {
            _szNormalPic = szNormalPic;
            _szOverPic = szOverPic;
        }

        protected override void OnMouseEnter(System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_szOverPic))
                return;
            Source = new BitmapImage(new Uri(_szOverPic, UriKind.RelativeOrAbsolute));

            try
            {
                Source = new BitmapImage(new Uri(_szOverPic, UriKind.RelativeOrAbsolute));
            }
            catch
            {

            } 
            base.OnMouseEnter(e);

        }
        protected override void OnMouseLeave(System.Windows.Input.MouseEventArgs e)
        {
            if (string.IsNullOrEmpty(_szNormalPic))
                return;
            try
            {
                Source = new BitmapImage(new Uri(_szNormalPic, UriKind.RelativeOrAbsolute));
            }
            catch 
            {
            	
            }   
            base.OnMouseLeave(e);
        }
    }
}
