using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Cliente
    {
        private int id;
        private string razonSocial;
        private string cuit;
        private string tipoCliente;
        private Persona persona;

        public Cliente(int id, string razonSocial, string cuit, string tipoCliente, Persona persona)
        {
            this.id = id;
            this.razonSocial = razonSocial;
            this.cuit = cuit;
            this.SetTipoCliente(tipoCliente);
            this.persona = persona;
        }

        public string GetTipoCliente()
        {
            return tipoCliente;
        }

        public void SetTipoCliente(string value)
        {
            tipoCliente = value;
        }

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

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }
    }
}
