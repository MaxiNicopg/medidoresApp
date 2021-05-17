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
            string nroMedidor, tipo, mensajeCliente, estado;
            string fechaServer;
            int valor;

            server.Escribir("Hola");
            mensajeCliente = server.Leer();
            Console.WriteLine(mensajeCliente);
            fechaServer = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss");
            server.Escribir(fechaServer+"|WAIT");
            mensajeCliente = server.Leer();
            Console.WriteLine(mensajeCliente);
            

            string[] textArray = mensajeCliente.Split('|');
            DateTime fechaCliente = DateTime.ParseExact(textArray[1], "yyyy-MM-dd-HH-mm-ss", CultureInfo.InvariantCulture);
            nroMedidor = textArray[0];
            tipo = textArray[2];
            valor = Convert.ToInt32(textArray[3]);
            estado = textArray[4];

            MensajeDetallado m = new MensajeDetallado()
            {
                NroSerie = Convert.ToInt32(nroMedidor),
                Tipo = tipo,
                Valor = valor,
                Estado = estado,
                Fecha = fechaCliente
            };

            if (tipo.Contains("consumo"))
            {
                dal.SaveConsumo(m);
            }else if (tipo.Contains("trafico"))
            {
                dal.SaveTrafico(m);
            }

        }
    }
}
