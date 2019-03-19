using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Usuario
    {
        private int idUsuario;
        private string nombreUsuario;
        private string password;
        private int cii;
        private bool habilitado;
        private Persona persona;

        public Usuario(int idUsuario, string nombreUsuario, string password, int cii, bool habilitado, Persona persona)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.cii = cii;
            this.habilitado = habilitado;
            this.persona = persona;
        }

        public int GetIdUsuario()
        {
            return idUsuario;
        }

        public void SetIdUsuario(int value)
        {
            idUsuario = value;
        }

        public string GetNombreUsuario()
        {
            return nombreUsuario;
        }

        public void SetNombreUsuario(string value)
        {
            nombreUsuario = value;
        }

        public string GetPassword()
        {
            return password;
        }

        public void SetPassword(string value)
        {
            password = value;
        }

        public int GetCii()
        {
            return cii;
        }

        public void SetCii(int value)
        {
            cii = value;
        }

        public bool GetHabilitado()
        {
            return habilitado;
        }

        public void SetHabilitado(bool value)
        {
            habilitado = value;
        }

        internal Persona GetPersona()
        {
            return persona;
        }

        internal void SetPersona(Persona value)
        {
            persona = value;
        }
    }
}
