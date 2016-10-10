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

namespace Equipu.Vista
{
    public partial class frmEquipoNuevo : Form
    {
        private EQuipu _equipu;
        Dictionary<int,Miembro> _currentSelected;
        private GestorMiembros _gMiembros;
      

        public frmEquipoNuevo(EQuipu equipu, GestorMiembros gMiembros)
        {
            InitializeComponent();
            _equipu = equipu;
            _gMiembros = gMiembros;
            _currentSelected = new Dictionary<int, Miembro>();       
        }
      
        private void frmEquipoNuevo_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmBuscarMiembros ventanaBuscarMiembros = new frmBuscarMiembros(_currentSelected,_gMiembros);
            ventanaBuscarMiembros.ShowDialog();
            Update();
        }

        public new void Update()
        {
            dataGridView1.Rows.Clear();
            foreach (var miembro in _currentSelected)
            {
                string[] row = new string[3];
                row[0] = miembro.Value.Codigo.ToString();
                row[1] = miembro.Value.Nombre;
                row[2] = miembro.Value.GetMe();
                dataGridView1.Rows.Add(row);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            string nombre = textBox1.Text;
            string interes = textBox2.Text;
            string cat = comboBox1.Text;

            Equipo newTeam = new Equipo(nombre, interes, cat);
            foreach(var miemb in _currentSelected)
            {
                try
                {
                    newTeam.AddMiembro(miemb.Value);
                }
                catch(ArgumentException exp)
                {
                    MessageBox.Show("El miembro ya se encuentra en este equipo" + miemb.Key.ToString());
                }               
            }            
            _equipu.AddEquipo(newTeam);
            MessageBox.Show("Equipo Registrado");
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
