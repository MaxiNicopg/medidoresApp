using SocketUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MedidoresAPP.Threads
{
    class HiloServer
    {
        private int puerto;
        private ServerSocket server;
        public HiloServer(int puerto)
        {
            this.puerto = puerto;
        }

        public void Ejecutar()
        {
            server = new ServerSocket(puerto);
            Console.WriteLine("Iniciando Server de comunicaciones...");
            if (server.Iniciar())
            {
                Console.WriteLine("Iniciado en el puerto {0}", puerto);
                while (true)
                {
                    Console.WriteLine("Esperando conexiones de clientes...");
                    
                    if (server.ObtenerCliente())
                    {
                        Console.WriteLine("Conexion establecida...");
                        //Aqui iniciar hilo del cliente
                        HiloCliente hiloCliente = new HiloCliente(server);
                        Thread t = new Thread(new ThreadStart(hiloCliente.Ejecutar));
                        t.IsBackground = true;
                        t.Start();
                        
                        
                        
                    }
                }
            }
        }
    }
}
