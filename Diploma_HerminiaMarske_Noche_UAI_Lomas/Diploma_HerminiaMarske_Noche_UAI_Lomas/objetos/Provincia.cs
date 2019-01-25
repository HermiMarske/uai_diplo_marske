using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Provincia
    {
        private string nombre;
        private int id;

        public Provincia()
        {

        }

        public Provincia(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public override string ToString()
        {
            return this.nombre;
        }
    }
}
