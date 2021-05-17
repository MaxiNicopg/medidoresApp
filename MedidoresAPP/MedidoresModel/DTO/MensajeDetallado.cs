using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class MensajeDetallado : Mensaje
    {
        private int nroSerie;
        private int valor;
        private string estado;

       
       /* public MensajeDetallado(DateTime fecha, string nro_medidor, string tipo,int nro_serie,int valor, string estado) : base(fecha, nro_medidor, tipo)
        {

            NroSerie = nro_serie;
            Valor = valor;
            Estado = estado;
        }*/

        public int NroSerie { get => nroSerie; set => nroSerie = value; }
        public int Valor { get => valor; set => valor = value; }
        public string Estado { get => estado; set => estado = value; }

        public override string ToString()
        {
            return NroSerie + "|" + Fecha + "|" + Tipo + "|" + Valor + "|" + Estado;
        }
    }
}
