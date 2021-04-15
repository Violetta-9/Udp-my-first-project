using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace UDP
{
    class Program
    {
        static void Main(string[] args)
        {
            const string ip = "127.0.0.1";
            const int port = 8081;
            var udpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port);
            var udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            udpSocket.Bind(udpEndPoint);
            while (true)
            {
                var buffer = new byte[256];
                var size = 0;
                var data = new StringBuilder();
                EndPoint senderEndPoint = new IPEndPoint(IPAddress.Any, 0);//Сохраняется адресс клиента

                do
                {

                    size = udpSocket.ReceiveFrom(buffer, ref senderEndPoint);//принимает EndPoint в качестве 2 параметра!!!!
                    data.Append(Encoding.UTF8.GetString(buffer));
                }
                while (udpSocket.Available > 0);
                udpSocket.SendTo(Encoding.UTF8.GetBytes("Сщщбщение полученно"), senderEndPoint);

                Console.WriteLine(data);
            }
            //TODO:закрытие сокета
        }
    }
}
   

