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
using Equipu.Modelo;    

namespace Equipu.Vista
{
    public partial class frmRendirEncuesta : Form
    {
        private EquipoxEvento _myTeam;
        private List<Pregunta> _preguntas;
        private List<double> _puntaje;
        private List<bool> _rpta;
        private int _currentIndex;

        public frmRendirEncuesta(EquipoxEvento team,List<Pregunta> preguntas)
        {
            InitializeComponent();
            _myTeam = team;
            _preguntas = preguntas;

            int size = _preguntas.Count;
            _puntaje = new List<double>();
            _rpta = new List<bool>();

            for(int i = 0;i<size;i++)
            {
                _rpta.Add(false);
            }

            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = _preguntas.Count;
            numericUpDown1.Value = 1;
            
            _currentIndex = 0;

            textBox1.Text = team.Team.Name;
            textBox2.Text = team.Team.Interest;
            textBox3.Text = team.Stand.Place;
            textBox7.Text = team.Team.Categoria.ToString();

            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox7.Enabled = false;

            textBox6.Text = preguntas[_currentIndex].PreguntaS;
            textBox6.Enabled = false;

            textBox6.Text = preguntas[_currentIndex].Min.ToString();
            textBox6.Enabled = false;

            textBox4.Text = preguntas[_currentIndex].Max.ToString();
            textBox4.Enabled = false;

            checkBox1.Checked = _rpta[_currentIndex];
            checkBox1.Enabled = false;

            numericUpDown2.Minimum = _preguntas[_currentIndex].Min;
            numericUpDown2.Maximum = _preguntas[_currentIndex].Max;
        }



        private void frmRendirEncuesta_Load(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _currentIndex = decimal.ToInt32(numericUpDown1.Value) -1;

            textBox4.Text = _preguntas[_currentIndex].PreguntaS;


            textBox5.Text = _preguntas[_currentIndex].Min.ToString();


            textBox6.Text = _preguntas[_currentIndex].Max.ToString();    

            checkBox1.Checked = _rpta[_currentIndex];

            numericUpDown2.Minimum = _preguntas[_currentIndex].Min;
            numericUpDown2.Maximum = _preguntas[_currentIndex].Max;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            _puntaje[_currentIndex] = decimal.ToDouble(numericUpDown2.Value);
            _rpta[_currentIndex] = true;
            checkBox1.Checked = _rpta[_currentIndex];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
