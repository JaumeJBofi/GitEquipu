using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Preg d
namespace PA120130698_G6.Model
{
    [Serializable]
    public class DatosProf : DatosBase
    {
        private int _codProf;
        private Foundation.ESTADOPROF _estado;               

        public DatosProf(string name,int codProf,Foundation.ESTADOPROF estado) : base(name)
        {
            CodProf = codProf;
            Estado = estado;
        }

        public int CodProf
        {
            get { return _codProf; }
            set { _codProf = value; }
        }
        

        internal Foundation.ESTADOPROF Estado
        {
            get { return _estado; }
            set { _estado = value; }
        }

        public override string ToString()
        {
            string estado;
            if(Estado == Foundation.ESTADOPROF.ACTIVO)
            {
                estado = "Activo";
            }else
            {
                estado = "No Activo";
            }
            return "Profesor: " + CodProf.ToString() + " - " + Name + " - " + estado + "\n";
        }
    }
}
