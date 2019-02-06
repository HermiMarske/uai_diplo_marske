using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Cliente
    {
        private int idPersona;
        private string razonSocial;
        private string cuit;
        private Persona persona;

        public string GetCuit()
        {
            return cuit;
        }

        public void SetCuit(string value)
        {
            cuit = value;
        }

        public Persona GetPersona()
        {
            return persona;
        }

        public void SetPersona(Persona value)
        {
            persona = value;
        }

        public string GetRazonSocial()
        {
            return razonSocial;
        }

        public void SetRazonSocial(string value)
        {
            razonSocial = value;
        }

        public int GetIdPersona()
        {
            return idPersona;
        }

        public void SetIdPersona(int value)
        {
            idPersona = value;
        }
    }
}
