using System;
using Thrift.Transport;
using Thrift.Server;
using Missing.Diagnostics;

namespace CalculonDb.InterfaceNode
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Log.Use().SimpleConsoleColored();

			Log.Information("Booting");

			try
			{
				int port = Int32.Parse(System.Configuration.ConfigurationManager.AppSettings["Interface.Port"]);

				InterfaceNodeHandler handler = new InterfaceNodeHandler();

				InterfaceNodeService.Processor processor = new InterfaceNodeService.Processor(handler);
				TServerTransport serverTransport = new TServerSocket(port);
				TServer server = new TSimpleServer(processor, serverTransport);

				Log.Information("Starting server on port {0}", port);
				server.Serve();
			}

			catch (Exception ex)
			{
				Log.Error(ex.ToString());
			}

			Log.Information("Done... closing");
		}
	}
}
