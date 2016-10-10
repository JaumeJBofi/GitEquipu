using PA120130698_G6.Foundation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

// #Preg b
namespace PA120130698_G6.Model
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

        public Evento(string fileName)
        {            
            _stands = new List<StandInformation>();
            _participants = new List<EquipoxEvento>();

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
                    _stands.Add(new StandInformation(tokens[0], tokens[1], tokens[2]));                    
                }                
            }
            reader.Close();
            fileStream.Close();
        }
        

        public void AddTeams(List<Equipo> teams)
        {
            int i = 1;
            foreach(var team in teams)
            {

                Console.WriteLine(i + ") " + team.ToString());
                i++;                    
            }

          
            while(true)
            {
                Console.Write("\nEscoga los Indices de los equipos a agregar al Evento y su informacion de Evento\nPresione -1 para terminar\n");
                int index = Int32.Parse(Console.ReadLine());
                if (index == -1) break;
                // Exepcion de indice....          
                _participants.Add(new EquipoxEvento(teams[index-1], new StandInformation()));
            }
        }
    
        public void ProcessEquipos()
        {
            int antCant = 0,posCant = 0;
            antCant = _stands.Count;
            foreach (var team in _participants)
            {                
                _stands.RemoveAll(o => o.Me == team.Stand);
                posCant = _stands.Count;
                team.AddRevenue(PriceEntry, antCant - posCant);
                antCant = posCant;
            }            
        }

        public void MakeRanking()
        {
            _participants.OrderByDescending(o => o.TotalEarned);
        }

        public override string ToString()
        {
            string buffer;
            buffer = "Nombre Evento : " + EventName + "  Numero de Entradas: " + NEntries + "  Precio Entrada: " + PriceEntry + "\n" + "Equipos:\n";
            string equipos = "";
            
            foreach(var team in _participants)
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
    }
}
