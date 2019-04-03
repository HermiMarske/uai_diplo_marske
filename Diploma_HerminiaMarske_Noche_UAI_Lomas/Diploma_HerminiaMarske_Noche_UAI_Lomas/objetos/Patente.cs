using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Patente
    {
        private int id;
        private string descripcion;
        private int idFamilia;

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

        public int GetIdFamilia()
        {
            return idFamilia;
        }

        public void SetIdFamilia(int value)
        {
            idFamilia = value;
        }
    }
}
