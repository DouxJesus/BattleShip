using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Battleship2019
{
    class NetworkControllerServer
    {
        private bool run_server;
        private TcpListener serverSocket;
        TcpClient clientSocket;
        public string my_ip;
        private string client_ip;
        public NetworkControllerServer()
        {
            this.run_server = false;
        }
       
        public void StartServer()
        {
            this.serverSocket = new TcpListener(8888);
            this.clientSocket = default(TcpClient);
            this.serverSocket.Start();
            this.clientSocket = serverSocket.AcceptTcpClient();
            Console.WriteLine("Starting Server");
            while ((true))
            {
                try
                {
                    NetworkStream networkStream = clientSocket.GetStream();
                    byte[] bytesFrom = new byte[10025];
                    networkStream.Read(bytesFrom, 0, (int)clientSocket.ReceiveBufferSize);
                    string dataFromClient = System.Text.Encoding.ASCII.GetString(bytesFrom);
                    dataFromClient = dataFromClient.Substring(0, dataFromClient.IndexOf("$"));
                    Console.WriteLine(" >> Data from client - " + dataFromClient);
                    string serverResponse = "Last Message from client" + dataFromClient;
                    Byte[] sendBytes = Encoding.ASCII.GetBytes(serverResponse);
                    networkStream.Write(sendBytes, 0, sendBytes.Length);
                    networkStream.Flush();
                    Console.WriteLine(" >> " + serverResponse);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }

        }

        public void StopServer()
        {
            clientSocket.Close();
            serverSocket.Stop()
        }

    }
}
