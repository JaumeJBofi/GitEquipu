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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Equipu.Controlador;

namespace Equipu.Vista
{
    public partial class frmMantMiembros : Form
    {        
        private List<Miembro> _vMiemb;
        // Pool, Dictionario?
        private GestorMiembros _gMiembros;        
        public frmMantMiembros(GestorMiembros miembros)
        {
            InitializeComponent();
            _gMiembros = miembros;
            _vMiemb = _gMiembros.GetMiembros();          
        }

        private void Nuevo(object sender, EventArgs e)
        {
            frmMiembroNuevo ventanaNuevo = new frmMiembroNuevo(_gMiembros);
            ventanaNuevo.ShowDialog();
            _vMiemb = _gMiembros.GetMiembros();        
            Update();
        }

        private void Editar(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            int codigo = Convert.ToInt32(this.dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString());
            frmMiembroNuevo ventanaEditar = new frmMiembroNuevo(_gMiembros[codigo],_gMiembros); ;
            ventanaEditar.ShowDialog();
            _vMiemb = _gMiembros.GetMiembros();
            Update();
        }

        private void frmMantMiembros_Load(object sender, EventArgs e)
        {
            Update();           
        }

        private new void Update()
        {           
            dataGridView1.Rows.Clear();
            foreach (var miembro in _vMiemb)
            {
                string[] row = new string[5];
                row[0] = miembro.Codigo.ToString();
                row[1] = miembro.Nombre;
                row[2] = miembro.GetMe();
                row[3] = miembro.Email;
                row[4] = miembro.Genero.ToString();
                dataGridView1.Rows.Add(row);
            }
        }

        private void AddMembers(List<Miembro> varMemb)
        {
            foreach(var miembro in varMemb)
            {
                _vMiemb.Add(miembro);
            }
        }

        private void Buscar(object sender, EventArgs e)
        {
            string codigo = textBox1.Text;
            string tipo = comboBox1.Text;
            List<Miembro> filter = new List<Miembro>();
            if(codigo.Equals(""))
            {
                if (!tipo.Equals(""))
                {
                    filter = _gMiembros.GetMiembros().Where(o => (o.GetMe() == tipo)).ToList();
                }
                else
                {
                    filter = _gMiembros.GetMiembros().ToList();
                }             
            }
            else
            {
                if (!tipo.Equals(""))
                {
                    filter = _gMiembros.GetMiembros().Where(o => (o.GetMe() == tipo) && (o.Codigo == Int32.Parse(codigo))).ToList();
                }
                else
                {
                    filter = _gMiembros.GetMiembros().Where(o => o.Codigo == Int32.Parse(codigo)).ToList();
                }

            }            
            _vMiemb = filter;
            Update();
        }

        private void Eliminar(object sender, EventArgs e)
        {
            int filaSeleccionada = dataGridView1.SelectedCells[0].RowIndex;
            int codigo = Convert.ToInt32(this.dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString());
            _gMiembros.Remove(codigo);

            _vMiemb = _gMiembros.GetMiembros();
            Update();
        }

        private void frmMantMiembros_FormClosing(object sender, FormClosingEventArgs e)
        {
            _gMiembros.Serialize();
        }
    }
}
