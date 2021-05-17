using MedidoresAPP.Threads;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidoresAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            int nuevoPuerto = 0;
            Console.WriteLine("Iniciando hilo de comunicacion del Server");
            Console.WriteLine("¿Continuar con el puerto por defecto?");
            do {
                if (Console.ReadLine().Trim().ToLower().Contains("no"))
                {
                    Console.WriteLine("Ingrese el nuevo puerto");
                    try {
                        nuevoPuerto = Console.Read();
                    } catch (Exception ex)
                    {
                        Console.WriteLine("Ingrese el puerto correctamente");
                        nuevoPuerto = 0;
                    }
                    }
                else
                {
                    nuevoPuerto = 0;
                    break;
                }
            } while (nuevoPuerto == 0);
            if(nuevoPuerto == 0)
            {
                Console.WriteLine("Puerto {0}", Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]));
            }
            else { 
            Console.WriteLine("Puerto definido: {0}", nuevoPuerto);
            }
            Console.ReadLine();
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
            while (true) ;
            /*
            if(nuevoPuerto == 0) {
                try { 
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            HiloServer hiloServer = new HiloServer(puerto);
            Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
            t.IsBackground = true;
            t.Start();
                }
                catch (Exception ex) {
                    Console.WriteLine("Error en la conexión del servicio" );
                }
            }
            else
            {
                try { 
                    Console.WriteLine("Iniciando Hilo");
                    Console.ReadLine();
                HiloServer hiloServer = new HiloServer(nuevoPuerto);
                Thread t = new Thread(new ThreadStart(hiloServer.Ejecutar));
                t.IsBackground = true;
                t.Start();
                }
                catch (Exception) {
                    Console.WriteLine("Error en la conexión del servicio");
                }
            }*/
        }
    }
}
