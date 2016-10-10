using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA120130698_G6.Model
{
    [Serializable]
    public abstract class Miembro
    {
        private int _codigo;
        private Foundation.GENERO _genero;
        private string _nombre;
        private DateTime _fNacimiento;
        private string _direccion;
        private string _password;

        public string Direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public Miembro(int codigo,string nombre,DateTime fNacimiento,Foundation.GENERO g,string direccion,string email,string passWord)
        {
            Codigo = codigo;
            Nombre = nombre;
            FNacimiento = fNacimiento;
            Genero = g;
            Direccion = direccion;
            Email = email;
            Password = passWord;
        }

        public int Codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }        

        public DateTime FNacimiento
        {
            get { return _fNacimiento; }
            set { _fNacimiento = value; }
        }       

        public Foundation.GENERO Genero
        {
            get { return _genero; }
            set { _genero = value; }
        }

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                _password = value;
            }
        }

        public abstract string getDatos();   

    }
}
