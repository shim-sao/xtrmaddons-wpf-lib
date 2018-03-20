using System;
using System.Drawing;
using System.Runtime.InteropServices;
using XtrmAddons.Net.Picture.ExtractLargeIconFromFile.Shell;

namespace XtrmAddons.Net.Picture.Classes
{
    public class Win32Icon
    {
        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_LARGEICON = 0x0; // 'Large icon
        public const uint SHGFI_SMALLICON = 0x1; // 'Small icon

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi, uint cbSizeFileInfo, uint uFlags);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fullname"></param>
        /// <param name="shgfi"></param>
        /// <returns></returns>
        public static Icon IconFromHandle(string fullname, uint shgfi = SHGFI_SMALLICON)
        {
            //Use this to get the small Icon
            IntPtr hImgSmall;
            SHFILEINFO shinfo = new SHFILEINFO();
            hImgSmall = SHGetFileInfo(fullname, 0, ref shinfo, (uint)Marshal.SizeOf(shinfo), SHGFI_ICON | shgfi);

            //The icon is returned in the hIcon member of the shinfo struct
            return Icon.FromHandle(shinfo.hIcon);
        }

    }
}
