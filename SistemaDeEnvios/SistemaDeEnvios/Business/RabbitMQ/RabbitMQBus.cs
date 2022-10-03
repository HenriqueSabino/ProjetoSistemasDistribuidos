using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SistemaDeEnvios.Business.Interfaces;

namespace SistemaDeEnvios.Business.RabbitMQ;

public class RabbitMQBus : IBus
{
    private readonly IModel _channel;

    internal RabbitMQBus(IModel channel)
    {
        _channel = channel;
    }

    public async Task SendAsync<T>(string queue, T message)
    {
        await Task.Run(() =>
        {
            _channel.QueueDeclare(queue, true, false, false);
            var properties = _channel.CreateBasicProperties();
            properties.Persistent = false;
            var output = JsonConvert.SerializeObject(message);
            _channel.BasicPublish(string.Empty, queue, null,
          Encoding.UTF8.GetBytes(output));
        });
    }

    public async Task ReceiveAsync<T>(string queue, Action<T> onMessage)
    {
        _channel.QueueDeclare(queue, true, false, false);
        var consumer = new AsyncEventingBasicConsumer(_channel);

        consumer.Received += async (s, e) =>
        {
            var jsonSpecified = Encoding.UTF8.GetString(e.Body.Span);
            var item = JsonConvert.DeserializeObject<T>(jsonSpecified);
            onMessage(item);
            await Task.Yield();
        };
        _channel.BasicConsume(queue, true, consumer);
        await Task.Yield();
    }
}