using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Preg d
namespace PA120130698_G6.Modelo
{
    [Serializable]
    public class DatosAlum : DatosBase
    {
        private double _craest;
        private int _codAlum;
      
        public DatosAlum(string name,double craest,int codAlum) : base(name)
        {
            Craest = craest;
            CodAlum = codAlum;  
        }

        public double Craest
        {
            get { return _craest; }
            set { _craest = value; }
        }

        public int CodAlum
        {
            get { return _codAlum; }
            set { _codAlum = value; }
        }

        public override string ToString()
        {
            return "Alumno: Nombre: " + CodAlum.ToString() + " - " + Name +  " - " + Craest.ToString() + "\n";
        }
    }
}
