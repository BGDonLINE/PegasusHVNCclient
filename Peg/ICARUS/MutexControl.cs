using System.Threading;

namespace Peg.ICARUS
{
	public static class MutexControl
	{
		public static Mutex currentApp;

		public static bool CreateMutex()
		{
			currentApp = new Mutex(initiallyOwned: false, Settings.MTX, out var createdNew);
			return createdNew;
		}

		public static void CloseMutex()
		{
			if (currentApp != null)
			{
				currentApp.Close();
				currentApp = null;
			}
		}
	}
}
