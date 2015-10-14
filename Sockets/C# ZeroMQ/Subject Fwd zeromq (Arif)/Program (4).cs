using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading;

using ZeroMQ;
namespace client2
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Console.WriteLine ("Hello World!");
			using (var context = ZmqContext.Create())
			{
				using (ZmqSocket subscriber = context.CreateSocket(SocketType.SUB))
				{
					subscriber.Connect("tcp://localhost:5563");
					subscriber.Subscribe(Encoding.Unicode.GetBytes("A"));
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

