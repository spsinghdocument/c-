namespace Sub
{
	using System;
	using System.Collections.Generic;
	//using System.Linq;
	using System.Text;
	using System.Threading;
	using CommandLine;
	using ZeroMQ;


	class Program
	{
		static void Main (string[] args)
		{


			// ZMQ Context and client socket
			/*using (ZmqContext context = ZmqContext.Create())
				using (ZmqSocket client = context.CreateSocket(SocketType.REQ))
			{
				client.Connect("tcp://localhost:5555");

			/*	string request = "Hello";
				for (int requestNum = 0; requestNum < 10; requestNum++)
				{
					Console.WriteLine("Sending request {0}...", requestNum);
					client.Send(request, Encoding.Unicode);

					string reply = client.Receive(Encoding.Unicode);
					Console.WriteLine("Received reply {0}: {1}", requestNum, reply);
				}
			}*/

			using (var context = ZmqContext.Create())
			{
				using (ZmqSocket publisher = context.CreateSocket(SocketType.PUB))
				{
					publisher.Bind("tcp://*:5563");

					while (true)
					{
						// Write two messages, each with an envelope and content
						publisher.SendMore("A", Encoding.Unicode);
						publisher.Send("We don't want to see this.", Encoding.Unicode);
						publisher.SendMore("B", Encoding.Unicode);
						publisher.Send("We would like to see this.", Encoding.Unicode);
						Thread.Sleep(1000); // avoid flooding the publisher
						//string address = publisher.Receive(Encoding.Unicode);
						//Console.WriteLine ("reciever="+address);
					}
				}
			}

			}
		}
	}


		
	

