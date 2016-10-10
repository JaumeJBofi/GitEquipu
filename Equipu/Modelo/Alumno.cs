using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Preg d
namespace PA120130698_G6.Modelo
{
    [Serializable]
    public class Alumno : Miembro,IConsultable
    {
        private DatosAlum _alumData;

        //Repeticion de nombre. Duplicidad pero no muy grave. Permite manejar como objecto o como dato.

        public Alumno(int codigo,string passWord, string nombre, DateTime fNacimiento, Foundation.GENERO g, string direccion, string email, int codAlum, double craest)
            : base(codigo, nombre, fNacimiento, g, direccion, email,passWord)
        {
            _alumData = new DatosAlum(nombre, craest, codAlum);
        }

        public DatosAlum AlumData
        {
            get { return _alumData; }
            set { _alumData = value; }
        }

        public override string getDatos()
        {
            return AlumData.ToString();
        }                
    }
}
