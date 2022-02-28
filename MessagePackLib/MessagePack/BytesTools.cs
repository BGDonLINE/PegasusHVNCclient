using System;
using System.Text;

namespace MessagePackLib.MessagePack
{
	public class BytesTools
	{
		private static UTF8Encoding utf8Encode = new UTF8Encoding();

		public static byte[] GetUtf8Bytes(string s)
		{
			return utf8Encode.GetBytes(s);
		}

		public static string GetString(byte[] utf8Bytes)
		{
			return utf8Encode.GetString(utf8Bytes);
		}

		public static string BytesAsString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in bytes)
			{
				stringBuilder.Append($"{b:D3} ");
			}
			return stringBuilder.ToString();
		}

		public static string BytesAsHexString(byte[] bytes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (byte b in bytes)
			{
				stringBuilder.Append($"{b:X2} ");
			}
			return stringBuilder.ToString();
		}

		public static byte[] SwapBytes(byte[] v)
		{
			byte[] array = new byte[v.Length];
			int num = v.Length - 1;
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = v[num];
				num--;
			}
			return array;
		}

		public static byte[] SwapInt64(long v)
		{
			return SwapBytes(BitConverter.GetBytes(v));
		}

		public static byte[] SwapInt32(int v)
		{
			byte[] array = new byte[4];
			array[3] = (byte)v;
			array[2] = (byte)(v >> 8);
			array[1] = (byte)(v >> 16);
			array[0] = (byte)(v >> 24);
			return array;
		}

		public static byte[] SwapInt16(short v)
		{
			byte[] array = new byte[2];
			array[1] = (byte)v;
			array[0] = (byte)(v >> 8);
			return array;
		}

		public static byte[] SwapDouble(double v)
		{
			return SwapBytes(BitConverter.GetBytes(v));
		}
	}
}
