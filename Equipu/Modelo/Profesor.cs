using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Preg d
namespace PA120130698_G6.Modelo
{
    [Serializable]
    public class Profesor:Miembro,IConsultable
    {
        private DatosProf _datosProf;

         public Profesor(int codigo,string passWord, string nombre,DateTime fNacimiento,Foundation.GENERO g,string direccion,string email,int codProf,Foundation.ESTADOPROF estado):
            base(codigo,nombre,fNacimiento,g,direccion,email, passWord)
        {
            _datosProf = new DatosProf(nombre, codProf, estado);
        }
       
        public DatosProf DatosProf
        {
            get { return _datosProf; }
            set { _datosProf = value; }
        }

        public override string getDatos()
        {
            return DatosProf.ToString();
        }          
    }
}
