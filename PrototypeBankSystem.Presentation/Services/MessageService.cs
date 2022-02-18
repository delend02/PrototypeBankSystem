using PrototypeBankSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBankSystem.Presentation.Services
{
    internal class MessageService 
    {

        internal event Action<string> OnMessageSend;

        internal void SendMessage(string text)
        {
            OnMessageSend?.Invoke(text);
        }
    }
}
