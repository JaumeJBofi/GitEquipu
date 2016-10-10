using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA120130698_G6.Foundation;

//Preg b
namespace PA120130698_G6.Model
{
    [Serializable]
    public class Equipo
    {
        private Dictionary<int,Miembro> _miembros;
        private string _name;
        private string _interest;
        private double _recaudado;
        private CATEGORIA _categoria;
       
        public Equipo(string name, string interest,string categoria)
        {
            _miembros = new Dictionary<int, Miembro>();
            Name = name;
            Interest = interest;
            Recaudado = 0.0;
            Categoria.Parse(categoria);
        }

        public Equipo(Equipo team)
        {
            _miembros = new Dictionary<int, Miembro>();
            Name = team.Name;
            Recaudado = team.Recaudado;
            _miembros = team._miembros;
            Categoria = team.Categoria;            
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

        public string Interest
        {
            get
            {
                return _interest;
            }

            set
            {
                _interest = value;
            }
        }

        public void AddRevenue(double revenue)
        {
            Recaudado += revenue;
        }

        public double Recaudado
        {
            get { return _recaudado; }
            set { _recaudado = value; }
        }

        public CATEGORIA Categoria
        {
            get
            {
                return _categoria;
            }

            set
            {
                _categoria = value;
            }
        }

        public override string ToString()
        {
            string buffer = "Nombre: " + Name + " Recaudado Total: " + Recaudado + "  Interes: " + Interest + "Categoria: " + Categoria.ToString() + "\n";
            return buffer;
        }
        public string getInfoMiembros()
        {
            string buffer = "";

            foreach(KeyValuePair<int,Miembro> miemb in _miembros)
            {
                buffer += miemb.Value.getDatos();                
            }
            return buffer;
        }

        public void AddMiembro(Miembro myMiem)
        {
            _miembros.Add(myMiem.Codigo, myMiem);
        }

        public Miembro GetMiembro(int codigo)
        {
            return _miembros[codigo];
        }

      
    }
}
