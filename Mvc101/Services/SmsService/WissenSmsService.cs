using Mvc101.Models;
using System.Diagnostics;

namespace Mvc101.Services.SmsService
{
    public class WissenSmsService : ISmsService
    {
        public SmsStates Send(SmsModel model)
        {
            Debug.Write(message: $"Wissen: {model.TelefonNo} - {model.Mesaj}");
            return SmsStates.Sent;
        }
    }
}
