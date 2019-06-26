using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Actividad
    {
        private int id;
        private string texto;
        private DateTime fechaHoraInicio;
        private Piloto piloto;
        private Cliente cliente;
        private Avion avion;
        private int horas;
        private Localidad localidad;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetTexto()
        {
            return texto;
        }

        public void SetTexto(string value)
        {
            texto = value;
        }

        public DateTime GetFechaHoraInicio()
        {
            return fechaHoraInicio;
        }

        public void SetFechaHoraInicio(DateTime value)
        {
            fechaHoraInicio = value;
        }

        public int GetHoras()
        {
            return horas;
        }

        public void SetHoras(int value)
        {
            horas = value;
        }

        internal Piloto GetPiloto()
        {
            return piloto;
        }

        internal void SetPiloto(Piloto value)
        {
            piloto = value;
        }

        internal Cliente GetCliente()
        {
            return cliente;
        }

        internal void SetCliente(Cliente value)
        {
            cliente = value;
        }

        internal Avion GetAvion()
        {
            return avion;
        }

        internal void SetAvion(Avion value)
        {
            avion = value;
        }

        internal Localidad GetLocalidad()
        {
            return localidad;
        }

        internal void SetLocalidad(Localidad value)
        {
            localidad = value;
        }
    }
}
