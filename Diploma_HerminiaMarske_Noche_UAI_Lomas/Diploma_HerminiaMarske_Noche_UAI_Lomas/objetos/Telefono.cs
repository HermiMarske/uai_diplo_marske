using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Telefono
    {
        private int id;
        private string numero;
        private string tipo;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetNumero()
        {
            return numero;
        }

        public void SetNumero(string value)
        {
            numero = value;
        }

        public string GetTipo()
        {
            return tipo;
        }

        public void SetTipo(string value)
        {
            tipo = value;
        }
    }
}
