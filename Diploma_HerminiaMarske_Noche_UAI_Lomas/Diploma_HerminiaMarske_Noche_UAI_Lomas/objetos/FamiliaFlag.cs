using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diploma_HerminiaMarske_Noche_UAI_Lomas.objetos
{
    class FamiliaFlag : Familia
    {
        private bool flag;

        public FamiliaFlag(int idFam, string descripcion, bool flag) : base (idFam, descripcion)
        {
            this.SetFlag(flag);            
        }

        public bool GetFlag()
        {
            return flag;
        }

        public void SetFlag(bool value)
        {
            flag = value;
        }
    }
}
