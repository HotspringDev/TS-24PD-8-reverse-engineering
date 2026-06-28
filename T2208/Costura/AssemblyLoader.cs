using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Costura
{
	// Token: 0x020000D3 RID: 211
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x0600099A RID: 2458 RVA: 0x0000A1D7 File Offset: 0x000083D7
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x0600099B RID: 2459 RVA: 0x0002AB40 File Offset: 0x00028D40
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x0600099C RID: 2460 RVA: 0x0002ABA8 File Offset: 0x00028DA8
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int num;
			while ((num = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, num);
			}
		}

		// Token: 0x0600099D RID: 2461 RVA: 0x0002ABDC File Offset: 0x00028DDC
		private static Stream LoadStream(string fullname)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullname.EndsWith(".compressed"))
			{
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullname))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						return memoryStream;
					}
				}
			}
			return executingAssembly.GetManifestResourceStream(fullname);
		}

		// Token: 0x0600099E RID: 2462 RVA: 0x0002AC60 File Offset: 0x00028E60
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string text;
			if (resourceNames.TryGetValue(name, out text))
			{
				return AssemblyLoader.LoadStream(text);
			}
			return null;
		}

		// Token: 0x0600099F RID: 2463 RVA: 0x0002AC80 File Offset: 0x00028E80
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x060009A0 RID: 2464 RVA: 0x0002ACA8 File Offset: 0x00028EA8
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = string.Format("{0}.{1}", requestedAssemblyName.CultureInfo.Name, text);
			}
			byte[] array;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				array = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] array2 = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(array, array2);
				}
			}
			return Assembly.Load(array);
		}

		// Token: 0x060009A1 RID: 2465 RVA: 0x0002AD68 File Offset: 0x00028F68
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				obj = AssemblyLoader.nullCacheLock;
				lock (obj)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if (assemblyName.Flags == AssemblyNameFlags.Retargetable)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x060009A2 RID: 2466 RVA: 0x0002AE28 File Offset: 0x00029028
		// Note: this type is marked as 'beforefieldinit'.
		static AssemblyLoader()
		{
			AssemblyLoader.assemblyNames.Add("basicclasslib", "costura.basicclasslib.dll.compressed");
			AssemblyLoader.symbolNames.Add("basicclasslib", "costura.basicclasslib.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("commlibrary", "costura.commlibrary.dll.compressed");
			AssemblyLoader.symbolNames.Add("commlibrary", "costura.commlibrary.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("fft", "costura.fft.dll.compressed");
			AssemblyLoader.symbolNames.Add("fft", "costura.fft.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("icsharpcode.avalonedit", "costura.icsharpcode.avalonedit.dll.compressed");
			AssemblyLoader.assemblyNames.Add("jaycustomcontrollib", "costura.jaycustomcontrollib.dll.compressed");
			AssemblyLoader.symbolNames.Add("jaycustomcontrollib", "costura.jaycustomcontrollib.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("jaylib", "costura.jaylib.dll.compressed");
			AssemblyLoader.symbolNames.Add("jaylib", "costura.jaylib.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("jetbrains.annotations", "costura.jetbrains.annotations.dll.compressed");
			AssemblyLoader.assemblyNames.Add("lib.controls.mycontrols", "costura.lib.controls.mycontrols.dll.compressed");
			AssemblyLoader.symbolNames.Add("lib.controls.mycontrols", "costura.lib.controls.mycontrols.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("mahapps.metro", "costura.mahapps.metro.dll.compressed");
			AssemblyLoader.assemblyNames.Add("materialdesigncolors", "costura.materialdesigncolors.dll.compressed");
			AssemblyLoader.assemblyNames.Add("materialdesignthemes.wpf", "costura.materialdesignthemes.wpf.dll.compressed");
			AssemblyLoader.assemblyNames.Add("microsoft.expression.interactions", "costura.microsoft.expression.interactions.dll.compressed");
			AssemblyLoader.assemblyNames.Add("seikaku.wpf.theme", "costura.seikaku.wpf.theme.dll.compressed");
			AssemblyLoader.symbolNames.Add("seikaku.wpf.theme", "costura.seikaku.wpf.theme.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("showmethexaml.avalonedit", "costura.showmethexaml.avalonedit.dll.compressed");
			AssemblyLoader.assemblyNames.Add("showmethexaml", "costura.showmethexaml.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.data.sqlite", "costura.system.data.sqlite.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.windows.interactivity", "costura.system.windows.interactivity.dll.compressed");
		}

		// Token: 0x060009A3 RID: 2467 RVA: 0x0000A1E8 File Offset: 0x000083E8
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x040004EE RID: 1262
		private static readonly object nullCacheLock = new object();

		// Token: 0x040004EF RID: 1263
		private static readonly Dictionary<string, bool> nullCache = new Dictionary<string, bool>();

		// Token: 0x040004F0 RID: 1264
		private static readonly Dictionary<string, string> assemblyNames = new Dictionary<string, string>();

		// Token: 0x040004F1 RID: 1265
		private static readonly Dictionary<string, string> symbolNames = new Dictionary<string, string>();

		// Token: 0x040004F2 RID: 1266
		private static int isAttached = 0;
	}
}
