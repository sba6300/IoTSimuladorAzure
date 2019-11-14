using Microsoft.Azure.Devices.Client;
using System;
using System.Text;

using System;
using System.IO.Ports;
using System.Threading;
using Twilio;
using Twilio.TwiML;
using System.Web;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace IoTSimuladoAzure
{
    class Program
    {
        

        static void Main(string[] args)
        {

            const string accountSID = "AC5ca630f56cfe26d162140b64f35dc947";
            const string authToken = "2df741311afe2749e930f7ec2f6afaae";

            // Initialize the TwilioClient.
            TwilioClient.Init(accountSID, authToken);

            // Use the Twilio-provided site for the TwiML response.
            var url = "https://twimlets.com/message?";
            //url = $"{url}?Message%5B0%5D=hola%20peterrrrrrr";
            var m = "<Response><Say voice=\"alice\" language=\"es-ES\">Peter mi hamburgesa</Say><Play>https://pwsandoval.com/ritmo.mp3</Play></Response>";
            var response = new VoiceResponse();
            response.Say("peter mi hamburgesa", voice: "man", language: "es-ES");

            // Set the call From, To, and URL values to use for the call.
            // This sample uses the sandbox number provided by
            // Twilio to make the call.

            m = HttpUtility.UrlPathEncode(m);

            /*byte[] bytes = Encoding.Default.GetBytes(m);
            m = Encoding.UTF8.GetString(bytes);*/

            url += m;
            var call = CallResource.Create(
                  to: new PhoneNumber("+51931289151"),
                  from: new PhoneNumber("+51961915596"),
                  url: new Uri(url));
            Console.WriteLine(url);
            Console.WriteLine("llamo: " + 931289151);
            Console.ReadKey();

            /* SerialPort _serialPort = new SerialPort();
             _serialPort.PortName = "COM2";//Set your board COM
             _serialPort.BaudRate = 9600;
             _serialPort.Open();
             while (true)
             {
                 string a = _serialPort.ReadExisting();
                 Console.WriteLine(a);
                 Thread.Sleep(1000);
             }


              try
              {
                  var deviceClient = DeviceClient.CreateFromConnectionString("HostName=MyArduinoIoTHub.azure-devices.net;DeviceId=arduinosensor;SharedAccessKey=/RthnpezK3JRhvCjl1UYOZvforOYhfo0zQmZu9x1SKQ=");
                  var formatJason = "{\"IdTest\" :5,\"Distance\" :7,\"Date\" :null}";
                  var msg = new Message(Encoding.UTF8.GetBytes(formatJason));
                   deviceClient.SendEventAsync(msg);
                  Console.WriteLine("mensaje enviado: " + formatJason);
                  Console.ReadKey();
              }
              catch (Exception ex)
              {
                  Console.WriteLine("!!!! " + ex.Message);
                  Console.ReadKey();
              }*/
        }
    }
}
