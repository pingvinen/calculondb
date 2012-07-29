using System;
using Thrift.Transport;
using Thrift.Protocol;
using Missing.Diagnostics;
using Missing.ObjectExtensions;
using CalculonDb;
using System.Collections.Generic;
using System.Configuration;

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
				string host = ConfigurationManager.AppSettings["Interface.Host"];
				int port = Int32.Parse(ConfigurationManager.AppSettings["Interface.Port"]);

				var socket = new TSocket(host, port);
				var transport = new TBufferedTransport(socket);
				var protocol = new TBinaryProtocol(transport);
				var client = new InterfaceNodeService.Client(protocol);
				transport.Open();

				#region Input loop
				bool doContinueLoop = true;
				string cmd = String.Empty;
				string input = String.Empty;

				Entry tmpEntry = null;
				Result res = null;

				while (doContinueLoop)
				{
					cmd = Prompt("What do you want to do? (insert, getreport, getset, quit)");

					switch (cmd)
					{
						#region Quit
						case "quit":
						{
							doContinueLoop = false;
							break;
						}
						#endregion Quit

						#region Insert
						case "insert":
						{
							tmpEntry = new Entry();
							tmpEntry.Data = new Dictionary<string, string>();

							input = Prompt("Enter an Entry type");

							tmpEntry.Type = input;
							string tmpVarName = String.Empty;
							string tmpVarValue = String.Empty;

							while (true)
							{
								tmpVarName = Prompt("Enter name of var (or \"send\")");

								if (tmpVarName.Equals("send"))
								{
									break;
								}

								tmpVarValue = Prompt("Enter the value of the var (or \"send\")");

								if (tmpVarValue.Equals("send"))
								{
									break;
								}

								tmpEntry.Data.Add(tmpVarName, tmpVarValue);
							}

							Log.Trace("Sending insert");
							res = client.insert(tmpEntry);
							Log.Debug(res.DumpToString());

							tmpEntry = null;

							break;
						}
						#endregion Insert

						#region Get report
						case "getreport":
						{
							input = Prompt("Enter the name of the report you wish to get");

							Log.Trace("Sending getReport");
							res = client.getReport(input);
							Log.Debug(res.DumpToString());

							break;
						}
						#endregion Get report

						#region Get set
						case "getset":
						{
							input = Prompt("Enter the name of the set you wish to get");

							Log.Trace("Sending getSet");
							res = client.getSet(input);
							Log.Debug(res.DumpToString());

							break;
						}
						#endregion Get set

						default:
						{
							Log.Error("Invalid command '{0}'", cmd);
							break;
						}
					}
				}
				#endregion Input loop
			}
			catch(Exception ex)
			{
				Log.Error(ex.ToString());
			}

			Log.Information("Done... closing");
		}

		private static string Prompt(string message)
		{
			Console.WriteLine(message);
			Console.Write("> ");

			return Console.ReadLine().Trim();
		}
	}
}