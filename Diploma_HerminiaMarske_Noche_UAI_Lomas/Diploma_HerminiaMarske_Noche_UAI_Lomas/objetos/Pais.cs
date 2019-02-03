namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    public class Pais
    {
        private string nombre;
        private int id;

        public Pais()
        {

        }

        public Pais(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public string GetNombre()
        {
            return nombre;
        }

        public void SetNombre(string value)
        {
            nombre = value;
        }

        public int GetId()
        {
            return id;
        }

        public void SetId(int value)
        {
            id = value;
        }
        
        public override string ToString()
        {
            return nombre;
        }
    }
}