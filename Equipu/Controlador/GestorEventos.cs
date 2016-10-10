using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA120130698_G6.Foundation;
using PA120130698_G6.Modelo;
using System.IO;

//# Preg a
namespace PA120130698_G6.Controlador
{
    [Serializable]
    public class GestorEventos
    {
        private Dictionary<CATEGORIA, Dictionary<string, Evento>> _eventos;
        private Dictionary<CATEGORIA, List<Equipo>> _equiposX_categoria;
        private CATEGORIA _categorias;       

        public GestorEventos()
        {
            Eventos = new Dictionary<CATEGORIA, Dictionary<string, Evento>>();
            EquiposX_categoria = new Dictionary<CATEGORIA, List<Equipo>>();

            foreach(var cat in CategoriaMethods.GetCategorias())
            {
                AddCategory(cat);
            }            
        }

        public GestorEventos(List<Equipo> currentEquipos)
        {
            Eventos = new Dictionary<CATEGORIA, Dictionary<string, Evento>>();
            EquiposX_categoria = new Dictionary<CATEGORIA, List<Equipo>>();

            foreach (var cat in CategoriaMethods.GetCategorias())
            {
                AddCategory(cat);

            }            

            foreach (var equip in currentEquipos)
            {
                EquiposX_categoria[equip.Categoria].Add(equip);
            }            
        }

        public void AddCategory(CATEGORIA newCat)
        {
            Eventos.Add(newCat, new Dictionary<string, Evento>());
            EquiposX_categoria.Add(newCat, new List<Equipo>());
        }

        public void ActualizarGanancias()
        {            
            List<CATEGORIA> listCategorias = CategoriaMethods.GetCategorias();
            foreach (var cat in listCategorias)
            {
                foreach (var evento in Eventos[cat])
                {
                    evento.Value.ProcessEquipos();
                }
            }
        }

        public void AddEquipo(Equipo equip)
        {
            EquiposX_categoria[equip.Categoria].Add(equip);
        }

        public void AddEquipos(List<Equipo> teams)
        {
            foreach(var equip in teams)
            {
                AddEquipo(equip);
            }
        }

        public void CreateEvent(CATEGORIA cat,string file)
        {
            char[] delim = { '.' };
            string[] toks = file.Split(delim);
        }

        public void CreateEvent(CATEGORIA cat, string name,double precioEntrada,int nEntries,List<EquipoxEvento> miembros)
        {                        
            Eventos[cat].Add(name, new Evento(cat,name,nEntries,precioEntrada));
            Eventos[cat][name].AddTeams(miembros);
            Eventos[cat][name].ProcessEquipos();            
        }
        

        public Evento GetEvento(CATEGORIA cat,string name)
        {
            if (!Eventos.ContainsKey(cat) || !Eventos[cat].ContainsKey(name)) return null; 
            return Eventos[cat][name];
        }
        
        public CATEGORIA Categorias
        {
            get
            {
                return _categorias;
            }

            set
            {
                _categorias = value;
            }
        }

        public Dictionary<CATEGORIA, List<Equipo>> EquiposX_categoria
        {
            get
            {
                return _equiposX_categoria;
            }

            set
            {
                _equiposX_categoria = value;
            }
        }

        public Dictionary<CATEGORIA, Dictionary<string, Evento>> Eventos
        {
            get
            {
                return _eventos;
            }

            set
            {
                _eventos = value;
            }
        }
    }
}
