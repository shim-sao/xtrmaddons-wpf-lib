using System.Runtime.InteropServices;

namespace XtrmAddons.Net.Picture.ExtractLargeIconFromFile.Shell
{
    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}
