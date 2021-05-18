using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidoresModel.DAL;
using MedidoresModel.DTO;
using SocketUtils;

namespace MedidoresAPP.Threads
{
    public class HiloCliente
    {
        
        List<int> medidores = new List<int> {1234, 1235, 1236, 1237, 1238};

        ServerSocket server;
        static IMensajeDetalladoDAL dal = MensajeDetalladoDALFactory.CreateDAL();
        public HiloCliente(ServerSocket server)
        {
            this.server = server;
        }
        public void Ejecutar()
        {
            string tipo, mensajeCliente, estado;
            string fechaServer, fechaCliente;
            int valor, nroMedidor;
            DateTime fecha1;
            DateTime fecha2;


            
            mensajeCliente = server.Leer();
            Console.WriteLine(mensajeCliente);
            fechaServer = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            
            //Se debe validar que el medidor este en el sistema
            string[] validacion = mensajeCliente.Split('|');
            Boolean existe = true;
            foreach (int element in medidores)
            {
                if(element == Convert.ToInt32(validacion[1]))
                {
                    
                    existe = true;
                    break;
                }
                else
                {
                    existe = false;
                }

            } 
            if(existe == false)
            {
                server.Escribir(fechaServer + '|' + validacion[1] + '|' + "ERROR");
                server.CerrarConexion();
                return;
                
            }
            else
            {
                server.Escribir(fechaServer + "|WAIT");
            

            //DateTime fecha = Convert.ToDateTime(fechaServer);
            
            fecha1 = DateTime.Now;
            mensajeCliente = server.Leer();
            Console.WriteLine(mensajeCliente);
            fecha2 = DateTime.Now;
            

            string[] textArray = mensajeCliente.Split('|');
            nroMedidor = Convert.ToInt32(textArray[0]);
            fechaCliente = textArray[1];
            //DateTime fechaCliente = DateTime.Now;
            tipo = textArray[2];
            valor = Convert.ToInt32(textArray[3]);
            estado = textArray[4];
            //TimeSpan diff = fechaCliente.Subtract(fecha);
            //if (diff.Minutes < 30)
            //{
            /*for(int i = 0; i < textArray.Length; i++)
            {
                Console.WriteLine(textArray[i]);
            }*/
            //nroMedidor = Int32.Parse(textArray[0]);
            if (fecha1.Subtract(fecha2).Minutes > 30) { server.CerrarConexion(); } else { 
            MensajeDetallado m = new MensajeDetallado()
            {
               NroSerie = nroMedidor,
               Fecha = fechaCliente,
               Tipo = tipo,
               Valor = Convert.ToInt32(valor),
               Estado = estado
            };
            
            if (tipo.Contains("consumo"))
            {
                lock (dal) { 
                dal.SaveConsumo(m);
                }
                        server.Escribir(nroMedidor + '|' + "OK");
                        server.CerrarConexion();
            }
            else if (tipo.Contains("trafico"))
            {
                lock (dal) { 
                dal.SaveTrafico(m);
                }
                        server.Escribir(nroMedidor + '|' + "OK");
                        server.CerrarConexion();
            }
            }
            //}
            //else
            //{
            //    server.CerrarConexion();
            //}
            }
        }
    }
}
