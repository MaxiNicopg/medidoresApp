using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    public class Mensaje
    {
        private string fecha;
        private string tipo;

        
        public string Tipo { get => tipo; set => tipo = value; }
        public string Fecha { get => fecha; set => fecha = value; }

        /*public Mensaje(DateTime fecha, string nro_medidor, string tipo)
        {
            Fecha = fecha;
            Nro_medidor = nro_medidor;
            Tipo = tipo;
        }*/

    }
}
