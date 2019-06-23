using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Avion
    {
        private string matricula;
        private string modelo;
        private string marca;
        private bool habilitado;
        private int id;

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetMatricula()
        {
            return matricula;
        }

        public void SetMatricula(string value)
        {
            matricula = value;
        }

        public string GetModelo()
        {
            return modelo;
        }

        public void SetModelo(string value)
        {
            modelo = value;
        }

        public string GetMarca()
        {
            return marca;
        }

        public void SetMarca(string value)
        {
            marca = value;
        }

        public bool GetHabilitado()
        {
            return habilitado;
        }

        public void SetHabilitado(bool value)
        {
            habilitado = value;
        }
    }
}
