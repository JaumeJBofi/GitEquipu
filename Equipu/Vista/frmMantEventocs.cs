using PA120130698_G6.Controlador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PA120130698_G6.Modelo;
using PA120130698_G6.Foundation;
using Equipu.Modelo;
using System.IO;

namespace Equipu.Vista
{
    public partial class frmMantEventocs : Form
    {
        private GestorEventos _eventManager;
        private List<Evento> _viewEvents;
        private CATEGORIA _currentCategory;
        private List<Pregunta> _preguntas;
        public frmMantEventocs(GestorEventos eventManager)
        {
            InitializeComponent();
            _eventManager = eventManager;
            comboBox1.Text = CATEGORIA.TECNOLOGIA.ToString();
            _currentCategory =_currentCategory.Parse(comboBox1.Text);
            _viewEvents = _eventManager.Eventos[_currentCategory].Values.ToList();
            _preguntas = new List<Pregunta>();

            FileStream fileStream = new FileStream("Preguntas.txt", FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(fileStream);

            string buffer;
            char[] delims = { ',' };
            string[] tokens = new string[3];
            try
            {
                while ((buffer = reader.ReadLine()) != null)
                {
                    tokens = buffer.Split(delims);
                    _preguntas.Add(new Pregunta(tokens[0], Int32.Parse(tokens[1]), Int32.Parse(tokens[2])));
                }

            }
            catch(Exception ex)
            { 
            }            

            reader.Close();
            fileStream.Close();
            Update();
        }
        public new void Update()
        {
            dataGridView1.Rows.Clear();
            string[] rows = new string[4];
            foreach(var evento in _viewEvents)
            {
                rows[0] = evento.EventName;
                rows[1] = evento.PriceEntry.ToString();
                rows[2] = evento.NEntries.ToString();
                rows[3] = evento.GetCantEquipos().ToString();
                dataGridView1.Rows.Add(rows);
            }
        }

        private void frmMantEventocs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmEventoNuevo ventanaEventoNuevo = new frmEventoNuevo(_eventManager);
            ventanaEventoNuevo.ShowDialog();
            _viewEvents = _eventManager.Eventos[_currentCategory].Values.ToList();
            Update();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentCategory = _currentCategory.Parse(comboBox1.Text);
            _viewEvents = _eventManager.Eventos[_currentCategory].Values.ToList();
            Update();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            _currentCategory = _currentCategory.Parse(comboBox1.Text);
            string nombre = textBox1.Text;

            if(nombre.Equals(""))
            {
                _viewEvents = _eventManager.Eventos[_currentCategory].Values.ToList();
            }
            else
            {
                _viewEvents = _eventManager.Eventos[_currentCategory].Values.Where(o => o.EventName == nombre).ToList();

            }
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {        
            if(comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Ingrese una Categoria Primero");
                return;
            }
            int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            string nombre = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            _eventManager.Eventos[_currentCategory].Remove(nombre);
            _viewEvents = _eventManager.Eventos[_currentCategory].Values.ToList();
            Update();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            string nombre = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            Evento myEvent = _eventManager.GetEvento(_currentCategory,nombre);
            if(myEvent ==null)
            {
                MessageBox.Show("No existe el evento");
                return;
            }
            frmMostrarEquiposEncuesta ventanaEquiposEncuesta = new frmMostrarEquiposEncuesta(myEvent,_currentCategory,_preguntas);
            ventanaEquiposEncuesta.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
                if (_viewEvents == null || _viewEvents.Count == 0) return;
                frmShowRanking ventanaRanking = new frmShowRanking(_viewEvents[filaSeleccionada]);
                ventanaRanking.ShowDialog();
            }
            catch(Exception ex)
            {

            }                        
        }
    }
}
