using System.Threading.Tasks;
using HackenSlay.Networking;
using Xunit;

namespace HackenSlay.Tests;

public class NetworkingTests
{
    [Fact]
    public async Task ClientCanConnectToServer()
    {
        using var server = new LobbyServer(0);
        server.Start();
        using var client = new LobbyClient();
        await client.ConnectAsync("127.0.0.1", server.Port);
        // give server some time to register
        await Task.Delay(50);
        Assert.True(server.Port > 0);
    }

    [Fact]
    public async Task MessagesAreBroadcast()
    {
        using var server = new LobbyServer(0);
        server.Start();
        using var client1 = new LobbyClient();
        using var client2 = new LobbyClient();
        var tcs = new TaskCompletionSource<string>();
        client1.MessageReceived += msg => tcs.TrySetResult(msg);
        await client1.ConnectAsync("127.0.0.1", server.Port);
        await client2.ConnectAsync("127.0.0.1", server.Port);
        await Task.Delay(50);
        await client2.SendAsync("ping");
        var received = await Task.WhenAny(tcs.Task, Task.Delay(1000));
        Assert.Equal("ping", await tcs.Task);
    }
}
