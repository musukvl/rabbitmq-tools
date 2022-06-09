using McMaster.Extensions.CommandLineUtils;
using RabbitMQ.Client;

namespace Amba.RabbitMqTools.Commands;

[Command("check-uri", Description = "Try to connect RabbitMQ server")]
public class CheckUriCommand : RabbitCommandBase
{
    private readonly IConsole _console;

    public CheckUriCommand(IConsole console)
    {
        _console = console;
    }
    
    public int OnExecute()
    {
        try
        {
            var connectionFactory = new ConnectionFactory
            {
                Uri = RabbitUri
            };

            using var connection = connectionFactory.CreateConnection();
            if (connection.IsOpen)
            {
                _console.WriteLine("Connection is opened");
                return 0;
            }
        }
        catch (Exception e)
        {
            _console.WriteLine("Connection failed: " + e.Message + " " + e.InnerException?.Message);
            return 1;
        }
        _console.WriteLine($"Not connected");
        return 1;
    }
}