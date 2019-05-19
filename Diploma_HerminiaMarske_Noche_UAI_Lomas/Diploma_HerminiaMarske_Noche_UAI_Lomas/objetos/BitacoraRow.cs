using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class BitacoraRow
    {
        private int idBitacoraRow;
        private DateTime timeStamp;
        private string descripcion;
        private string criticidad;
        private Usuario usuario;

        public string GetCriticidad()
        {
            return criticidad;
        }

        public void SetCriticidad(string value)
        {
            criticidad = value;
        }

        public string GetDescripcion()
        {
            return descripcion;
        }

        public void SetDescripcion(string value)
        {
            descripcion = value;
        }

        public DateTime GetTimeStamp()
        {
            return timeStamp;
        }

        public void SetTimeStamp(DateTime value)
        {
            timeStamp = value;
        }

        public int GetIdBitacoraRow()
        {
            return idBitacoraRow;
        }

        public void SetIdBitacoraRow(int value)
        {
            idBitacoraRow = value;
        }

        internal Usuario GetUsuario()
        {
            return usuario;
        }

        internal void SetUsuario(Usuario value)
        {
            usuario = value;
        }
    }
}
