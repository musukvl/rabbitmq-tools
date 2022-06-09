using System.ComponentModel.DataAnnotations;
using McMaster.Extensions.CommandLineUtils;

namespace Amba.RabbitMqTools.Commands;

public abstract class RabbitCommandBase 
{
    [Option("-uri|--uri", "RabbitUri used for RabbitMQ connection", CommandOptionType.SingleValue)]
    [Required]
    public Uri RabbitUri { get; set; }
    
}