using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* -----------------------------------------------------------------------------
 * Class Summary:
 * 
 * -----------------------------------------------------------------------------*/
namespace Equipu.Modelo
{
    public class Pregunta
    {
        private string _pregunta;
        private int _min;
        private int _max;

        public Pregunta(string preg,int min,int max)
        {
            _pregunta = preg;
            _min = min;
            _max = max;
        }
        public int Min
        {
            get
            {
                return _min;
            }

            set
            {
                _min = value;
            }
        }

        public string PreguntaS
        {
            get
            {
                return _pregunta;
            }

            set
            {
                _pregunta = value;
            }
        }

        public int Max
        {
            get
            {
                return _max;
            }

            set
            {
                _max = value;
            }
        }
    }
}
