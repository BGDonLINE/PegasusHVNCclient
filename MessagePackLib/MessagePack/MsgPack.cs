using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace MessagePackLib.MessagePack
{
	public class MsgPack : IEnumerable
	{
		private string name;

		private string lowerName;

		private object innerValue;

		private MsgPackType valueType;

		private MsgPack parent;

		private List<MsgPack> children = new List<MsgPack>();

		private MsgPackArray refAsArray;

		public string AsString
		{
			get
			{
				return GetAsString();
			}
			set
			{
				SetAsString(value);
			}
		}

		public long AsInteger
		{
			get
			{
				return GetAsInteger();
			}
			set
			{
				SetAsInteger(value);
			}
		}

		public double AsFloat
		{
			get
			{
				return GetAsFloat();
			}
			set
			{
				SetAsFloat(value);
			}
		}

		public MsgPackArray AsArray
		{
			get
			{
				lock (this)
				{
					if (refAsArray == null)
					{
						refAsArray = new MsgPackArray(this, children);
					}
				}
				return refAsArray;
			}
		}

		public MsgPackType ValueType => valueType;

		private void SetName(string value)
		{
			name = value;
			lowerName = name.ToLower();
		}

		private void Clear()
		{
			for (int i = 0; i < children.Count; i++)
			{
				children[i].Clear();
			}
			children.Clear();
		}

		private MsgPack InnerAdd()
		{
			MsgPack msgPack = new MsgPack();
			msgPack.parent = this;
			children.Add(msgPack);
			return msgPack;
		}

		private int IndexOf(string name)
		{
			int num = -1;
			int result = -1;
			string text = name.ToLower();
			foreach (MsgPack child in children)
			{
				num++;
				if (text.Equals(child.lowerName))
				{
					return num;
				}
			}
			return result;
		}

		public MsgPack FindObject(string name)
		{
			int num = IndexOf(name);
			if (num == -1)
			{
				return null;
			}
			return children[num];
		}

		private MsgPack InnerAddMapChild()
		{
			if (valueType != MsgPackType.Map)
			{
				Clear();
				valueType = MsgPackType.Map;
			}
			return InnerAdd();
		}

		private MsgPack InnerAddArrayChild()
		{
			if (valueType != MsgPackType.Array)
			{
				Clear();
				valueType = MsgPackType.Array;
			}
			return InnerAdd();
		}

		public MsgPack AddArrayChild()
		{
			return InnerAddArrayChild();
		}

		private void WriteMap(Stream ms)
		{
			int count = children.Count;
			if (count <= 15)
			{
				byte value = (byte)(128 + (byte)count);
				ms.WriteByte(value);
			}
			else if (count <= 65535)
			{
				byte value = 222;
				ms.WriteByte(value);
				byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes((short)count));
				ms.Write(array, 0, array.Length);
			}
			else
			{
				byte value = 223;
				ms.WriteByte(value);
				byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes(count));
				ms.Write(array, 0, array.Length);
			}
			for (int i = 0; i < count; i++)
			{
				WriteTools.WriteString(ms, children[i].name);
				children[i].Encode2Stream(ms);
			}
		}

		private void WirteArray(Stream ms)
		{
			int count = children.Count;
			if (count <= 15)
			{
				byte value = (byte)(144 + (byte)count);
				ms.WriteByte(value);
			}
			else if (count <= 65535)
			{
				byte value = 220;
				ms.WriteByte(value);
				byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes((short)count));
				ms.Write(array, 0, array.Length);
			}
			else
			{
				byte value = 221;
				ms.WriteByte(value);
				byte[] array = BytesTools.SwapBytes(BitConverter.GetBytes(count));
				ms.Write(array, 0, array.Length);
			}
			for (int i = 0; i < count; i++)
			{
				children[i].Encode2Stream(ms);
			}
		}

		public void SetAsInteger(long value)
		{
			innerValue = value;
			valueType = MsgPackType.Integer;
		}

		public void SetAsUInt64(ulong value)
		{
			innerValue = value;
			valueType = MsgPackType.UInt64;
		}

		public ulong GetAsUInt64()
		{
			return valueType switch
			{
				MsgPackType.Integer => Convert.ToUInt64((long)innerValue), 
				MsgPackType.UInt64 => (ulong)innerValue, 
				MsgPackType.String => ulong.Parse(innerValue.ToString().Trim()), 
				MsgPackType.Float => Convert.ToUInt64((double)innerValue), 
				MsgPackType.Single => Convert.ToUInt64((float)innerValue), 
				MsgPackType.DateTime => Convert.ToUInt64((DateTime)innerValue), 
				_ => 0uL, 
			};
		}

		public long GetAsInteger()
		{
			return valueType switch
			{
				MsgPackType.Integer => (long)innerValue, 
				MsgPackType.UInt64 => Convert.ToInt64((long)innerValue), 
				MsgPackType.String => long.Parse(innerValue.ToString().Trim()), 
				MsgPackType.Float => Convert.ToInt64((double)innerValue), 
				MsgPackType.Single => Convert.ToInt64((float)innerValue), 
				MsgPackType.DateTime => Convert.ToInt64((DateTime)innerValue), 
				_ => 0L, 
			};
		}

		public double GetAsFloat()
		{
			return valueType switch
			{
				MsgPackType.Integer => Convert.ToDouble((long)innerValue), 
				MsgPackType.String => double.Parse((string)innerValue), 
				MsgPackType.Float => (double)innerValue, 
				MsgPackType.Single => (float)innerValue, 
				MsgPackType.DateTime => Convert.ToInt64((DateTime)innerValue), 
				_ => 0.0, 
			};
		}

		public void SetAsBytes(byte[] value)
		{
			innerValue = value;
			valueType = MsgPackType.Binary;
		}

		public byte[] GetAsBytes()
		{
			return valueType switch
			{
				MsgPackType.Integer => BitConverter.GetBytes((long)innerValue), 
				MsgPackType.String => BytesTools.GetUtf8Bytes(innerValue.ToString()), 
				MsgPackType.Float => BitConverter.GetBytes((double)innerValue), 
				MsgPackType.Single => BitConverter.GetBytes((float)innerValue), 
				MsgPackType.DateTime => BitConverter.GetBytes(((DateTime)innerValue).ToBinary()), 
				MsgPackType.Binary => (byte[])innerValue, 
				_ => new byte[0], 
			};
		}

		public void Add(string key, string value)
		{
			MsgPack msgPack = InnerAddArrayChild();
			msgPack.name = key;
			msgPack.SetAsString(value);
		}

		public void Add(string key, int value)
		{
			MsgPack msgPack = InnerAddArrayChild();
			msgPack.name = key;
			msgPack.SetAsInteger(value);
		}

		public bool LoadFileAsBytes(string fileName)
		{
			if (File.Exists(fileName))
			{
				byte[] array = null;
				FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
				array = new byte[fileStream.Length];
				fileStream.Read(array, 0, (int)fileStream.Length);
				fileStream.Close();
				fileStream.Dispose();
				SetAsBytes(array);
				return true;
			}
			return false;
		}

		public bool SaveBytesToFile(string fileName)
		{
			if (innerValue != null)
			{
				FileStream fileStream = new FileStream(fileName, FileMode.Append);
				fileStream.Write((byte[])innerValue, 0, ((byte[])innerValue).Length);
				fileStream.Close();
				fileStream.Dispose();
				return true;
			}
			return false;
		}

		public MsgPack ForcePathObject(string path)
		{
			MsgPack msgPack = this;
			string[] array = path.Trim().Split('.', '/', '\\');
			string text = null;
			if (array.Length == 0)
			{
				return null;
			}
			if (array.Length > 1)
			{
				for (int i = 0; i < array.Length - 1; i++)
				{
					text = array[i];
					MsgPack msgPack2 = msgPack.FindObject(text);
					if (msgPack2 == null)
					{
						msgPack = msgPack.InnerAddMapChild();
						msgPack.SetName(text);
					}
					else
					{
						msgPack = msgPack2;
					}
				}
			}
			text = array[array.Length - 1];
			int num = msgPack.IndexOf(text);
			if (num > -1)
			{
				return msgPack.children[num];
			}
			msgPack = msgPack.InnerAddMapChild();
			msgPack.SetName(text);
			return msgPack;
		}

		public void SetAsNull()
		{
			Clear();
			innerValue = null;
			valueType = MsgPackType.Null;
		}

		public void SetAsString(string value)
		{
			innerValue = value;
			valueType = MsgPackType.String;
		}

		public string GetAsString()
		{
			if (innerValue == null)
			{
				return "";
			}
			return innerValue.ToString();
		}

		public void SetAsBoolean(bool bVal)
		{
			valueType = MsgPackType.Boolean;
			innerValue = bVal;
		}

		public void SetAsSingle(float fVal)
		{
			valueType = MsgPackType.Single;
			innerValue = fVal;
		}

		public void SetAsFloat(double fVal)
		{
			valueType = MsgPackType.Float;
			innerValue = fVal;
		}

		public void DecodeFromBytes(byte[] bytes)
		{
			using MemoryStream memoryStream = new MemoryStream();
			bytes = Zip.Decompress(bytes);
			memoryStream.Write(bytes, 0, bytes.Length);
			memoryStream.Position = 0L;
			DecodeFromStream(memoryStream);
		}

		public void DecodeFromFile(string fileName)
		{
			FileStream fileStream = new FileStream(fileName, FileMode.Open);
			DecodeFromStream(fileStream);
			fileStream.Dispose();
		}

		public void DecodeFromStream(Stream ms)
		{
			byte b = (byte)ms.ReadByte();
			byte[] array = null;
			int num = 0;
			int num2 = 0;
			if (b <= 127)
			{
				SetAsInteger(b);
				return;
			}
			if (b >= 128 && b <= 143)
			{
				Clear();
				valueType = MsgPackType.Map;
				num = b - 128;
				for (num2 = 0; num2 < num; num2++)
				{
					MsgPack msgPack = InnerAdd();
					msgPack.SetName(ReadTools.ReadString(ms));
					msgPack.DecodeFromStream(ms);
				}
				return;
			}
			if (b >= 144 && b <= 159)
			{
				Clear();
				valueType = MsgPackType.Array;
				num = b - 144;
				for (num2 = 0; num2 < num; num2++)
				{
					InnerAdd().DecodeFromStream(ms);
				}
				return;
			}
			if (b >= 160 && b <= 191)
			{
				num = b - 160;
				SetAsString(ReadTools.ReadString(ms, num));
				return;
			}
			if (b >= 224 && b <= byte.MaxValue)
			{
				SetAsInteger((sbyte)b);
				return;
			}
			switch (b)
			{
			case 192:
				SetAsNull();
				return;
			case 193:
				throw new Exception("(never used) type $c1");
			case 194:
				SetAsBoolean(bVal: false);
				return;
			case 195:
				SetAsBoolean(bVal: true);
				return;
			case 196:
				num = ms.ReadByte();
				array = new byte[num];
				ms.Read(array, 0, num);
				SetAsBytes(array);
				return;
			case 197:
				array = new byte[2];
				ms.Read(array, 0, 2);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToUInt16(array, 0);
				array = new byte[num];
				ms.Read(array, 0, num);
				SetAsBytes(array);
				return;
			case 198:
				array = new byte[4];
				ms.Read(array, 0, 4);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToInt32(array, 0);
				array = new byte[num];
				ms.Read(array, 0, num);
				SetAsBytes(array);
				return;
			case 199:
			case 200:
			case 201:
				throw new Exception("(ext8,ext16,ex32) type $c7,$c8,$c9");
			case 202:
				array = new byte[4];
				ms.Read(array, 0, 4);
				array = BytesTools.SwapBytes(array);
				SetAsSingle(BitConverter.ToSingle(array, 0));
				return;
			case 203:
				array = new byte[8];
				ms.Read(array, 0, 8);
				array = BytesTools.SwapBytes(array);
				SetAsFloat(BitConverter.ToDouble(array, 0));
				return;
			case 204:
				b = (byte)ms.ReadByte();
				SetAsInteger(b);
				return;
			case 205:
				array = new byte[2];
				ms.Read(array, 0, 2);
				array = BytesTools.SwapBytes(array);
				SetAsInteger(BitConverter.ToUInt16(array, 0));
				return;
			case 206:
				array = new byte[4];
				ms.Read(array, 0, 4);
				array = BytesTools.SwapBytes(array);
				SetAsInteger(BitConverter.ToUInt32(array, 0));
				return;
			case 207:
				array = new byte[8];
				ms.Read(array, 0, 8);
				array = BytesTools.SwapBytes(array);
				SetAsUInt64(BitConverter.ToUInt64(array, 0));
				return;
			case 220:
				array = new byte[2];
				ms.Read(array, 0, 2);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToInt16(array, 0);
				Clear();
				valueType = MsgPackType.Array;
				for (num2 = 0; num2 < num; num2++)
				{
					InnerAdd().DecodeFromStream(ms);
				}
				return;
			case 221:
				array = new byte[4];
				ms.Read(array, 0, 4);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToInt16(array, 0);
				Clear();
				valueType = MsgPackType.Array;
				for (num2 = 0; num2 < num; num2++)
				{
					InnerAdd().DecodeFromStream(ms);
				}
				return;
			case 217:
				SetAsString(ReadTools.ReadString(b, ms));
				return;
			case 222:
				array = new byte[2];
				ms.Read(array, 0, 2);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToInt16(array, 0);
				Clear();
				valueType = MsgPackType.Map;
				for (num2 = 0; num2 < num; num2++)
				{
					MsgPack msgPack2 = InnerAdd();
					msgPack2.SetName(ReadTools.ReadString(ms));
					msgPack2.DecodeFromStream(ms);
				}
				return;
			}
			switch (b)
			{
			case 222:
				array = new byte[2];
				ms.Read(array, 0, 2);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToInt16(array, 0);
				Clear();
				valueType = MsgPackType.Map;
				for (num2 = 0; num2 < num; num2++)
				{
					MsgPack msgPack4 = InnerAdd();
					msgPack4.SetName(ReadTools.ReadString(ms));
					msgPack4.DecodeFromStream(ms);
				}
				break;
			case 223:
				array = new byte[4];
				ms.Read(array, 0, 4);
				array = BytesTools.SwapBytes(array);
				num = BitConverter.ToInt32(array, 0);
				Clear();
				valueType = MsgPackType.Map;
				for (num2 = 0; num2 < num; num2++)
				{
					MsgPack msgPack3 = InnerAdd();
					msgPack3.SetName(ReadTools.ReadString(ms));
					msgPack3.DecodeFromStream(ms);
				}
				break;
			case 218:
				SetAsString(ReadTools.ReadString(b, ms));
				break;
			case 219:
				SetAsString(ReadTools.ReadString(b, ms));
				break;
			case 208:
				SetAsInteger((sbyte)ms.ReadByte());
				break;
			case 209:
				array = new byte[2];
				ms.Read(array, 0, 2);
				array = BytesTools.SwapBytes(array);
				SetAsInteger(BitConverter.ToInt16(array, 0));
				break;
			case 210:
				array = new byte[4];
				ms.Read(array, 0, 4);
				array = BytesTools.SwapBytes(array);
				SetAsInteger(BitConverter.ToInt32(array, 0));
				break;
			case 211:
				array = new byte[8];
				ms.Read(array, 0, 8);
				array = BytesTools.SwapBytes(array);
				SetAsInteger(BitConverter.ToInt64(array, 0));
				break;
			}
		}

		public byte[] Encode2Bytes()
		{
			using MemoryStream memoryStream = new MemoryStream();
			Encode2Stream(memoryStream);
			byte[] array = new byte[memoryStream.Length];
			memoryStream.Position = 0L;
			memoryStream.Read(array, 0, (int)memoryStream.Length);
			return Zip.Compress(array);
		}

		public void Encode2Stream(Stream ms)
		{
			switch (valueType)
			{
			case MsgPackType.Unknown:
			case MsgPackType.Null:
				WriteTools.WriteNull(ms);
				break;
			case MsgPackType.String:
				WriteTools.WriteString(ms, (string)innerValue);
				break;
			case MsgPackType.Integer:
				WriteTools.WriteInteger(ms, (long)innerValue);
				break;
			case MsgPackType.UInt64:
				WriteTools.WriteUInt64(ms, (ulong)innerValue);
				break;
			case MsgPackType.Boolean:
				WriteTools.WriteBoolean(ms, (bool)innerValue);
				break;
			case MsgPackType.Float:
				WriteTools.WriteFloat(ms, (double)innerValue);
				break;
			case MsgPackType.Single:
				WriteTools.WriteFloat(ms, (float)innerValue);
				break;
			case MsgPackType.DateTime:
				WriteTools.WriteInteger(ms, GetAsInteger());
				break;
			case MsgPackType.Binary:
				WriteTools.WriteBinary(ms, (byte[])innerValue);
				break;
			case MsgPackType.Map:
				WriteMap(ms);
				break;
			case MsgPackType.Array:
				WirteArray(ms);
				break;
			default:
				WriteTools.WriteNull(ms);
				break;
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new MsgPackEnum(children);
		}
	}
}
