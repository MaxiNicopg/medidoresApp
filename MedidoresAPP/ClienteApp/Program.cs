using MedidoresModel.DAL;
using MedidoresModel.DTO;
using SocketUtils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteApp
{
    class Program
    {
        private static IMensajeDetalladoDAL dal = MensajeDetalladoDALFactory.CreateDAL();
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
            
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Conectado a {0}:{1}", ip, puerto);
            ClienteSocket conServidor = new ClienteSocket(puerto, ip);
            if (conServidor.Conectar())
            {
                /*conServidor.Escribir("Hola mundo");
                string mensaje = conServidor.Leer();
                Console.WriteLine(mensaje);*/
                string nroMedidor, tipo, mensajeServidor, estado, fecha,respuesta;
                int valor;
                do
                {
                    Console.WriteLine("Ingrese la id del medidor");
                    nroMedidor = Console.ReadLine();
                    Console.WriteLine("Ingrese tipo del medidor");
                    tipo = Console.ReadLine().Trim().ToLower();
                    
                    fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    Console.WriteLine(fecha);
                    mensajeServidor = conServidor.Leer();
                    Console.WriteLine(mensajeServidor);
                    conServidor.Escribir( fecha + '|' + nroMedidor + '|' + tipo);

                    mensajeServidor = conServidor.Leer();
                    Console.WriteLine(mensajeServidor);
                    if (mensajeServidor.Contains("WAIT"))
                    { }
                    else
                    {
                        mensajeServidor = null;
                    }

                } while (mensajeServidor == string.Empty);
                
                    Console.WriteLine("Ingrese valor: ");
                    valor = Console.Read();
                    Console.WriteLine("¿Desea ingresar estado?");
                    respuesta = Console.ReadLine().Trim().ToLower();
                    fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                    if (respuesta.Contains("si"))
                    {
                        Console.WriteLine("Ingrese estado:");
                        estado = Console.ReadLine();
                        conServidor.Escribir(nroMedidor + '|' + fecha + '|' + tipo + '|' + valor + '|' + estado + '|' + "UPDATE");
                    }
                    else
                    {
                        conServidor.Escribir(nroMedidor + '|' + fecha + '|' + tipo + '|' + valor + '|' + "UPDATE");
                        mensajeServidor = conServidor.Leer();
                        estado = null;
                    }

                conServidor.CerrarConexion();
                Console.WriteLine("Conexión cerrada");
                Console.ReadKey();
            }
        }
    }
}
