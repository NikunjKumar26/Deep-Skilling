using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace ChatProducer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

            Console.WriteLine("=== Chat Publisher ===");
            Console.Write("Enter your username: ");
            string username = Console.ReadLine() ?? "Anonymous";

            using (var producer = new ProducerBuilder<Null, string>(config).Build())
            {
                Console.WriteLine("Type your messages below (type 'exit' to quit):");
                string text;
                while ((text = Console.ReadLine()) != "exit")
                {
                    if (string.IsNullOrWhiteSpace(text)) continue;

                    string message = $"[{username}]: {text}";
                    
                    try
                    {
                        var deliveryResult = await producer.ProduceAsync("chat-topic", new Message<Null, string> { Value = message });
                        Console.WriteLine($"Delivered '{deliveryResult.Value}' to '{deliveryResult.TopicPartitionOffset}'");
                    }
                    catch (ProduceException<Null, string> e)
                    {
                        Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    }
                }
            }
        }
    }
}
