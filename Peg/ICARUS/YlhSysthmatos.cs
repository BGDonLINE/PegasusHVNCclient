using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Peg.ICARUS
{
	public static class YlhSysthmatos
	{
		public static string Ylh()
		{
			try
			{
				string s = string.Concat(Environment.ProcessorCount, Environment.UserName, Environment.MachineName, Environment.OSVersion, new DriveInfo(Path.GetPathRoot(Environment.SystemDirectory)).TotalSize);
				MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
				byte[] bytes = Encoding.ASCII.GetBytes(s);
				bytes = mD5CryptoServiceProvider.ComputeHash(bytes);
				StringBuilder stringBuilder = new StringBuilder();
				byte[] array = bytes;
				foreach (byte b in array)
				{
					stringBuilder.Append(b.ToString("x2"));
				}
				return stringBuilder.ToString().Substring(0, 20).ToUpper();
			}
			catch
			{
				return "Err HWID";
			}
		}
	}
}
