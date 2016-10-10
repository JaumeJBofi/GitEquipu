using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//#Preg d
namespace PA120130698_G6.Modelo
{
    [Serializable]
    public abstract class DatosBase
    {
        private string _name;

        public DatosBase(string name)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }
}
