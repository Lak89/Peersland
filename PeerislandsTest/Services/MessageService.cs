using PeerislandsTest.Contracts;
using System;

namespace PeerislandsTest.Services
{
    public class MessageService : IMessageService
    {
        /// <summary>
        /// This method display message in console window
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            Console.WriteLine($"{message} \n\n");
        }
    }
}
