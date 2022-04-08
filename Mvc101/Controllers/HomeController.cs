using Microsoft.AspNetCore.Mvc;
using Mvc101.Models;
using Mvc101.Services.EmailService;
using Mvc101.Services.SmsService;
using System.Diagnostics;

namespace Mvc101.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISmsService _smsService;
        private readonly IEmailService _emailService;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly IServiceProvider _serviceProvider;
        

        public HomeController(ISmsService smsService, IEmailService emailService, IWebHostEnvironment appEnvironment, IServiceProvider serviceProvider)
        {
            _smsService=smsService;
            _emailService = emailService;
            _appEnvironment = appEnvironment;
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index(int id=0)
        {
            var result = _smsService.Send(new SmsModel()
            {
                TelefonNo="12345",
                Mesaj="home/index çalıştı"
            });

            var WissenSms = (WissenSmsService)_smsService;
            Debug.WriteLine(WissenSms.EndPoint);


            IEmailService emailService;
            if(id % 2 ==0)
            {
                emailService = (IEmailService)_serviceProvider.GetService(typeof(SendGridEmailService));
            }
            else
            {
                emailService = (IEmailService)_serviceProvider.GetService<OutLookEmailService>();
            }

            var fileStream = new FileStream($"{_appEnvironment.WebRootPath}\\files\\portre.jpeg", FileMode.Open);

            _emailService.SendMailAsync(new MailModel()
            {
                To = new List<EmailModel>()
                {
                    new EmailModel()
                    {
                        Name = "Wissen",
                        Adress = "site@wissenakademie.com"
                    }
                },
                Subject = "Index Açıldı",
                Body = "Bu emailin body kısmıdır",
                Attachs = new List<Stream>()
                {
                    fileStream
                }
            });

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}