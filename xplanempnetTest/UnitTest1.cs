using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace XPlaneMPNet.Native.Test
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void Test()
		{
			var returnMessage1 = NativeBridge.XPMPMultiplayerInit(intPrefsProvider, floatPrefsProvider, "C:\\abs\\");
			string str1 = Marshal.PtrToStringAnsi(returnMessage1);

			var returnMessage2 = NativeBridge.XPMPLoadCSLPackage(
				@"C:\Users\markusb\Desktop\X-Plane 11\Resources\plugins\disabled\XPlanePlugin\Resources\CSL",
				@"C:\Users\markusb\Desktop\X-Plane 11\Resources\plugins\disabled\XPlanePlugin\Resources\related.txt",
				@"C:\Users\markusb\Desktop\X-Plane 11\Resources\plugins\disabled\XPlanePlugin\Resources\Doc8643.txt");
			string str2 = Marshal.PtrToStringAnsi(returnMessage2);

			//XPMPMultiplayerDisable();
		}

		private static float floatPrefsProvider(string section, string key, float defaultValue)
		{
			return 3.0F;
		}

		private static int intPrefsProvider(string section, string key, int defaultValue)
		{
			return 50;
		}

	}
}
