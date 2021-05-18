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
            //do { 
            if (conServidor.Conectar())
            {
                /*conServidor.Escribir("Hola mundo");
                string mensaje = conServidor.Leer();
                Console.WriteLine(mensaje);*/
                string tipo, mensajeServidor, estado, fecha,respuesta;
                string valor,nroMedidor;
                int valorMedidor;
                int valorValor;
                do
                {
                    do
                    {
                        try
                        {
                            Console.WriteLine("Ingrese la id del medidor");
                            valorMedidor = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Dato ingresado no es un valor aceptado");
                            valorMedidor = 0;
                        }
                    } while (valorMedidor == 0);
                    nroMedidor = Convert.ToString(valorMedidor);
                    do
                    {
                        try { 
                            Console.WriteLine("Ingrese tipo del medidor");
                            tipo = Console.ReadLine().Trim().ToLower();
                            if (tipo == "consumo") { }else if (tipo=="trafico") { } else { tipo = null;}
                        }catch (Exception ex) {
                            tipo = null;
                            Console.WriteLine("Ingrese un tipo correspondiente");
                        }
                    } while (tipo == null);
                    fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");              
                    conServidor.Escribir( fecha + '|' + nroMedidor + '|' + tipo);

                    mensajeServidor = conServidor.Leer();
                    Console.WriteLine(mensajeServidor);
                    if (mensajeServidor.Contains("WAIT"))
                    {

                    }
                    else
                    {
                        Console.WriteLine("El medidor ingresado no existe en el sistema");
                        conServidor.CerrarConexion();
                        Console.ReadKey();
                        return;
                        
                    }
                     
                   //} while (mensajeServidor.Contains("ERROR"));

                    do { 
                            try { 
                                Console.WriteLine("Ingrese valor:");
                                valorValor = Convert.ToInt32(Console.ReadLine());
                                if(valorValor>1000 || valorValor < 0)
                                {
                                    valorValor = 2000;
                                }
                            }
                            catch (Exception ex)
                            {
                                valorValor = 2000;
                                Console.WriteLine("El dato ingresado no está dentro de los parametros");
                            }
                        } while (valorValor == 2000);
                    valor = Convert.ToString(valorValor);
                    do { 
                                Console.WriteLine("¿Desea ingresar estado?");
                                respuesta = Console.ReadLine().Trim().ToLower();
                                if (respuesta=="si")
                                {
                                Console.WriteLine("Ingrese estado");
                                estado = Console.ReadLine();
                                if (estado == "-1") { } else if (estado == "0") { } else if (estado == "1") { } else if (estado == "2") { } else { estado = "error"; }
                                }   
                                else if (respuesta=="no")
                                {
                                estado = null;
                                }
                                else
                                {
                                    respuesta = null;Console.WriteLine("Ingrese el texto correspondiente");
                                    estado = "error";
                                }
                    } while (respuesta == null || estado == "error");

                } while (mensajeServidor == string.Empty);
                    
                    
                    fecha = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
                
                if (estado != null)
                {
                    conServidor.Escribir(nroMedidor + '|' + fecha + '|' + tipo + '|' + valor + '|' + estado + '|' + "UPDATE");
                }
                else
                {
                    conServidor.Escribir(nroMedidor + '|' + fecha + '|' + tipo + '|' + valor + '|' +"sin lectura"+'|'+ "UPDATE");
                }
                mensajeServidor = conServidor.Leer();
                Console.WriteLine(mensajeServidor);
                conServidor.CerrarConexion();
                Console.WriteLine("Conexión cerrada");
                Console.ReadKey();
            }
        }
    }
}
