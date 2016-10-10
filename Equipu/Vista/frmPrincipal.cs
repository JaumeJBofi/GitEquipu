using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equipu.Vista;
using PA120130698_G6.Controlador;
using System.IO;
using PA120130698_G6.Modelo;
using Equipu.Controlador;
using System.Runtime.Serialization.Formatters.Binary;

namespace Equipu
{
    // TODO EL CODIGO AGREGADO POR MI ES PARA LA PREGUNA... CASI TODO ES NUEVO. Por tiempo no he podido poner el numero de la pregunta.
    public partial class Form1 : Form
    {
        private EQuipu _equipu;
        private GestorMiembros _gMiembros;

        public Form1()
        {
            InitializeComponent();

            /// Esto es para el serializado... No esta funcionando tan bien
            ///       
            _gMiembros = new GestorMiembros();                  
            _equipu = new EQuipu(true);
        }

        private void miembrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Solo del primer equipo
            frmMantMiembros ventanaMantMiembros = new frmMantMiembros(_gMiembros);
            ventanaMantMiembros.MdiParent = this;
            ventanaMantMiembros.Show();
        }

        private void equiposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantEquipos ventanaMantEquipos = new frmMantEquipos(_equipu,_gMiembros);
            ventanaMantEquipos.MdiParent = this;
            ventanaMantEquipos.Show();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            _equipu.Save();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void eventosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMantEventocs ventanaMantEventos = new frmMantEventocs(_equipu.Events);
            ventanaMantEventos.MdiParent = this;
            ventanaMantEventos.Show();
        }
    }
}
