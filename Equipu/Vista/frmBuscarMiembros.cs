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
using Equipu.Controlador;

namespace Equipu.Vista
{
    public partial class frmBuscarMiembros : Form
    {
        Dictionary<int,Miembro> _currentSelected;
        private Miembro _currentSearched;
        private GestorMiembros _gMiembros;

        public frmBuscarMiembros(Dictionary<int,Miembro> currentSelected,GestorMiembros pool)
        {
            InitializeComponent();
            _currentSelected = currentSelected;
            _gMiembros = pool;
            _currentSearched = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_currentSearched!=null)
            {
                try
                {
                    _currentSelected.Add(_currentSearched.Codigo, _currentSearched);
                }catch(ArgumentException)
                {
                    MessageBox.Show("Miembro ya ingresado");
                }
                
            }            
            Close();
        }

        private void frmBuscarMiembros_Load(object sender, EventArgs e)
        {

        }

        private new void Update()
        {
            dataGridView1.Rows.Clear();
            Miembro miembro = _currentSearched;
            if(miembro != null)
            {
                string[] row = new string[3];
                row[0] = miembro.Codigo.ToString();
                row[1] = miembro.Nombre;
                row[2] = miembro.GetMe();
                dataGridView1.Rows.Add(row);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int codigo = Int32.Parse(textBox1.Text);
                if (_gMiembros.GetCodigos().Contains(codigo))
                {
                    _currentSearched = _gMiembros[codigo];
                }
                else
                {
                    MessageBox.Show("No existe usuario con ese Código");
                }
                Update();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Codigo Incorrecto");
            }                        
        }
    }
}
