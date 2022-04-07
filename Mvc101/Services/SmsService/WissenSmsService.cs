using Mvc101.Models;
using System.Diagnostics;

namespace Mvc101.Services.SmsService
{
    public class WissenSmsService : ISmsService
    {
        public string EndPoint { get; set; } = "https://wissenakademie.com";
        public SmsStates Send(SmsModel model)
        {
            Debug.WriteLine(message: $"Wissen: {model.TelefonNo} - {model.Mesaj}");
            return SmsStates.Sent;
        }
    }
}
