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
            //DateTime fecha = Convert.ToDateTime(fechaServer);
            server.Escribir(fechaServer+"|WAIT");
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
            for(int i = 0; i < textArray.Length; i++)
            {
                Console.WriteLine(textArray[i]);
            }
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
                server.CerrarConexion();
            }
            else if (tipo.Contains("trafico"))
            {
                lock (dal) { 
                dal.SaveTrafico(m);
                }
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
