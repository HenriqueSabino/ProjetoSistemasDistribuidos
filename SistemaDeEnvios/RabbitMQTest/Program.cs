using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;

ConnectionFactory _factory;
IConnection _connection;
IModel _channel;


_factory = new ConnectionFactory
{
    HostName = "localhost",
    DispatchConsumersAsync = true
};

_connection = _factory.CreateConnection();
_channel = _connection.CreateModel();

string queue = "parcel-requests";

_channel.QueueDeclare(queue, true, false, false);
var properties = _channel.CreateBasicProperties();
properties.Persistent = false;

var message = new
{
};

var output = JsonConvert.SerializeObject(message);
_channel.BasicPublish(string.Empty, queue, null,
Encoding.UTF8.GetBytes(output));
