using System.Net.Mail;
using System.Net;

namespace PinchofPepperV2.Models
{
    public static class Emael
    {
        public static void EmaelSend(string userEmail, string subject, string body)
        {
            var client = new SmtpClient("sandbox.smtp.mailtrap.io", 2525)
            {
                Credentials = new NetworkCredential("515c6d0a0cfb9d", "8dffeaabb6464b"),
                EnableSsl = true
            };
            client.Send("POP@pinchofpepper.com", userEmail, subject, body);
            Console.WriteLine("Sent");
        }
    }
}
