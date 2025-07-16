using System.Net.Sockets;
using System.Text;

namespace HackenSlay.Networking;

public class NetworkManager
{
    private TcpClient? _client;

    public void Connect(string host, int port)
    {
        _client = new TcpClient();
        _client.Connect(host, port);
    }

    public void Send(string message)
    {
        if (_client == null) return;
        byte[] data = Encoding.UTF8.GetBytes(message);
        _client.GetStream().Write(data, 0, data.Length);
    }
}
