using PrototypeBankSystem.Domain.Entities;
using System;

namespace PrototypeBankSystem.Presentation.Services
{
    static internal class MessageService 
    {
        static internal event Action<string> OnMessageSend;
        
        static internal void SendMessage(string text)
        {
            OnMessageSend?.Invoke(text);
        }
    }
}
