using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Preg d
namespace PA120130698_G6.Model
{
    [Serializable]
    public class Externo:Miembro,IConsultable
    {
        private Foundation.TDEDICACION _tDedica;

        public Foundation.TDEDICACION TDedica
        {
            get { return _tDedica; }
            set { _tDedica = value; }
        }
        public Externo(int codigo,string passWord, string nombre, DateTime fNacimiento, Foundation.GENERO g, string direccion, string email,Foundation.TDEDICACION tDedica)
            : base(codigo, nombre, fNacimiento, g, direccion, email,passWord)
        {
            TDedica = TDedica;
        }

        public override string getDatos()
        {
            return String.Empty;
        }
    }
}
