using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MedidoresModel.DTO;
using Newtonsoft.Json;

namespace MedidoresModel.DAL
{
    public class MensajeDetalladoDALArchivos : IMensajeDetalladoDAL
    {
        private string archivoTrafico = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "trafico.txt";
        private string archivoConsumo = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "consumo.txt";
        private MensajeDetalladoDALArchivos()
        {

        }
        private static IMensajeDetalladoDAL instance;
        public static IMensajeDetalladoDAL GetInstance()
        {
            if (instance == null)
                instance = new MensajeDetalladoDALArchivos();
            return instance;
        }
        public List<MensajeDetallado> GetAllConsumos()
        {
            List<MensajeDetallado> mensajes = new List<MensajeDetallado>();
            try
            {
                using (StreamReader reader = new StreamReader(archivoConsumo))
                {
                    string text = null;
                    do
                    {
                        text = reader.ReadLine();
                        if (text != null)
                        {
                            string[] textArray = text.Trim().Split('|');

                            MensajeDetallado m = new MensajeDetallado() { 
                                NroSerie = Convert.ToInt32(textArray[0]),
                                Fecha = textArray[1],
                                Tipo = textArray[2],
                                Valor = Convert.ToInt32(textArray[3]),
                                Estado = textArray[4]
                                };
                            mensajes.Add(m);

                        }
                    } while (text != null);
                }
            }catch(IOException ex)
            {
                mensajes = null;
            }
            return mensajes;
        }

        public List<MensajeDetallado> GetAllTrafico()
        {
            List<MensajeDetallado> mensajes = new List<MensajeDetallado>();
            try
            {
                using(StreamReader reader = new StreamReader(archivoTrafico))
                {
                    
                    string text = null;
                    do
                    {
                        string[] textArray = text.Trim().Split('|');

                        MensajeDetallado m = new MensajeDetallado() { 
                            NroSerie = Convert.ToInt32(textArray[0]),
                            Fecha = textArray[1],
                            Tipo = textArray[2],
                            Valor = Convert.ToInt32(textArray[3]),
                            Estado = textArray[4]
                        };
                        mensajes.Add(m);
                    } while (text != null);
                }
            }
            catch (IOException ex)
            {
                
            }
            return mensajes;
        }

        public void SaveTrafico(MensajeDetallado m)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(archivoTrafico, true))
                {
                    string texto = JsonConvert.SerializeObject(m);
                    writer.WriteLine(texto.ToString());
                    writer.Flush();
                }
            }catch(IOException ex)
            {

            }
        }

        public void SaveConsumo(MensajeDetallado m)
        {
            try
            {
                using(StreamWriter writer = new StreamWriter(archivoConsumo,true))
                {
                    string texto = JsonConvert.SerializeObject(m);
                    writer.WriteLine(texto.ToString());
                    writer.Flush();
                }
            }catch(IOException ex)
            {

            }
        }
    }
}
