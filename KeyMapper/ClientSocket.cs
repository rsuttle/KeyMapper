using System;
using System.Text;
using System.Net.Sockets;

namespace KeyMapper
{
    class ClientSocket
    {

        private Socket clientSocket;

        public ClientSocket(Socket s)
        {
            clientSocket = s;
        }

        public void Disconnect()
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }

        public void SendMsg(string s)
        {
            byte[] echoToClient = Encoding.ASCII.GetBytes(s);
            clientSocket.Send(echoToClient);
        }

        public string GetMsg()
        {
            //Buffer for incoming data
            byte[] bytes = new Byte[1024];

            try
            {

                while (true)
                {
                    Console.WriteLine("Listening for incoming connections...");

                    string data = null;

                    while (true)
                    {
                        int bytesRec = clientSocket.Receive(bytes);
                        data += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                        if (data.IndexOf("<EOF>") > -1)
                        {
                            //Remove the <EOF>
                            data = data.Substring(0, data.Length - 5);
                            break;
                        }
                    }

                    return data;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return "";
        }
    }
}
