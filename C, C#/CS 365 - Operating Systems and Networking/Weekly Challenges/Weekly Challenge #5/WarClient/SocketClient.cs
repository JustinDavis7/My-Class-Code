using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WarClient
{
    public static class SocketClient
    {
        private const int Port = 11000;
        private const int BufferSize = 256;

        public static void StartClient(out Socket client)
        {
            client = null;

            try
            {
                var ipHostInfo = Dns.GetHostEntry("localhost");
                var ipAddress = ipHostInfo.AddressList[0];
                var remoteEp = new IPEndPoint(ipAddress, Port);

                client = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                client.Connect(remoteEp);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static byte[] Receive(Socket socket)
        {
            var buffer = new byte[BufferSize];
            byte[] bytes = null;

            try
            {
                var messageSize = int.MinValue;
                var memoryStream = new MemoryStream();

                while (true)
                {
                    var bytesReceived = socket.Receive(buffer);

                    memoryStream.Write(buffer, 0, bytesReceived);

                    if (bytesReceived > 0 && messageSize == int.MinValue) messageSize = memoryStream.ToArray()[0];
                    if (messageSize == memoryStream.Length - 1) break;
                }

                bytes = memoryStream.ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine($"Received {bytes.Length} from server\n Data: {ConvertBytesToString(bytes)}");
            return bytes;
        }

        public static void Send(Socket client, byte[] bytes)
        {
            var bytesSent = client.Send(bytes);
            Console.WriteLine($"Sent {bytesSent} bytes to server\n Data: {ConvertBytesToString(bytes)}");
        }

        public static void Shutdown(Socket client)
        {
            client.Shutdown(SocketShutdown.Both);
            client.Close();
        }

        private static string ConvertBytesToString(byte[] bytes)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; ++i)
            {
                stringBuilder.Append(Convert.ToString(bytes[i]));
                if (i != bytes.Length - 1) stringBuilder.Append(" - ");
            }

            return stringBuilder.ToString();
        }
    }
}