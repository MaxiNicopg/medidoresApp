using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    class Medidor
    {
        private int id;
        private string tipo;
        private int capacidad;
        private string vidaUtil;

        public int Id { get => id; set => id = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string VidaUtil { get => vidaUtil; set => vidaUtil = value; }

        /*public Medidor(int id, string tipo, int capacidad, string vidaUtil)
        {
            Id = id;
            Tipo = tipo;
            Capacidad = capacidad;
            VidaUtil = vidaUtil;
        }*/
    }
}
