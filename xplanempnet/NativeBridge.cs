using System;
using System.Runtime.InteropServices;

namespace XPlaneMPNet.Native
{
	public static class NativeBridge
	{
		/// <summary>
		/// Initializes XPMP. Call this once, typically from your XPluginStart routine.
		/// </summary>
		/// <param name="floatPrefsFunc">Function that returns a value for a given preference key.</param>
		/// <param name="intPrefsFunc">Function that returns a value for a given preference key.</param>
		/// <param name="resourceDir">A string path to the resource directory of 
		/// the calling plugin for storing the user vertical offset config file.</param>
		[DllImport("libxplanemp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public extern static IntPtr XPMPMultiplayerInit(IntPrefsFunc intPrefsFunc, FloatPrefsFunc floatPrefsFunc,
			[MarshalAs(UnmanagedType.LPStr)] string resourceDir);

		[DllImport("libxplanemp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public extern static IntPtr XPMPLoadCSLPackage(
			[MarshalAs(UnmanagedType.LPStr)] string cslFolder,
			[MarshalAs(UnmanagedType.LPStr)] string relatedPath,
			[MarshalAs(UnmanagedType.LPStr)] string inDoc8643);

		[DllImport("libxplanemp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public extern static IntPtr XPMPMultiplayerEnable();

		[DllImport("libxplanemp.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
		public extern static void XPMPMultiplayerDisable();

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate int IntPrefsFunc(
			[MarshalAs(UnmanagedType.LPStr)] string section,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			int defaultValue
		);

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate float FloatPrefsFunc(
			[MarshalAs(UnmanagedType.LPStr)] string section,
			[MarshalAs(UnmanagedType.LPStr)] string key,
			float defaultValue
		);
	}
}
