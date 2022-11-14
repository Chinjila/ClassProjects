using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using Microsoft.Extensions.Configuration;

var configuration = new ConfigurationBuilder().AddUserSecrets<Program>();
var configs = configuration.Build();

string secret = configs["secret"];

QueueClient queueClient = new QueueClient(secret, "class");

for (int i = 0; i < 100; i++)
{
    queueClient.SendMessageAsync($"Message From Victor #{i}");
}

while (true)
{
    QueueMessage[] retrievedMessage = await queueClient.ReceiveMessagesAsync(10);
    foreach (var item in retrievedMessage)
    {
        Console.WriteLine($"Retrieved message with content '{item.Body}'");
        await queueClient.DeleteMessageAsync(item.MessageId, item.PopReceipt);
        Console.WriteLine($"Deleted message: '{item.Body}'");
    }
    await Task.Delay(1000);
}
//process message


// Async delete the message

