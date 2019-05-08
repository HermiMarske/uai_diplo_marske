using System;
using System.Collections.Generic;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Persona
    {
        private int idPersona;
        private string dni;
        private string nombre;
        private string apellido;
        private string sexo;
        private DateTime fechaNacimiento;
        private List<Patente> patentes;

        public Persona(int idPersona, string dni, string nombre, string apellido, string sexo)
        {
            this.idPersona = idPersona;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
        }

        public Persona(int idPersona, string dni, string nombre, string apellido, string sexo, DateTime fechaNacimiento)
        {
            this.idPersona = idPersona;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
        }

        public Persona(int idPersona, string dni, string nombre, string apellido, string sexo, DateTime fechaNacimiento, List<Patente> patentes)
        {
            this.idPersona = idPersona;
            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.sexo = sexo;
            this.fechaNacimiento = fechaNacimiento;
            this.patentes = patentes;
        }

        public int GetIdPersona()
        {
            return idPersona;
        }

        public void SetIdPersona(int value)
        {
            idPersona = value;
        }

        public string GetDni()
        {
            return dni;
        }

        public void SetDni(string value)
        {
            dni = value;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }

        public string GetApellido()
        {
            return apellido;
        }

        public void SetApellido(string value)
        {
            apellido = value;
        }

        public string GetSexo()
        {
            return sexo;
        }

        public void SetSexo(string value)
        {
            sexo = value;
        }

        public DateTime GetFechaNacimiento()
        {
            return fechaNacimiento;
        }

        public void SetFechaNacimiento(DateTime value)
        {
            fechaNacimiento = value;
        }
    }
}
