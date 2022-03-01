using PrototypeBankSystem.Domain.Entities;
using System;

namespace PrototypeBankSystem.Presentation.Services
{
    static internal class MessageService 
    {
        static internal event Action OnMessageSend;
        
        static internal void SendMessage()
        {
            OnMessageSend?.Invoke();
        }
    }
}
