using PA120130698_G6.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* -----------------------------------------------------------------------------
 * Class Summary:
 * 
 * -----------------------------------------------------------------------------*/
namespace PA120130698_G6.Modelo
{
    [Serializable]
    public class EquipoxEvento
    {
        private StandInformation _stand;
        private int _entriesSold;
        private double _totalEarned;
        private Equipo _team;
            
        public EquipoxEvento(Equipo team, string place, string date, string time)
        {
            _team = team;
            TotalEarned = 0.0;
            EntriesSold = 0;
            Stand = new StandInformation(date, time, place);            
        }

        public EquipoxEvento(Equipo team, StandInformation stand)
        {
            _team = team;
            TotalEarned = 0.0;
            EntriesSold = 0;
            Stand = stand;
        }

        public double TotalEarned
        {
            get
            {
                return _totalEarned;
            }

            set
            {
                _totalEarned = value;
            }
        }

        public int EntriesSold
        {
            get
            {
                return _entriesSold;
            }

            set
            {
                _entriesSold = value;
            }
        }       

        public StandInformation Stand
        {
            get
            {
                return _stand;
            }

            set
            {
                _stand = value;
            }
        }

        public Equipo Team
        {
            get
            {
                return _team;
            }

            set
            {
                _team = value;
            }
        }

        public void AddRevenue(double cant,int numSold)
        {
            TotalEarned = cant*numSold;
            EntriesSold = numSold;
            Team.Recaudado += TotalEarned * EntriesSold;
        }

        public override string ToString()
        {
            return Team.ToString() + "\n" + "Recaudado Actual: " + TotalEarned + "   Cantidad de Entradas: " + EntriesSold + "\n";
        }
    }
}
