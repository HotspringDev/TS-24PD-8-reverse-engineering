using System;
using System.Windows.Input;

namespace T2208.ViewModels
{
	// Token: 0x02000027 RID: 39
	public class AnotherCommandImplementation : ICommand
	{
		// Token: 0x06000103 RID: 259 RVA: 0x00003FBE File Offset: 0x000021BE
		public AnotherCommandImplementation(Action<object> execute)
			: this(execute, null)
		{
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0000E40C File Offset: 0x0000C60C
		public AnotherCommandImplementation(Action<object> execute, Func<object, bool> canExecute)
		{
			bool flag = execute == null;
			if (flag)
			{
				throw new ArgumentNullException("execute");
			}
			this._execute = execute;
			this._canExecute = canExecute ?? ((object x) => true);
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000105 RID: 261 RVA: 0x00003FCA File Offset: 0x000021CA
		// (remove) Token: 0x06000106 RID: 262 RVA: 0x00003FD4 File Offset: 0x000021D4
		public event EventHandler CanExecuteChanged
		{
			add
			{
				CommandManager.RequerySuggested += value;
			}
			remove
			{
				CommandManager.RequerySuggested -= value;
			}
		}

		// Token: 0x06000107 RID: 263 RVA: 0x0000E468 File Offset: 0x0000C668
		public bool CanExecute(object parameter)
		{
			return this._canExecute(parameter);
		}

		// Token: 0x06000108 RID: 264 RVA: 0x00003FDE File Offset: 0x000021DE
		public void Execute(object parameter)
		{
			this._execute(parameter);
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00003FEE File Offset: 0x000021EE
		public void Refresh()
		{
			CommandManager.InvalidateRequerySuggested();
		}

		// Token: 0x040000A8 RID: 168
		private readonly Func<object, bool> _canExecute;

		// Token: 0x040000A9 RID: 169
		private readonly Action<object> _execute;
	}
}
