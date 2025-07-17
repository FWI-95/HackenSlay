using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace HackenSlay.Networking;

/// <summary>
/// Provides a simple TCP server and client for lobby style communication.
/// </summary>
public class LobbyServer : IDisposable
{
    private readonly TcpListener _listener;
    private readonly ConcurrentBag<TcpClient> _clients = new();
    private bool _running;

    /// <summary>
    /// Gets the port the server is listening on.
    /// </summary>
    public int Port => ((IPEndPoint)_listener.LocalEndpoint).Port;

    public LobbyServer(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
    }

    /// <summary>
    /// Starts listening for incoming connections.
    /// </summary>
    public void Start()
    {
        if (_running) return;
        _listener.Start();
        _running = true;
        _ = Task.Run(AcceptLoopAsync);
    }

    private async Task AcceptLoopAsync()
    {
        while (_running)
        {
            var client = await _listener.AcceptTcpClientAsync().ConfigureAwait(false);
            _clients.Add(client);
            _ = Task.Run(() => HandleClientAsync(client));
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        var stream = client.GetStream();
        byte[] buffer = new byte[1024];
        try
        {
            while (_running)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                if (read <= 0) break;
                var text = Encoding.UTF8.GetString(buffer, 0, read);
                await BroadcastAsync(text).ConfigureAwait(false);
            }
        }
        finally
        {
            client.Dispose();
        }
    }

    /// <summary>
    /// Sends a message to all connected clients.
    /// </summary>
    public async Task BroadcastAsync(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        foreach (var c in _clients.ToArray())
        {
            if (!c.Connected) continue;
            try
            {
                await c.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
            }
            catch
            {
                // ignore disconnected clients
            }
        }
    }

    public void Dispose()
    {
        _running = false;
        foreach (var c in _clients) c.Dispose();
        _listener.Stop();
    }
}

/// <summary>
/// Simple TCP client for lobby messages.
/// </summary>
public class LobbyClient : IDisposable
{
    private readonly TcpClient _client = new();
    public event Action<string>? MessageReceived;

    /// <summary>
    /// Connects to the given server host and port.
    /// </summary>
    public async Task ConnectAsync(string host, int port)
    {
        await _client.ConnectAsync(host, port).ConfigureAwait(false);
        _ = Task.Run(ReceiveLoopAsync);
    }

    /// <summary>
    /// Sends a text message to the server.
    /// </summary>
    public async Task SendAsync(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(message);
        await _client.GetStream().WriteAsync(data, 0, data.Length).ConfigureAwait(false);
    }

    private async Task ReceiveLoopAsync()
    {
        var stream = _client.GetStream();
        byte[] buffer = new byte[1024];
        try
        {
            while (true)
            {
                int read = await stream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false);
                if (read <= 0) break;
                var text = Encoding.UTF8.GetString(buffer, 0, read);
                MessageReceived?.Invoke(text);
            }
        }
        catch
        {
            // connection closed
        }
    }

    public void Dispose() => _client.Dispose();
}
