using EasyNetQ;
using REALWorks.AuthServer.Events;
using System;

namespace REALWorks.ClientConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bus = RabbitHutch.CreateBus("host=192.168.99.100"))
            {
                bus.Subscribe<string>("real", HandleTextMessage);

                Console.WriteLine("Listening for messages. Hit <return> to quit.");
                Console.ReadLine();
            }

            Console.WriteLine("Hello World!");
            Console.WriteLine("Listening for messages. Hit <return> to quit.");
            Console.ReadLine(); // Keep the console window open
        }

        private static void HandleTextMessage(string message)
        {
            //throw new NotImplementedException();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Got message: {0}", message);
            Console.ResetColor();
        }
    }
}
