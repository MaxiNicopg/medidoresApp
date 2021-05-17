using MedidoresModel.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public interface IMensajeDetalladoDAL
    {
        void SaveConsumo(MensajeDetallado m);
        void SaveTrafico(MensajeDetallado m);

        List<MensajeDetallado> GetAllConsumos();
        List<MensajeDetallado> GetAllTrafico();
    }
}
