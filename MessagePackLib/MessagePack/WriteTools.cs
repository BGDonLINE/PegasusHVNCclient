using System;
using System.IO;

namespace MessagePackLib.MessagePack
{
	internal class WriteTools
	{
		public static void WriteNull(Stream ms)
		{
			ms.WriteByte(192);
		}

		public static void WriteString(Stream ms, string strVal)
		{
			byte[] utf8Bytes = BytesTools.GetUtf8Bytes(strVal);
			byte[] array = null;
			int num = utf8Bytes.Length;
			byte b = 0;
			if (num <= 31)
			{
				b = (byte)(160 + (byte)num);
				ms.WriteByte(b);
			}
			else if (num <= 255)
			{
				b = 217;
				ms.WriteByte(b);
				b = (byte)num;
				ms.WriteByte(b);
			}
			else if (num <= 65535)
			{
				b = 218;
				ms.WriteByte(b);
				array = BytesTools.SwapBytes(BitConverter.GetBytes((short)num));
				ms.Write(array, 0, array.Length);
			}
			else
			{
				b = 219;
				ms.WriteByte(b);
				array = BytesTools.SwapBytes(BitConverter.GetBytes(num));
				ms.Write(array, 0, array.Length);
			}
			ms.Write(utf8Bytes, 0, utf8Bytes.Length);
		}

		public static void WriteBinary(Stream ms, byte[] rawBytes)
		{
			byte[] array = null;
			int num = rawBytes.Length;
			byte b = 0;
			if (num <= 255)
			{
				b = 196;
				ms.WriteByte(b);
				b = (byte)num;
				ms.WriteByte(b);
			}
			else if (num <= 65535)
			{
				b = 197;
				ms.WriteByte(b);
				array = BytesTools.SwapBytes(BitConverter.GetBytes((short)num));
				ms.Write(array, 0, array.Length);
			}
			else
			{
				b = 198;
				ms.WriteByte(b);
				array = BytesTools.SwapBytes(BitConverter.GetBytes(num));
				ms.Write(array, 0, array.Length);
			}
			ms.Write(rawBytes, 0, rawBytes.Length);
		}

		public static void WriteFloat(Stream ms, double fVal)
		{
			ms.WriteByte(203);
			ms.Write(BytesTools.SwapDouble(fVal), 0, 8);
		}

		public static void WriteSingle(Stream ms, float fVal)
		{
			ms.WriteByte(202);
			ms.Write(BytesTools.SwapBytes(BitConverter.GetBytes(fVal)), 0, 4);
		}

		public static void WriteBoolean(Stream ms, bool bVal)
		{
			if (bVal)
			{
				ms.WriteByte(195);
			}
			else
			{
				ms.WriteByte(194);
			}
		}

		public static void WriteUInt64(Stream ms, ulong iVal)
		{
			ms.WriteByte(207);
			byte[] bytes = BitConverter.GetBytes(iVal);
			ms.Write(BytesTools.SwapBytes(bytes), 0, 8);
		}

		public static void WriteInteger(Stream ms, long iVal)
		{
			if (iVal >= 0)
			{
				if (iVal <= 127)
				{
					ms.WriteByte((byte)iVal);
				}
				else if (iVal <= 255)
				{
					ms.WriteByte(204);
					ms.WriteByte((byte)iVal);
				}
				else if (iVal <= 65535)
				{
					ms.WriteByte(205);
					ms.Write(BytesTools.SwapInt16((short)iVal), 0, 2);
				}
				else if (iVal <= uint.MaxValue)
				{
					ms.WriteByte(206);
					ms.Write(BytesTools.SwapInt32((int)iVal), 0, 4);
				}
				else
				{
					ms.WriteByte(211);
					ms.Write(BytesTools.SwapInt64(iVal), 0, 8);
				}
			}
			else if (iVal <= int.MinValue)
			{
				ms.WriteByte(211);
				ms.Write(BytesTools.SwapInt64(iVal), 0, 8);
			}
			else if (iVal <= -32768)
			{
				ms.WriteByte(210);
				ms.Write(BytesTools.SwapInt32((int)iVal), 0, 4);
			}
			else if (iVal <= -128)
			{
				ms.WriteByte(209);
				ms.Write(BytesTools.SwapInt16((short)iVal), 0, 2);
			}
			else if (iVal <= -32)
			{
				ms.WriteByte(208);
				ms.WriteByte((byte)iVal);
			}
			else
			{
				ms.WriteByte((byte)iVal);
			}
		}
	}
}
