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
        private string idioma;
        private string respuesta;
        private int fkPregunta;
        private Persona persona;
        private List<Patente> patentes;
        private List<Familia> familias;
        private DateTime borrado;

        public DateTime GetBorrado()
        {
            return borrado;
        }

        public void SetBorrado(DateTime value)
        {
            borrado = value;
        }

        internal List<Familia> GetFamilias()
        {
            return familias;
        }

        internal void SetFamilias(List<Familia> value)
        {
            familias = value;
        }

        internal List<Patente> GetPatentes()
        {
            return patentes;
        }

        internal void SetPatentes(List<Patente> value)
        {
            patentes = value;
        }

        public Usuario()
        {
        }

        public Usuario(int idUsuario, string nombreUsuario, string password, int cii, bool habilitado, Persona persona)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.cii = cii;
            this.habilitado = habilitado;
            this.persona = persona;
        }

        public Usuario(int id, string usuario)
        {
            this.idUsuario = id;
            this.nombreUsuario = usuario;
        }

        public Usuario(int idUsuario, string nombreUsuario, string password, int cii, bool habilitado, string respuesta, int fkPregunta, Persona persona)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.password = password;
            this.cii = cii;
            this.habilitado = habilitado;
            this.respuesta = respuesta;
            this.fkPregunta = fkPregunta;
            this.persona = persona;
        }

        public Usuario(int idUsuario, string nombreUsuario, string idioma, Persona persona, List<Patente> patentes)
        {
            this.idUsuario = idUsuario;
            this.nombreUsuario = nombreUsuario;
            this.idioma = idioma;
            this.persona = persona;
            this.patentes = patentes;
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

        public int GetFkPregunta()
        {
            return fkPregunta;
        }

        public void SetFkPregunta(int value)
        {
            fkPregunta = value;
        }

        public string GetRespuesta()
        {
            return respuesta;
        }

        public void SetRespuesta(string value)
        {
            respuesta = value;
        }
    }
}
