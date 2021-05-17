using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    class MedidorConsumo : Medidor
    {
        private int idMedidor;
        private double consumo;
        private bool disponibilidad;
        private bool mantenimiento;

        

        /*public MedidorConsumo(int id, string tipo, int capacidad, string vidaUtil, int idMedidor, double consumo, bool disponibilidad, bool mantenimiento) : base(id, tipo, capacidad, vidaUtil)
        {
            IdMedidor = idMedidor;
            Consumo = consumo;
            Disponibilidad = disponibilidad;
            Mantenimiento = mantenimiento;
        }*/

        public int IdMedidor { get => idMedidor; set => idMedidor = value; }
        public double Consumo { get => consumo; set => consumo = value; }
        public bool Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public bool Mantenimiento { get => mantenimiento; set => mantenimiento = value; }

    }
}
