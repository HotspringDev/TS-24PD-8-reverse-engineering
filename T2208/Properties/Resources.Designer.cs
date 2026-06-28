using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace T2208.Properties
{
	// Token: 0x02000014 RID: 20
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[CompilerGenerated]
	public class Resources
	{
		// Token: 0x0600008F RID: 143 RVA: 0x00003D5D File Offset: 0x00001F5D
		internal Resources()
		{
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000090 RID: 144 RVA: 0x0000BE78 File Offset: 0x0000A078
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager resourceManager = new ResourceManager("T2208.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000091 RID: 145 RVA: 0x0000BEC0 File Offset: 0x0000A0C0
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00003D67 File Offset: 0x00001F67
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		public static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x04000052 RID: 82
		private static ResourceManager resourceMan;

		// Token: 0x04000053 RID: 83
		private static CultureInfo resourceCulture;
	}
}
