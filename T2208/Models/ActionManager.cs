using System;
using System.Collections.Generic;
using System.Timers;

namespace T2208.Models
{
	// Token: 0x0200008B RID: 139
	public class ActionManager
	{
		// Token: 0x06000792 RID: 1938 RVA: 0x000244A8 File Offset: 0x000226A8
		public ActionManager()
		{
			this.Timer.AutoReset = true;
			this.Timer.Elapsed += this.Timer_Elapsed;
			this.Timer.Start();
		}

		// Token: 0x06000793 RID: 1939 RVA: 0x00024504 File Offset: 0x00022704
		private void Timer_Elapsed(object sender, ElapsedEventArgs e)
		{
			Action action = null;
			lock (this._ActionQueue)
			{
				bool flag = this._ActionQueue.Count > 30;
				if (flag)
				{
					this.Timer.Interval = 60.0;
				}
				else
				{
					this.Timer.Interval = 80.0;
				}
				bool flag2 = this._ActionQueue.Count > 0;
				if (flag2)
				{
					action = this._ActionQueue.Dequeue();
				}
			}
			if (action != null)
			{
				action();
			}
		}

		// Token: 0x06000794 RID: 1940 RVA: 0x00008DEF File Offset: 0x00006FEF
		public void Add(Action action)
		{
			lock (this._ActionQueue)
			{
				this._ActionQueue.Enqueue(action);
			}
		}

		// Token: 0x04000439 RID: 1081
		private Queue<Action> _ActionQueue = new Queue<Action>();

		// Token: 0x0400043A RID: 1082
		private Timer Timer = new Timer(80.0);
	}
}
