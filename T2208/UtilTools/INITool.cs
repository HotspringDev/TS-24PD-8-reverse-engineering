using System;
using System.Runtime.InteropServices;
using System.Text;
using T2208.ViewModels;

namespace T2208.UtilTools
{
	// Token: 0x0200004D RID: 77
	public class INITool
	{
		// Token: 0x060003D9 RID: 985
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		// Token: 0x060003DA RID: 986
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		// Token: 0x060003DB RID: 987 RVA: 0x0001AE28 File Offset: 0x00019028
		public INITool(string iniPath)
		{
			this.path = iniPath;
			StringBuilder stringBuilder = new StringBuilder(255);
			bool flag = INITool.GetPrivateProfileString(Final.INI_sec, "Title", "", stringBuilder, 255, this.path) == 0;
			if (flag)
			{
				this.IniWritevalue(Final.INI_sec, "Title", Final.Name_APP);
			}
			bool flag2 = INITool.GetPrivateProfileString(Final.INI_sec, "Title", "", stringBuilder, 255, this.path) == 0;
			if (flag2)
			{
				this.IniWritevalue(Final.INI_sec, "Title", Final.Title);
			}
			bool flag3 = INITool.GetPrivateProfileString(Final.INI_sec, "Version", "", stringBuilder, 255, this.path) == 0;
			if (flag3)
			{
				this.IniWritevalue(Final.INI_sec, "Version", Final.Ver);
			}
			bool flag4 = INITool.GetPrivateProfileString(Final.INI_sec, "Support Version", "", stringBuilder, 255, this.path) == 0;
			if (flag4)
			{
				this.IniWritevalue(Final.INI_sec, "Support Version", Final.SuppVer);
			}
			bool flag5 = INITool.GetPrivateProfileString(Final.INI_sec, "AgNum", "", stringBuilder, 255, this.path) == 0;
			if (flag5)
			{
				this.IniWritevalue(Final.INI_sec, "AgNum", Final.AgNum);
			}
		}

		// Token: 0x060003DC RID: 988 RVA: 0x00006375 File Offset: 0x00004575
		public void IniWritevalue(string Section, string Key, string value)
		{
			INITool.WritePrivateProfileString(Section, Key, value, this.path);
		}

		// Token: 0x060003DD RID: 989 RVA: 0x0001AF90 File Offset: 0x00019190
		public string IniReadvalue(string Section, string Key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			int privateProfileString = INITool.GetPrivateProfileString(Section, Key, "", stringBuilder, 255, this.path);
			return stringBuilder.ToString();
		}

		// Token: 0x04000277 RID: 631
		public string path;
	}
}
