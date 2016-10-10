using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PA120130698_G6.Modelo;
using PA120130698_G6.Foundation;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

//Preg c
namespace PA120130698_G6.Controlador
{
    [Serializable]
    public class EQuipu
    {
        private List<Equipo> _equipos;
        private List<Miembro> _organizadores;
        private GestorEventos _events;

        public EQuipu()
        {
            Equipos = new List<Equipo>();
            Organizadores = new List<Miembro>();
            Events = new GestorEventos();          
        }

        public EQuipu(bool load)
        {
            Equipos = new List<Equipo>();
            Organizadores = new List<Miembro>();
            Events = new GestorEventos();          

            if(load==true)
            {                
                DeserializarEquipu();
            }
        }

        public void Save()
        {
            SerializarEquipu();
        }

        public string ConsultarMiembrosDeEquipo(int codigo)
        {
            return Equipos[codigo].getInfoMiembros();
        }
        public List<Equipo> Equipos
        {
            get
            {
                return _equipos;
            }

            set
            {
                _equipos = value;
            }
        }

        public List<Miembro> Organizadores
        {
            get
            {
                return _organizadores;
            }

            set
            {
                _organizadores = value;
            }
        }

        public GestorEventos Events
        {
            get
            {
                return _events;
            }

            set
            {
                _events = value;
            }
        }

        public void AddEquipo(Equipo newTeam)
        {
            Equipos.Add(newTeam);
            Events.AddEquipo(newTeam);
        }

        public void AddOrganizadores(Miembro newMember)
        {
            Organizadores.Add(newMember);
        }

        public void CrearEvento(string nombre,CATEGORIA cat)
        {
            // Interfaz Grafica Creacion.            
            Events.CreateEvent(cat, nombre);
        }

        public void GetInfoEvento(CATEGORIA cat,string name)
        {
            // Interfaz Grafica Interaction.
            Console.WriteLine(Events.GetEvento(cat, name));
        }

        public void SerializarEquipu()
        {
            Stream stream = File.Open("Equipu1.bin", FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();

            bin.Serialize(stream, Equipos);
            bin.Serialize(stream, Organizadores);
            bin.Serialize(stream, Events);        
            stream.Close();
        }

        public void DeserializarEquipu()
        {
            Stream stream = File.Open("Equipu1.bin", FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();

            //Equipos            
            Equipos = (List<Equipo>)bin.Deserialize(stream);

            //Orgs
            Organizadores = (List<Miembro>)bin.Deserialize(stream); 

            //Eventos
            Events = (GestorEventos)bin.Deserialize(stream);
          
            stream.Close();            
        }

        //Preg d
        //public void ProcesarEventosEnArchivos()
        //{
        //    _events.ProcessEvents();
        //}

        //public void MostrarRanking(string nombreEvento)
        //{
        //    _events.ActualizarGanancias();
        //    _events.MostrarEvento(nombreEvento);

        //}
    }
}
