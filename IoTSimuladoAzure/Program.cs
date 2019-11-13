using Microsoft.Azure.Devices.Client;
using System;
using System.Text;

namespace IoTSimuladoAzure
{
    class Program
    {
        static void Main(string[] args)
        {
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
            }
        }
    }
}
