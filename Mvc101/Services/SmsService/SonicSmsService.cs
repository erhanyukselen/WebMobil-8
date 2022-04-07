using Mvc101.Models;
using System.Diagnostics;

namespace Mvc101.Services.SmsService
{
    public class SonicSmsService : ISmsService
    {
        public SmsStates Send(SmsModel model)
        {
            Debug.Write(message: $"Sonic: {model.TelefonNo} - {model.Mesaj}");
            return SmsStates.Sent;
        }
    }
}
