using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Idioma
    {
        private string codigo;
        private string descripcion;

        public string GetDescripcion()
        {
            return descripcion;
        }

        public void SetDescripcion(string value)
        {
            descripcion = value;
        }

        public string GetCodigo()
        {
            return codigo;
        }

        public void SetCodigo(string value)
        {
            codigo = value;
        }

        public Idioma(string codigo, string descripcion)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public override string ToString()
        {
            ComponentResourceManager rm = new ComponentResourceManager(typeof(Properties.strings));
            return rm.GetString(descripcion);
        }
    }
}
