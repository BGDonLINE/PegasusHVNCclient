using System;
using System.Management;

namespace Peg.ICARUS
{
	internal class GetGPU_RAM
	{
		private static readonly string[] SizeSuffixes = new string[9] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

		public static string SYP()
		{
			string result = "";
			foreach (ManagementObject item in new ManagementObjectSearcher("select * from Win32_VideoController").Get())
			{
				result = Convert.ToString(item["AdapterRAM"]);
			}
			return result;
		}

		private static int GetVideoMemory()
		{
			int result = 0;
			foreach (ManagementObject item in new ManagementObjectSearcher("select AdapterRAM from Win32_VideoController").Get())
			{
				uint? num = item.Properties["AdapterRAM"].Value as uint?;
				if (num.HasValue)
				{
					result = (int)(num / 1048576u).Value;
				}
			}
			return result;
		}

		public static string Get()
		{
			try
			{
				return SizeSuffix((long)Convert.ToDouble(GetVideoMemory()));
			}
			catch
			{
				return "N/A";
			}
		}

		private static string SizeSuffix(long value)
		{
			if (value < 0)
			{
				return "-" + SizeSuffix(-value);
			}
			if (value == 0)
			{
				return "0";
			}
			int num = (int)Math.Log(value, 1024.0);
			decimal num2 = value / (1L << num * 10);
			return string.Format("{0:n0}", num2, SizeSuffixes[num]);
		}
	}
}
