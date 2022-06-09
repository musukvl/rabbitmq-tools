# Amba.RabbitMqTools
Tool for checking RabbitMq connection

Install tool:

```
dotnet tool install --global Amba.RabbitMqTools
```

CLI tool help:

```
Usage: amba-rabbitmq-tools [command] [options]

Options:
  -?|-h|--help  Show help information.

Commands:
  check-tcp  --host localhost --port 5672             # Try to establish TCP connection to host:port
  check-uri  --uri amqp://guest:guest@localhost:5672  # Try to connect RabbitMQ server

```