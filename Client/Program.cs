using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new TcpClient();
            client.Connect(IPAddress.Parse("127.0.0.1"), 5000);
            var stream = client.GetStream();

            var msg = Encoding.UTF8.GetBytes("Hello there");
            stream.Write(msg, 0, msg.Length);

            var buffer = new byte[client.ReceiveBufferSize];
            var readCnt = stream.Read(buffer, 0, buffer.Length);

            var response = Encoding.UTF8.GetString(buffer, 0, readCnt);
            Console.WriteLine($"Response: {response}");

            stream.Close();
            client.Close();
        }
    }
}
