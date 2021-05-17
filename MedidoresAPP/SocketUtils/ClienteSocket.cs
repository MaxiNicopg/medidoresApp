using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocketUtils
{
    public class ClienteSocket
    {
        private int puerto;
        private string ipServidor;
        private Socket servidor;
        private Socket comServidor;
        private StreamWriter writer;
        private StreamReader reader;

        public ClienteSocket(int puerto, string ipServidor)
        {
            this.puerto = puerto;
            this.ipServidor = ipServidor;
        }
        public bool Conectar()
        {
            try
            {
                this.comServidor = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(ipServidor), puerto);
                this.comServidor.Connect(endpoint);
                Stream stream = new NetworkStream(this.comServidor);
                this.writer = new StreamWriter(stream);
                this.reader = new StreamReader(stream);
                return true;
            }
            catch (IOException ex)
            {
                return false;
            }
        }

        public string Leer()
        {
            try
            {
                return this.reader.ReadLine().Trim();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public bool Escribir(string mensaje)
        {
            try
            {
                this.writer.WriteLine(mensaje);
                this.writer.Flush();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public void CerrarConexion()
        {
            comServidor.Close();
        }
    }
}
