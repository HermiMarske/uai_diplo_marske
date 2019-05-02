namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class Patente
    {
        private int id;
        private string codigo;
        private int idFamilia;

        public Patente(int id, string codigo, int idFamilia)
        {
            this.id = id;
            this.idFamilia = idFamilia;
            this.codigo = codigo;
        }

        public Patente(int id, string codigo)
        {
            this.id = id;
            this.codigo = codigo;
        }

        public Patente()
        {

        }

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
            return codigo;
        }

        public void SetDescripcion(string value)
        {
            codigo = value;
        }

        public int GetIdFamilia()
        {
            return idFamilia;
        }

        public void SetIdFamilia(int value)
        {
            idFamilia = value;
        }

        public override string ToString()
        {
            return codigo;
        }
    }
}
