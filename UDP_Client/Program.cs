

using System.Net;
using System.Net.Sockets;
using System.Text;

string localIP = "192.168.0.105";
string serverIP = "192.168.0.105";

int port = 11001;
string message;

byte[] buffer = new byte[1024];
Socket udpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
IPEndPoint localHost = new IPEndPoint(IPAddress.Parse(localIP), port);
EndPoint remoteHost = new IPEndPoint(IPAddress.Parse(serverIP), port);

Console.WriteLine("UDP-клиент запущен...");

Console.WriteLine("Введите пример : ");
message = Console.ReadLine();


buffer = Encoding.UTF8.GetBytes(message);


int bytesAmount = await udpSocket.SendToAsync(buffer, remoteHost);

var result = await udpSocket.ReceiveFromAsync(buffer, remoteHost);


Console.WriteLine($"Результат : {Encoding.UTF8.GetString(buffer, 0, result.ReceivedBytes)}");
