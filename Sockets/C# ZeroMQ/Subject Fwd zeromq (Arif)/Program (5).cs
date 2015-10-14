using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

using ZeroMQ;
namespace push
{
	class MainClass
	{
		public static void Main (string[] args)
		{

			/*Console.WriteLine(Counter.SerialString);
			Counter.Serial++;
			Console.WriteLine(Counter.SerialString);
			Console.ReadKey();*/


			Console.WriteLine ("Push!");
			using(var ctx = ZmqContext.Create())
			{
				using (ZmqSocket socket = ctx.CreateSocket(SocketType.PUSH ))
				{
					//socket.Connect("tcp://localhost:5563");
					socket.Connect("tcp://192.168.168.36:8008");
				long msgCptr = 0;

				while (true)
				{

					msgCptr++;

					
					//var msg =msgCptr.ToString("d2");
						//var msg = GetRandomString ()+"="+msgCptr.ToString();

						//Thread.Sleep(1000);
					Console.WriteLine("Pushing: " + msgCptr);
						socket.Send("Pushing: " + msgCptr, Encoding.UTF8);
				}
			}
		}
		}

		public static string GetRandomString()
		{
			string path = Path.GetRandomFileName();
			path = path.Replace(".", ""); // Remove period.
			return path;
		}

		public class Counter
		{
			public static int Serial;

			public static string SerialString
			{
				get
				{
					return Serial.ToString("d2");
				}
			}
		}
	}
}
