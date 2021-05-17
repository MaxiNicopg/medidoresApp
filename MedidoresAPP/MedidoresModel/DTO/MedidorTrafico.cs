using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DTO
{
    class MedidorTrafico : Medidor
    {
        private int idTrafico;
        private int cantidadVehiculos;
        private DateTime hora;

        /*public MedidorTrafico(int id, string tipo, int capacidad, string vidaUtil,int idTrafico,int cantidadVehiculos,DateTime hora) : base(id, tipo, capacidad, vidaUtil)
        {
            IdTrafico = IdTrafico;
            CantidadVehiculos = cantidadVehiculos;
            Hora = hora;
        }*/

        public int IdTrafico { get => idTrafico; set => idTrafico = value; }
        public int CantidadVehiculos { get => cantidadVehiculos; set => cantidadVehiculos = value; }
        public DateTime Hora { get => hora; set => hora = value; }
    }
}
