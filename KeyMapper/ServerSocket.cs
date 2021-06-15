using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace KeyMapper
{
    class ServerSocket
    {

        private Socket serverSocket;
        public ServerSocket(int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(string.Empty);
            IPAddress ipAddress = null;

            //Get the ipv4 address
            for (int i = 0; i < ipHostInfo.AddressList.Length; i++)
            {
                if (ipHostInfo.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ipHostInfo.AddressList[i];
                    Console.WriteLine(ipAddress);
                }
            }

            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, port);

            serverSocket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            serverSocket.Bind(localEndPoint);
            serverSocket.Listen(10);

        }

        public Socket AcceptClient()
        {
            return serverSocket.Accept();
        }


    }
}
