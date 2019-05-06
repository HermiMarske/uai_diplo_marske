using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Familia
    {
        private int id;
        private string descripcion;
        private List<Patente> patentes;

        public Familia() { }

        public Familia(int id, string descripcion)
        {
            this.id = id;
            this.descripcion = descripcion;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetDescripcion()
        {
            return descripcion;
        }

        public void SetDescripcion(string value)
        {
            descripcion = value;
        }

        internal List<Patente> GetPatentes()
        {
            return patentes;
        }

        internal void SetPatentes(List<Patente> value)
        {
            patentes = value;
        }

        public override string ToString()
        {
            return string.Concat(descripcion, " Nº Patentes(", patentes.Count, ")");
        }
    }
}
