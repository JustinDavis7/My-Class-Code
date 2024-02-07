using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace WarServer
{
    public class SocketServer
    {
        public const int BufferSize = 256;

        public static void StartListening()
        {
            var ipHostInfo = Dns.GetHostEntry("localhost");
            var ipAddress = ipHostInfo.AddressList[0];
            var localEndPoint = new IPEndPoint(ipAddress, 11000);

            var listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    var handler = listener.Accept();
                    Program.Players.Add(handler);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
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

            Console.WriteLine($"Received {bytes.Length} from client\n Data: {ConvertBytesToString(bytes)}");
            return bytes;
        }

        public static void Send(Socket client, byte[] bytes)
        {
            var bytesSent = client.Send(bytes);
            Console.WriteLine($"Sent {bytesSent} bytes to client\n Data: {ConvertBytesToString(bytes)}");
        }

        public static void Shutdown(Socket socket)
        {
            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
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