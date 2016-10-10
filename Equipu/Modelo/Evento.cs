using PA120130698_G6.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// #Preg b
namespace PA120130698_G6.Modelo
{
    [Serializable]
    public class Evento
    {

        private string _fileName;        

        private List<StandInformation> _stands;
        private List<EquipoxEvento> _participants;

        private string _eventName;
        private int _nEntries;
        private double _priceEntry;
        private CATEGORIA cat = CATEGORIA.TECNOLOGIA;

        public Evento(CATEGORIA cat,string name,int entries,double price)
        {
            Stands = new List<StandInformation>();
            Participants = new List<EquipoxEvento>();
            _fileName = name + ".txt";
            EventName = name;
            NEntries = entries;
            PriceEntry = price;
            if(File.Exists(_fileName))
            {
                FileStream fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(fileStream);

                string buffer;
                char[] delims = { ' ', ';', '.' };
                string[] tokens;

                for (int i = 0; i < NEntries; i++)
                {
                    buffer = reader.ReadLine();
                    if (buffer != null)
                    {
                        tokens = buffer.Split(delims);
                        Stands.Add(new StandInformation(tokens[0], tokens[1], tokens[2]));
                    }
                }
                reader.Close();
                fileStream.Close();
            }
            else
            {
                FileStream fileStream = new FileStream(_fileName, FileMode.OpenOrCreate, FileAccess.Read);
                fileStream.Close();
            }       
        }

        public void ProcessGainings()
        {

            FileStream fileStream = new FileStream(_fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);

            string buffer;
            char[] delims = { ' ', ';', '.',',' };
            string[] tokens;

            for (int i = 0; i < NEntries; i++)
            {
                buffer = reader.ReadLine();
                if (buffer != null)
                {
                    tokens = buffer.Split(delims);
                    Stands.Add(new StandInformation(tokens[0], tokens[1], tokens[2]));
                }
            }
            reader.Close();
            fileStream.Close();
            ProcessEquipos();
            // Hack feo
            Stands.Add(new StandInformation("0", "0", "0"));

        }
        public Evento(string fileName)
        {            
            Stands = new List<StandInformation>();
            Participants = new List<EquipoxEvento>();

            FileName = fileName;
            FileStream fileStream = new FileStream(fileName,FileMode.OpenOrCreate,FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);

            char[] delims = { ' ', ';', '.' };
            string[] names = fileName.Split(delims);
            EventName = names[0];
            
            string[] tokens = reader.ReadLine().Split(delims);
            NEntries = Int32.Parse(tokens[0]);
            PriceEntry = Double.Parse(tokens[1]);
            
            string buffer;

            for (int i = 0; i < NEntries;i++)
            {
                buffer = reader.ReadLine();
                if (buffer != null)
                {
                    tokens = buffer.Split(delims);
                    Stands.Add(new StandInformation(tokens[0], tokens[1], tokens[2]));                    
                }                
            }
            reader.Close();
            fileStream.Close();
        }

        public int GetCantEquipos()
        {
            if (Participants == null) return 0;
            return Participants.Count;
        }

        public void AddTeams(List<Equipo> teams)
        {                   
            foreach(var team in teams)
            {
                Participants.Add(new EquipoxEvento(team, new StandInformation()));
            }                              
        }

        public void AddTeams(List<EquipoxEvento> teams)
        {
            foreach (var team in teams)
            {
                Participants.Add(team);
            }
        }

        public void ProcessEquipos()
        {
            int antCant = 0,posCant = 0;
            antCant = Stands.Count;
            if (Stands == null) return;
            foreach (var team in Participants)
            {                
                Stands.RemoveAll(o => o.Me == team.Stand);
                posCant = Stands.Count;
                team.AddRevenue(PriceEntry, antCant - posCant);
                antCant = posCant;
            }            
        }

        public void MakeRanking()
        {
            Participants.OrderByDescending(o => o.TotalEarned);
        }

        public override string ToString()
        {
            string buffer;
            buffer = "Nombre Evento : " + EventName + "  Numero de Entradas: " + NEntries + "  Precio Entrada: " + PriceEntry + "\n" + "Equipos:\n";
            string equipos = "";
            
            foreach(var team in Participants)
            {
                equipos += "\n" + team.ToString();
            }
            return buffer + equipos;
        }


        public string FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }       

        public string EventName
        {
            get { return _eventName; }
            set { _eventName = value; }
        }

        public int NEntries
        {
            get { return _nEntries; }
            set { _nEntries = value; }
        }
       
        public double PriceEntry
        {
            get { return _priceEntry; }
            set { _priceEntry = value; }
        }

        public List<EquipoxEvento> Participants
        {
            get
            {
                return _participants;
            }

            set
            {
                _participants = value;
            }
        }

        public List<StandInformation> Stands
        {
            get
            {
                return _stands;
            }

            set
            {
                _stands = value;
            }
        }
    }
}
