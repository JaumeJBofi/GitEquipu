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

namespace Equipu.Vista
{
    public partial class frmShowRanking : Form
    {        
        public frmShowRanking(Evento myEvent)
        {
            InitializeComponent();

           

            textBox1.Name = myEvent.EventName;
            textBox1.Enabled = false;

            textBox2.Name = myEvent.NEntries.ToString();
            textBox2.Enabled = false;

            textBox3.Name = myEvent.PriceEntry.ToString();
            textBox3.Enabled = false;

            if (myEvent.Participants!=null)
            {
                comboBox1.Text = myEvent.Participants.First().Team.Categoria.ToString();
            }
            comboBox1.Enabled = false;

            myEvent.Stands.Clear();

            if(myEvent.Stands.Count==0)
            {
                myEvent.ProcessGainings();
            }

            List<EquipoxEvento> ordered = myEvent.Participants.OrderByDescending(o => o.TotalEarned).ToList();
            string[] rows = new string[5];

            foreach(var team in ordered)
            {
                rows[0] = team.Team.Name;
                rows[1] = team.Team.Interest;
                rows[2] = team.Stand.Place;
                rows[3] = team.Stand.Date;
                rows[4] = team.TotalEarned.ToString();
                dataGridView1.Rows.Add(rows);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
