using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using McMaster.Extensions.CommandLineUtils;
using RabbitMQ.Client;

namespace Amba.RabbitMqTools.Commands;

[Command("check-tcp", Description = "Try to establish TCP connection to host:port")]
public class CheckTcpCommand 
{
    [Option("-h|--host", "Host used for tcp connection", CommandOptionType.SingleValue)]
    [Required]
    public string Host { get; set; }
    
    [Option("-p|--port", "Port used for tcp connection", CommandOptionType.SingleValue)]
    [Required]
    public int Port { get; set; }
    
    private readonly IConsole _console;

    public CheckTcpCommand(IConsole console)
    {
        _console = console;
    }
    
    public int OnExecute()
    {
        try
        {
            using var tcpClient = new TcpClient(Host, Port);
            if (tcpClient.Connected)
            {
                _console.WriteLine($"Connected");
                return 0;
            }
        }
        catch (Exception e)
        {
            _console.WriteLine(e);
            return 1;
        }
        _console.WriteLine($"Not connected");
        return 1;
    }
}
