using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;

namespace Client
{
	public class Client
	{
		private readonly Socket _sock;

		public void Run()
		{
			new Thread(() =>
			{
				while (true) ReceiveData();
			}) {IsBackground = true}.Start();

			while (true) SendData();
		}

		public Client(IPAddress address, int port)
		{
			_sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			_sock.Connect(address, port);
		}

		public void ReceiveData()
		{
			byte[] buffer = new Byte[1024];
			var bytesize = _sock.Receive(buffer, SocketFlags.None);
			var str = Encoding.ASCII.GetString(buffer);
			var output = "";
			for (int i = 0; i < bytesize; i++)
			{
				output += str[i];
			}
			if (String.IsNullOrEmpty(output))
				return;
			Console.WriteLine("{0} : {1} ", DateTime.Now.TimeOfDay, output);
			
			
		}

		public void SendData()
		{
			byte[] buffer = new Byte[1024];
			
			
			string input = Console.ReadLine();
			var byte_input = Encoding.ASCII.GetBytes(input);
			int i = 0;
			while (i < input.Length && i < 1024)
			{
				buffer[i] = byte_input[i];
				i++;
			}
			_sock.Send(buffer, byte_input.Length, SocketFlags.None);
		}
	}
}