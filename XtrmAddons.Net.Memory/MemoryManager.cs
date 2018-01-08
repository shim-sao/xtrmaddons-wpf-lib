using System;
using System.Runtime.InteropServices;
using System.Security;

namespace XtrmAddons.Net.Memory
{
    /// <summary>
    /// Class XtrmAddons Net Common Memory Manager.
    /// </summary>
    public static class MemoryManager
    {
        /// <summary>
        /// <para>Metod to fix memory leak.</para>
        /// <para>Execute this method in a timer or something like that.</para>
        /// </summary>
        public static void fixMemoryLeak()
        {
            IntPtr pHandle = UnsafeNativeMethods.GetCurrentProcess();
            UnsafeNativeMethods.SetProcessWorkingSetSize(pHandle, -1, -1);
        }
    }


    /// <summary>
    /// Class XtrmAddons Net Common Memory Manager Unsafe Native Methods.
    /// </summary>
    [SuppressUnmanagedCodeSecurityAttribute]
    internal static class UnsafeNativeMethods
    {
        /// <summary>
        /// Method to set working process size.
        /// </summary>
        /// <param name="pProcess">The handled process.</param>
        /// <param name="dwMinimumWorkingSetSize">Minimum working process size.</param>
        /// <param name="dwMaximumWorkingSetSize">Maximum working process size.</param>
        /// <returns>Return true on success otherwise false.</returns>
        [DllImport("KERNEL32.DLL", EntryPoint = "SetProcessWorkingSetSize", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern bool SetProcessWorkingSetSize(IntPtr pProcess, int dwMinimumWorkingSetSize, int dwMaximumWorkingSetSize);

        /// <summary>
        /// Method to get current process.
        /// </summary>
        /// <returns>The handled current process.</returns>
        [DllImport("KERNEL32.DLL", EntryPoint = "GetCurrentProcess", SetLastError = true, CallingConvention = CallingConvention.StdCall)]
        internal static extern IntPtr GetCurrentProcess();
    }
}
