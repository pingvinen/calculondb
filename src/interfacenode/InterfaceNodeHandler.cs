using System;
using Missing.Diagnostics;
using Missing.ObjectExtensions;

namespace CalculonDb.InterfaceNode
{
	public class InterfaceNodeHandler : InterfaceNodeService.Iface
	{
		public InterfaceNodeHandler()
		{
		}

		public Result insert(Entry entry)
		{
			Log.Trace();
			Log.Debug(entry.DumpToString());

			return new Result() {
				StatusCode = 200,
				StatusMessage = "OK - insert"
			};
		}

		public Result getReport(string reportName)
		{
			Log.Trace();
			Log.Debug("reportName = '{0}'", reportName);

			return new Result() {
				StatusCode = 200,
				StatusMessage = "OK - getReport"
			};
		}

		public Result getSet(string setName)
		{
			Log.Trace();
			Log.Debug("setName = '{0}'", setName);

			return new Result() {
				StatusCode = 200,
				StatusMessage = "OK - getSet"
			};
		}
	}
}