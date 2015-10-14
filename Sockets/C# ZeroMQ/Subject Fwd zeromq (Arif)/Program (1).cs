using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using ZeroMQ;
using System;
namespace worker
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("worker!");
			using(var ctx = ZmqContext.Create())
			{
				using (ZmqSocket receiver = ctx.CreateSocket(SocketType.PULL),
				       sender = ctx.CreateSocket(SocketType.PUSH))
				{
					receiver.Bind("tcp://*:5563");
					//receiver.Connect("tcp://localhost:5563");
					sender.Connect("tcp://localhost:5562");
					int i = 0;
					string sndMsg;
					while (true)
					{
						string rcvdMsg = receiver.Receive (Encoding.UTF8);
						Console.WriteLine("Pulled : " + rcvdMsg);
						if (i == 1 || i == 5 || i == 10 || i == 15 || i == 20 || i == 25)
							sndMsg = "#Arif#";
						else
							sndMsg = rcvdMsg;
						//Thread.Sleep(1000);
						Console.WriteLine("Pushing: " + sndMsg);
						sender.Send(sndMsg, Encoding.UTF8);
						i++;
					}
				}
			}
		}
	}
}
