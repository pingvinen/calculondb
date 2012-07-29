using System;
using Thrift.Transport;
using Thrift.Protocol;
using Missing.Diagnostics;
using Missing.ObjectExtensions;
using CalculonDb;
using System.Collections.Generic;

namespace testclient
{
	class Program
	{
		static void Main(string[] args)
		{
			Log.Use().SimpleConsoleColored();

			Log.Information("Booting");

			try
			{
				int port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Interface.Port"]);

				var socket = new TSocket("localhost", port);
				var transport = new TBufferedTransport(socket);
				var protocol = new TBinaryProtocol(transport);
				var client = new InterfaceNodeService.Client(protocol);
				transport.Open();

				Log.Trace("Sending insert");
				Result res = client.insert(new Entry() {
					Type = "DumbTest",
					Data = new Dictionary<string, string>() {
						{"Var1", "One"},
						{"VarTwo", "2"}
					}
				});

				Log.Debug(res.DumpToString());
			}
			catch(Exception ex)
			{
				Log.Error(ex.ToString());
			}

			Log.Information("Done... closing");
		}
	}
}