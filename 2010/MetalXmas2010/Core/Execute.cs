using System;
using System.Windows.Threading;

namespace MetalXmas2010.Core
{
	public static class Execute
	{
		public static Dispatcher CurrentDispatcher { get; set; }

		public static void OnUIThread(Action action)
		{
			CurrentDispatcher.BeginInvoke(action);
		}
	}
}