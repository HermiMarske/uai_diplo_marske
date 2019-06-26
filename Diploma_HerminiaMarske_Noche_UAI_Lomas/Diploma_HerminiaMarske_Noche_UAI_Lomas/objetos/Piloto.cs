using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Piloto
    {
        private int id;
        private Persona persona;
        private DateTime fechaExpedicionPsicofisico;
        private DateTime fechaVencimientoPsicofisico;
        private string licencia;

        public Piloto(int id, Persona persona)
        {
            this.id = id;
            this.persona = persona;
        }

        public Piloto()
        {
        }

        public override string ToString()
        {
            return persona.GetApellido() + ", " + persona.GetNombre(); 
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public Persona GetPersona()
        {
            return persona;
        }

        public void SetPersona(Persona value)
        {
            persona = value;
        }

        public DateTime GetFechaExpedicionPsicofisico()
        {
            return fechaExpedicionPsicofisico;
        }

        public void SetFechaExpedicionPsicofisico(DateTime value)
        {
            fechaExpedicionPsicofisico = value;
        }

        public DateTime GetFechaVencimientoPsicofisico()
        {
            return fechaVencimientoPsicofisico;
        }

        public void SetFechaVencimientoPsicofisico(DateTime value)
        {
            fechaVencimientoPsicofisico = value;
        }

        public string GetLicencia()
        {
            return licencia;
        }

        public void SetLicencia(string value)
        {
            licencia = value;
        }
    }
}
