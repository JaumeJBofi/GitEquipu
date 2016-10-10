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
using Equipu.Controlador;
using PA120130698_G6.Foundation;

namespace Equipu.Vista
{
    public partial class frmMantEquipos : Form
    {
        private EQuipu _equipu;
        private GestorMiembros _gMiembros;
        private List<Equipo> _equiposView;

        public frmMantEquipos(EQuipu equipu,GestorMiembros miembros)
        {
            InitializeComponent();
            _equipu = equipu;
            _gMiembros = miembros;
            _equiposView = _equipu.Equipos;
            Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmEquipoNuevo ventanaNuevo = new frmEquipoNuevo(_equipu,_gMiembros);
            ventanaNuevo.ShowDialog();
            _equiposView = _equipu.Equipos;
            Update();
        }

        public new void Update()
        {
            dataGridView1.Rows.Clear();
            string[] rows = new string[4];
            foreach (var team in _equiposView)
            {
                rows[0] = team.Name;
                rows[1] = team.Interest;
                rows[2] = team.Categoria.ToString();
                rows[3] = team.Recaudado.ToString();
                dataGridView1.Rows.Add(rows);
            }
        }

        private void frmMantEquipos_Load(object sender, EventArgs e)
        {
            Dictionary<CATEGORIA,List<Equipo>> _team = _equipu.Events.EquiposX_categoria;
            List<Equipo> equip;
            foreach(var team in _equipu.Equipos)
            {
                 equip = _team[team.Categoria].Where(o => o.Name == team.Name).ToList();
                if(equip!=null)
                {
                    team.Recaudado = equip.First().Recaudado;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {            
            string cat = comboBox1.Text.ToUpper();           
            if(!cat.Equals(""))
            {
                _equiposView = _equipu.Equipos.Where(o => o.Categoria.ToString() == cat).ToList();
            }
            else
            {
                _equiposView = _equipu.Equipos;
            }            
            Update();
        }

        private void frmMantEquipos_FormClosing(object sender, FormClosingEventArgs e)
        {
            _equipu.SerializarEquipu();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            string name = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();

            List<Equipo> select = _equipu.Equipos.Where(o => o.Name.Equals(name)).ToList();
            if(select.Count!=0)
            {
                _equipu.Equipos.Remove(select.First());
            }
            else
            {
                MessageBox.Show("Ese equipo no existe");
            }
            _equiposView = _equipu.Equipos;
            Update();
            

        }
    }
}
