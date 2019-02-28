namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Domicilio
    {
        private int id;
        private string calle;
        private string numero;
        private int piso;
        private string dpto;
        private string comentario;
        private string codigoPostal;
        private string tipoDomicilio;
        private Localidad localidad;
        private Pais pais;
        private Provincia provincia;

        public Domicilio()
        {

        }

        public Domicilio(int id, string calle, string numero, int piso, string dpto, string comentario, string codigoPostal, string tipoDomicilio, Localidad localidad)
        {
            this.id = id;
            this.calle = calle;
            this.numero = numero;
            this.piso = piso;
            this.dpto = dpto;
            this.comentario = comentario;
            this.codigoPostal = codigoPostal;
            this.tipoDomicilio = tipoDomicilio;
            this.localidad = localidad;
        }

        public Domicilio(int id, string calle, string numero, int piso, string dpto, string comentario, string codigoPostal, string tipoDomicilio, Localidad localidad, Pais pais, Provincia provincia)
        {
            this.id = id;
            this.calle = calle;
            this.numero = numero;
            this.piso = piso;
            this.dpto = dpto;
            this.comentario = comentario;
            this.codigoPostal = codigoPostal;
            this.tipoDomicilio = tipoDomicilio;
            this.localidad = localidad;
            this.pais = pais;
            this.provincia = provincia;
        }

        public Pais GetPais()
        {
            return pais;
        }

        public void SetPais(Pais value)
        {
            pais = value;
        }

        internal Provincia GetProvincia()
        {
            return provincia;
        }

        internal void SetProvincia(Provincia value)
        {
            provincia = value;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }

        public string GetCalle()
        {
            return calle;
        }

        public void SetCalle(string value)
        {
            calle = value;
        }

        public string GetNumero()
        {
            return numero;
        }

        public void SetNumero(string value)
        {
            numero = value;
        }

        public int GetPiso()
        {
            return piso;
        }

        public void SetPiso(int value)
        {
            piso = value;
        }

        public string GetDpto()
        {
            return dpto;
        }

        public void SetDpto(string value)
        {
            dpto = value;
        }

        public string GetComentario()
        {
            return comentario;
        }

        public void SetComentario(string value)
        {
            comentario = value;
        }

        public string GetCodigoPostal()
        {
            return codigoPostal;
        }

        public void SetCodigoPostal(string value)
        {
            codigoPostal = value;
        }

        public string GetTipoDomicilio()
        {
            return tipoDomicilio;
        }

        public void SetTipoDomicilio(string value)
        {
            tipoDomicilio = value;
        }

        public Localidad GetLocalidad()
        {
            return localidad;
        }

        public void SetLocalidad(Localidad value)
        {
            localidad = value;
        }
    }
}
