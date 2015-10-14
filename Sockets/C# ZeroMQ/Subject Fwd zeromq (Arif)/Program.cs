using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading;


using Pub;
using ZeroMQ;

namespace ZMQGuide
{
	class Program
	{
		static void Main(string[] args)
		{
			// ZMQ Context, server socket
			/*using (ZmqContext context = ZmqContext.Create())
				using (ZmqSocket server = context.CreateSocket(SocketType.REP))
			{
				server.Bind("tcp://*:5555");

				while (true)
				{
					// Wait for next request from client
					string message = server.Receive(Encoding.Unicode);
					Console.WriteLine("Received request: {0}", message);

					// Do Some 'work'
					Thread.Sleep(1000);

					// Send reply back to client
					server.Send("World", Encoding.Unicode);
				}
			}*/
			using (var context = ZmqContext.Create())
			{
				using (ZmqSocket subscriber = context.CreateSocket(SocketType.SUB))
				{
					subscriber.Connect("tcp://localhost:5563");
					subscriber.Subscribe(Encoding.Unicode.GetBytes("B"));
					//subscriber.SubscribeAll ();
				
					while (true)
					{
						string address = subscriber.Receive(Encoding.Unicode);
						string contents = subscriber.Receive(Encoding.Unicode);
						Console.WriteLine("{0} : {1}", address, contents);
						//subscriber.SendM("World", Encoding.Unicode);
					}
				}
			}

		}
		}
	}
