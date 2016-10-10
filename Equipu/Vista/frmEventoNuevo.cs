using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PA120130698_G6.Controlador;
using PA120130698_G6.Modelo;
using PA120130698_G6.Foundation;

namespace Equipu.Vista
{
    public partial class frmEventoNuevo : Form
    {
        private GestorEventos _eventManager;
        private List<EquipoxEvento> _equipos;
        public frmEventoNuevo(GestorEventos eventManager)
        {
            InitializeComponent();
            _eventManager = eventManager;
            _equipos = new List<EquipoxEvento>();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        public new void Update()
        {
            dataGridView1.Rows.Clear();
            string[] rows = new string[4];
            foreach (var equipo in _equipos)
            {
                rows[0] = equipo.Team.Name;
                rows[1] = equipo.Team.Interest;
                rows[2] = equipo.Team.Recaudado.ToString();
                dataGridView1.Rows.Add(rows);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string eventName = textBox1.Text;
                string categoria = comboBox1.Text;
                double precioEntrada = Double.Parse(textBox2.Text);
                int numeroEntradas = Int32.Parse(textBox3.Text);

                CATEGORIA cat = CATEGORIA.TECNOLOGIA;

                cat = cat.Parse(categoria);
                _eventManager.CreateEvent(cat, eventName, precioEntrada, numeroEntradas, _equipos);
                MessageBox.Show("Equipo Guardado");

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error en datos");
            }
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text.Equals(""))
            {
                MessageBox.Show("Ingrese una categoria primero");
                return;
            }
            string categoria = comboBox1.Text;
            CATEGORIA cat = CATEGORIA.TECNOLOGIA;
            cat = cat.Parse(categoria);
            frmBuscarEquipoCategoria ventanaEquipoCategoria = new frmBuscarEquipoCategoria(_eventManager.EquiposX_categoria[cat],_equipos,cat);
            ventanaEquipoCategoria.ShowDialog();
            Update();

        }

        private void frmEventoNuevo_Load(object sender, EventArgs e)
        {

        }
    }
}
