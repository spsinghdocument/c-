using System;
using ZeroMQ;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Taskcollector
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Task Collector!");
			using(var ctx = ZmqContext.Create())
			{
				using (var socket = ctx.CreateSocket(SocketType.PULL))
				{

					socket.Bind("tcp://*:5562");

					while (true)
					{
						//Thread.Sleep(1000);
						var msg = socket.Receive(Encoding.UTF8);
						Console.WriteLine("Received: " + msg);
					}
				}
			}
		}
	}
}
