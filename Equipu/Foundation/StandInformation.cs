using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/* -----------------------------------------------------------------------------
 * Class Summary:
 * 
 * -----------------------------------------------------------------------------*/
namespace PA120130698_G6.Foundation
{
    [Serializable]
    public class StandInformation
    {
        private string _date;
        private string _time;
        private string _place;
        public StandInformation(string date, string time, string place)
        {
            Time = time;
            Place = place;
            Date = date;
        }

        public DateTime GetDate()
        {
            return DateTime.Parse(Date);
        }

        public TimeSpan GetTime()
        {
            return TimeSpan.Parse(Time);
        }

        public string Place
        {
            get
            {
                return _place;
            }

            set
            {
                _place = value;
            }
        }

        public string Time
        {
            get
            {
                return _time;
            }

            set
            {
                _time = value;
            }
        }

        public string Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }

        public StandInformation Me
        {
            get
            {
                return this;
            }
        }

        public StandInformation()
        {
            Console.WriteLine("Escriba el dia:");
            Date = Console.ReadLine();

            Console.WriteLine("Escriba el tiempo:");
            Time = Console.ReadLine();

            Console.WriteLine("Escriba el lugar:");
            Place = Console.ReadLine();
        }

        public static bool operator ==(StandInformation a,StandInformation b)
        {
            return a.Date.Equals(b.Date) && a.Time.Equals(b.Time) && a.Place.Equals(b.Place);
        }

        public static bool operator !=(StandInformation a, StandInformation b)
        {
            return !(a == b);
        }
    }
}
