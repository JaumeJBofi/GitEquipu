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

namespace Equipu.Vista
{
    public partial class frmBuscarEquipoCategoria : Form
    {
        private List<Equipo> _teamPool;
        private List<Equipo> _filterTeam;
        private List<EquipoxEvento> _newTeams;
        public frmBuscarEquipoCategoria(List<Equipo> teamPool,List<EquipoxEvento> newTeams,CATEGORIA cat)
        {
            InitializeComponent();
            _teamPool = teamPool;
            _newTeams = newTeams;
            _filterTeam = _teamPool;
            comboBox1.Text = cat.ToString();
            comboBox1.Enabled = false;
            Update();
        }

        public new void Update()
        {
            dataGridView1.Rows.Clear();
            string[] rows = new string[3];
            foreach(var team in _filterTeam)
            {
                rows[0] = team.Name;
                rows[1] = team.Recaudado.ToString();
                rows[2] = team.Interest;
                dataGridView1.Rows.Add(rows);
            }
        }

        private void frmBuscarEquipoCategoria_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            if(nombre.Equals(""))
            {
                _filterTeam = _teamPool;
            }
            else
            {
                _filterTeam = _teamPool.Where(o => o.Name.Equals(nombre)).ToList();
            }
            
            Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = textBox3.Text;
            string time = textBox4.Text;
            string place = textBox2.Text;
            int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            _newTeams.Add(new EquipoxEvento(_teamPool[filaSeleccionada], new StandInformation(date, time, place)));

            MessageBox.Show("Equipo Añadido");
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
                _teamPool.RemoveAt(filaSeleccionada);
                _filterTeam = _teamPool;
                Update();
            }
            catch(Exception ex)
            {

            }            
        }
    }
}
