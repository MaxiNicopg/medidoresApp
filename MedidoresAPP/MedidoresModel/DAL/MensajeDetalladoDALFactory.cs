using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedidoresModel.DAL
{
    public class MensajeDetalladoDALFactory
    {
        public static IMensajeDetalladoDAL CreateDAL()
        {
            return MensajeDetalladoDALArchivos.GetInstance();
        }
    }
}
