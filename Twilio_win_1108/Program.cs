using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Twilio_win_1108
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Your Account SID from twilio.com/console
            //var accountSid = "AC7741c5772d721eda51064d804ff22444";
            //// Your Auth Token from twilio.com/console
            //var authToken = "f403e41cabbbcee9acc3344af79d2d8c";

            //TwilioClient.Init(accountSid, authToken);

            //var message = MessageResource.Create(
            //    to: new PhoneNumber("+14166299386"),
            //    from: new PhoneNumber("+12898060265 "),
            //    body: "Hello from C#");

            //Console.WriteLine(message.Sid);
           // Console.Write("Press any key to continue.");
           // Console.ReadKey();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
