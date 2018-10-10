using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {

            var server = new TcpListener(IPAddress.Parse("127.0.0.1"), 5000); 
            server.Start();
            Console.WriteLine("Server started...");

            while (true)
            {

                var client = server.AcceptTcpClient();
                var stream = client.GetStream(); 
                var buffer = new byte[client.ReceiveBufferSize];

                var readCount =
                    stream.Read(buffer, 0, buffer.Length); 

                var message = Encoding.UTF8.GetString(buffer, 0, readCount);

                Console.WriteLine($"Message is: {message}");

                var payload =
                    Encoding.UTF8.GetBytes(message.ToUpper()); 
                stream.Write(payload, 0, payload.Length);


                stream.Close();
                client.Close();
            }
        }
    }
}
