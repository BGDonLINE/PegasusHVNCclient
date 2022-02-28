using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Peg.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

		public static Settings Default => defaultInstance;

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpuBin
		{
			get
			{
				return (string)this["cpuBin"];
			}
			set
			{
				this["cpuBin"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string gpuBin
		{
			get
			{
				return (string)this["gpuBin"];
			}
			set
			{
				this["gpuBin"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string cpuProc
		{
			get
			{
				return (string)this["cpuProc"];
			}
			set
			{
				this["cpuProc"] = value;
			}
		}

		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string gpuProc
		{
			get
			{
				return (string)this["gpuProc"];
			}
			set
			{
				this["gpuProc"] = value;
			}
		}
	}
}
