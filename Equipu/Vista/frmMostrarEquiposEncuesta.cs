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

namespace Equipu.Vista
{
    public partial class frmMostrarEquiposEncuesta : Form
    {
        private Evento _myEvent;
        private List<EquipoxEvento> _filterEquip;
        private List<Pregunta> _preguntas;
        public frmMostrarEquiposEncuesta(Evento evento,CATEGORIA cat,List<Pregunta> preguntas)
        {
            InitializeComponent();
            _myEvent = evento;

            textBox1.Text = evento.EventName;
            textBox2.Text = cat.ToString();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            _filterEquip = _myEvent.Participants;
            _preguntas = preguntas;
            Update();

        }

        public new void Update()
        {
            dataGridView1.Rows.Clear();
            string[] rows = new string[4];

            foreach(var team in _filterEquip)
            {
                rows[0] = team.Team.Name;
                rows[1] = team.Stand.Place;
                rows[2] = team.Team.Interest;
                rows[3] = team.TotalEarned.ToString();
                dataGridView1.Rows.Add(rows);
            }
        }

        private void frmMostrarEquiposEncuesta_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox3.Text;
            if(nombre.Equals(""))
            {
                _filterEquip = _myEvent.Participants;
            }
            else
            {
                _filterEquip = _myEvent.Participants.Where(o => o.Team.Name == nombre).ToList();
            }

            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
                frmRendirEncuesta ventanaEncuesta = new frmRendirEncuesta(_filterEquip.ElementAt(filaSeleccionada), _preguntas);
                ventanaEncuesta.ShowDialog();
            }
            catch(Exception ex)
            {

            }
            
        }
    }
}
