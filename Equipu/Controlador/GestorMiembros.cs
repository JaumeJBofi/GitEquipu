using PA120130698_G6.Modelo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;


/* -----------------------------------------------------------------------------
 * Class Summary:
 * 
 * -----------------------------------------------------------------------------*/
namespace Equipu.Controlador
{
    [Serializable]
    public class GestorMiembros
    {
        private Dictionary<int,Miembro> _miembros;
        private int _currentCode;    
        public GestorMiembros(int initialCode)
        {
            CurrentCode = initialCode;
            _miembros = new Dictionary<int, Miembro>();
        }
        public GestorMiembros()
        {
            Deserialize();
        }
        public GestorMiembros(int initialCode,Dictionary<int,Miembro> _dict)
        {
            CurrentCode = initialCode;
            Miembros = _dict;           
        }

        public List<Miembro> GetMiembros()
        {
            return _miembros.Values.ToList();
        }

        public List<int> GetCodigos()
        {
            return _miembros.Keys.ToList();
        }

        public void Add(Miembro newMiembro)
        {
            _miembros.Add(newMiembro.Codigo, newMiembro);
        }

        public void Remove(int deletedMiebro)
        {
            _miembros.Remove(deletedMiebro);

        }


        public void Serialize()
        {
            Stream stream = File.Open("Miembros.bin", FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(stream, _miembros);
            bin.Serialize(stream, CurrentCode);
            stream.Close();
        }

        public void Deserialize()
        {
            try
            {
                Stream stream = File.Open("Miembros.bin", FileMode.Open);
                BinaryFormatter bin = new BinaryFormatter();
                _miembros = (Dictionary<int,Miembro>)bin.Deserialize(stream);
                _currentCode = (int)bin.Deserialize(stream);
                stream.Close();
            }
            catch (FileNotFoundException ex)
            {

            }
        }

        public Miembro this[int index]
        {
            get
            {
                return _miembros[index];
            }
            set
            {
                _miembros[index] = value;
            }
        }

        public int CurrentCode
        {
            get
            {
                return _currentCode;
            }

            set
            {
                _currentCode = value;
            }
        }

        public Dictionary<int, Miembro> Miembros
        {
            get
            {
                return _miembros;
            }

            set
            {
                _miembros = value;
            }
        }

    }
}
