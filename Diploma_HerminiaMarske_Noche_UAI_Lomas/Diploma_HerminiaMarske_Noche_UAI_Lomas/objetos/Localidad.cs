using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Localidad
    {
        private int id;
        private int referencia;
        private string nombre;
        private Provincia provincia;
        private Pais pais;

        internal Provincia GetProvincia()
        {
            return provincia;
        }

        internal void SetProvincia(Provincia value)
        {
            provincia = value;
        }

        public Pais GetPais()
        {
            return pais;
        }

        public void SetPais(Pais value)
        {
            pais = value;
        }

        public Localidad()
        {

        }

        public Localidad(string nombre, int id, int referencia)
        {
            this.nombre = nombre;
            this.id = id;
            this.referencia = referencia;
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

        public void SetReferencia(int value)
        {
            referencia = value;
        }


        public int GetReferencia()
        {
            return referencia;
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
