﻿using Amba.RabbitMqTools.Commands;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;

[HelpOption(Inherited = true)]
[Command(Description = "Rabbitmq tools"),
 Subcommand(typeof(CheckUriCommand)),
 Subcommand(typeof(CheckTcpCommand)),
]
public class Program
{
    public static int Main(string[] args)
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddSingleton(PhysicalConsole.Singleton);
        var services = serviceCollection.BuildServiceProvider();

        var app = new CommandLineApplication<Program>();
        app.Conventions
            .UseDefaultConventions()
            .UseConstructorInjection(services);

        var console = (IConsole)services.GetService(typeof(IConsole));

        try
        {
            return app.Execute(args);
        }
        catch (Exception ex)
        {
            console.WriteLine(ex);
            return 1;
        }
    }
    
    public int OnExecute(CommandLineApplication app, IConsole console)
    {
        console.WriteLine("Please specify a command.");
        app.ShowHelp();
        return 1;
    }

}