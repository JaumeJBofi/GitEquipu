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
using Equipu.Controlador;

namespace Equipu.Vista
{
    //PREG1
    public partial class frmMiembroNuevo : Form
    {
        private GestorMiembros _gMiembros;

        private Miembro _editedMiembro;
        private string _persistentMe;

        private bool _editMode;
        public frmMiembroNuevo(GestorMiembros pool)
        {
            InitializeComponent();
            _gMiembros = pool;
            _editMode = false;
            textBox1.Enabled = false;
        }
        public frmMiembroNuevo(Miembro miembro,GestorMiembros pool)
        {
            InitializeComponent();
            _editedMiembro = miembro;
            _gMiembros = pool;
            textBox1.Enabled = false;           
            _editMode = true;
        }

        private void frmMiembroNuevo_Load(object sender, EventArgs e)
        {
            if(_editMode)
            {
                textBox1.Text = _editedMiembro.Codigo.ToString();                
                textBox2.Text = _editedMiembro.Nombre;
                textBox3.Text = _editedMiembro.Direccion;
                textBox4.Text = _editedMiembro.Email;

                dateTimePicker1.Value = _editedMiembro.FNacimiento;

                comboBox1.Text = _editedMiembro.Genero.ToString();
                comboBox2.Text = _editedMiembro.GetMe();

                _persistentMe = _editedMiembro.GetMe();

                if (_editedMiembro is Alumno)
                {
                    textBox5.Text = (_editedMiembro as Alumno).AlumData.CodAlum.ToString();
                    textBox6.Text = (_editedMiembro as Alumno).AlumData.Craest.ToString();
                }
                else if (_editedMiembro is Profesor)
                {
                    textBox7.Text = (_editedMiembro as Profesor).DatosProf.CodProf.ToString();
                    textBox8.Text = (_editedMiembro as Profesor).DatosProf.Estado.ToString();
                }
                else
                {
                    comboBox3.Text = (_editedMiembro as Externo).TDedica.ToString();
                }
            }
            else
            {
                textBox1.Text = "";
            }
            
        }                

        private void button1_Click(object sender, EventArgs e)
        {
            string tipo = comboBox2.Text;
            string codigo = textBox1.Text;
            string nombre = textBox2.Text;
            DateTime a = dateTimePicker1.Value;
            string direccion = textBox3.Text;
            string email = textBox4.Text;
            string sexo = comboBox1.Text;

            GENERO g = GENERO.MASCULINO;
            g = g.Parse(sexo);


            // Definiciones
            string codigoProf = "";
            string estado = "";
            ESTADOPROF estadoP = ESTADOPROF.ACTIVO;

            string codigoPucp = "";
            string craest = "";

            string dedicacion = "";
            TDEDICACION tde = TDEDICACION.PARCIAL;

            try
            {
                if (!_editMode || (_editMode && !_persistentMe.Equals(tipo)))
                {   
                    if(!_editMode)
                    {
                        codigo = _gMiembros.CurrentCode++.ToString();
                    }
                    if (tipo.Equals("Profesor"))
                    {

                        codigoProf = textBox7.Text;
                        estado = textBox8.Text;
                        estadoP = ESTADOPROF.ACTIVO;
                        estadoP = estadoP.Parse(estado);
                        _editedMiembro = new Profesor(Int32.Parse(codigo), "", nombre, a, g, direccion, email, Int32.Parse(codigoProf), estadoP);
                    }
                    else if (tipo.Equals("Alumno"))
                    {
                        codigoPucp = textBox5.Text;
                        craest = textBox6.Text;
                        _editedMiembro = new Alumno(Int32.Parse(codigo), "", nombre, a, g, direccion, email, Int32.Parse(codigoPucp), Double.Parse(craest));
                    }
                    else
                    {
                        dedicacion = comboBox3.Text;
                        tde = TDEDICACION.PARCIAL;
                        tde = tde.Parse(dedicacion);

                        _editedMiembro = new Externo(Int32.Parse(codigo), "", nombre, a, g, direccion, email, tde);
                    }
                    if (_editMode)
                    {
                        _gMiembros.Remove(Int32.Parse(codigo));
                        _gMiembros.Add(_editedMiembro);
                        MessageBox.Show("Usuario Editado");                        
                    }
                    else
                    {
                        _gMiembros.Add(_editedMiembro);
                        MessageBox.Show("Usuario Registrado, su codigo es: " + codigo);
                    }
                }
                else
                {
                    _editedMiembro.Codigo = Int32.Parse(codigo);
                    _editedMiembro.Nombre = nombre;
                    _editedMiembro.FNacimiento = a;
                    _editedMiembro.Email = email;
                    _editedMiembro.Genero = g;
                    _editedMiembro.Direccion = direccion;

                    if (tipo.Equals("Alumno"))
                    {
                        (_editedMiembro as Alumno).AlumData.CodAlum = Int32.Parse(codigoPucp);
                        (_editedMiembro as Alumno).AlumData.Craest = Double.Parse(craest);
                    }
                    else if (tipo.Equals("Profesor"))
                    {
                        (_editedMiembro as Profesor).DatosProf.CodProf = Int32.Parse(codigoProf);
                        (_editedMiembro as Profesor).DatosProf.Estado = estadoP;
                    }
                    else
                    {
                        (_editedMiembro as Externo).TDedica = tde;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Datos Invalidos");

            }                                                            
            Close();
        }
             

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            comboBox3.Enabled = false;

            string tipo = comboBox2.Text;
            if (tipo.Equals("Profesor"))
            {
                textBox7.Enabled = true;
                textBox8.Enabled = true;
            }
            else if (tipo.Equals("Alumno"))
            {
                textBox5.Enabled = true;
                textBox6.Enabled = true;
            }
            else
            {
                comboBox3.Enabled = true;
            }
        }
    }
}
