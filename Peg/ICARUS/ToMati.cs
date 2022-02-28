using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Peg.ICARUS
{
	internal class ToMati
	{
		[ComImport]
		[ComVisible(true)]
		[Guid("29840822-5B84-11D0-BD3B-00A0C911CE86")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface ICreateDevEnum
		{
			int CreateClassEnumerator([In] ref Guid pType, [In][Out] ref IEnumMoniker ppEnumMoniker, [In] int dwFlags);
		}

		[ComImport]
		[ComVisible(true)]
		[Guid("55272A00-42CB-11CE-8135-00AA004BB851")]
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPropertyBag
		{
			int Read([MarshalAs(UnmanagedType.LPWStr)] string PropName, ref object Var, int ErrorLog);

			int Write(string PropName, ref object Var);
		}

		public static readonly Guid CLSID_VideoInputDeviceCategory = new Guid("{860BB310-5D01-11d0-BD3B-00A0C911CE86}");

		public static readonly Guid CLSID_SystemDeviceEnum = new Guid("{62BE5D10-60EB-11d0-BD3B-00A0C911CE86}");

		public static readonly Guid IID_IPropertyBag = new Guid("{55272A00-42CB-11CE-8135-00AA004BB851}");

		public static bool havecamera()
		{
			if (FindDevices().Length == 0)
			{
				return false;
			}
			return true;
		}

		public static string[] FindDevices()
		{
			return GetFiltes(CLSID_VideoInputDeviceCategory).ToArray();
		}

		public static List<string> GetFiltes(Guid category)
		{
			List<string> result = new List<string>();
			EnumMonikers(category, delegate(IMoniker moniker, IPropertyBag prop)
			{
				object Var = null;
				prop.Read("FriendlyName", ref Var, 0);
				string item = (string)Var;
				result.Add(item);
				return false;
			});
			return result;
		}

		private static void EnumMonikers(Guid category, Func<IMoniker, IPropertyBag, bool> func)
		{
			IEnumMoniker ppEnumMoniker = null;
			ICreateDevEnum createDevEnum = null;
			try
			{
				createDevEnum = (ICreateDevEnum)Activator.CreateInstance(Type.GetTypeFromCLSID(CLSID_SystemDeviceEnum));
				createDevEnum.CreateClassEnumerator(ref category, ref ppEnumMoniker, 0);
				if (ppEnumMoniker == null)
				{
					return;
				}
				IMoniker[] array = new IMoniker[1];
				IntPtr zero = IntPtr.Zero;
				while (ppEnumMoniker.Next(array.Length, array, zero) == 0)
				{
					IMoniker moniker = array[0];
					object ppvObj = null;
					Guid riid = IID_IPropertyBag;
					moniker.BindToStorage(null, null, ref riid, out ppvObj);
					IPropertyBag propertyBag = (IPropertyBag)ppvObj;
					try
					{
						if (func(moniker, propertyBag))
						{
							break;
						}
					}
					finally
					{
						Marshal.ReleaseComObject(propertyBag);
						if (moniker != null)
						{
							Marshal.ReleaseComObject(moniker);
						}
					}
				}
			}
			finally
			{
				if (ppEnumMoniker != null)
				{
					Marshal.ReleaseComObject(ppEnumMoniker);
				}
				if (createDevEnum != null)
				{
					Marshal.ReleaseComObject(createDevEnum);
				}
			}
		}
	}
}
