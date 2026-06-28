using System;
using System.Windows;
using System.Windows.Threading;

namespace T2208.API
{
	// Token: 0x020000BF RID: 191
	public static class Execute
	{
		// Token: 0x06000992 RID: 2450 RVA: 0x0002AB08 File Offset: 0x00028D08
		public static void InitializeWithDispatcher()
		{
			Dispatcher currentDispatcher = Dispatcher.CurrentDispatcher;
			Execute._executor = delegate(Action action)
			{
				Application.Current.Dispatcher.Invoke(action);
			};
		}

		// Token: 0x06000993 RID: 2451 RVA: 0x0000A188 File Offset: 0x00008388
		public static void OnUiThread(this Action action)
		{
			Execute._executor(action);
		}

		// Token: 0x040004D6 RID: 1238
		private static Action<Action> _executor = delegate(Action action)
		{
			action();
		};
	}
}
