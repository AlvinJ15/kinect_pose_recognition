using System;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Apps.engine.communication.Test
{
    class Program
    {
        public static TestType testConfig;

                                                      //nombre posicion;;;;;;;;;cantidad de veces que se repetira
        public static string[] positionSimulator = { "hombroizquierdo;4", "hombroderecho;2", "hombroizquierdo;6", "hombroderecho;10" };
        public static void Main(string[] args)
        {


            testConfig = TestType.Automatic;   //change for automatic or manual


            MainAsync(args).Wait();
        }
        static async System.Threading.Tasks.Task MainAsync(string[] args)
        {
            byte[] buffer = new byte[1024];

            IPHostEntry iphostInfo = await Dns.GetHostEntryAsync(Dns.GetHostName());
            IPAddress ipAddress = iphostInfo.AddressList[0];
            IPEndPoint localEndpoint = new IPEndPoint(ipAddress, 8080);

            Socket sock = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);


            sock.Bind(localEndpoint);
            sock.Listen(5);
            string data = "" ;
            int index = 0;
            int count = 0;
            while (true)
            {
                Socket confd = sock.Accept();

                Console.WriteLine("Hay 1 Conexion...");
                if(testConfig == TestType.Manual)
                {
                    data = Console.ReadLine();
                }
                else
                {
                    Thread.Sleep(1000);
                    if(count == 0)
                    {
                        if (index >= positionSimulator.Length) break;
                        var current = positionSimulator[index++];
                        count = Convert.ToInt32(current.Split(';')[1]);
                        data = current.Split(';')[0];
                    }
                    count--;
                }
                byte[] dateReceived = new byte[128];
                int size = confd.Receive(dateReceived);
                string rutina = Encoding.ASCII.GetString(dateReceived).Replace("\0", string.Empty);
                Console.WriteLine("Comparando:::  +"+data + "  -  " + rutina);
                string response = rutina.Equals(data, StringComparison.OrdinalIgnoreCase) ? "True" : "False";
                confd.Send(Encoding.ASCII.GetBytes(response));
                Console.WriteLine("Respuesta Enviada: " + response);
                //Console.WriteLine("Respuesta Enviada: " + data);

            }
            Console.WriteLine("-------------------FIN---------------------");
            Console.ReadKey();
        }
    }
    enum TestType
    {
        Manual,
        Automatic
    }
}