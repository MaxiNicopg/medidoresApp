using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class Mensaje
    {
        private DateTime fecha;
        private string nro_medidor;
        private string tipo;

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Nro_medidor { get => nro_medidor; set => nro_medidor = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        /*public Mensaje(DateTime fecha, string nro_medidor, string tipo)
        {
            Fecha = fecha;
            Nro_medidor = nro_medidor;
            Tipo = tipo;
        }*/

    }
}
