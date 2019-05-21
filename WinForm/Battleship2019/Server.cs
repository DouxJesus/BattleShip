using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    public class Server
    {
        private readonly int _port;
        private readonly Socket _sock;
        private readonly List<Socket> _clients;

        public void Run()
        {
            try
            {
                Init();
                while (true)
                {
                    var client = Accept();
                    new Thread(() => HandleClient(client)) {IsBackground = true}.Start();
                    Console.WriteLine("[" + client.RemoteEndPoint + "] " + "Connected");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                _sock.Close();
            }
        }

        public void HandleClient(Socket client)
        {
            try
            {
                while (true)
                {
                    ReceiveMessages(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[" + client.RemoteEndPoint + "] " + e.Message);
                client.Close();
            }
        }

        public Server(int port)
        {
            _sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clients = new List<Socket>();
            _port = port;
        }

        public void Init()
        {
            var ip = new IPEndPoint(IPAddress.Any, _port);
            _sock.Bind(ip);
            _sock.Listen(10);
            Console.WriteLine("Server Started");
        }

        public Socket Accept()
        {
            var client = _sock.Accept();
            _clients.Add(client);
            return client;
        }

        public void ReceiveMessages(Socket client)
        {
            byte[] buffer = new Byte[1024];
            var bytesize = client.Receive(buffer, SocketFlags.None);;
            if(bytesize == 0)
                return;
            SendMessage(Encoding.ASCII.GetString(buffer), client);
        }

        public void SendMessage(string message, Socket sender)
        {
            if (String.IsNullOrEmpty(message))
            {
                return;
            }
            byte[] buffer = new Byte[1024];
            byte[] input = Encoding.ASCII.GetBytes(message);


            int i = 0;
            while (i < input.Length && i < 1024)
            {
                buffer[i] = input[i];
                i++;
            }
            
            foreach (var e in _clients)
            {
                if (e != sender)
                    e.Send(buffer, input.Length, SocketFlags.None);
            }
            // logs
            Console.WriteLine("{0} : {1} sent {2}", DateTime.Now, sender, message);
        }
    }
}

