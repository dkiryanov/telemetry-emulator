using Microsoft.ServiceBus.Messaging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;


namespace EventHubMessageSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TELEMETRY SENDER EMULATOR");
            Console.WriteLine("__________________________");
            Console.ResetColor();

            SendTelemetryMessages();

            Console.ReadKey();
        }

        static async void SendTelemetryMessages()
        {
            EventHubClient eventHubClient = EventHubClient.CreateFromConnectionString(Settings.Default.EventHubConnectionString, Settings.Default.EventHubName);

            Random rand = new Random();

            Thread.Sleep(5000);

            while (true)
            {
                TelemetryPoint telemetryPoint = new TelemetryPoint(rand);
                string messageString = JsonConvert.SerializeObject(telemetryPoint);

                await eventHubClient.SendAsync(new EventData(Encoding.UTF8.GetBytes(messageString)));

                Console.WriteLine($"Sending message: {messageString}");

                Thread.Sleep(2000);
            }
        }
    }
}
